using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace MultipleWebViews.Controls
{


    public class HybridWebView : WebView
    {

        bool LoadFinish;

        public static readonly BindableProperty IdProperty =
          BindableProperty.Create(nameof(Id), typeof(string), typeof(HybridWebView), string.Empty);

        public string Id
        {
            get { return (string)GetValue(IdProperty).ToString(); }
            set
            {
                SetValue(IdProperty, value);
            }
        }

        Action<string> action;

        public static readonly BindableProperty messageContentProperty =
          BindableProperty.Create(nameof(messageContent), typeof(string), typeof(HybridWebView), string.Empty);

        public string messageContent
        {
            get { return (string)GetValue(messageContentProperty).ToString(); }
            set { SetValue(messageContentProperty, value); }
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }


        public HybridWebView()
        {
            // HeightRequest = 116;
            Source = "";
            this.PropertyChanged += HybridWebView_PropertyChanged;

            MessagingCenter.Subscribe<Object, PassModel>(this, "LoadFinished", (args, obj) => {

                var id = obj.Id;

                var model = obj as PassModel;

                if (model.Id == this.Id && !LoadFinish)
                {
                    LoadFinish = true;
                    var parent = this.Parent;
                    while (parent != null && !(parent is ViewCell))
                    {
                        parent = parent.Parent;
                    }
                    if (parent is ViewCell cell)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            this.HeightRequest = model.Height;
                            cell.ForceUpdateSize();
                        });
                    }
                }

            });

        }

//      <link rel=""stylesheet"" href=""chatmessage-content.css"">
//      <a class=""btn btn-true"" onclick=""setresponseandsubmit('1ca15124-9624-431e-8644-22a5839b7a10')"">test: </a>"


        private void HybridWebView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName.Equals(nameof(messageContent)))
            {
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = @"<html>
                                    <head>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no'>
                                    </head>
                                    <body style=""background-color: #DDDDDD; margin: 0px; padding: 0px; border:1px solid #FF00FF;"">"
                                       + messageContent +
                                    "</body></html>";
                Source = htmlSource;
            }
        }
    }
}
