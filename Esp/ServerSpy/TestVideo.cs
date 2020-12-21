using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace Esp.ServerSpy
{
    public partial class TestVideo : Form
    {
       
        public TestVideo()
        {
          InitializeComponent();
          ShowDialog();
        }

        private async void TestVideo_Load(object sender, EventArgs e)
        {
            var port = 48654;
            var client = new UdpClient(port);
            while (true)
            {
                var data = await client.ReceiveAsync();
                using (var ms = new MemoryStream(data.Buffer))
                {
                    pictureBox2.Image = new Bitmap(ms);
                    Text = $"Bytes received: {data.Buffer.Length * sizeof(byte)}";
                }
            }
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            MessageBox.Show(string.Join("\n",
                host.AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork)));
        }
    }
}
