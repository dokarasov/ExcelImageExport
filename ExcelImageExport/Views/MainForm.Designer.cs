namespace ExcelImageExport.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btn_ReportDownload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_FilePath = new System.Windows.Forms.TextBox();
            this.btn_GetFilePath = new System.Windows.Forms.Button();
            this.tb_SaveFolderPath = new System.Windows.Forms.TextBox();
            this.btn_SaveFolderPath = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.npd_NamesColumnIndex = new System.Windows.Forms.NumericUpDown();
            this.npd_ImagesColumnIndex = new System.Windows.Forms.NumericUpDown();
            this.npd_StartRowIndex = new System.Windows.Forms.NumericUpDown();
            this.reportProgressBar = new System.Windows.Forms.ProgressBar();
            this.reportProgressBarDescription = new System.Windows.Forms.Label();
            this.btn_ReportCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tp_DownloadImages = new System.Windows.Forms.TabPage();
            this.tp_SkuUpdater = new System.Windows.Forms.TabPage();
            this.btn_SkuUpdate = new System.Windows.Forms.Button();
            this.btn_SkuCancel = new System.Windows.Forms.Button();
            this.skuProgressBarDescription = new System.Windows.Forms.Label();
            this.skuProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_SkuFilePath = new System.Windows.Forms.TextBox();
            this.btn_GetSkuFilePath = new System.Windows.Forms.Button();
            this.tb_ProductsFilePath = new System.Windows.Forms.TextBox();
            this.btn_GetProductsFilePath = new System.Windows.Forms.Button();
            this.skuBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.npd_NamesColumnIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_ImagesColumnIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_StartRowIndex)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tp_DownloadImages.SuspendLayout();
            this.tp_SkuUpdater.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ReportDownload
            // 
            this.btn_ReportDownload.Location = new System.Drawing.Point(532, 205);
            this.btn_ReportDownload.Name = "btn_ReportDownload";
            this.btn_ReportDownload.Size = new System.Drawing.Size(86, 62);
            this.btn_ReportDownload.TabIndex = 1;
            this.btn_ReportDownload.Text = "Download";
            this.btn_ReportDownload.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Names Column Index";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Images Column Index";
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.Location = new System.Drawing.Point(101, 127);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.Size = new System.Drawing.Size(386, 20);
            this.tb_FilePath.TabIndex = 5;
            // 
            // btn_GetFilePath
            // 
            this.btn_GetFilePath.Location = new System.Drawing.Point(493, 125);
            this.btn_GetFilePath.Name = "btn_GetFilePath";
            this.btn_GetFilePath.Size = new System.Drawing.Size(125, 23);
            this.btn_GetFilePath.TabIndex = 6;
            this.btn_GetFilePath.Text = "Get File";
            this.btn_GetFilePath.UseVisualStyleBackColor = true;
            // 
            // tb_SaveFolderPath
            // 
            this.tb_SaveFolderPath.Location = new System.Drawing.Point(101, 157);
            this.tb_SaveFolderPath.Name = "tb_SaveFolderPath";
            this.tb_SaveFolderPath.Size = new System.Drawing.Size(386, 20);
            this.tb_SaveFolderPath.TabIndex = 7;
            // 
            // btn_SaveFolderPath
            // 
            this.btn_SaveFolderPath.Location = new System.Drawing.Point(493, 157);
            this.btn_SaveFolderPath.Name = "btn_SaveFolderPath";
            this.btn_SaveFolderPath.Size = new System.Drawing.Size(125, 23);
            this.btn_SaveFolderPath.TabIndex = 8;
            this.btn_SaveFolderPath.Text = "Get Save Folder Path";
            this.btn_SaveFolderPath.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Row Index";
            // 
            // npd_NamesColumnIndex
            // 
            this.npd_NamesColumnIndex.Location = new System.Drawing.Point(120, 34);
            this.npd_NamesColumnIndex.Name = "npd_NamesColumnIndex";
            this.npd_NamesColumnIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_NamesColumnIndex.TabIndex = 1;
            // 
            // npd_ImagesColumnIndex
            // 
            this.npd_ImagesColumnIndex.Location = new System.Drawing.Point(120, 61);
            this.npd_ImagesColumnIndex.Name = "npd_ImagesColumnIndex";
            this.npd_ImagesColumnIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_ImagesColumnIndex.TabIndex = 2;
            // 
            // npd_StartRowIndex
            // 
            this.npd_StartRowIndex.Location = new System.Drawing.Point(120, 7);
            this.npd_StartRowIndex.Name = "npd_StartRowIndex";
            this.npd_StartRowIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_StartRowIndex.TabIndex = 0;
            // 
            // reportProgressBar
            // 
            this.reportProgressBar.Location = new System.Drawing.Point(9, 302);
            this.reportProgressBar.Maximum = 4;
            this.reportProgressBar.Name = "reportProgressBar";
            this.reportProgressBar.Size = new System.Drawing.Size(609, 23);
            this.reportProgressBar.Step = 1;
            this.reportProgressBar.TabIndex = 11;
            // 
            // reportProgressBarDescription
            // 
            this.reportProgressBarDescription.AutoSize = true;
            this.reportProgressBarDescription.Location = new System.Drawing.Point(15, 286);
            this.reportProgressBarDescription.Name = "reportProgressBarDescription";
            this.reportProgressBarDescription.Size = new System.Drawing.Size(116, 13);
            this.reportProgressBarDescription.TabIndex = 12;
            this.reportProgressBarDescription.Text = "progressBarDescription";
            // 
            // btn_ReportCancel
            // 
            this.btn_ReportCancel.Location = new System.Drawing.Point(9, 205);
            this.btn_ReportCancel.Name = "btn_ReportCancel";
            this.btn_ReportCancel.Size = new System.Drawing.Size(86, 62);
            this.btn_ReportCancel.TabIndex = 13;
            this.btn_ReportCancel.Text = "Cancel";
            this.btn_ReportCancel.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "File Path";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Save Folder Path";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tp_DownloadImages);
            this.tabControl2.Controls.Add(this.tp_SkuUpdater);
            this.tabControl2.Location = new System.Drawing.Point(12, 11);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(637, 361);
            this.tabControl2.TabIndex = 16;
            // 
            // tp_DownloadImages
            // 
            this.tp_DownloadImages.Controls.Add(this.label8);
            this.tp_DownloadImages.Controls.Add(this.label11);
            this.tp_DownloadImages.Controls.Add(this.btn_ReportDownload);
            this.tp_DownloadImages.Controls.Add(this.label6);
            this.tp_DownloadImages.Controls.Add(this.label10);
            this.tp_DownloadImages.Controls.Add(this.label7);
            this.tp_DownloadImages.Controls.Add(this.tb_FilePath);
            this.tp_DownloadImages.Controls.Add(this.btn_ReportCancel);
            this.tp_DownloadImages.Controls.Add(this.btn_GetFilePath);
            this.tp_DownloadImages.Controls.Add(this.tb_SaveFolderPath);
            this.tp_DownloadImages.Controls.Add(this.reportProgressBarDescription);
            this.tp_DownloadImages.Controls.Add(this.btn_SaveFolderPath);
            this.tp_DownloadImages.Controls.Add(this.npd_NamesColumnIndex);
            this.tp_DownloadImages.Controls.Add(this.reportProgressBar);
            this.tp_DownloadImages.Controls.Add(this.npd_ImagesColumnIndex);
            this.tp_DownloadImages.Controls.Add(this.npd_StartRowIndex);
            this.tp_DownloadImages.Location = new System.Drawing.Point(4, 22);
            this.tp_DownloadImages.Name = "tp_DownloadImages";
            this.tp_DownloadImages.Padding = new System.Windows.Forms.Padding(3);
            this.tp_DownloadImages.Size = new System.Drawing.Size(629, 335);
            this.tp_DownloadImages.TabIndex = 0;
            this.tp_DownloadImages.Text = "Download Images";
            this.tp_DownloadImages.UseVisualStyleBackColor = true;
            // 
            // tp_SkuUpdater
            // 
            this.tp_SkuUpdater.Controls.Add(this.btn_SkuUpdate);
            this.tp_SkuUpdater.Controls.Add(this.btn_SkuCancel);
            this.tp_SkuUpdater.Controls.Add(this.skuProgressBarDescription);
            this.tp_SkuUpdater.Controls.Add(this.skuProgressBar);
            this.tp_SkuUpdater.Controls.Add(this.label1);
            this.tp_SkuUpdater.Controls.Add(this.label2);
            this.tp_SkuUpdater.Controls.Add(this.tb_SkuFilePath);
            this.tp_SkuUpdater.Controls.Add(this.btn_GetSkuFilePath);
            this.tp_SkuUpdater.Controls.Add(this.tb_ProductsFilePath);
            this.tp_SkuUpdater.Controls.Add(this.btn_GetProductsFilePath);
            this.tp_SkuUpdater.Location = new System.Drawing.Point(4, 22);
            this.tp_SkuUpdater.Name = "tp_SkuUpdater";
            this.tp_SkuUpdater.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SkuUpdater.Size = new System.Drawing.Size(629, 335);
            this.tp_SkuUpdater.TabIndex = 1;
            this.tp_SkuUpdater.Text = "Update Sku";
            this.tp_SkuUpdater.UseVisualStyleBackColor = true;
            // 
            // btn_SkuUpdate
            // 
            this.btn_SkuUpdate.Location = new System.Drawing.Point(532, 205);
            this.btn_SkuUpdate.Name = "btn_SkuUpdate";
            this.btn_SkuUpdate.Size = new System.Drawing.Size(86, 62);
            this.btn_SkuUpdate.TabIndex = 22;
            this.btn_SkuUpdate.Text = "Update";
            this.btn_SkuUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_SkuCancel
            // 
            this.btn_SkuCancel.Location = new System.Drawing.Point(9, 205);
            this.btn_SkuCancel.Name = "btn_SkuCancel";
            this.btn_SkuCancel.Size = new System.Drawing.Size(86, 62);
            this.btn_SkuCancel.TabIndex = 25;
            this.btn_SkuCancel.Text = "Cancel";
            this.btn_SkuCancel.UseVisualStyleBackColor = true;
            // 
            // skuProgressBarDescription
            // 
            this.skuProgressBarDescription.AutoSize = true;
            this.skuProgressBarDescription.Location = new System.Drawing.Point(15, 286);
            this.skuProgressBarDescription.Name = "skuProgressBarDescription";
            this.skuProgressBarDescription.Size = new System.Drawing.Size(116, 13);
            this.skuProgressBarDescription.TabIndex = 24;
            this.skuProgressBarDescription.Text = "progressBarDescription";
            // 
            // skuProgressBar
            // 
            this.skuProgressBar.Location = new System.Drawing.Point(9, 302);
            this.skuProgressBar.Maximum = 6;
            this.skuProgressBar.Name = "skuProgressBar";
            this.skuProgressBar.Size = new System.Drawing.Size(609, 23);
            this.skuProgressBar.Step = 1;
            this.skuProgressBar.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Products File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Sku File Path";
            // 
            // tb_SkuFilePath
            // 
            this.tb_SkuFilePath.Location = new System.Drawing.Point(105, 6);
            this.tb_SkuFilePath.Name = "tb_SkuFilePath";
            this.tb_SkuFilePath.Size = new System.Drawing.Size(382, 20);
            this.tb_SkuFilePath.TabIndex = 16;
            // 
            // btn_GetSkuFilePath
            // 
            this.btn_GetSkuFilePath.Location = new System.Drawing.Point(493, 4);
            this.btn_GetSkuFilePath.Name = "btn_GetSkuFilePath";
            this.btn_GetSkuFilePath.Size = new System.Drawing.Size(125, 23);
            this.btn_GetSkuFilePath.TabIndex = 17;
            this.btn_GetSkuFilePath.Text = "Get Sku File";
            this.btn_GetSkuFilePath.UseVisualStyleBackColor = true;
            // 
            // tb_ProductsFilePath
            // 
            this.tb_ProductsFilePath.Location = new System.Drawing.Point(105, 36);
            this.tb_ProductsFilePath.Name = "tb_ProductsFilePath";
            this.tb_ProductsFilePath.Size = new System.Drawing.Size(382, 20);
            this.tb_ProductsFilePath.TabIndex = 18;
            // 
            // btn_GetProductsFilePath
            // 
            this.btn_GetProductsFilePath.Location = new System.Drawing.Point(493, 36);
            this.btn_GetProductsFilePath.Name = "btn_GetProductsFilePath";
            this.btn_GetProductsFilePath.Size = new System.Drawing.Size(125, 23);
            this.btn_GetProductsFilePath.TabIndex = 19;
            this.btn_GetProductsFilePath.Text = "Get Products File";
            this.btn_GetProductsFilePath.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 384);
            this.Controls.Add(this.tabControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 378);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.npd_NamesColumnIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_ImagesColumnIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_StartRowIndex)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tp_DownloadImages.ResumeLayout(false);
            this.tp_DownloadImages.PerformLayout();
            this.tp_SkuUpdater.ResumeLayout(false);
            this.tp_SkuUpdater.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker reportBackgroundWorker;
        private System.Windows.Forms.Button btn_ReportDownload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_FilePath;
        private System.Windows.Forms.Button btn_GetFilePath;
        private System.Windows.Forms.TextBox tb_SaveFolderPath;
        private System.Windows.Forms.Button btn_SaveFolderPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown npd_NamesColumnIndex;
        private System.Windows.Forms.NumericUpDown npd_ImagesColumnIndex;
        private System.Windows.Forms.NumericUpDown npd_StartRowIndex;
        private System.Windows.Forms.ProgressBar reportProgressBar;
        private System.Windows.Forms.Label reportProgressBarDescription;
        private System.Windows.Forms.Button btn_ReportCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tp_DownloadImages;
        private System.Windows.Forms.TabPage tp_SkuUpdater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_SkuFilePath;
        private System.Windows.Forms.Button btn_GetSkuFilePath;
        private System.Windows.Forms.TextBox tb_ProductsFilePath;
        private System.Windows.Forms.Button btn_GetProductsFilePath;
        private System.Windows.Forms.Button btn_SkuUpdate;
        private System.Windows.Forms.Button btn_SkuCancel;
        private System.Windows.Forms.Label skuProgressBarDescription;
        private System.Windows.Forms.ProgressBar skuProgressBar;
        private System.ComponentModel.BackgroundWorker skuBackgroundWorker;
    }
}

