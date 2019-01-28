using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp1
{
    public interface IGetFileLocation
    {
        string GetPath(IDownloadFile file);
    }
}
