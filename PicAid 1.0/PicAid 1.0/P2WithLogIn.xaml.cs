using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PicAid_1._0.src;

namespace PicAid_1._0
{
    public partial class P2WithLogIn : PhoneApplicationPage
    {
        public P2WithLogIn()
        {
            InitializeComponent();
        }

        private void HubTile_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/user_profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnfndhoscat_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/hos_searchall.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnfndDocCat_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/doc_searchall.xaml", UriKind.RelativeOrAbsolute));
        }
//multispecialist
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/multi_hos.xaml", UriKind.RelativeOrAbsolute));
        }

     
    }
}