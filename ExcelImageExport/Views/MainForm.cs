using Serilog;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ExcelImageExport.Views
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;

        public event Action DownloadImages;
        public event Func<string[]> ValidateModel;

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

        public CancellationTokenSource CancellationTokenSource { get; set; }

        public MainForm(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();

            backgroundWorker.DoWork += (sender, args) => InvokeDownloadImages();
            btn_Download.Click += (sender, args) => backgroundWorker.RunWorkerAsync();
            btn_GetFile.Click += (sender, args) => GetFilePath();
            btn_SaveFolderPath.Click += (sender, args) => GetSaveFolderPath();
            btn_Cancel.Click += (sender, args) => Cancel();

            progressBarDescription.Text = string.Empty;
        }

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

        public void Cancel()
        {
            if (CancellationTokenSource == null) return;

            CancellationTokenSource.Cancel();

            progressBarDescription.Text = "Operation has been canceled.";

            MessageBox.Show("Operation has been canceled.");
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public void ReportProgress(int value, string description)
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new MethodInvoker(delegate { progressBar.Value = value; }));
            else
                progressBar.Value = value;

            if (progressBarDescription.InvokeRequired)
                progressBarDescription.Invoke(
                    new MethodInvoker(delegate { progressBarDescription.Text = description; }));
            else
                progressBarDescription.Text = description;
        }

        private void InvokeDownloadImages()
        {
            var validation = ValidateModel?.Invoke();
            if (validation != null && validation.Length != 0)
            {
                MessageBox.Show(string.Join("\r\n", validation), "Model Validation Errors", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            CancellationTokenSource = new CancellationTokenSource();
            try
            {
                UpdateButtonState(false);

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

            CancellationTokenSource = null;
            UpdateButtonState(true);
        }

        private void UpdateButtonState(bool enabled)
        {
            if (btn_Download.InvokeRequired)
                btn_Download.Invoke(new MethodInvoker(delegate { btn_Download.Enabled = enabled; }));
            else
                btn_Download.Enabled = enabled;

            if (btn_GetFile.InvokeRequired)
                btn_GetFile.Invoke(new MethodInvoker(delegate { btn_GetFile.Enabled = enabled; }));
            else
                btn_GetFile.Enabled = enabled;

            if (btn_SaveFolderPath.InvokeRequired)
                btn_SaveFolderPath.Invoke(new MethodInvoker(delegate { btn_SaveFolderPath.Enabled = enabled; }));
            else
                btn_SaveFolderPath.Enabled = enabled;
        }
    }
}