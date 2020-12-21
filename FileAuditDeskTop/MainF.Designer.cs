
namespace FileAuditDeskTop
{
    partial class MainF
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gb_OtherOptions = new System.Windows.Forms.GroupBox();
            this.gb_IgnoreDirs = new System.Windows.Forms.GroupBox();
            this.lbx_IgnoreDir = new System.Windows.Forms.ListBox();
            this.btn_AddDirIgnore = new System.Windows.Forms.Button();
            this.gbIgnore = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dud_FileSeziBaseTo = new System.Windows.Forms.DomainUpDown();
            this.nud_IgnoreFrom = new System.Windows.Forms.NumericUpDown();
            this.dud_FileSeziBaseFrom = new System.Windows.Forms.DomainUpDown();
            this.nud_IgnoreTo = new System.Windows.Forms.NumericUpDown();
            this.chb_SaveAllProperty = new System.Windows.Forms.CheckBox();
            this.gb_FileSys = new System.Windows.Forms.GroupBox();
            this.lbx_FolderToScan = new System.Windows.Forms.ListBox();
            this.cms_FolderToScan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTLSMI_FTS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTLSMI_FTS_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddFoldersSearch = new System.Windows.Forms.Button();
            this.gb_AllInfoDisk = new System.Windows.Forms.GroupBox();
            this.txb_DriveInfo = new System.Windows.Forms.TextBox();
            this.lbl_Disks = new System.Windows.Forms.Label();
            this.cbx_DiskInfo = new System.Windows.Forms.ComboBox();
            this.btn_RefreshDiskInfo = new System.Windows.Forms.Button();
            this.gb_Words = new System.Windows.Forms.GroupBox();
            this.btn_AddWordsFromFile = new System.Windows.Forms.Button();
            this.btn_UserAddWord = new System.Windows.Forms.Button();
            this.txb_WordForAudit = new System.Windows.Forms.TextBox();
            this.lbx_WordPatterns = new System.Windows.Forms.ListBox();
            this.cms_WordPattern = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTLSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTLSMI_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_TlMI_ExportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_TlMI_ImportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFileExt = new System.Windows.Forms.GroupBox();
            this.btn_AddListFileTypeScan = new System.Windows.Forms.Button();
            this.lbx_FileType = new System.Windows.Forms.ListBox();
            this.lblIsRegiteredFileEx = new System.Windows.Forms.Label();
            this.txbUserChoseFileType = new System.Windows.Forms.TextBox();
            this.chbAllFileType = new System.Windows.Forms.CheckBox();
            this.cbxListFileExt = new System.Windows.Forms.ComboBox();
            this.lbx_AuditMonitor = new System.Windows.Forms.ListBox();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_FileAudit = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_TestHook = new System.Windows.Forms.GroupBox();
            this.btn_PrinterHook = new System.Windows.Forms.Button();
            this.btn_ProgHook = new System.Windows.Forms.Button();
            this.btn_ClipboardHook = new System.Windows.Forms.Button();
            this.btn_KeyboardHook = new System.Windows.Forms.Button();
            this.btn_MouseHookTest = new System.Windows.Forms.Button();
            this.cms_FileType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTLSMI_FTyp_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTLSMI_FTyp_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_lbx_WordPatrs = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_FoldScan = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_lbxFileType = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btn_TlSM_MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SM_StartScan = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_TSM_Hot = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_TSM_HotFileAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_TSM_HotDirAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_TSM_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLP_Audit = new System.Windows.Forms.FlowLayoutPanel();
            this.timerRunModul = new System.Windows.Forms.Timer(this.components);
            this.btn_CameraSpy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gb_OtherOptions.SuspendLayout();
            this.gb_IgnoreDirs.SuspendLayout();
            this.gbIgnore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IgnoreFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IgnoreTo)).BeginInit();
            this.gb_FileSys.SuspendLayout();
            this.cms_FolderToScan.SuspendLayout();
            this.gb_AllInfoDisk.SuspendLayout();
            this.gb_Words.SuspendLayout();
            this.cms_WordPattern.SuspendLayout();
            this.gbFileExt.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_FileAudit.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gb_TestHook.SuspendLayout();
            this.cms_FileType.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.flowLP_Audit.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(3, 3);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gb_OtherOptions);
            this.scMain.Panel1.Controls.Add(this.gb_FileSys);
            this.scMain.Panel1.Controls.Add(this.gb_Words);
            this.scMain.Panel1.Controls.Add(this.gbFileExt);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.lbx_AuditMonitor);
            this.scMain.Size = new System.Drawing.Size(771, 411);
            this.scMain.SplitterDistance = 294;
            this.scMain.TabIndex = 0;
            // 
            // gb_OtherOptions
            // 
            this.gb_OtherOptions.Controls.Add(this.gb_IgnoreDirs);
            this.gb_OtherOptions.Controls.Add(this.gbIgnore);
            this.gb_OtherOptions.Controls.Add(this.chb_SaveAllProperty);
            this.gb_OtherOptions.Location = new System.Drawing.Point(533, 12);
            this.gb_OtherOptions.Name = "gb_OtherOptions";
            this.gb_OtherOptions.Size = new System.Drawing.Size(188, 253);
            this.gb_OtherOptions.TabIndex = 4;
            this.gb_OtherOptions.TabStop = false;
            this.gb_OtherOptions.Text = "Додатково";
            // 
            // gb_IgnoreDirs
            // 
            this.gb_IgnoreDirs.Controls.Add(this.lbx_IgnoreDir);
            this.gb_IgnoreDirs.Controls.Add(this.btn_AddDirIgnore);
            this.gb_IgnoreDirs.Location = new System.Drawing.Point(7, 141);
            this.gb_IgnoreDirs.Name = "gb_IgnoreDirs";
            this.gb_IgnoreDirs.Size = new System.Drawing.Size(170, 104);
            this.gb_IgnoreDirs.TabIndex = 6;
            this.gb_IgnoreDirs.TabStop = false;
            this.gb_IgnoreDirs.Text = "Ігорування директорій";
            // 
            // lbx_IgnoreDir
            // 
            this.lbx_IgnoreDir.FormattingEnabled = true;
            this.lbx_IgnoreDir.Location = new System.Drawing.Point(6, 44);
            this.lbx_IgnoreDir.Name = "lbx_IgnoreDir";
            this.lbx_IgnoreDir.Size = new System.Drawing.Size(158, 56);
            this.lbx_IgnoreDir.TabIndex = 1;
            // 
            // btn_AddDirIgnore
            // 
            this.btn_AddDirIgnore.Location = new System.Drawing.Point(7, 14);
            this.btn_AddDirIgnore.Name = "btn_AddDirIgnore";
            this.btn_AddDirIgnore.Size = new System.Drawing.Size(157, 23);
            this.btn_AddDirIgnore.TabIndex = 0;
            this.btn_AddDirIgnore.Text = "До списку";
            this.btn_AddDirIgnore.UseVisualStyleBackColor = true;
            this.btn_AddDirIgnore.Click += new System.EventHandler(this.btn_AddDirIgnore_Click);
            // 
            // gbIgnore
            // 
            this.gbIgnore.Controls.Add(this.label2);
            this.gbIgnore.Controls.Add(this.label1);
            this.gbIgnore.Controls.Add(this.dud_FileSeziBaseTo);
            this.gbIgnore.Controls.Add(this.nud_IgnoreFrom);
            this.gbIgnore.Controls.Add(this.dud_FileSeziBaseFrom);
            this.gbIgnore.Controls.Add(this.nud_IgnoreTo);
            this.gbIgnore.Location = new System.Drawing.Point(7, 44);
            this.gbIgnore.Name = "gbIgnore";
            this.gbIgnore.Size = new System.Drawing.Size(170, 90);
            this.gbIgnore.TabIndex = 5;
            this.gbIgnore.TabStop = false;
            this.gbIgnore.Text = "Ігнорування файлів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(82, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "До";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Від";
            // 
            // dud_FileSeziBaseTo
            // 
            this.dud_FileSeziBaseTo.Location = new System.Drawing.Point(85, 59);
            this.dud_FileSeziBaseTo.Name = "dud_FileSeziBaseTo";
            this.dud_FileSeziBaseTo.Size = new System.Drawing.Size(70, 20);
            this.dud_FileSeziBaseTo.TabIndex = 2;
            this.dud_FileSeziBaseTo.SelectedItemChanged += new System.EventHandler(this.dud_FileSeziBaseTo_SelectedItemChanged);
            // 
            // nud_IgnoreFrom
            // 
            this.nud_IgnoreFrom.Location = new System.Drawing.Point(6, 37);
            this.nud_IgnoreFrom.Name = "nud_IgnoreFrom";
            this.nud_IgnoreFrom.Size = new System.Drawing.Size(70, 20);
            this.nud_IgnoreFrom.TabIndex = 1;
            this.nud_IgnoreFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_IgnoreFrom.ValueChanged += new System.EventHandler(this.nud_IgnoreFrom_ValueChanged);
            // 
            // dud_FileSeziBaseFrom
            // 
            this.dud_FileSeziBaseFrom.Location = new System.Drawing.Point(6, 59);
            this.dud_FileSeziBaseFrom.Name = "dud_FileSeziBaseFrom";
            this.dud_FileSeziBaseFrom.Size = new System.Drawing.Size(70, 20);
            this.dud_FileSeziBaseFrom.TabIndex = 2;
            this.dud_FileSeziBaseFrom.SelectedItemChanged += new System.EventHandler(this.dud_FileSeziBaseFrom_SelectedItemChanged);
            // 
            // nud_IgnoreTo
            // 
            this.nud_IgnoreTo.Location = new System.Drawing.Point(85, 37);
            this.nud_IgnoreTo.Name = "nud_IgnoreTo";
            this.nud_IgnoreTo.Size = new System.Drawing.Size(70, 20);
            this.nud_IgnoreTo.TabIndex = 1;
            this.nud_IgnoreTo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_IgnoreTo.ValueChanged += new System.EventHandler(this.nud_IgnoreTo_ValueChanged);
            // 
            // chb_SaveAllProperty
            // 
            this.chb_SaveAllProperty.AutoSize = true;
            this.chb_SaveAllProperty.Location = new System.Drawing.Point(6, 19);
            this.chb_SaveAllProperty.Name = "chb_SaveAllProperty";
            this.chb_SaveAllProperty.Size = new System.Drawing.Size(148, 17);
            this.chb_SaveAllProperty.TabIndex = 0;
            this.chb_SaveAllProperty.Text = "Зберегти налаштування";
            this.chb_SaveAllProperty.UseVisualStyleBackColor = true;
            // 
            // gb_FileSys
            // 
            this.gb_FileSys.Controls.Add(this.lbx_FolderToScan);
            this.gb_FileSys.Controls.Add(this.btn_AddFoldersSearch);
            this.gb_FileSys.Controls.Add(this.gb_AllInfoDisk);
            this.gb_FileSys.Controls.Add(this.lbl_Disks);
            this.gb_FileSys.Controls.Add(this.cbx_DiskInfo);
            this.gb_FileSys.Controls.Add(this.btn_RefreshDiskInfo);
            this.gb_FileSys.Location = new System.Drawing.Point(151, 12);
            this.gb_FileSys.Name = "gb_FileSys";
            this.gb_FileSys.Size = new System.Drawing.Size(245, 253);
            this.gb_FileSys.TabIndex = 3;
            this.gb_FileSys.TabStop = false;
            this.gb_FileSys.Text = "Місця пошуку";
            // 
            // lbx_FolderToScan
            // 
            this.lbx_FolderToScan.ContextMenuStrip = this.cms_FolderToScan;
            this.lbx_FolderToScan.FormattingEnabled = true;
            this.lbx_FolderToScan.Location = new System.Drawing.Point(9, 187);
            this.lbx_FolderToScan.Name = "lbx_FolderToScan";
            this.lbx_FolderToScan.Size = new System.Drawing.Size(226, 56);
            this.lbx_FolderToScan.TabIndex = 10;
            this.toolTip_FoldScan.SetToolTip(this.lbx_FolderToScan, "Здійснення сканування по окремим директоріям.");
            // 
            // cms_FolderToScan
            // 
            this.cms_FolderToScan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTLSMI_FTS_Delete,
            this.btnTLSMI_FTS_DeleteAll});
            this.cms_FolderToScan.Name = "cms_WordPattern";
            this.cms_FolderToScan.Size = new System.Drawing.Size(148, 48);
            // 
            // btnTLSMI_FTS_Delete
            // 
            this.btnTLSMI_FTS_Delete.Name = "btnTLSMI_FTS_Delete";
            this.btnTLSMI_FTS_Delete.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_FTS_Delete.Text = "Bидалити";
            this.btnTLSMI_FTS_Delete.Click += new System.EventHandler(this.btnTLSMI_FTS_Delete_Click);
            // 
            // btnTLSMI_FTS_DeleteAll
            // 
            this.btnTLSMI_FTS_DeleteAll.Name = "btnTLSMI_FTS_DeleteAll";
            this.btnTLSMI_FTS_DeleteAll.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_FTS_DeleteAll.Text = "Видалити все";
            this.btnTLSMI_FTS_DeleteAll.Click += new System.EventHandler(this.btnTLSMI_FTS_DeleteAll_Click);
            // 
            // btn_AddFoldersSearch
            // 
            this.btn_AddFoldersSearch.Location = new System.Drawing.Point(9, 155);
            this.btn_AddFoldersSearch.Name = "btn_AddFoldersSearch";
            this.btn_AddFoldersSearch.Size = new System.Drawing.Size(226, 23);
            this.btn_AddFoldersSearch.TabIndex = 9;
            this.btn_AddFoldersSearch.Text = "Окремо директорія(ї)";
            this.btn_AddFoldersSearch.UseVisualStyleBackColor = true;
            this.btn_AddFoldersSearch.Click += new System.EventHandler(this.btn_AddFoldersSearch_Click);
            // 
            // gb_AllInfoDisk
            // 
            this.gb_AllInfoDisk.Controls.Add(this.txb_DriveInfo);
            this.gb_AllInfoDisk.Location = new System.Drawing.Point(9, 44);
            this.gb_AllInfoDisk.Name = "gb_AllInfoDisk";
            this.gb_AllInfoDisk.Size = new System.Drawing.Size(226, 105);
            this.gb_AllInfoDisk.TabIndex = 8;
            this.gb_AllInfoDisk.TabStop = false;
            this.gb_AllInfoDisk.Text = "Загальна інформація";
            // 
            // txb_DriveInfo
            // 
            this.txb_DriveInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txb_DriveInfo.Location = new System.Drawing.Point(7, 20);
            this.txb_DriveInfo.Multiline = true;
            this.txb_DriveInfo.Name = "txb_DriveInfo";
            this.txb_DriveInfo.ReadOnly = true;
            this.txb_DriveInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txb_DriveInfo.Size = new System.Drawing.Size(213, 79);
            this.txb_DriveInfo.TabIndex = 0;
            // 
            // lbl_Disks
            // 
            this.lbl_Disks.AutoSize = true;
            this.lbl_Disks.Location = new System.Drawing.Point(6, 20);
            this.lbl_Disks.Name = "lbl_Disks";
            this.lbl_Disks.Size = new System.Drawing.Size(34, 13);
            this.lbl_Disks.TabIndex = 7;
            this.lbl_Disks.Text = "Диск";
            // 
            // cbx_DiskInfo
            // 
            this.cbx_DiskInfo.FormattingEnabled = true;
            this.cbx_DiskInfo.Location = new System.Drawing.Point(46, 17);
            this.cbx_DiskInfo.Name = "cbx_DiskInfo";
            this.cbx_DiskInfo.Size = new System.Drawing.Size(121, 21);
            this.cbx_DiskInfo.TabIndex = 4;
            this.cbx_DiskInfo.SelectedIndexChanged += new System.EventHandler(this.cbx_DiskInfo_SelectedIndexChanged);
            // 
            // btn_RefreshDiskInfo
            // 
            this.btn_RefreshDiskInfo.Location = new System.Drawing.Point(173, 15);
            this.btn_RefreshDiskInfo.Name = "btn_RefreshDiskInfo";
            this.btn_RefreshDiskInfo.Size = new System.Drawing.Size(62, 23);
            this.btn_RefreshDiskInfo.TabIndex = 5;
            this.btn_RefreshDiskInfo.Text = "Оновити";
            this.btn_RefreshDiskInfo.UseVisualStyleBackColor = true;
            this.btn_RefreshDiskInfo.Click += new System.EventHandler(this.btn_RefreshDiskInfo_Click);
            // 
            // gb_Words
            // 
            this.gb_Words.Controls.Add(this.btn_AddWordsFromFile);
            this.gb_Words.Controls.Add(this.btn_UserAddWord);
            this.gb_Words.Controls.Add(this.txb_WordForAudit);
            this.gb_Words.Controls.Add(this.lbx_WordPatterns);
            this.gb_Words.Location = new System.Drawing.Point(13, 12);
            this.gb_Words.Name = "gb_Words";
            this.gb_Words.Size = new System.Drawing.Size(132, 253);
            this.gb_Words.TabIndex = 2;
            this.gb_Words.TabStop = false;
            this.gb_Words.Text = "Патерн пошуку ";
            // 
            // btn_AddWordsFromFile
            // 
            this.btn_AddWordsFromFile.Location = new System.Drawing.Point(5, 222);
            this.btn_AddWordsFromFile.Name = "btn_AddWordsFromFile";
            this.btn_AddWordsFromFile.Size = new System.Drawing.Size(120, 23);
            this.btn_AddWordsFromFile.TabIndex = 3;
            this.btn_AddWordsFromFile.Text = "Додати з файлу";
            this.btn_AddWordsFromFile.UseVisualStyleBackColor = true;
            this.btn_AddWordsFromFile.Click += new System.EventHandler(this.btn_AddWordsFromFile_Click);
            // 
            // btn_UserAddWord
            // 
            this.btn_UserAddWord.Location = new System.Drawing.Point(6, 46);
            this.btn_UserAddWord.Name = "btn_UserAddWord";
            this.btn_UserAddWord.Size = new System.Drawing.Size(119, 23);
            this.btn_UserAddWord.TabIndex = 2;
            this.btn_UserAddWord.Text = "До списку";
            this.btn_UserAddWord.UseVisualStyleBackColor = true;
            this.btn_UserAddWord.Click += new System.EventHandler(this.btn_UserAddWord_Click);
            // 
            // txb_WordForAudit
            // 
            this.txb_WordForAudit.Location = new System.Drawing.Point(6, 19);
            this.txb_WordForAudit.Name = "txb_WordForAudit";
            this.txb_WordForAudit.Size = new System.Drawing.Size(119, 20);
            this.txb_WordForAudit.TabIndex = 1;
            this.txb_WordForAudit.TextChanged += new System.EventHandler(this.txb_WordForAudit_TextChanged);
            // 
            // lbx_WordPatterns
            // 
            this.lbx_WordPatterns.AllowDrop = true;
            this.lbx_WordPatterns.ContextMenuStrip = this.cms_WordPattern;
            this.lbx_WordPatterns.FormattingEnabled = true;
            this.lbx_WordPatterns.Location = new System.Drawing.Point(5, 75);
            this.lbx_WordPatterns.Name = "lbx_WordPatterns";
            this.lbx_WordPatterns.Size = new System.Drawing.Size(120, 134);
            this.lbx_WordPatterns.TabIndex = 0;
            this.toolTip_lbx_WordPatrs.SetToolTip(this.lbx_WordPatterns, "Список слів які потрібно знайти в файлі.\r\nПеретягніть текстовий файл сюди або дод" +
        "айте через інтерфейс.");
            this.lbx_WordPatterns.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbx_WordPatterns_DragDrop);
            this.lbx_WordPatterns.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbx_WordPatterns_DragEnter);
            // 
            // cms_WordPattern
            // 
            this.cms_WordPattern.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTLSMI_Delete,
            this.btnTLSMI_DeleteAll,
            this.toolStripSeparator1,
            this.btn_TlMI_ExportFile,
            this.btn_TlMI_ImportFile});
            this.cms_WordPattern.Name = "cms_WordPattern";
            this.cms_WordPattern.Size = new System.Drawing.Size(148, 98);
            // 
            // btnTLSMI_Delete
            // 
            this.btnTLSMI_Delete.Name = "btnTLSMI_Delete";
            this.btnTLSMI_Delete.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_Delete.Text = "Bидалити";
            this.btnTLSMI_Delete.Click += new System.EventHandler(this.btnTLSMI_Delete_Click);
            // 
            // btnTLSMI_DeleteAll
            // 
            this.btnTLSMI_DeleteAll.Name = "btnTLSMI_DeleteAll";
            this.btnTLSMI_DeleteAll.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_DeleteAll.Text = "Видалити все";
            this.btnTLSMI_DeleteAll.Click += new System.EventHandler(this.btnTLSMI_DeleteAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // btn_TlMI_ExportFile
            // 
            this.btn_TlMI_ExportFile.Name = "btn_TlMI_ExportFile";
            this.btn_TlMI_ExportFile.Size = new System.Drawing.Size(147, 22);
            this.btn_TlMI_ExportFile.Text = "Експорт";
            this.btn_TlMI_ExportFile.Click += new System.EventHandler(this.btn_TlMI_ExportFile_Click);
            // 
            // btn_TlMI_ImportFile
            // 
            this.btn_TlMI_ImportFile.Name = "btn_TlMI_ImportFile";
            this.btn_TlMI_ImportFile.Size = new System.Drawing.Size(147, 22);
            this.btn_TlMI_ImportFile.Text = "Імпорт";
            this.btn_TlMI_ImportFile.Click += new System.EventHandler(this.btn_TlMI_ImportFile_Click);
            // 
            // gbFileExt
            // 
            this.gbFileExt.Controls.Add(this.btn_AddListFileTypeScan);
            this.gbFileExt.Controls.Add(this.lbx_FileType);
            this.gbFileExt.Controls.Add(this.lblIsRegiteredFileEx);
            this.gbFileExt.Controls.Add(this.txbUserChoseFileType);
            this.gbFileExt.Controls.Add(this.chbAllFileType);
            this.gbFileExt.Controls.Add(this.cbxListFileExt);
            this.gbFileExt.Location = new System.Drawing.Point(402, 12);
            this.gbFileExt.Name = "gbFileExt";
            this.gbFileExt.Size = new System.Drawing.Size(124, 253);
            this.gbFileExt.TabIndex = 1;
            this.gbFileExt.TabStop = false;
            this.gbFileExt.Text = "Враховувати";
            // 
            // btn_AddListFileTypeScan
            // 
            this.btn_AddListFileTypeScan.Location = new System.Drawing.Point(6, 108);
            this.btn_AddListFileTypeScan.Name = "btn_AddListFileTypeScan";
            this.btn_AddListFileTypeScan.Size = new System.Drawing.Size(107, 23);
            this.btn_AddListFileTypeScan.TabIndex = 3;
            this.btn_AddListFileTypeScan.Text = "До списку";
            this.btn_AddListFileTypeScan.UseVisualStyleBackColor = true;
            this.btn_AddListFileTypeScan.Click += new System.EventHandler(this.btn_AddListFileTypeScan_Click);
            // 
            // lbx_FileType
            // 
            this.lbx_FileType.FormattingEnabled = true;
            this.lbx_FileType.Location = new System.Drawing.Point(8, 137);
            this.lbx_FileType.Name = "lbx_FileType";
            this.lbx_FileType.Size = new System.Drawing.Size(105, 108);
            this.lbx_FileType.TabIndex = 4;
            this.toolTip_lbxFileType.SetToolTip(this.lbx_FileType, "Здійснення сканування файлів з розширенням\r\nякі вказані в списку.");
            // 
            // lblIsRegiteredFileEx
            // 
            this.lblIsRegiteredFileEx.AutoSize = true;
            this.lblIsRegiteredFileEx.Location = new System.Drawing.Point(6, 66);
            this.lblIsRegiteredFileEx.Name = "lblIsRegiteredFileEx";
            this.lblIsRegiteredFileEx.Size = new System.Drawing.Size(52, 13);
            this.lblIsRegiteredFileEx.TabIndex = 3;
            this.lblIsRegiteredFileEx.Text = "Вказати:";
            // 
            // txbUserChoseFileType
            // 
            this.txbUserChoseFileType.AutoCompleteCustomSource.AddRange(new string[] {
            ".txt"});
            this.txbUserChoseFileType.Location = new System.Drawing.Point(6, 82);
            this.txbUserChoseFileType.Name = "txbUserChoseFileType";
            this.txbUserChoseFileType.Size = new System.Drawing.Size(107, 20);
            this.txbUserChoseFileType.TabIndex = 2;
            this.txbUserChoseFileType.TextChanged += new System.EventHandler(this.txbUserChoseFileType_TextChanged);
            // 
            // chbAllFileType
            // 
            this.chbAllFileType.AutoSize = true;
            this.chbAllFileType.Location = new System.Drawing.Point(9, 19);
            this.chbAllFileType.Name = "chbAllFileType";
            this.chbAllFileType.Size = new System.Drawing.Size(104, 17);
            this.chbAllFileType.TabIndex = 1;
            this.chbAllFileType.Text = "Всі типи файлів";
            this.chbAllFileType.UseVisualStyleBackColor = true;
            this.chbAllFileType.CheckedChanged += new System.EventHandler(this.chbAllFileType_CheckedChanged);
            // 
            // cbxListFileExt
            // 
            this.cbxListFileExt.FormattingEnabled = true;
            this.cbxListFileExt.Location = new System.Drawing.Point(6, 42);
            this.cbxListFileExt.Name = "cbxListFileExt";
            this.cbxListFileExt.Size = new System.Drawing.Size(107, 21);
            this.cbxListFileExt.TabIndex = 0;
            this.cbxListFileExt.SelectedIndexChanged += new System.EventHandler(this.cbxListFileExt_SelectedIndexChanged);
            // 
            // lbx_AuditMonitor
            // 
            this.lbx_AuditMonitor.FormattingEnabled = true;
            this.lbx_AuditMonitor.Location = new System.Drawing.Point(3, 3);
            this.lbx_AuditMonitor.Name = "lbx_AuditMonitor";
            this.lbx_AuditMonitor.Size = new System.Drawing.Size(756, 95);
            this.lbx_AuditMonitor.TabIndex = 0;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_FileAudit);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Location = new System.Drawing.Point(3, 3);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(785, 443);
            this.tabControl_Main.TabIndex = 1;
            // 
            // tabPage_FileAudit
            // 
            this.tabPage_FileAudit.BackColor = System.Drawing.Color.Ivory;
            this.tabPage_FileAudit.Controls.Add(this.scMain);
            this.tabPage_FileAudit.Location = new System.Drawing.Point(4, 22);
            this.tabPage_FileAudit.Name = "tabPage_FileAudit";
            this.tabPage_FileAudit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FileAudit.Size = new System.Drawing.Size(777, 417);
            this.tabPage_FileAudit.TabIndex = 0;
            this.tabPage_FileAudit.Text = "Аудит файлів";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.gb_TestHook);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(777, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Хукі";
            // 
            // gb_TestHook
            // 
            this.gb_TestHook.Controls.Add(this.btn_CameraSpy);
            this.gb_TestHook.Controls.Add(this.btn_PrinterHook);
            this.gb_TestHook.Controls.Add(this.btn_ProgHook);
            this.gb_TestHook.Controls.Add(this.btn_ClipboardHook);
            this.gb_TestHook.Controls.Add(this.btn_KeyboardHook);
            this.gb_TestHook.Controls.Add(this.btn_MouseHookTest);
            this.gb_TestHook.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gb_TestHook.Location = new System.Drawing.Point(7, 7);
            this.gb_TestHook.Name = "gb_TestHook";
            this.gb_TestHook.Size = new System.Drawing.Size(95, 213);
            this.gb_TestHook.TabIndex = 0;
            this.gb_TestHook.TabStop = false;
            this.gb_TestHook.Text = "Тест";
            // 
            // btn_PrinterHook
            // 
            this.btn_PrinterHook.BackColor = System.Drawing.Color.Black;
            this.btn_PrinterHook.Location = new System.Drawing.Point(7, 150);
            this.btn_PrinterHook.Name = "btn_PrinterHook";
            this.btn_PrinterHook.Size = new System.Drawing.Size(75, 23);
            this.btn_PrinterHook.TabIndex = 4;
            this.btn_PrinterHook.Text = "Прінтер";
            this.btn_PrinterHook.UseVisualStyleBackColor = false;
            this.btn_PrinterHook.Click += new System.EventHandler(this.btn_PrinterHook_Click);
            // 
            // btn_ProgHook
            // 
            this.btn_ProgHook.BackColor = System.Drawing.Color.Black;
            this.btn_ProgHook.Location = new System.Drawing.Point(7, 121);
            this.btn_ProgHook.Name = "btn_ProgHook";
            this.btn_ProgHook.Size = new System.Drawing.Size(75, 23);
            this.btn_ProgHook.TabIndex = 3;
            this.btn_ProgHook.Text = "Програма";
            this.btn_ProgHook.UseVisualStyleBackColor = false;
            this.btn_ProgHook.Click += new System.EventHandler(this.btn_ProgHook_Click);
            // 
            // btn_ClipboardHook
            // 
            this.btn_ClipboardHook.BackColor = System.Drawing.Color.Black;
            this.btn_ClipboardHook.Location = new System.Drawing.Point(7, 79);
            this.btn_ClipboardHook.Name = "btn_ClipboardHook";
            this.btn_ClipboardHook.Size = new System.Drawing.Size(75, 35);
            this.btn_ClipboardHook.TabIndex = 2;
            this.btn_ClipboardHook.Text = "Буфер обміну";
            this.btn_ClipboardHook.UseVisualStyleBackColor = false;
            this.btn_ClipboardHook.Click += new System.EventHandler(this.btn_ClipboardHook_Click);
            // 
            // btn_KeyboardHook
            // 
            this.btn_KeyboardHook.BackColor = System.Drawing.Color.Black;
            this.btn_KeyboardHook.Location = new System.Drawing.Point(7, 50);
            this.btn_KeyboardHook.Name = "btn_KeyboardHook";
            this.btn_KeyboardHook.Size = new System.Drawing.Size(75, 23);
            this.btn_KeyboardHook.TabIndex = 1;
            this.btn_KeyboardHook.Text = "Клавіатура";
            this.btn_KeyboardHook.UseVisualStyleBackColor = false;
            this.btn_KeyboardHook.Click += new System.EventHandler(this.btn_KeyboardHook_Click);
            // 
            // btn_MouseHookTest
            // 
            this.btn_MouseHookTest.BackColor = System.Drawing.Color.Black;
            this.btn_MouseHookTest.Location = new System.Drawing.Point(7, 20);
            this.btn_MouseHookTest.Name = "btn_MouseHookTest";
            this.btn_MouseHookTest.Size = new System.Drawing.Size(75, 23);
            this.btn_MouseHookTest.TabIndex = 0;
            this.btn_MouseHookTest.Text = "Мишка";
            this.btn_MouseHookTest.UseVisualStyleBackColor = false;
            this.btn_MouseHookTest.Click += new System.EventHandler(this.btn_MouseHookTest_Click);
            // 
            // cms_FileType
            // 
            this.cms_FileType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTLSMI_FTyp_Delete,
            this.btnTLSMI_FTyp_DeleteAll});
            this.cms_FileType.Name = "cms_WordPattern";
            this.cms_FileType.Size = new System.Drawing.Size(148, 48);
            // 
            // btnTLSMI_FTyp_Delete
            // 
            this.btnTLSMI_FTyp_Delete.Name = "btnTLSMI_FTyp_Delete";
            this.btnTLSMI_FTyp_Delete.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_FTyp_Delete.Text = "Bидалити";
            this.btnTLSMI_FTyp_Delete.Click += new System.EventHandler(this.btnTLSMI_FTyp_Delete_Click);
            // 
            // btnTLSMI_FTyp_DeleteAll
            // 
            this.btnTLSMI_FTyp_DeleteAll.Name = "btnTLSMI_FTyp_DeleteAll";
            this.btnTLSMI_FTyp_DeleteAll.Size = new System.Drawing.Size(147, 22);
            this.btnTLSMI_FTyp_DeleteAll.Text = "Видалити все";
            this.btnTLSMI_FTyp_DeleteAll.Click += new System.EventHandler(this.btnTLSMI_FTyp_DeleteAll_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_TlSM_MainMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(793, 24);
            this.menuStrip.TabIndex = 3;
            // 
            // btn_TlSM_MainMenu
            // 
            this.btn_TlSM_MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_SM_StartScan,
            this.btn_TSM_Hot,
            this.toolStripSeparator2,
            this.btn_TSM_Exit});
            this.btn_TlSM_MainMenu.Name = "btn_TlSM_MainMenu";
            this.btn_TlSM_MainMenu.Size = new System.Drawing.Size(53, 20);
            this.btn_TlSM_MainMenu.Text = "Меню";
            // 
            // btn_SM_StartScan
            // 
            this.btn_SM_StartScan.Name = "btn_SM_StartScan";
            this.btn_SM_StartScan.Size = new System.Drawing.Size(133, 22);
            this.btn_SM_StartScan.Text = "Старт";
            this.btn_SM_StartScan.Click += new System.EventHandler(this.btn_SM_StartScan_Click);
            // 
            // btn_TSM_Hot
            // 
            this.btn_TSM_Hot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_TSM_HotFileAudit,
            this.btn_TSM_HotDirAudit});
            this.btn_TSM_Hot.Name = "btn_TSM_Hot";
            this.btn_TSM_Hot.Size = new System.Drawing.Size(133, 22);
            this.btn_TSM_Hot.Text = "Терміново";
            // 
            // btn_TSM_HotFileAudit
            // 
            this.btn_TSM_HotFileAudit.Name = "btn_TSM_HotFileAudit";
            this.btn_TSM_HotFileAudit.Size = new System.Drawing.Size(166, 22);
            this.btn_TSM_HotFileAudit.Text = "Аудит файлу";
            this.btn_TSM_HotFileAudit.Click += new System.EventHandler(this.btn_TSM_HotFileAudit_Click);
            // 
            // btn_TSM_HotDirAudit
            // 
            this.btn_TSM_HotDirAudit.Name = "btn_TSM_HotDirAudit";
            this.btn_TSM_HotDirAudit.Size = new System.Drawing.Size(166, 22);
            this.btn_TSM_HotDirAudit.Text = "Аудит директорії";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(130, 6);
            // 
            // btn_TSM_Exit
            // 
            this.btn_TSM_Exit.Name = "btn_TSM_Exit";
            this.btn_TSM_Exit.Size = new System.Drawing.Size(133, 22);
            this.btn_TSM_Exit.Text = "Вихід";
            // 
            // flowLP_Audit
            // 
            this.flowLP_Audit.Controls.Add(this.tabControl_Main);
            this.flowLP_Audit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLP_Audit.Location = new System.Drawing.Point(0, 24);
            this.flowLP_Audit.Name = "flowLP_Audit";
            this.flowLP_Audit.Size = new System.Drawing.Size(793, 451);
            this.flowLP_Audit.TabIndex = 4;
            // 
            // timerRunModul
            // 
            this.timerRunModul.Tick += new System.EventHandler(this.timerRunModul_Tick);
            // 
            // btn_CameraSpy
            // 
            this.btn_CameraSpy.BackColor = System.Drawing.Color.Black;
            this.btn_CameraSpy.Location = new System.Drawing.Point(6, 179);
            this.btn_CameraSpy.Name = "btn_CameraSpy";
            this.btn_CameraSpy.Size = new System.Drawing.Size(75, 23);
            this.btn_CameraSpy.TabIndex = 4;
            this.btn_CameraSpy.Text = "Камера";
            this.btn_CameraSpy.UseVisualStyleBackColor = false;
            this.btn_CameraSpy.Click += new System.EventHandler(this.btn_CameraSpy_Click);
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(793, 475);
            this.Controls.Add(this.flowLP_Audit);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test file search&hooks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainF_FormClosing);
            this.Load += new System.EventHandler(this.MainF_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gb_OtherOptions.ResumeLayout(false);
            this.gb_OtherOptions.PerformLayout();
            this.gb_IgnoreDirs.ResumeLayout(false);
            this.gbIgnore.ResumeLayout(false);
            this.gbIgnore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IgnoreFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IgnoreTo)).EndInit();
            this.gb_FileSys.ResumeLayout(false);
            this.gb_FileSys.PerformLayout();
            this.cms_FolderToScan.ResumeLayout(false);
            this.gb_AllInfoDisk.ResumeLayout(false);
            this.gb_AllInfoDisk.PerformLayout();
            this.gb_Words.ResumeLayout(false);
            this.gb_Words.PerformLayout();
            this.cms_WordPattern.ResumeLayout(false);
            this.gbFileExt.ResumeLayout(false);
            this.gbFileExt.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_FileAudit.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gb_TestHook.ResumeLayout(false);
            this.cms_FileType.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.flowLP_Audit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbFileExt;
        private System.Windows.Forms.Label lblIsRegiteredFileEx;
        private System.Windows.Forms.TextBox txbUserChoseFileType;
        private System.Windows.Forms.CheckBox chbAllFileType;
        private System.Windows.Forms.ComboBox cbxListFileExt;
        private System.Windows.Forms.GroupBox gb_Words;
        private System.Windows.Forms.GroupBox gb_AllInfoDisk;
        private System.Windows.Forms.Label lbl_Disks;
        private System.Windows.Forms.Button btn_RefreshDiskInfo;
        private System.Windows.Forms.ComboBox cbx_DiskInfo;
        private System.Windows.Forms.Button btn_AddWordsFromFile;
        private System.Windows.Forms.Button btn_UserAddWord;
        private System.Windows.Forms.TextBox txb_WordForAudit;
        private System.Windows.Forms.ListBox lbx_WordPatterns;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_FileAudit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gb_FileSys;
        private System.Windows.Forms.TextBox txb_DriveInfo;
        private System.Windows.Forms.ListBox lbx_FolderToScan;
        private System.Windows.Forms.Button btn_AddFoldersSearch;
        private System.Windows.Forms.ListBox lbx_AuditMonitor;
        private System.Windows.Forms.ContextMenuStrip cms_WordPattern;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_Delete;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_DeleteAll;
        private System.Windows.Forms.ContextMenuStrip cms_FolderToScan;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_FTS_Delete;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_FTS_DeleteAll;
        private System.Windows.Forms.Button btn_AddListFileTypeScan;
        private System.Windows.Forms.ListBox lbx_FileType;
        private System.Windows.Forms.ContextMenuStrip cms_FileType;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_FTyp_Delete;
        private System.Windows.Forms.ToolStripMenuItem btnTLSMI_FTyp_DeleteAll;
        private System.Windows.Forms.ToolTip toolTip_FoldScan;
        private System.Windows.Forms.ToolTip toolTip_lbx_WordPatrs;
        private System.Windows.Forms.ToolTip toolTip_lbxFileType;
        private System.Windows.Forms.GroupBox gbIgnore;
        private System.Windows.Forms.DomainUpDown dud_FileSeziBaseTo;
        private System.Windows.Forms.NumericUpDown nud_IgnoreFrom;
        private System.Windows.Forms.DomainUpDown dud_FileSeziBaseFrom;
        private System.Windows.Forms.NumericUpDown nud_IgnoreTo;
        private System.Windows.Forms.GroupBox gb_OtherOptions;
        private System.Windows.Forms.CheckBox chb_SaveAllProperty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_IgnoreDirs;
        private System.Windows.Forms.ListBox lbx_IgnoreDir;
        private System.Windows.Forms.Button btn_AddDirIgnore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btn_TlMI_ExportFile;
        private System.Windows.Forms.ToolStripMenuItem btn_TlMI_ImportFile;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btn_TlSM_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem btn_TSM_Hot;
        private System.Windows.Forms.ToolStripMenuItem btn_TSM_HotFileAudit;
        private System.Windows.Forms.ToolStripMenuItem btn_TSM_HotDirAudit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btn_TSM_Exit;
        private System.Windows.Forms.FlowLayoutPanel flowLP_Audit;
        private System.Windows.Forms.ToolStripMenuItem btn_SM_StartScan;
        private System.Windows.Forms.Timer timerRunModul;
        private System.Windows.Forms.GroupBox gb_TestHook;
        private System.Windows.Forms.Button btn_MouseHookTest;
        private System.Windows.Forms.Button btn_ProgHook;
        private System.Windows.Forms.Button btn_ClipboardHook;
        private System.Windows.Forms.Button btn_KeyboardHook;
        private System.Windows.Forms.Button btn_PrinterHook;
        private System.Windows.Forms.Button btn_CameraSpy;
    }
}

