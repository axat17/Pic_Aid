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
    public partial class doc_detail : PhoneApplicationPage
    {
        public doc_detail()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = NavigationContext.QueryString["id"];
            pic_srcSoapClient sc = new pic_srcSoapClient();
            sc.doc_dtl_by_listCompleted += sc_doc_dtl_by_listCompleted;
            sc.doc_dtl_by_listAsync(x);
        }

        void sc_doc_dtl_by_listCompleted(object sender, doc_dtl_by_listCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                pic_doctor_tbl[] r = new pic_doctor_tbl[e.Result.Count];
                r = e.Result.ToArray();
                //lst_dlt.Items.Clear();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_doctor_tbl b = new pic_doctor_tbl();
                    txt_docname.Text = r[i].doc_name.ToString();
                    txt_doc_for.Text = r[i].doc_for.ToString();
                    txt_doc_add.Text = r[i].doc_hos_add.ToString();
                    txt_doc_area.Text = r[i].area.ToString();
                    txt_doc_city.Text = r[i].city_doc.ToString();
                    txt_doc_cont.Text = r[i].contact.ToString();
                    txt_doc_email.Text = r[i].email_id.ToString();
                    //lst_dlt.Items.Add(b);
                }
            }
        }

    }
}