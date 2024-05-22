using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BuyLoad : UserControl
    {
        public BuyLoad()
        {
            InitializeComponent();
        }

        private void BuyLoad_Load(object sender, EventArgs e)
        {
            Global.TimerDone.Start();

            switch (Global.MailChoose)
            {
                case "@mail.ru":
                    SendMessageMail(Global.Mail);
                    break;

                case "@gmail.com":
                    SendMessageGMail(Global.Mail);
                    break;

                case "@yandex.ru":
                    SendMessageYandex(Global.Mail);
                    break;
            }
           
        }
        private void SendMessageMail(string mailtext)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "danjukov11022004@mail.ru";
            string smtpPassword = "Rgg6DmeQfJzBGCiXb6V8";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(mailtext);
                    mailMessage.Subject = "Автоматизированная информационная система: 'Бронирование билетов'. Забронированный билет";
                    mailMessage.Body = "Забронированный Вами билет. Счастливого пути!";
                    mailMessage.Attachments.Add(new Attachment(Environment.CurrentDirectory + @"\DoneTicket\ticket.docx"));

                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch
                    {
                        MessageBox.Show($"Произошла ошибка при отправке сообщения", "Ошибка");
                    }
                }
            }
        }

        private void SendMessageGMail(string mailtext)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "gnezd20@gmail.com";
            string smtpPassword = "xvfqxoxhdnciudlo";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(mailtext);
                    mailMessage.Subject = "Автоматизированная информационная система: 'Бронирование билетов'. Забронированный билет";
                    mailMessage.Body = "Забронированный Вами билет. Счастливого пути!";
                    mailMessage.Attachments.Add(new Attachment(Environment.CurrentDirectory + @"\DoneTicket\ticket.docx"));

                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch
                    {
                        MessageBox.Show($"Произошла ошибка при отправке сообщения", "Ошибка");
                    }
                }
            }
        }

        private void SendMessageYandex(string mailtext)
        {
            string smtpServer = "smtp.yandex.ru";
            int smtpPort = 587;
            string smtpUsername = "AisTicket@yandex.ru";
            string smtpPassword = "djwxgoxjwihlnlyc";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(mailtext);
                    mailMessage.Subject = "Автоматизированная информационная система: 'Бронирование билетов'. Забронированный билет";
                    mailMessage.Body = "Забронированный Вами билет. Счастливого пути!";
                    mailMessage.Attachments.Add(new Attachment(Environment.CurrentDirectory + @"\DoneTicket\ticket.docx"));

                    try
                    {
                        smtpClient.Send(mailMessage);
                    }
                    catch
                    {
                        MessageBox.Show($"Произошла ошибка при отправке сообщения", "Ошибка");
                    }
                }
            }
        }
    }
}
