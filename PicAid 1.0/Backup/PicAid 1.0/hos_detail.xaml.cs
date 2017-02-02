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
    public partial class hos_detail : PhoneApplicationPage
    {
        public hos_detail()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = NavigationContext.QueryString["id"];
            pic_srcSoapClient sc = new pic_srcSoapClient();
            sc.hos_dtl_by_listCompleted += sc_hos_dtl_by_listCompleted;
            sc.hos_dtl_by_listAsync(x);
        }

        void sc_hos_dtl_by_listCompleted(object sender, hos_dtl_by_listCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                pic_hospital_tbl[] r = new pic_hospital_tbl[e.Result.Count];
                r = e.Result.ToArray();
                //lst_dlt.Items.Clear();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_hospital_tbl b = new pic_hospital_tbl();
                    txthos_name.Text = r[i].hos_name.ToString();
                    txthos_for.Text = r[i].hos_for.ToString();
                    txthosAdd.Text = r[i].address.ToString();
                    txtHosArea.Text = r[i].area.ToString();
                    txtcity.Text = r[i].city.ToString();
                    txtCon1.Text = r[i].contact_1.ToString();
                    txtCon2.Text = r[i].contact_2.ToString();
                    txtEmail.Text = r[i].email_id.ToString();
                    //lst_dlt.Items.Add(b);
                }
            }
        }
    }
}