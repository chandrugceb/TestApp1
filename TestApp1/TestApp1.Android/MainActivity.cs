using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Java.IO;

namespace TestApp1.Droid
{
    [Activity(Label = "TestApp1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
            // WriteFile();
            LoadApplication(new App());
        }

        public void WriteFile()
        {
            //var dirPath = Android.App.Application.Context.FilesDir + "/MyFolder";
            var dirPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"HTML");
            var exists = Directory.Exists(dirPath);
            var filepath = dirPath + "/test4.html";
            if(!exists)
            {
                Directory.CreateDirectory(dirPath);
            }                     
                if (!System.IO.File.Exists(filepath))
                {
                    var newfile = new Java.IO.File(dirPath, "test4.html");
                    using (FileOutputStream outfile = new FileOutputStream(newfile))
                    {
                        string line = "<html><body>sample html</body></html>";
                        outfile.Write(System.Text.Encoding.ASCII.GetBytes(line));
                        outfile.Close();
                    }
                }
            
        }
    }
}