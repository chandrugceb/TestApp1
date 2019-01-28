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
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using TestApp1.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetFileLocation))]
namespace TestApp1.Droid
{
    class GetFileLocation : IGetFileLocation
    {
        public string GetPath(IDownloadFile file)
        {
            //string path;
            //CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file => {

                string fileName = Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();
                 string path = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
            return path;
            //});
            //return path;
        }
    }
}