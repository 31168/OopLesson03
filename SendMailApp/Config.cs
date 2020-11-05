using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp
{
    class Config
    {
        public string Smtp { get; set; }//SMTP Server
        public string MailAddress { get; set; }//My MailAddress (From)
        public string PassWord { get; set; }//Password
        public int Port { get; set; }//Port number
        public bool Ssl { get; set; }//SSl Setting

        //Default Setting
        public void DefaultSet()
        {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
    }
}
