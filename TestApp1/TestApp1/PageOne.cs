using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestApp1
{
	public class PageOne : ContentPage
	{
		public PageOne ()
		{
            Button btn = new Button();
            btn.Text = "Highlight";
            
            btn.WidthRequest = 200;
            
           

            var content = new WebView();
            var urlSource = new UrlWebViewSource();
            string url = DependencyService.Get<IBaseUrl>().Get();       
            string TempUrl = Path.Combine(url, "pageone.html");
            urlSource.Url = TempUrl;
            content.Source = urlSource;
            content.HorizontalOptions = LayoutOptions.FillAndExpand;
            content.VerticalOptions = LayoutOptions.FillAndExpand;

            btn.Clicked += async (sender, args) => await content.EvaluateJavaScriptAsync($"highlightSelection()");

            StackLayout stacklayout = new StackLayout();
            stacklayout.Orientation = StackOrientation.Vertical;
            stacklayout.Children.Add(content);
            stacklayout.Children.Add(btn);
            this.Content = stacklayout; ;

            //content.EvaluateJavaScriptAsync("highlight");
             //content.InvokeScriptAsync("eval", new string[] { highlightFunctionJS + " HighlightFunction('" + HighlightTerm.Text + "');" });

        }
	}
}