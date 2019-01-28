using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestApp1.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalUrl))]
namespace TestApp1.Droid
{
    class LocalUrl : IBaseUrl
    {
        public string Get()
        {

           // //  string path = Android.App.Application.Context.FilesDir + "/MyFolder/";
            //string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
           // return path;
            return "file:///android_asset/";

            //return "/storage/emulated/0/Android/data/com.companyname.TestApp1/files/Download/";

            // return Path.Combine(Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath);
        }
    }
}