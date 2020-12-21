using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Esp.WebCam
{
    public class WebcamEventArgs : EventArgs
    {
        private ulong m_FrameNumber = 0;
        private Image m_Image;

        public Image WebCamImage
        {
            get
            {
                return this.m_Image;
            }
            set
            {
                this.m_Image = value;
            }
        }

        public ulong FrameNumber
        {
            get
            {
                return this.m_FrameNumber;
            }
            set
            {
                this.m_FrameNumber = value;
            }
        }
    }
    public class WebCamCapture : UserControl
    {
        private int m_TimeToCapture_milliseconds = 100;
        private int m_Width = 320;
        private int m_Height = 240;
        private ulong m_FrameNumber = 0;
        private WebcamEventArgs x = new WebcamEventArgs();
        private bool bStopped = true;
        public const int WM_USER = 1024;
        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GET_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;
        public const int WM_CAP_START = 1024;
        public const int WM_CAP_DLG_VIDEOFORMAT = 1065;
        public const int WM_CAP_DLG_VIDEOSOURCE = 1066;
        public const int WM_CAP_DLG_VIDEODISPLAY = 1067;
        public const int WM_CAP_GET_VIDEOFORMAT = 1068;
        public const int WM_CAP_SET_VIDEOFORMAT = 1069;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = 1070;
        public const int WM_CAP_SET_PREVIEW = 1074;
        private IContainer components;
        private Timer timer1;
        private int mCapHwnd;
        private IDataObject tempObj;
        private Image tempImg;
        public ClientSpy.ClientSpy _cs;
        public event WebCamCapture.WebCamEventHandler ImageCaptured;

        [DllImport("user32")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("avicap32.dll")]
        public static extern int capCreateCaptureWindowA(
          string lpszWindowName,
          int dwStyle,
          int X,
          int Y,
          int nWidth,
          int nHeight,
          int hwndParent,
          int nID);

        [DllImport("user32")]
        public static extern int OpenClipboard(int hWnd);

        [DllImport("user32")]
        public static extern int EmptyClipboard();

        [DllImport("user32")]
        public static extern int CloseClipboard();

        public WebCamCapture(ClientSpy.ClientSpy cs)
        {
            this.InitializeComponent();
            _cs = cs;
        }

        ~WebCamCapture()
        {
            this.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            this.timer1 = new Timer(this.components);
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.Name = nameof(WebCamCapture);
            this.Size = new Size(342, 252);
        }

        public int TimeToCapture_milliseconds
        {
            get
            {
                return this.m_TimeToCapture_milliseconds;
            }
            set
            {
                this.m_TimeToCapture_milliseconds = value;
            }
        }

        public int CaptureHeight
        {
            get
            {
                return this.m_Height;
            }
            set
            {
                this.m_Height = value;
            }
        }

        public int CaptureWidth
        {
            get
            {
                return this.m_Width;
            }
            set
            {
                this.m_Width = value;
            }
        }

        public ulong FrameNumber
        {
            get
            {
                return this.m_FrameNumber;
            }
            set
            {
                this.m_FrameNumber = value;
            }
        }

        public void Start(ulong FrameNum)
        {
            try
            {
                this.Stop();
                this.mCapHwnd = WebCamCapture.capCreateCaptureWindowA("WebCap", 0, 0, 0, this.m_Width, this.m_Height, this.Handle.ToInt32(), 0);
                Application.DoEvents();
                WebCamCapture.SendMessage(this.mCapHwnd, 1034U, 0, 0);
                WebCamCapture.SendMessage(this.mCapHwnd, 1074U, 0, 0);
                this.m_FrameNumber = FrameNum;
                this.timer1.Interval = this.m_TimeToCapture_milliseconds;
                this.bStopped = false;
                this.timer1.Start();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An error ocurred while starting the video capture. Check that your webcamera is connected properly and turned on.\r\n\n" + ex.Message);
                this.Stop();
            }
        }

        public void Stop()
        {
            try
            {
                this.bStopped = true;
                this.timer1.Stop();
                Application.DoEvents();
                WebCamCapture.SendMessage(this.mCapHwnd, 1035U, 0, 0);
            }
            catch (Exception ex)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Stop();
                WebCamCapture.SendMessage(this.mCapHwnd, 1084U, 0, 0);
                WebCamCapture.SendMessage(this.mCapHwnd, 1054U, 0, 0);
                if (this.ImageCaptured != null)
                {
                    this.tempObj = Clipboard.GetDataObject();
                    this.tempImg = (Image)this.tempObj.GetData(DataFormats.Bitmap);
                   // _cs.Start_Sending_Video(tempImg);
                    Debug.WriteLine($" IMG {tempImg.Size}");
                    this.x.WebCamImage = this.tempImg.GetThumbnailImage(this.m_Width, this.m_Height, (Image.GetThumbnailImageAbort)null, IntPtr.Zero);
                    
                    this.ImageCaptured((object)this, this.x);
                }
                Application.DoEvents();
                if (this.bStopped)
                    return;
                this.timer1.Start();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An error ocurred while capturing the video image. The video capture will now be terminated.\r\n\n" + ex.Message);
                this.Stop();
            }
        }

        public delegate void WebCamEventHandler(object source, WebcamEventArgs e);
    }
}