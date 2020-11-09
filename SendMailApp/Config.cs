using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp
{
    public  class Config
    {
        private static Config Instance { get; set; }

        public string Smtp { get; set; }//SMTP Server
        public string MailAddress { get; set; }//My MailAddress (From)
        public string PassWord { get; set; }//Password
        public int Port { get; set; }//Port number
        public bool Ssl { get; set; }//SSl Setting

        public static Config GetInstance()
        {
            if (Instance == null)
                Instance = new Config();
            return Instance;
        }
        //Default Setting
        public void DefaultSet()
        {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }

        public Config getDefaultStatus()
        {
            Config obj = new Config
            {
                Smtp = "smtp.gmail.com",
                MailAddress = "ojsinfosys01@gmail.com",
                PassWord = "ojsInfosys2020",
                Port = 587,
                Ssl = true
            };
            return obj;
        }

        public bool UpdateStatus(string smtp,string mailAddress,string passWord,int port,bool ssl)
        {
            Smtp = smtp;
            MailAddress = mailAddress;
            PassWord = passWord;
            Port = port;
            return true;
        }
    }
}