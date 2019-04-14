using ExcelImageExport.Presenter;
using ExcelImageExport.Views;
using System;
using System.Windows.Forms;
using ExcelImageExport.Features;
using ExcelImageExport.Presenter.Common;
using Serilog;
using System.IO;

namespace ExcelImageExport
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Excel-Image-Export",
                        "logs", "ExcelImageExportLogs.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var controller = new ApplicationController(new DryIocAdapter())
                .RegisterView<IMainView, MainForm>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter>();
        }
    }
}