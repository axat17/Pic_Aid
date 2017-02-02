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
    public partial class doc_list : PhoneApplicationPage
    {
        public doc_list()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = NavigationContext.QueryString["id"];
            pic_srcSoapClient sc = new pic_srcSoapClient();
            sc.get_doc_by_idCompleted += sc_get_doc_by_idCompleted;
            sc.get_doc_by_idAsync(x);
        }

        void sc_get_doc_by_idCompleted(object sender, get_doc_by_idCompletedEventArgs e)
        {
           if (e.Error == null)
            {
                pic_doctor_tbl[] r = new pic_doctor_tbl[e.Result.Count];
                r = e.Result.ToArray();
                lst_doc_name.Items.Clear();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_doctor_tbl b = new pic_doctor_tbl();
                    b.doc_id = Convert.ToInt32(r[i].doc_id.ToString());
                    b.doc_name = r[i].doc_name.ToString();
                    b.doc_for = r[i].doc_for.ToString();
                    lst_doc_name.Items.Add(b);
                }
            }
        }

        private void lst_doc_name_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            pic_doctor_tbl c = (pic_doctor_tbl)lst_doc_name.SelectedItem;

            NavigationService.Navigate(new Uri("/doc_detail.xaml?id=" + c.doc_id, UriKind.RelativeOrAbsolute));
        }
        
    }
}