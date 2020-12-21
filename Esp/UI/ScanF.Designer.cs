
namespace Esp.UI
{
    partial class ScanF
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
            this.cbx_Prior = new System.Windows.Forms.ComboBox();
            this.cbx_Doing = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancell = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.pb_Scan = new System.Windows.Forms.ProgressBar();
            this.lbl_Scan = new System.Windows.Forms.Label();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.pb_Files = new System.Windows.Forms.ProgressBar();
            this.lbl_Files = new System.Windows.Forms.Label();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.pb_Dirs = new System.Windows.Forms.ProgressBar();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.lbl_Dirs = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gb3.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_Prior
            // 
            this.cbx_Prior.FormattingEnabled = true;
            this.cbx_Prior.Items.AddRange(new object[] {
            "Високий",
            "Стандартний",
            "Низький"});
            this.cbx_Prior.Location = new System.Drawing.Point(138, 281);
            this.cbx_Prior.Name = "cbx_Prior";
            this.cbx_Prior.Size = new System.Drawing.Size(105, 21);
            this.cbx_Prior.TabIndex = 20;
            this.cbx_Prior.SelectedIndexChanged += new System.EventHandler(this.cbx_Prior_SelectedIndexChanged);
            // 
            // cbx_Doing
            // 
            this.cbx_Doing.FormattingEnabled = true;
            this.cbx_Doing.Items.AddRange(new object[] {
            "Швидко",
            "Стандартно",
            "Повільно"});
            this.cbx_Doing.Location = new System.Drawing.Point(24, 281);
            this.cbx_Doing.Name = "cbx_Doing";
            this.cbx_Doing.Size = new System.Drawing.Size(105, 21);
            this.cbx_Doing.TabIndex = 21;
            this.cbx_Doing.SelectedIndexChanged += new System.EventHandler(this.cbx_Doing_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Пріорітет виконання: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Процес виконання: ";
            // 
            // btn_Cancell
            // 
            this.btn_Cancell.Location = new System.Drawing.Point(389, 279);
            this.btn_Cancell.Name = "btn_Cancell";
            this.btn_Cancell.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancell.TabIndex = 16;
            this.btn_Cancell.Text = "Відмінити";
            this.btn_Cancell.UseVisualStyleBackColor = true;
            this.btn_Cancell.Click += new System.EventHandler(this.btn_Cancell_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(308, 279);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(75, 23);
            this.btn_Pause.TabIndex = 17;
            this.btn_Pause.Text = "Пауза";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // pb_Scan
            // 
            this.pb_Scan.Location = new System.Drawing.Point(6, 41);
            this.pb_Scan.Name = "pb_Scan";
            this.pb_Scan.Size = new System.Drawing.Size(459, 23);
            this.pb_Scan.TabIndex = 2;
            // 
            // lbl_Scan
            // 
            this.lbl_Scan.AutoSize = true;
            this.lbl_Scan.Location = new System.Drawing.Point(6, 25);
            this.lbl_Scan.Name = "lbl_Scan";
            this.lbl_Scan.Size = new System.Drawing.Size(18, 13);
            this.lbl_Scan.TabIndex = 1;
            this.lbl_Scan.Text = "../";
            this.lbl_Scan.TextChanged += new System.EventHandler(this.lbl_Scan_TextChanged);
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.pb_Scan);
            this.gb3.Controls.Add(this.lbl_Scan);
            this.gb3.Location = new System.Drawing.Point(12, 174);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(471, 75);
            this.gb3.TabIndex = 13;
            this.gb3.TabStop = false;
            this.gb3.Text = "Сканування файлів за патерном (списком слів):";
            // 
            // pb_Files
            // 
            this.pb_Files.Location = new System.Drawing.Point(6, 41);
            this.pb_Files.Name = "pb_Files";
            this.pb_Files.Size = new System.Drawing.Size(459, 23);
            this.pb_Files.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_Files.TabIndex = 2;
            // 
            // lbl_Files
            // 
            this.lbl_Files.AutoSize = true;
            this.lbl_Files.Location = new System.Drawing.Point(6, 25);
            this.lbl_Files.Name = "lbl_Files";
            this.lbl_Files.Size = new System.Drawing.Size(18, 13);
            this.lbl_Files.TabIndex = 1;
            this.lbl_Files.Text = "../";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.pb_Files);
            this.gb2.Controls.Add(this.lbl_Files);
            this.gb2.Location = new System.Drawing.Point(12, 93);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(471, 75);
            this.gb2.TabIndex = 14;
            this.gb2.TabStop = false;
            this.gb2.Text = "Отримання списку файлів:";
            // 
            // pb_Dirs
            // 
            this.pb_Dirs.Location = new System.Drawing.Point(6, 41);
            this.pb_Dirs.Name = "pb_Dirs";
            this.pb_Dirs.Size = new System.Drawing.Size(459, 23);
            this.pb_Dirs.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_Dirs.TabIndex = 2;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.pb_Dirs);
            this.gb1.Controls.Add(this.lbl_Dirs);
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(471, 75);
            this.gb1.TabIndex = 15;
            this.gb1.TabStop = false;
            this.gb1.Text = "Отримання списку директорій:";
            // 
            // lbl_Dirs
            // 
            this.lbl_Dirs.AutoSize = true;
            this.lbl_Dirs.Location = new System.Drawing.Point(6, 25);
            this.lbl_Dirs.Name = "lbl_Dirs";
            this.lbl_Dirs.Size = new System.Drawing.Size(18, 13);
            this.lbl_Dirs.TabIndex = 1;
            this.lbl_Dirs.Text = "../";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ScanF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 315);
            this.Controls.Add(this.cbx_Prior);
            this.Controls.Add(this.cbx_Doing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancell);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Name = "ScanF";
            this.Text = "ScanF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanF_FormClosing);
            this.Load += new System.EventHandler(this.ScanF_Load);
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbx_Prior;
        private System.Windows.Forms.ComboBox cbx_Doing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancell;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.ProgressBar pb_Scan;
        private System.Windows.Forms.Label lbl_Scan;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.ProgressBar pb_Files;
        private System.Windows.Forms.Label lbl_Files;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.ProgressBar pb_Dirs;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label lbl_Dirs;
        private System.Windows.Forms.Timer timer;
    }
}