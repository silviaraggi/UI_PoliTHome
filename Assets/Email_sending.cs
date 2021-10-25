using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using System;
using System.Threading;

public class Email_sending : MonoBehaviour
{
   
        public InputField bodyMessage;
        
        public InputField myEmail;
        public InputField docEmail;

        public GameObject username;
        public GameObject Exercise;
        public GameObject EmailBox;
        private string Username;

        public GameObject success;

        private bool success_bool = false;

        private String[] Lines;

        private string MyEmail;
        private string DocEmail;

        public void SendEmail()
        {
            

            Lines = System.IO.File.ReadAllLines(@"Assets/TextFile/silviraggi.txt");
            MyEmail = Lines[3];
            DocEmail = Lines[5];
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Timeout = 10000;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 587;

            mail.From = new MailAddress(MyEmail);
            mail.To.Add(new MailAddress(DocEmail));

            mail.Subject = "Test";
            mail.Body = bodyMessage.text;


            SmtpServer.Credentials = new System.Net.NetworkCredential(MyEmail, "chr17m2007!kh24!") as ICredentialsByHost; SmtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpServer.Send(mail);

            success.SetActive(true);
            success_bool = true;
            bodyMessage.Select();
            bodyMessage.text = "";

           
    }

    private void Update()
    {
        if(success_bool is true && Input.GetKeyDown(KeyCode.Return))
        {
            Exercise.SetActive(true);
            EmailBox.SetActive(false);
            success_bool = false;
            success.SetActive(false);

        }
    }




}
