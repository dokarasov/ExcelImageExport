using System;
using System.Threading;
using ExcelImageExport.Presenter.Common;
using ExcelImageExport.Services.Models;

namespace ExcelImageExport.Views
{
    public interface IDownloadImages
    {
        string SaveFolderPath { get; set; }
        string FilePath { get; set; }

        int StartRowIndex { get; set; }
        int NamesColumnIndex { get; set; }
        int ImagesColumnIndex { get; set; }

        CancellationTokenSource ReportCancellationTokenSource { get; set; }

        event Action DownloadImages;
        event Func<string[]> ValidateReportModel;

        void ReportProgress(ReportProgressStep reportProgressStep, string additionalInfo = null);
    }

    public interface ISkuUpdater
    {
        string SkuFilePath { get; set; }
        string ProductsFilePath { get; set; }
        
        CancellationTokenSource SkuCancellationTokenSource { get; set; }

        event Action UpdateSku;
        event Func<string[]> ValidateSkuModel;

        void SkuProgress(SkuProgressStep skuProgressStep, string additionalInfo = null);
    }

    public interface IMainView : IView, IDownloadImages, ISkuUpdater
    {
    }
}