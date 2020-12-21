using System;
using System.Threading;
using System.Windows.Forms;

namespace Esp.UI
{
    public partial class ScanF : Form
    {
        private ModuleBox _mBox;
        private Thread _task;
        public ScanF(object obj)
        {
            InitializeComponent();
            _mBox = new ModuleBox(obj as ModuleBox) {ScanFListener = UpdateUi};
            _mBox.ModListener(new ModuleBox(){CodeId = CodeId.BindWithScanF, ScanFListener = _mBox.ScanFListener});
            timer.Start();
        }
        private void UpdateUi(object obj)
        {

            try
            {
                if (InvokeRequired)
                {
                    Invoke(_mBox.ScanFListener, obj);
                }
                else
                {
                    ModuleBox m = obj as ModuleBox;
                    switch (m.CodeId)
                    {
                        case CodeId.ProgresBarMax:
                            pb_Scan.Maximum=m.IntBody;
                            break;
                        case CodeId.ProgresBarStep:
                            pb_Scan.Value = m.IntBody;
                            break;
                        case CodeId.UpdateLblCurFile:
                            lbl_Scan.Text = m.StringBody;
                            break;
                        case CodeId.UpdateLblDirFiles:
                            lbl_Files.Text = m.StringBody;
                            break;
                        case CodeId.UpdateLblDirectories:
                            lbl_Dirs.Text = m.StringBody;
                            break;
                        case CodeId.BindWithModule:
                            _mBox.ModListener = m.ModListener;
                            break;
                        case CodeId.BindwithScan:
                            _mBox.ScanListener = m.ScanListener;
                            break;
                    }
                }
            }
            catch 
            {
                //
            }
        }
        private void ScanF_Load(object sender, EventArgs e)
        {
            cbx_Prior.SelectedIndex = 1;
            cbx_Doing.SelectedIndex = 1;
        }

        private bool _isPause = false;
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (_isPause)
            {
                _isPause = false;
                btn_Pause.Text = "Пауза";
                _mBox.ScanListener?.Invoke(new ModuleBox(){CodeId = CodeId.PauseScan});
            }
            else
            {
                _isPause = true;
                btn_Pause.Text = "Відновити";
                _mBox.ScanListener?.Invoke(new ModuleBox() { CodeId = CodeId.PauseScan });
            }
        }

        private void btn_Cancell_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbx_Doing_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbx_Doing.SelectedIndex > -1)
            {
                switch (cbx_Doing.SelectedIndex)
                {
                    case 0:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.ProcHight });
                        break;
                    case 1:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.ProcNormal });
                        break;
                    case 2:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.ProcLow });
                        break;
                }

               
            }
        }

        private void cbx_Prior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Prior.SelectedIndex > -1)
            {
                switch (cbx_Prior.SelectedIndex)
                {
                    case 0:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.PriorHight });
                        break;
                    case 1:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.PriorNormal });
                        break;
                    case 2:
                        //_sBox.Dbox.ModD?.Invoke(new SBox() { CodeId = CodeId.PriorLow });
                        break;
                }

                
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _task = new Thread(new FileSystemScan(new ModuleBox(_mBox)).GetAllDirectoryInfo);
            ModuleBox m = new ModuleBox(_mBox);
            _task.Start(m);
            timer.Stop();
        }

        private void ScanF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_task.IsAlive)
            {
                _task.Abort();
            }
        }

        private void lbl_Scan_TextChanged(object sender, EventArgs e)
        {
            if (lbl_Scan.Text == @"Завершено.")
            {
                Thread.Sleep(500);
                Close();
            }
        }
    }
}
