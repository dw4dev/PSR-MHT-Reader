
namespace PsrMhtReader
{
    partial class fMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClosePage = new System.Windows.Forms.Button();
            this.btnSrcFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClosePage);
            this.groupBox1.Controls.Add(this.btnSrcFile);
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source File";
            // 
            // btnClosePage
            // 
            this.btnClosePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosePage.BackgroundImage = global::PsrMhtReader.Properties.Resources.icons8_close_sign_24;
            this.btnClosePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClosePage.Location = new System.Drawing.Point(898, 14);
            this.btnClosePage.Name = "btnClosePage";
            this.btnClosePage.Size = new System.Drawing.Size(28, 28);
            this.btnClosePage.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnClosePage, "Close open files.");
            this.btnClosePage.UseVisualStyleBackColor = true;
            this.btnClosePage.Click += new System.EventHandler(this.btnClosePage_Click);
            // 
            // btnSrcFile
            // 
            this.btnSrcFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrcFile.Image = global::PsrMhtReader.Properties.Resources.icons8_linking_24;
            this.btnSrcFile.Location = new System.Drawing.Point(857, 14);
            this.btnSrcFile.Name = "btnSrcFile";
            this.btnSrcFile.Size = new System.Drawing.Size(28, 28);
            this.btnSrcFile.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSrcFile, "Open the disassembled folder of the mht file");
            this.btnSrcFile.UseVisualStyleBackColor = true;
            this.btnSrcFile.Click += new System.EventHandler(this.btnSrcFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 14);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(32, 28);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "...";
            this.toolTip1.SetToolTip(this.btnOpenFile, "Open mht file...");
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.BackColor = System.Drawing.Color.OldLace;
            this.txtFilePath.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtFilePath.Location = new System.Drawing.Point(44, 16);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(809, 25);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.Text = "ttttt";
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.ProcessFile_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.ProcessFileDrop_DragEnter);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = false;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 61);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(932, 442);
            this.webView21.Source = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 10);
            this.panel1.TabIndex = 2;
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "mht File|*.mht";
            this.ofdOpenFile.Title = "Select the mht file to open ...";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 503);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "fMain";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Text = "Problem Steps Recorder - MHT Reader";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ProcessFile_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ProcessFileDrop_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Button btnSrcFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClosePage;
    }
}

