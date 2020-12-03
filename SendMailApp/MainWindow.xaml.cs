using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        private void Sc_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("送信はキャンセルされました。");
            else
                MessageBox.Show(e.Error?.Message ??"送信完了しました。");
        }

        SmtpClient sc = new SmtpClient();



        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Config cc = Config.GetInstance();
                MailMessage msg = new MailMessage(cc.MailAddress, tbTo.Text);
                
                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbNote.Text; //本文

                if (tbCc.Text != "")
                    msg.CC.Add(tbBc.Text);

                if (tbBc.Text != "")
                    msg.Bcc.Add(tbBc.Text);                

                sc.Host = cc.Smtp; //SMTPサーバの設定
                sc.Port = cc.Port;
                sc.EnableSsl = cc.Ssl;
                sc.Credentials = new NetworkCredential(cc.MailAddress, cc.PassWord);
                foreach (var item in tbAthor.Items)
                {
                    msg.Attachments.Add(new Attachment(item.ToString()));
                }
                sc.SendMailAsync(msg); //送信
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {

            sc.SendAsyncCancel();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Show();
        }

        //メインウインドウがロードするタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialise();
            }
            catch (FileNotFoundException)
            {
                ConfigWindow configWindow = new ConfigWindow();
                configWindow.Show();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try{
                Config.GetInstance().Serialise();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var add = new OpenFileDialog();

            if (add.ShowDialog() == true)
                tbAthor.Items.Add(add.FileName);
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            tbAthor.Items.Clear();
        }
    }
}
