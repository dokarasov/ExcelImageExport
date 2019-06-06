using Serilog;
using System;
using System.Threading;
using System.Windows.Forms;
using ExcelImageExport.Features;
using ExcelImageExport.Services.Models;

namespace ExcelImageExport.Views
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;

        #region Download Images Properties

        public event Action DownloadImages;
        public event Func<string[]> ValidateReportModel;

        public string SaveFolderPath
        {
            get => tb_SaveFolderPath.Text;
            set => tb_SaveFolderPath.Text = value;
        }

        public string FilePath
        {
            get => tb_FilePath.Text;
            set => tb_FilePath.Text = value;
        }

        public int StartRowIndex
        {
            get => (int) npd_StartRowIndex.Value;
            set => npd_StartRowIndex.Value = value;
        }

        public int NamesColumnIndex
        {
            get => (int) npd_NamesColumnIndex.Value;
            set => npd_NamesColumnIndex.Value = value;
        }

        public int ImagesColumnIndex
        {
            get => (int) npd_ImagesColumnIndex.Value;
            set => npd_ImagesColumnIndex.Value = value;
        }

        public CancellationTokenSource ReportCancellationTokenSource { get; set; }

        #endregion

        #region Sku Updater Properties

        public event Action UpdateSku;
        public event Func<string[]> ValidateSkuModel;

        public string SkuFilePath
        {
            get => tb_SkuFilePath.Text;
            set => tb_SkuFilePath.Text = value;
        }

        public string ProductsFilePath
        {
            get => tb_ProductsFilePath.Text;
            set => tb_ProductsFilePath.Text = value;
        }


        public CancellationTokenSource SkuCancellationTokenSource { get; set; }

        #endregion

        public MainForm(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();

            reportBackgroundWorker.DoWork += (sender, args) => InvokeDownloadImages();
            btn_ReportDownload.Click += (sender, args) => reportBackgroundWorker.RunWorkerAsync();
            btn_GetFilePath.Click += (sender, args) => GetFilePath();
            btn_SaveFolderPath.Click += (sender, args) => GetSaveFolderPath();
            btn_ReportCancel.Click += (sender, args) => ReportCancel();

            reportProgressBarDescription.Text = string.Empty;

            skuBackgroundWorker.DoWork += (sender, args) => InvokeUpdateSku();
            btn_SkuUpdate.Click += (sender, args) => skuBackgroundWorker.RunWorkerAsync();
            btn_GetSkuFilePath.Click += (sender, args) => GetSkuFilePath();
            btn_GetProductsFilePath.Click += (sender, args) => GetProductsFilePath();
            btn_SkuCancel.Click += (sender, args) => SkuCancel();

            skuProgressBarDescription.Text = string.Empty;
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        #region Download Images Methods

        public void GetFilePath()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                    FilePath = openFileDialog.FileName;
            }
        }

        public void GetSaveFolderPath()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                    SaveFolderPath = folderBrowserDialog.SelectedPath;
            }
        }

        public void ReportCancel()
        {
            if (ReportCancellationTokenSource == null) return;

            ReportCancellationTokenSource.Cancel();

            reportProgressBarDescription.Text = "Operation has been canceled.";

            MessageBox.Show("Operation has been canceled.");
        }

        public void ReportProgress(ReportProgressStep reportProgressStep, string additionalInfo = null)
        {
            if (reportProgressBar.InvokeRequired)
                reportProgressBar.Invoke(new MethodInvoker(() => reportProgressBar.Value = (int) reportProgressStep));
            else
                reportProgressBar.Value = (int) reportProgressStep;

            if (reportProgressBarDescription.InvokeRequired)
                reportProgressBarDescription.Invoke(
                    new MethodInvoker(() =>
                    {
                        reportProgressBarDescription.Text =
                            EnumHelper<ReportProgressStep>.GetDisplayValue(reportProgressStep);

                        if (!string.IsNullOrWhiteSpace(additionalInfo))
                            reportProgressBarDescription.Text += $" {additionalInfo}";
                    }));
            else
            {
                reportProgressBarDescription.Text = EnumHelper<ReportProgressStep>.GetDisplayValue(reportProgressStep);

                if (!string.IsNullOrWhiteSpace(additionalInfo))
                    reportProgressBarDescription.Text += $" {additionalInfo}";
            }
        }

        private void InvokeDownloadImages()
        {
            var validation = ValidateReportModel?.Invoke();
            if (validation != null && validation.Length != 0)
            {
                MessageBox.Show(string.Join("\r\n", validation),
                    "Model Validation Errors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ReportCancellationTokenSource = new CancellationTokenSource();
            try
            {
                UpdateReportButtonState(false);

                DownloadImages?.Invoke();
                MessageBox.Show("Success.");
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There is some error during download images.");

                MessageBox.Show("There is some error. See logs for more details.");
            }

            ReportCancellationTokenSource = null;
            UpdateReportButtonState(true);
        }

        private void UpdateReportButtonState(bool enabled)
        {
            if (btn_ReportDownload.InvokeRequired)
                btn_ReportDownload.Invoke(new MethodInvoker(() => btn_ReportDownload.Enabled = enabled));
            else
                btn_ReportDownload.Enabled = enabled;

            if (btn_GetFilePath.InvokeRequired)
                btn_GetFilePath.Invoke(new MethodInvoker(() => btn_GetFilePath.Enabled = enabled));
            else
                btn_GetFilePath.Enabled = enabled;

            if (btn_SaveFolderPath.InvokeRequired)
                btn_SaveFolderPath.Invoke(new MethodInvoker(() => btn_SaveFolderPath.Enabled = enabled));
            else
                btn_SaveFolderPath.Enabled = enabled;
        }

        #endregion

        #region Sku Updater Properties

        public void GetProductsFilePath()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                    ProductsFilePath = openFileDialog.FileName;
            }
        }

        public void GetSkuFilePath()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                    SkuFilePath = openFileDialog.FileName;
            }
        }

        public void SkuCancel()
        {
            if (SkuCancellationTokenSource == null) return;

            SkuCancellationTokenSource.Cancel();

            skuProgressBarDescription.Text = "Operation has been canceled.";

            MessageBox.Show("Operation has been canceled.");
        }

        public void SkuProgress(SkuProgressStep skuProgressStep, string additionalInfo = null)
        {
            if (skuProgressBar.InvokeRequired)
                skuProgressBar.Invoke(new MethodInvoker(() => skuProgressBar.Value = (int) skuProgressStep));
            else
                skuProgressBar.Value = (int) skuProgressStep;

            if (skuProgressBarDescription.InvokeRequired)
                skuProgressBarDescription.Invoke(
                    new MethodInvoker(() =>
                    {
                        skuProgressBarDescription.Text =
                            EnumHelper<SkuProgressStep>.GetDisplayValue(skuProgressStep);

                        if (!string.IsNullOrWhiteSpace(additionalInfo))
                            skuProgressBarDescription.Text += $" {additionalInfo}";
                    }));
            else
            {
                skuProgressBarDescription.Text = EnumHelper<SkuProgressStep>.GetDisplayValue(skuProgressStep);

                if (!string.IsNullOrWhiteSpace(additionalInfo))
                    skuProgressBarDescription.Text += $" {additionalInfo}";
            }
        }

        private void InvokeUpdateSku()
        {
            var validation = ValidateSkuModel?.Invoke();
            if (validation != null && validation.Length != 0)
            {
                MessageBox.Show(string.Join("\r\n", validation),
                    "Model Validation Errors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SkuCancellationTokenSource = new CancellationTokenSource();
            try
            {
                UpdateSkuButtonState(false);

                UpdateSku?.Invoke();
                MessageBox.Show("Success.");
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There is some error during sku update.");

                MessageBox.Show("There is some error. See logs for more details.");
            }

            SkuCancellationTokenSource = null;
            UpdateSkuButtonState(true);
        }

        private void UpdateSkuButtonState(bool enabled)
        {
            if (btn_SkuUpdate.InvokeRequired)
                btn_SkuUpdate.Invoke(new MethodInvoker(() => btn_SkuUpdate.Enabled = enabled));
            else
                btn_SkuUpdate.Enabled = enabled;

            if (btn_GetSkuFilePath.InvokeRequired)
                btn_GetSkuFilePath.Invoke(new MethodInvoker(() => btn_GetSkuFilePath.Enabled = enabled));
            else
                btn_GetSkuFilePath.Enabled = enabled;

            if (btn_GetProductsFilePath.InvokeRequired)
                btn_GetProductsFilePath.Invoke(new MethodInvoker(() => btn_GetProductsFilePath.Enabled = enabled));
            else
                btn_GetProductsFilePath.Enabled = enabled;
        }

        #endregion
    }
}