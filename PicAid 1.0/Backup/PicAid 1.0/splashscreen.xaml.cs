using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.IO;
using System.IO.IsolatedStorage;

namespace PicAid_1._0
{
    public partial class splashscreen : PhoneApplicationPage
    {
        System.Windows.Threading.DispatcherTimer _splashTimer;
        public splashscreen()
        {
            InitializeComponent();
            _splashTimer = new System.Windows.Threading.DispatcherTimer();
            this.Loaded += splashscreen_Loaded;
        }

        void splashscreen_Loaded(object sender, RoutedEventArgs e)
        {
            if (_splashTimer != null)
            {
                _splashTimer.Interval = new TimeSpan(0, 0, 5);
                _splashTimer.Tick += _splashTimer_Tick;
                _splashTimer.Start();
                
            }
        }

        void _splashTimer_Tick(object sender, EventArgs e)
        {
            _splashTimer.Stop();
            _splashTimer.Tick -= new EventHandler(_splashTimer_Tick);
            _splashTimer = null;
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            if (isf.FileExists("user_mail.txt"))
            {
                StreamReader sr = new StreamReader(new IsolatedStorageFileStream("user_mail.txt", FileMode.Open, isf));
                string email = sr.ReadLine().TrimEnd('\r', '\n');
                sr.Close();
                (App.Current as App).email_id = email.ToString();
                NavigationService.Navigate(new Uri("/P2WithLogIn.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                NavigationService.Navigate(new Uri("/CitySelect.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}