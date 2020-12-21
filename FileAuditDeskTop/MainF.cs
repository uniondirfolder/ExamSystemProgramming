using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Esp;
using Esp.UI;
using Convert = Esp.Convert;


namespace FileAuditDeskTop
{
    public partial class MainF : Form
    {
        #region MEMBERS

        private ModuleBox _mBox;
        
        #endregion
        public MainF()
        {
            _mBox = new ModuleBox() { MainFListener = UpdateFace, CodeId = CodeId.BindWithMainF };
            
            InitializeComponent();
            timerRunModul.Start();
        }

        private Thread _task;
        private void timerRunModul_Tick(object sender, EventArgs e)
        {
            if (_task != null)
            {
                if (_task.IsAlive)
                {
                    _mBox.ModListener(new ModuleBox() { CodeId = CodeId.DisposeModule });
                    Thread.Sleep(2000);
                    _task.Abort();
                }
            }
            _task = new Thread(new Module(_mBox).RunModule);
            _task.Start(new ModuleBox(_mBox));
            Thread.Sleep(100);
            
            timerRunModul.Stop();
            timerRunModul.Enabled = false;
        }
        private void MainF_Load(object sender, System.EventArgs e)
        {
            if (Module.FilesTypeInSystem != null)
            {
                cbxListFileExt.Items.AddRange(items: Module.FilesTypeInSystem.ToArray());
                cbxListFileExt.SelectedIndex = cbxListFileExt.Items.IndexOf(".txt");
            }
            lblIsRegiteredFileEx.Text = @"Вказати:";

            cbx_DiskInfo.Items.Add("../");
            cbx_DiskInfo.Items.AddRange(Module.GetDrivesName().ToArray());
            cbx_DiskInfo.SelectedIndex = 0;

            //dud_FileSeziBaseFrom.Items.Add(ByteTo.EB);
            //dud_FileSeziBaseTo.Items.Add(ByteTo.EB);
            //dud_FileSeziBaseFrom.Items.Add(ByteTo.GB);
            //dud_FileSeziBaseTo.Items.Add(ByteTo.GB);
            dud_FileSeziBaseFrom.Items.Add(ByteTo.MB);
            dud_FileSeziBaseTo.Items.Add(ByteTo.MB);
            dud_FileSeziBaseFrom.Items.Add(ByteTo.KB);
            dud_FileSeziBaseTo.Items.Add(ByteTo.KB);
            dud_FileSeziBaseFrom.Items.Add(ByteTo.BYTE);
            dud_FileSeziBaseTo.Items.Add(ByteTo.BYTE);
            dud_FileSeziBaseFrom.SelectedIndex=2;
            dud_FileSeziBaseTo.SelectedIndex=0;
            WriteChangeToOptionsOfFileSizes();


            lbx_IgnoreDir.Items.Add(Directory.GetCurrentDirectory());

            btn_UserAddWord.Enabled = false;

            cbxListFileExt.Items.AddRange(RegisteredFileType.GetFileType().ToArray());
            cbxListFileExt.SelectedIndex = cbxListFileExt.Items.IndexOf(".txt");
        }
        private void MainF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_task != null)
            {
                if (_task.IsAlive)
                {
                    _mBox.ModListener(new ModuleBox() {CodeId = CodeId.DisposeModule});
                    Thread.Sleep(500);
                    _task.Abort();
                }
            }
        }
        
        #region GUI EVENTS

        #region WORD_PATTERN
        private void btn_TlMI_ExportFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "|*.txt";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lbx_WordPatterns.Items.Clear();

                File.WriteAllText(sfd.FileName, Module.ItemToStringFromListBox(lbx_WordPatterns));

                WriteChangeToOptionsOfWordPattern();
            }
        }
        private void lbx_WordPatterns_DragDrop(object sender, DragEventArgs e)
        {
            lbx_WordPatterns.Items.Clear();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.HasExtension(file) && Path.GetExtension(file) == ".txt")
                {
                    var add = Module.GetWordsFromString(File.ReadAllText(file));
                    lbx_WordPatterns.Items.AddRange(add.ToArray());
                }
                else
                {
                    MessageBox.Show($"Не вірне розширення файлу!\r\n{file}\r\n Шаблон: <Назва файлу>.txt", @"Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            WriteChangeToOptionsOfWordPattern();
        }
        private void lbx_WordPatterns_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private void btnTLSMI_Delete_Click(object sender, EventArgs e)
        {
            if (lbx_WordPatterns.SelectedIndex > -1)
            {
                lbx_WordPatterns.Items.RemoveAt(lbx_WordPatterns.SelectedIndex);
                WriteChangeToOptionsOfWordPattern();
            }
        }
        private void btnTLSMI_DeleteAll_Click(object sender, EventArgs e)
        {
            lbx_WordPatterns.Items.Clear();
        }
        private void btn_TlMI_ImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "|*.txt";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.HasExtension(ofd.FileName) && Path.GetExtension(ofd.FileName) == ".txt")
                {
                    var add = Module.GetWordsFromString(File.ReadAllText(ofd.FileName));
                    lbx_WordPatterns.Items.AddRange(add.ToArray());
                    WriteChangeToOptionsOfWordPattern();
                }
                else
                {
                    MessageBox.Show($"Не вірне розширення файлу!\r\n{ofd.FileName}\r\n Шаблон: <Назва файлу>.txt", @"Увага!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btn_UserAddWord_Click(object sender, EventArgs e)
        {
            lbx_WordPatterns.Items.Add(txb_WordForAudit.Text);
            WriteChangeToOptionsOfWordPattern();
            txb_WordForAudit.Text = "";
        }

        private void txb_WordForAudit_TextChanged(object sender, EventArgs e)
        {
            if (txb_WordForAudit.Text.Length > 0)
            {
                btn_UserAddWord.Enabled = true;
            }
            else
            {
                btn_UserAddWord.Enabled = false;
            }
        }

        private void btn_AddWordsFromFile_Click(object sender, EventArgs e)
        {
            btn_TlMI_ImportFile_Click(sender, e);
        }
        #endregion

        #region PLACES_SEARCH
        private void btn_RefreshDiskInfo_Click(object sender, EventArgs e)
        {
            cbx_DiskInfo.Items.AddRange(items: Module.GetDrivesName().ToArray());
            WriteChangeToOptionsListCustomSelectDirs();
        }
        private void cbx_DiskInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txb_DriveInfo.Text = Module.GetStringDriveState(cbx_DiskInfo.SelectedItem.ToString());
            WriteChangeToOptionsListCustomSelectDirs();
        }
        private void btn_AddFoldersSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                if (!lbx_FolderToScan.Items.Contains(fbd.SelectedPath))
                {

                    cbx_DiskInfo.Enabled = false;
                    btn_RefreshDiskInfo.Enabled = false;

                    lbx_FolderToScan.Items.Add(fbd.SelectedPath);
                    WriteChangeToOptionsListCustomSelectDirs();
                }
                else
                {
                    MessageBox.Show(@"Вже існує в списку!", @"Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnTLSMI_FTS_Delete_Click(object sender, EventArgs e)
        {
            if (lbx_FolderToScan.SelectedIndex > -1)
            {
                lbx_FolderToScan.Items.RemoveAt(lbx_FolderToScan.SelectedIndex);
                WriteChangeToOptionsListCustomSelectDirs();
                if (lbx_FolderToScan.Items.Count==0) { cbx_DiskInfo.Enabled = true;
                    btn_RefreshDiskInfo.Enabled = true;
                }
            }
        }
        private void btnTLSMI_FTS_DeleteAll_Click(object sender, EventArgs e)
        {
            lbx_FolderToScan.Items.Clear();
            cbx_DiskInfo.Enabled = true;
            btn_RefreshDiskInfo.Enabled = true;
            cbx_DiskInfo_SelectedIndexChanged(null, e);
        }

        #endregion

        #region CONSIDER_TYPE

        private void txbUserChoseFileType_TextChanged(object sender, EventArgs e)
        {
            if (txbUserChoseFileType.Text.Length > 0)
            {
                if (cbxListFileExt.Items.Contains(txbUserChoseFileType.Text))
                {
                    lblIsRegiteredFileEx.Text = @"Відомий тип";
                }
                else
                {
                    lblIsRegiteredFileEx.Text = @"Довільний тип";
                }

                cbxListFileExt.Enabled = false;
                chbAllFileType.Checked = false;
                chbAllFileType.Enabled = false;
            }
            else
            {
                cbxListFileExt.Enabled = true;
                chbAllFileType.Enabled = true;
                lblIsRegiteredFileEx.Text = @"Вказати:";
            }

            WriteChangeToOptionsFileType();
        }
        private void cbxListFileExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxListFileExt.SelectedIndex > -1)
            {
                txbUserChoseFileType.Text = "";
            }

            WriteChangeToOptionsFileType();
        }
        private void btn_AddListFileTypeScan_Click(object sender, EventArgs e)
        {
            if (txbUserChoseFileType.Text.Length > 0 && !lbx_FileType.Items.Contains(txbUserChoseFileType.Text) && txbUserChoseFileType.Text[0] == '.')
            {
                lbx_FileType.Items.Add(txbUserChoseFileType.Text);
                txbUserChoseFileType.Text = "";
            }
            else
            {
                MessageBox.Show(@"Нема назви файлового типу або\r\nвже існує в списку!\r\n Шаблон: .<назва>", @"Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            WriteChangeToOptionsFileType();
        }
        private void btnTLSMI_FTyp_Delete_Click(object sender, EventArgs e)
        {
            if (lbx_FileType.SelectedIndex > -1)
            {
                lbx_FileType.Items.RemoveAt(lbx_FileType.SelectedIndex);
            }

            WriteChangeToOptionsFileType();
        }
        private void btnTLSMI_FTyp_DeleteAll_Click(object sender, EventArgs e)
        {
            lbx_FileType.Items.Clear();
            WriteChangeToOptionsFileType();
        }
        private void chbAllFileType_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllFileType.Checked)
            {
                _mBox.ApplicationOptions.FileExtensionForExecute.Clear();
                _mBox.ApplicationOptions.FileExtensionForExecute.AddRange(Module.ItemToListStringsFromComboBox(cbxListFileExt));
                cbxListFileExt.Enabled = false;
                txbUserChoseFileType.Enabled = false;
                btn_AddListFileTypeScan.Enabled = false;
                lbx_FileType.Enabled = false;
            }
            else
            {
                _mBox.ApplicationOptions.FileExtensionForExecute.Clear();
                cbxListFileExt.Enabled = true;
                txbUserChoseFileType.Enabled = true;
                btn_AddListFileTypeScan.Enabled = true;
                lbx_FileType.Enabled = true;
                if (lbx_FileType.Items.Count > 0) { _mBox.ApplicationOptions.FileExtensionForExecute.AddRange(Module.ItemToListStringsFromListBox(lbx_FileType)); }
            }

            WriteChangeToOptionsFileType();
        }

        #endregion

        #region RELATIONS
        private void UpdateFace(object obj)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(_mBox.MainFListener, obj);
                }
                catch
                {
                    //
                }
            }
            else
            {
                try
                {
                    ModuleBox m = obj as ModuleBox;
                    File.AppendAllText("TTX.txt", $"\r\nMF- {m.CodeId}");
                    switch (m.CodeId)
                    {
                        case CodeId.UpdateAuditMonitor:
                            lbx_AuditMonitor.Items.Insert(0, m.StringBody);
                            break;
                        case CodeId.BindWithModule:
                            _mBox.ModListener = m.ModListener;
                            break;
                        case CodeId.ListReportAudit:
                            ShowReport(obj);
                            break;
                    }
                }
                catch
                {
                    
                }
            }
        }

        #endregion

        #region MAIN_MENU
        private void btn_SM_StartScan_Click(object sender, EventArgs e)
        {
            if (_mBox.ApplicationOptions.DirectoriesForScanStart.Count > 0 &&
                _mBox.ApplicationOptions.FilePatterns.Count > 0)
            {
                //timerRunModul.Enabled = true;
                //timerRunModul.Start();
                _mBox.ModListener(new ModuleBox(_mBox) { CodeId = CodeId.RunScanForm });
            }
            else
            {
                MessageBox.Show(@"Не всі параметри заповнені!", @"Увага!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion

        #region ADDITIONALLY
        //Todo  drag and drop and cheked

        #region IGNORE_FILES
        private void nud_IgnoreFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nud_IgnoreFrom.Value > nud_IgnoreTo.Value)
            {
                nud_IgnoreTo.Value = nud_IgnoreFrom.Value;
            }

            WriteChangeToOptionsOfFileSizes();
        }

        private void nud_IgnoreTo_ValueChanged(object sender, EventArgs e)
        {
            if (nud_IgnoreFrom.Value > nud_IgnoreTo.Value)
            {
                nud_IgnoreFrom.Value = nud_IgnoreTo.Value;
            }

            WriteChangeToOptionsOfFileSizes();
        }

        private void dud_FileSeziBaseFrom_SelectedItemChanged(object sender, EventArgs e)
        {
            if (dud_FileSeziBaseFrom.SelectedIndex > -1 && dud_FileSeziBaseTo.SelectedIndex > -1)
            {
                if (Convert.FromStringToByteGetLong(
                        dud_FileSeziBaseFrom.SelectedItem.ToString())
                    >
                    Convert.FromStringToByteGetLong(dud_FileSeziBaseTo.SelectedItem.ToString()))
                {
                    dud_FileSeziBaseTo.SelectedIndex = dud_FileSeziBaseFrom.SelectedIndex;
                }
                WriteChangeToOptionsOfFileSizes();
            }

            
        }

        private void dud_FileSeziBaseTo_SelectedItemChanged(object sender, EventArgs e)
        {
            if (dud_FileSeziBaseFrom.SelectedIndex > -1 && dud_FileSeziBaseTo.SelectedIndex > -1)
            {
                if (Convert.FromStringToByteGetLong(
                        dud_FileSeziBaseFrom.SelectedItem.ToString())
                    >
                    Convert.FromStringToByteGetLong(dud_FileSeziBaseTo.SelectedItem.ToString()))
                {
                    dud_FileSeziBaseFrom.SelectedIndex = dud_FileSeziBaseTo.SelectedIndex;
                }
                WriteChangeToOptionsOfFileSizes();
            }

            
        }

        #endregion

        #region IGNORE_LIST_DIRS
        //Todo future list of option and history template
        private void btn_AddDirIgnore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var listDirs = File.ReadAllLines(ofd.FileName);
                    lbx_IgnoreDir.Items.Clear();
                    foreach (var dirs in listDirs)
                    {
                        if (Directory.Exists(dirs))
                        {
                            lbx_IgnoreDir.Items.Add(dirs);
                        }
                    }
                    WriteChangeToOptionsListIgnoreDirs();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        #endregion

        #endregion

        #region SAVE_OPTIONS
        private void WriteChangeToOptionsOfWordPattern()
        {
            _mBox.ApplicationOptions.FilePatterns.Clear();
            _mBox.ApplicationOptions.FilePatterns.AddRange(Module.ItemToListStringsFromListBox(lbx_WordPatterns));
        }
        private void WriteChangeToOptionsOfFileSizes()
        {
            if (dud_FileSeziBaseFrom.SelectedIndex > -1 && dud_FileSeziBaseTo.SelectedIndex > -1)
            {
                _mBox.ApplicationOptions.FileSizeIgnoreFrom = (long) nud_IgnoreFrom.Value *
                                                              Convert.FromStringToByteGetLong(dud_FileSeziBaseFrom
                                                                  .SelectedItem
                                                                  .ToString());
                _mBox.ApplicationOptions.FileSizeIgnoreTo = (long) nud_IgnoreTo.Value *
                                                            Convert.FromStringToByteGetLong(dud_FileSeziBaseTo
                                                                .SelectedItem
                                                                .ToString());
            }
        }
        private void WriteChangeToOptionsListIgnoreDirs()
        {
            _mBox.ApplicationOptions.DirectoriesForScanIgnore.Clear();
            foreach (var dir in lbx_IgnoreDir.Items)
            {
                _mBox.ApplicationOptions.DirectoriesForScanIgnore.Add(new DirectoryInfo(dir.ToString()));
            }
        }
        private void WriteChangeToOptionsListCustomSelectDirs()
        {
            _mBox.ApplicationOptions.DirectoriesForScanStart.Clear();

            if (lbx_FolderToScan.Items.Count > 0)
            {
                _mBox.ApplicationOptions.DirectoriesForScanStart.AddRange(Module.ItemToListDirInfoFromListBox(lbx_FolderToScan));
            }
            else if(cbx_DiskInfo.SelectedItem.ToString()=="../")
            {
                try
                {
                    var D = DriveInfo.GetDrives();
                    foreach (var disk in D)
                    {
                        try
                        {
                            if (disk.IsReady)
                            {
                                _mBox.ApplicationOptions.DirectoriesForScanStart.Add(new DirectoryInfo(disk.Name));
                            }
                        }
                        catch
                        {
                            //
                        }
                    }
                }
                catch
                {
                    if (_mBox.ApplicationOptions.DirectoriesForScanStart.Count == 0)
                        MessageBox.Show(@"Лист для сканування порожній!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                try
                {
                    var D = DriveInfo.GetDrives();
                    foreach (var disk in D)
                    {
                        if (disk.IsReady && disk.Name == cbx_DiskInfo.SelectedItem.ToString())
                        {
                            _mBox.ApplicationOptions.DirectoriesForScanStart.Add(new DirectoryInfo(cbx_DiskInfo.SelectedItem.ToString()));
                            break;
                        }
                        
                    }
                    if(_mBox.ApplicationOptions.DirectoriesForScanStart.Count==0)
                        throw new Exception("XYZ");
                }
                catch
                {
                    MessageBox.Show(@"Носій порожній! Оберіть інший.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void WriteChangeToOptionsFileType()
        {
            if (lbx_FileType.Items.Count > 0)
            {
                _mBox.ApplicationOptions.FileExtensionForExecute.AddRange(Module.ItemToListStringsFromListBox(lbx_FileType));
            }
            else if (chbAllFileType.Checked)
            {
                _mBox.ApplicationOptions.FileExtensionForExecute.AddRange(Module.ItemToListStringsFromComboBox(cbxListFileExt));
            }
            else
            {
                _mBox.ApplicationOptions.FileExtensionForExecute.Add(cbxListFileExt.SelectedItem.ToString());
            }
        }




        #endregion

        #endregion

        private void btn_TSM_HotFileAudit_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                FileSystemScan.AuditValid(new ModuleBox(_mBox) {CodeId = CodeId.Nothing, StringBody = ofd.FileName});
            }
        }

        private void ShowReport(object obj)
        {
            Debug.WriteLine(" ShowReport(object obj)");
            var m = obj as ModuleBox;
            
            var arr = _mBox.ApplicationOptions.FilePatterns;
            var arrIndx = new int[arr.Count];

            foreach (var au in m.ListReportAudit)
            {
                foreach (var fw in au.FindWords)
                {
                    arrIndx[fw.WordIndexArr] += fw.CountInFile;
                }
            }
            m.ListReportAudit.Clear();
            List<string> report = new List<string>();
            string str = "\n\rЗнайдені слова:";

            for (int i = 0; i < arrIndx.Length; i++)
            {
                str += $"\n\r{_mBox.ApplicationOptions.FilePatterns[i]} - {arrIndx[i]} раз.";
            }

            for (int i = 0; i < lbx_AuditMonitor.Items.Count; i++)
            {
                str += "\r\n" + lbx_AuditMonitor.Items[i].ToString();
            }

            str += $"\r\n Пушук збережено у файлі: {_mBox.ApplicationOptions.PathToCopyFile + @"\Report.txt"}";
            lbx_AuditMonitor.Items.Clear();
            FormReport fr = new FormReport(str);
            fr.ShowDialog();
        }

        private void btn_MouseHookTest_Click(object sender, EventArgs e)
        {
            //var mh = new TestMouseHook();
            //mh.ShowDialog();
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestHookMouse });
        }

        private void btn_KeyboardHook_Click(object sender, EventArgs e)
        {
            //var hk = new TestKeyBoardHook();
            //hk.ShowDialog();
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestHookKeyboard });
        }

        private void btn_ClipboardHook_Click(object sender, EventArgs e)
        {
            //var cb = new TestClipBordHook();
            //cb.ShowDialog();
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestHookClipboard });
        }

        private void btn_ProgHook_Click(object sender, EventArgs e)
        {
            //var app = new TestAppHook();
            //app.ShowDialog();
            
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestHookApp});
        }

        private void btn_PrinterHook_Click(object sender, EventArgs e)
        {
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestHookPrint });
        }

        private void btn_CameraSpy_Click(object sender, EventArgs e)
        {
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.TestCameraSpy });
        }
    }
}
