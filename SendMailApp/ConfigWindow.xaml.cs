using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace SendMailApp
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        
        public bool Change = false;

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbSmtp.Text == "" || tbUserName.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" || tbSender.Text == "")
            {
                MessageBox.Show("未入力の項目があります。");
                return;
            }

            btApply_Click(sender, e);
            this.Close();

        }

        private void btDefault_Click(object sender, RoutedEventArgs e)
        {

            Config cf = Config.GetInstance().getDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl; 
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Config.GetInstance().UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false);
                ChangeOk(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show("値を入力してください");
            }

       
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Change == true)
            {
                MessageBoxResult result = MessageBox.Show("内容が変更されています。保存しますか？", "Daanger", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    ChangeOk(sender, e);
                    this.Close();
                }
                else if (result == MessageBoxResult.OK)
                {
                    btApply_Click(sender, e);
                    this.Close();
                }
            }
            else
            {
                ChangeOk(sender, e);
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config ss = Config.GetInstance();

            ss = Config.GetInstance();
            tbSmtp.Text = ss.Smtp;
            tbUserName.Text = ss.MailAddress;
            tbPassWord.Password = ss.PassWord;
            tbPort.Text = ss.Port.ToString();
            cbSsl.IsChecked = ss.Ssl;

        }

        private void Arate()
        {
            if (tbPassWord == null || tbPort == null || tbSender == null || tbSmtp == null || tbUserName == null)
            {
                MessageBox.Show("正しい値を入力してください");
                return;
            }
        }

        private void ChangeOk(object sender, RoutedEventArgs e)
        {
            Change = false;
        }
    }
}
