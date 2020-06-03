using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using WebView = Android.Webkit.WebView;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using MultipleWebViews.Controls;
using MultipleWebViews.Droid.Renderers;
using Android.Webkit;
using System.Threading.Tasks;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace MultipleWebViews.Droid.Renderers
{
    public class HybridWebViewRenderer : WebViewRenderer
    {

        public static int _webViewHeight;
        HybridWebView _xwebView = null;
        WebView _webView;
        Context _context;
        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (Control != null)
            {
                Control.Settings.JavaScriptEnabled = true;
            }



            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            _xwebView = e.NewElement as HybridWebView;
            _webView = Control;

            Control.SetWebViewClient(new HybridWebViewClient(_xwebView));

        }

    }



    public class HybridWebViewClient : WebViewClient
    {
        WebView _webView;
        HybridWebView _xwebView = null;


        public HybridWebViewClient(HybridWebView webview)
        {
            _xwebView = webview;
        }

        public async override void OnPageFinished(WebView view, string url)
        {
            try
            {
                _webView = view;
                if (_xwebView != null)
                {
                    view.Settings.JavaScriptEnabled = true;
                    await Task.Delay(100);
                    string result = await _xwebView.EvaluateJavaScriptAsync("(function(){return document.body.scrollHeight;})()");

                    _xwebView.HeightRequest = Convert.ToDouble(result);




                    MessagingCenter.Send<Object, PassModel>(this, "LoadFinished", new PassModel(_xwebView.Id, Convert.ToDouble(result)));

                }
                base.OnPageFinished(view, url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}