using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PicAid_1._0.src;

namespace PicAid_1._0
{
    public partial class pro_set : PhoneApplicationPage
    {
        public pro_set()
        {
            InitializeComponent();
        }
        pic_srcSoapClient sc = new pic_srcSoapClient();

        private void btnSignUp_Click_1(object sender, RoutedEventArgs e)
        {
            sc.sign_upCompleted += sc_sign_upCompleted;
            sc.sign_upAsync(txt_email.Text,Name.Text,txtPass.Text,txtmo.Text,txtGen.Text,txtcity.Text,dob.Text);
        }

        void sc_sign_upCompleted(object sender, sign_upCompletedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/loginmain.xaml", UriKind.RelativeOrAbsolute));
        }
        
      
      
    }
}