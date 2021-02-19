namespace Wan_Thingy
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.tbHostList = new System.Windows.Forms.TextBox();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExcludeList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTimeOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbUA = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearURL = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadFilters = new System.Windows.Forms.Button();
            this.btnLoadURLS = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.CbFilteredOutput = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(567, 705);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbHostList
            // 
            this.tbHostList.Location = new System.Drawing.Point(22, 50);
            this.tbHostList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbHostList.MaxLength = 647670;
            this.tbHostList.Multiline = true;
            this.tbHostList.Name = "tbHostList";
            this.tbHostList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHostList.Size = new System.Drawing.Size(530, 318);
            this.tbHostList.TabIndex = 2;
            // 
            // bg
            // 
            this.bg.WorkerReportsProgress = true;
            this.bg.WorkerSupportsCancellation = true;
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_ProgressChanged);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(814, 705);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(572, 218);
            this.pb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(380, 102);
            this.pb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(567, 325);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status: Not Running";
            // 
            // tbExcludeList
            // 
            this.tbExcludeList.Location = new System.Drawing.Point(22, 463);
            this.tbExcludeList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbExcludeList.Multiline = true;
            this.tbExcludeList.Name = "tbExcludeList";
            this.tbExcludeList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbExcludeList.Size = new System.Drawing.Size(530, 227);
            this.tbExcludeList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 434);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exclude These Strings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL List To Scan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(567, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Timeout:";
            // 
            // tbTimeOut
            // 
            this.tbTimeOut.Location = new System.Drawing.Point(710, 161);
            this.tbTimeOut.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbTimeOut.Name = "tbTimeOut";
            this.tbTimeOut.Size = new System.Drawing.Size(68, 29);
            this.tbTimeOut.TabIndex = 9;
            this.tbTimeOut.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(567, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "User Agent:";
            // 
            // lbUA
            // 
            this.lbUA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUA.FormattingEnabled = true;
            this.lbUA.ItemHeight = 24;
            this.lbUA.Items.AddRange(new object[] {
            "Google Bot",
            "Bing Bot",
            "DuckDuckBot",
            "Baidu Bot",
            "Yandex Bot",
            "Internet Explorer",
            "Firefox",
            "Chrome",
            "America Online"});
            this.lbUA.Location = new System.Drawing.Point(710, 50);
            this.lbUA.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lbUA.Name = "lbUA";
            this.lbUA.Size = new System.Drawing.Size(240, 98);
            this.lbUA.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(792, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "(in seconds)";
            // 
            // btnClearURL
            // 
            this.btnClearURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearURL.Location = new System.Drawing.Point(418, 382);
            this.btnClearURL.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClearURL.Name = "btnClearURL";
            this.btnClearURL.Size = new System.Drawing.Size(138, 46);
            this.btnClearURL.TabIndex = 14;
            this.btnClearURL.Text = "Clear List";
            this.btnClearURL.UseVisualStyleBackColor = true;
            this.btnClearURL.Click += new System.EventHandler(this.btnClearURL_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.Location = new System.Drawing.Point(418, 705);
            this.btnClearFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(138, 46);
            this.btnClearFilter.TabIndex = 14;
            this.btnClearFilter.Text = "Clear Filters";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(567, 354);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 340);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadFilters
            // 
            this.btnLoadFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFilters.Location = new System.Drawing.Point(22, 705);
            this.btnLoadFilters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLoadFilters.Name = "btnLoadFilters";
            this.btnLoadFilters.Size = new System.Drawing.Size(138, 46);
            this.btnLoadFilters.TabIndex = 14;
            this.btnLoadFilters.Text = "Load Filters";
            this.btnLoadFilters.UseVisualStyleBackColor = true;
            this.btnLoadFilters.Click += new System.EventHandler(this.btnLoadFilters_Click);
            // 
            // btnLoadURLS
            // 
            this.btnLoadURLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadURLS.Location = new System.Drawing.Point(22, 382);
            this.btnLoadURLS.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLoadURLS.Name = "btnLoadURLS";
            this.btnLoadURLS.Size = new System.Drawing.Size(138, 46);
            this.btnLoadURLS.TabIndex = 14;
            this.btnLoadURLS.Text = "Load List";
            this.toolTip1.SetToolTip(this.btnLoadURLS, "Supports Masscan or Nmap XML files, or  text files.");
            this.btnLoadURLS.UseVisualStyleBackColor = true;
            this.btnLoadURLS.Click += new System.EventHandler(this.btnLoadURLS_Click);
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDebug.Location = new System.Drawing.Point(567, 761);
            this.cbDebug.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(322, 26);
            this.cbDebug.TabIndex = 15;
            this.cbDebug.Text = "Don\'t Try Passwords (just scan)";
            this.cbDebug.UseVisualStyleBackColor = true;
            // 
            // CbFilteredOutput
            // 
            this.CbFilteredOutput.AutoSize = true;
            this.CbFilteredOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbFilteredOutput.Location = new System.Drawing.Point(22, 761);
            this.CbFilteredOutput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CbFilteredOutput.Name = "CbFilteredOutput";
            this.CbFilteredOutput.Size = new System.Drawing.Size(418, 26);
            this.CbFilteredOutput.TabIndex = 16;
            this.CbFilteredOutput.Text = "Just Output Unfiltered Hosts (skip request)";
            this.CbFilteredOutput.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(961, 814);
            this.Controls.Add(this.CbFilteredOutput);
            this.Controls.Add(this.cbDebug);
            this.Controls.Add(this.btnLoadFilters);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnLoadURLS);
            this.Controls.Add(this.btnClearURL);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbUA);
            this.Controls.Add(this.tbTimeOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbExcludeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.tbHostList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Wan Scan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbHostList;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExcludeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTimeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbUA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearURL;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnLoadFilters;
        private System.Windows.Forms.Button btnLoadURLS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.CheckBox CbFilteredOutput;
    }
}

