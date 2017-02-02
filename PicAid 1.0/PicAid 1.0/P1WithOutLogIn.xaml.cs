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

namespace PicAid_1._0
{
    public partial class P1WithOutLogIn : PhoneApplicationPage
    {
        public P1WithOutLogIn()
        {
            InitializeComponent();
        }



        private void btnLogInPivot_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/loginmain.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSignUpPivot_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pro_set.xaml", UriKind.RelativeOrAbsolute));
        }




        private void btnfndDocCat_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/doc_searchall.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnfndhoscat_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/hos_searchall.xaml", UriKind.RelativeOrAbsolute));
        }
 




        private void doc_name_search_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/doc_searchall.xaml", UriKind.RelativeOrAbsolute));
        }

        private void hos_name_search_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/hos_searchall.xaml", UriKind.RelativeOrAbsolute));
        }

        private void e_service_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/e_service.xaml", UriKind.RelativeOrAbsolute));
        }

        private void awrnes_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Awareness.xaml", UriKind.RelativeOrAbsolute));
        }
//multispecialist
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/multi_hos.xaml", UriKind.RelativeOrAbsolute));
        }




    }
}