using System;
using Foundation;
using UIKit;
using WebKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using MultipleWebViews.Controls;
using MultipleWebViews.iOS.Renderers;
using CoreGraphics;
using System.Drawing;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace MultipleWebViews.iOS.Renderers
{
    public class HybridWebViewRenderer : WkWebViewRenderer, IWKScriptMessageHandler
    {

        // const string JavaScriptFunction = "function setresponseandsubmit(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
        WKUserContentController userController;

        public HybridWebViewRenderer() : this(new WKWebViewConfiguration())
        {
        }

        public HybridWebViewRenderer(WKWebViewConfiguration config) : base(config)
        {
            userController = config.UserContentController;
            // var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
           // userController.AddUserScript(script);
            userController.AddScriptMessageHandler(this, "invokeAction");
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                userController.RemoveAllUserScripts();
                userController.RemoveScriptMessageHandler("invokeAction");
                HybridWebView hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }

            if (e.NewElement != null)
            {
            }

            this.NavigationDelegate = new NavigationDelegate(this);

        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            ((HybridWebView)Element).InvokeAction(message.Body.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((HybridWebView)Element).Cleanup();
            }
            base.Dispose(disposing);
        }

    }

    class NavigationDelegate : WKNavigationDelegate
    {
        HybridWebViewRenderer webViewRenderer;

        public NavigationDelegate(HybridWebViewRenderer _webViewRenderer = null)
        {
            webViewRenderer = _webViewRenderer ?? new HybridWebViewRenderer();
        }

        public override async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {

            try
            {
                var _webView = webViewRenderer.Element as HybridWebView;
                if (_webView != null)
                {

                    await System.Threading.Tasks.Task.Delay(100);
                    var resultWidth = (double)webView.ScrollView.ContentSize.Width;
                    var resultHeight = (double)webView.ScrollView.ContentSize.Height;
                    System.Console.WriteLine("----" + resultWidth + "-----" + resultHeight + "----" + _webView.Width);

                    double result = MeasureTextHeightSize(_webView.messageContent, _webView.Width, UIFont.LabelFontSize, null);

                    _webView.HeightRequest = result;

                    MessagingCenter.Send<Object, PassModel>(this, "LoadFinished", new PassModel(_webView.Id, Convert.ToDouble(result)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at HybridWebViewRenderer LoadingFinished: " + ex.Message);
            }
        }

        private double MeasureTextHeightSize(string text, double width, double fontSize, string fontName = null)
        {
            var nsText = new NSString(text);
            var boundSize = new SizeF((float)width, float.MaxValue);
            var options = NSStringDrawingOptions.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin;

            if (fontName == null)
            {
                fontName = "HelveticaNeue";
            }

            var attributes = new UIStringAttributes
            {
                Font = UIFont.FromName(fontName, (float)fontSize)
            };

            var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;

            //return new Xamarin.Forms.Size((double)sizeF.Width, (double)sizeF.Height);
            return (double)sizeF.Height;
        }

    }
}