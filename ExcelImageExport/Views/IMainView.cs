using System;
using System.Threading;
using ExcelImageExport.Presenter.Common;

namespace ExcelImageExport.Views
{
    public interface IMainView : IView
    {
        string SaveFolderPath { get; set; }
        string FilePath { get; set; }

        int StartRowIndex { get; set; }
        int NamesColumnIndex { get; set; }
        int ImagesColumnIndex { get; set; }

        CancellationTokenSource CancellationTokenSource { get; set; }

        event Action DownloadImages;
        event Func<string[]> ValidateModel;

        void ReportProgress(int value, string description);
    }
}