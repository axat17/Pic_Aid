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
    public partial class hos_list : PhoneApplicationPage
    {
        public hos_list()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = NavigationContext.QueryString["id"];
            pic_srcSoapClient sc = new pic_srcSoapClient();
            sc.get_hos_by_idCompleted += sc_get_hos_by_idCompleted;
            sc.get_hos_by_idAsync(x);
                       
        }

        void sc_get_hos_by_idCompleted(object sender, get_hos_by_idCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                pic_hospital_tbl[] r = new pic_hospital_tbl[e.Result.Count];
                r = e.Result.ToArray();
                lst_hos_name.Items.Clear();
                 for (int i = 0; i < e.Result.Count; i++)
                {
                    string z = " Hospital";
                    pic_hospital_tbl b = new pic_hospital_tbl();
                    b.hos_for = r[i].hos_for.ToString();
                    string a = b.hos_for.ToString();
                    titleHosType.Text = a + z;
                }
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_hospital_tbl b = new pic_hospital_tbl();
                    b.hos_id = Convert.ToInt32(r[i].hos_id.ToString());
                    b.hos_name = r[i].hos_name.ToString();
                    b.hos_for = r[i].hos_for.ToString();
                    lst_hos_name.Items.Add(b);
                }
               
            }
           
            
        }

        private void lst_hos_name_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            pic_hospital_tbl c = (pic_hospital_tbl)lst_hos_name.SelectedItem;

            NavigationService.Navigate(new Uri("/hos_detail.xaml?id=" + c.hos_id, UriKind.RelativeOrAbsolute));
        }
       
    }
}