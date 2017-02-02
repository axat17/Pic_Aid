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
    public partial class hos_searchall : PhoneApplicationPage
    {
        public hos_searchall()
        {
            InitializeComponent();
        }
        pic_srcSoapClient sc = new pic_srcSoapClient();
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            sc.get_hos_catCompleted += sc_get_hos_catCompleted;
            sc.get_hos_catAsync();
        }
        void sc_get_hos_catCompleted(object sender, get_hos_catCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                pic_hos_cat_tbl[] r = new pic_hos_cat_tbl[e.Result.Count];
                r = e.Result.ToArray();
                lst_cat.Items.Clear();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_hos_cat_tbl b = new pic_hos_cat_tbl();
                    b.hos_cat_id = Convert.ToInt32(r[i].hos_cat_id.ToString());
                    b.hos_cat_name = r[i].hos_cat_name.ToString();
                    lst_cat.Items.Add(b);
                }


            }
        }

        private void img_name_search_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void lst_cat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            pic_hos_cat_tbl c = (pic_hos_cat_tbl)lst_cat.SelectedItem;

            NavigationService.Navigate(new Uri("/hos_list.xaml?id=" + c.hos_cat_id, UriKind.RelativeOrAbsolute));
        }
    }
}
