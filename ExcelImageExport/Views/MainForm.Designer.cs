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
            this.btn_Download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_FilePath = new System.Windows.Forms.TextBox();
            this.btn_GetFile = new System.Windows.Forms.Button();
            this.btn_SaveFolderPath = new System.Windows.Forms.Button();
            this.tb_SaveFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.npd_NamesColumnIndex = new System.Windows.Forms.NumericUpDown();
            this.npd_ImagesColumnIndex = new System.Windows.Forms.NumericUpDown();
            this.npd_StartRowIndex = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarDescription = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.npd_NamesColumnIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_ImagesColumnIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_StartRowIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(529, 205);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(86, 62);
            this.btn_Download.TabIndex = 1;
            this.btn_Download.Text = "Download";
            this.btn_Download.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Names Column Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Images Column Index";
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.Location = new System.Drawing.Point(98, 127);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.Size = new System.Drawing.Size(386, 20);
            this.tb_FilePath.TabIndex = 5;
            // 
            // btn_GetFile
            // 
            this.btn_GetFile.Location = new System.Drawing.Point(490, 125);
            this.btn_GetFile.Name = "btn_GetFile";
            this.btn_GetFile.Size = new System.Drawing.Size(125, 23);
            this.btn_GetFile.TabIndex = 6;
            this.btn_GetFile.Text = "Get File";
            this.btn_GetFile.UseVisualStyleBackColor = true;
            // 
            // btn_SaveFolderPath
            // 
            this.btn_SaveFolderPath.Location = new System.Drawing.Point(490, 157);
            this.btn_SaveFolderPath.Name = "btn_SaveFolderPath";
            this.btn_SaveFolderPath.Size = new System.Drawing.Size(125, 23);
            this.btn_SaveFolderPath.TabIndex = 8;
            this.btn_SaveFolderPath.Text = "Get Save Folder Path";
            this.btn_SaveFolderPath.UseVisualStyleBackColor = true;
            // 
            // tb_SaveFolderPath
            // 
            this.tb_SaveFolderPath.Location = new System.Drawing.Point(98, 157);
            this.tb_SaveFolderPath.Name = "tb_SaveFolderPath";
            this.tb_SaveFolderPath.Size = new System.Drawing.Size(386, 20);
            this.tb_SaveFolderPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start Row Index";
            // 
            // npd_NamesColumnIndex
            // 
            this.npd_NamesColumnIndex.Location = new System.Drawing.Point(117, 34);
            this.npd_NamesColumnIndex.Name = "npd_NamesColumnIndex";
            this.npd_NamesColumnIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_NamesColumnIndex.TabIndex = 1;
            // 
            // npd_ImagesColumnIndex
            // 
            this.npd_ImagesColumnIndex.Location = new System.Drawing.Point(117, 61);
            this.npd_ImagesColumnIndex.Name = "npd_ImagesColumnIndex";
            this.npd_ImagesColumnIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_ImagesColumnIndex.TabIndex = 2;
            // 
            // npd_StartRowIndex
            // 
            this.npd_StartRowIndex.Location = new System.Drawing.Point(117, 7);
            this.npd_StartRowIndex.Name = "npd_StartRowIndex";
            this.npd_StartRowIndex.Size = new System.Drawing.Size(120, 20);
            this.npd_StartRowIndex.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 302);
            this.progressBar.Maximum = 4;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(609, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 11;
            // 
            // progressBarDescription
            // 
            this.progressBarDescription.AutoSize = true;
            this.progressBarDescription.Location = new System.Drawing.Point(12, 286);
            this.progressBarDescription.Name = "progressBarDescription";
            this.progressBarDescription.Size = new System.Drawing.Size(116, 13);
            this.progressBarDescription.TabIndex = 12;
            this.progressBarDescription.Text = "progressBarDescription";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(6, 205);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(86, 62);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "File Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Save Folder Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 339);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.progressBarDescription);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.npd_StartRowIndex);
            this.Controls.Add(this.npd_ImagesColumnIndex);
            this.Controls.Add(this.npd_NamesColumnIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_SaveFolderPath);
            this.Controls.Add(this.tb_SaveFolderPath);
            this.Controls.Add(this.btn_GetFile);
            this.Controls.Add(this.tb_FilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Download);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 378);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 378);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.npd_NamesColumnIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_ImagesColumnIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npd_StartRowIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_FilePath;
        private System.Windows.Forms.Button btn_GetFile;
        private System.Windows.Forms.Button btn_SaveFolderPath;
        private System.Windows.Forms.TextBox tb_SaveFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown npd_NamesColumnIndex;
        private System.Windows.Forms.NumericUpDown npd_ImagesColumnIndex;
        private System.Windows.Forms.NumericUpDown npd_StartRowIndex;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label progressBarDescription;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

