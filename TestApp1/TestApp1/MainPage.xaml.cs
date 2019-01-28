using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
           
            urlEntry.Text = "http://g.oswego.edu/dl/csc241/sample.html";
            var url = urlEntry.Text;
            await DownloadFile(url);

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;

        }

        public bool isDownloading = true;
        
        public async Task DownloadFile(String fileName)
        {
            var status = DownloadFileStatus.INITIALIZED;
            await Task.Yield();
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file1 => {
                return DependencyService.Get<IGetFileLocation>().GetPath(file1);
            });
            await Task.Run(() =>
            {
                var downloadManager = CrossDownloadManager.Current;
                var file = downloadManager.CreateDownloadFile(fileName);
               
                downloadManager.Start(file, true);

                while (isDownloading)
                {
                    isDownloading = IsDownloading(file);
                }
                status = file.Status;
            });

           
            if (!isDownloading)
            {
                await DisplayAlert("Status", "File Download "+ Convert.ToString(status)+"", "OK");               
            }
        }

        public bool IsDownloading(IDownloadFile file)
        {
            if (file == null) return false;

            switch (file.Status)
            {
                case DownloadFileStatus.INITIALIZED:
                case DownloadFileStatus.PAUSED:
                case DownloadFileStatus.PENDING:
                case DownloadFileStatus.RUNNING:
                    return true;

                case DownloadFileStatus.COMPLETED:
                case DownloadFileStatus.CANCELED:
                case DownloadFileStatus.FAILED:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

       
    }
}
