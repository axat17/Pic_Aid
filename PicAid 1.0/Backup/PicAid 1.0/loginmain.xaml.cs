using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using PicAid_1._0.src;

namespace PicAid_1._0
{
    public partial class LogIn : PhoneApplicationPage
    {
        public LogIn()
        {
            InitializeComponent();
        }
        pic_srcSoapClient sc = new pic_srcSoapClient();
       
        private void btnLogIn_Click_1(object sender, RoutedEventArgs e)
        {
            sc.chk_usr_passCompleted += sc_chk_usr_passCompleted;
            sc.chk_usr_passAsync(pass_txt.Password, txt_email.Text);
        }

        void sc_chk_usr_passCompleted(object sender, chk_usr_passCompletedEventArgs e)
        {

            if (e.Result == 1)
            {
                
                IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
                StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("user_mail.txt", FileMode.Create, isf));
                sw.WriteLine(txt_email.Text);
                sw.Close();
                (App.Current as App).email_id = txt_email.Text;

                NavigationService.Navigate(new Uri("/P2WithLogIn.xaml", UriKind.RelativeOrAbsolute));

            }
            else
            {
                MessageBox.Show("invalid email id or password");
            }
        }

        private void btnsignup_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pro_set.xaml", UriKind.RelativeOrAbsolute));
        }

      
    }
}