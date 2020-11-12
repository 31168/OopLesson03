using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        Config config = new Config();
            
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPassWord.Password) || !string.IsNullOrWhiteSpace(tbPort.Text) ||
                !string.IsNullOrWhiteSpace(tbSender.Text) || !string.IsNullOrWhiteSpace(tbSmtp.Text) || !string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                MessageBox.Show("正しい値を入力してください");
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
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl; 
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPassWord.Password) || !string.IsNullOrWhiteSpace(tbPort.Text) ||
                !string.IsNullOrWhiteSpace(tbSender.Text) || !string.IsNullOrWhiteSpace(tbSmtp.Text) || !string.IsNullOrWhiteSpace(tbUserName.Text) )
            {
                MessageBox.Show("正しい値を入力してください");
                return;
            }

            Config.GetInstance().UpdateStatus(
            tbSmtp.Text,
            tbUserName.Text,
            tbPassWord.Password,
            int.Parse(tbPort.Text),
            cbSsl.IsChecked ?? false);

            
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

                Config ss = Config.GetInstance();
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
    }
}
