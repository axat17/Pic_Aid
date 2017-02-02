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
    public partial class user_profile : PhoneApplicationPage
    {
        static string[] d;
        public user_profile()
        {
            InitializeComponent();
        }

        pic_srcSoapClient sc = new pic_srcSoapClient();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sc.user_detailCompleted += sc_user_detailCompleted;
            sc.user_detailAsync((App.Current as App).email_id.ToString());

            sc.get_donation_typeCompleted += sc_get_donation_typeCompleted;
            sc.get_donation_typeAsync();
        }

        void sc_get_donation_typeCompleted(object sender, get_donation_typeCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                d = new string[e.Result.Count];
                pic_donation_sub_cat_tbl[] r = new pic_donation_sub_cat_tbl[e.Result.Count];
                r = e.Result.ToArray();
                lstOrganList.Items.Clear();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    pic_donation_sub_cat_tbl b = new pic_donation_sub_cat_tbl();
                    b.sub_cat_name = r[i].sub_cat_name.ToString();                   
                    lstOrganList.Items.Add(b);
                    lstNeedOrganList.Items.Add(b);
                }
            }
        }

        void sc_user_detailCompleted(object sender, user_detailCompletedEventArgs e)
        {
            pic_user_tbl[] p = new pic_user_tbl[e.Result.Count];
            p = e.Result.ToArray();
            name_block.Text = p[0].f_name;
            mail_block.Text = p[0].email_id;
            gender_block.Text = p[0].gen;
            city_block.Text = p[0].city;
            mobile_block.Text = p[0].mobile;
            dob_block.Text = p[0].dob;

        }

        private void tglBlood_Checked_1(object sender, RoutedEventArgs e)
        {
            Donate_blood_stack.Visibility = Visibility.Visible;
        }

        private void tglOrgan_Checked_1(object sender, RoutedEventArgs e)
        {
            Donate_organ_stack.Visibility = Visibility.Visible;
        }

        private void tglBlood_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Donate_blood_stack.Visibility = Visibility.Collapsed;
        }

        private void tglOrgan_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Donate_organ_stack.Visibility = Visibility.Collapsed;
        }
        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/loginmain.xaml", UriKind.RelativeOrAbsolute));
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            isf.DeleteFile("user_mail.txt");

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            

            string x = "";

            if (APO.IsChecked==true)
            {
                x=APO.Content.ToString();
            }
            else if (BPO.IsChecked==true)
            {
                 x=BPO.Content.ToString();
            }
             else if (ABPO.IsChecked==true)
            {
                 x=ABPO.Content.ToString();
            }
             else if (OPO.IsChecked==true)
            {
                 x=OPO.Content.ToString();
            }
             else if (ANAG.IsChecked==true)
            {
                 x=ANAG.Content.ToString();
            }
             else if (BNAG.IsChecked==true)
            {
                 x=BNAG.Content.ToString();
            }
             else if (ABNAG.IsChecked==true)
            {
                 x=ABNAG.Content.ToString();
            }
             else if (ONAG.IsChecked==true)
            {
                 x=ONAG.Content.ToString();
            }

            int donat_cat_id=1;

            sc.insert_bloodCompleted += sc_insert_bloodCompleted;
            sc.insert_bloodAsync(mail_block.Text, donat_cat_id, x,dt);
        }
    

        void sc_insert_bloodCompleted(object sender, insert_bloodCompletedEventArgs e)
        {
            if (e.Result == 1)
            {
                MessageBox.Show("Your Donation detail has been updated.");
            }
            else
            {

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            pic_donation_sub_cat_tbl d1 = c.DataContext as pic_donation_sub_cat_tbl;
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == null)
                {
                    d[i] = d1.sub_cat_name;
                    break;
                }
            }
        }

        private void lstOrganList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //donate_cat_tbl d1 = (donate_cat_tbl)lstNeedOrganList.SelectedItem;
        }

        private void chk1_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            pic_donation_sub_cat_tbl d1 = c.DataContext as pic_donation_sub_cat_tbl;
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == d1.sub_cat_name)
                {
                    d[i] = "";
                }
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            int donate_cat_id=2;
            string x = "";
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] != "")
                {
                    if (x == "")
                    {
                        x = d[i];
                    }
                    else
                    {
                        x += "," + d[i];

                       
                    }
                   
                }
            }
            sc.insert_organCompleted += sc_insert_organCompleted;
            sc.insert_organAsync(mail_block.Text, donate_cat_id, x,dt);
        }

        void sc_insert_organCompleted(object sender, insert_organCompletedEventArgs e)
        {
            if (e.Result == 1)
            {
                MessageBox.Show("Your Donation detail has been updated.");
            }
            else
            {

            }
        }

        private void tglPatientOrgan_Checked(object sender, RoutedEventArgs e)
        {
            Need_Organ_stack.Visibility = Visibility.Visible;
        }

        private void tglPatientOrgan_Unchecked(object sender, RoutedEventArgs e)
        {
            Need_Organ_stack.Visibility = Visibility.Collapsed;
        }

        private void needbld_btn_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dt = System.DateTime.Now;


            string x = "";

            if (NDAPO.IsChecked == true)
            {
                x =NDAPO.Content.ToString();
            }
            else if (NDBPO.IsChecked == true)
            {
                x = NDBPO.Content.ToString();
            }
            else if (NDABPO.IsChecked == true)
            {
                x = NDABPO.Content.ToString();
            }
            else if (NDOPO.IsChecked == true)
            {
                x = NDOPO.Content.ToString();
            }
            else if (NDANAG.IsChecked == true)
            {
                x = NDANAG.Content.ToString();
            }
            else if (NDBNAG.IsChecked == true)
            {
                x = NDBNAG.Content.ToString();
            }
            else if (NDABNAG.IsChecked == true)
            {
                x = NDABNAG.Content.ToString();
            }
            else if (NDONAG.IsChecked == true)
            {
                x = NDONAG.Content.ToString();
            }

            int donat_cat_id = 1;

            sc.insert_request_bloodCompleted += sc_insert_request_bloodCompleted;
            sc.insert_request_bloodAsync(mail_block.Text, donat_cat_id, x, dt);
        }

        void sc_insert_request_bloodCompleted(object sender, insert_request_bloodCompletedEventArgs e)
        {
            if (e.Result == 1)
            {
                MessageBox.Show("Your request has been updated.");
            }
            else
            {

            }
        }

        private void tglPaientBlood_Checked_1(object sender, RoutedEventArgs e)
        {
            Need_blood_stack.Visibility = Visibility.Visible;
        }

        private void tglPaientBlood_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Need_blood_stack.Visibility = Visibility.Collapsed;
        }

        private void chk2_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            pic_donation_sub_cat_tbl d1 = c.DataContext as pic_donation_sub_cat_tbl;
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == null)
                {
                    d[i] = d1.sub_cat_name;
                    break;
                }
            }
        }

        private void chk2_Unchecked_1(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            pic_donation_sub_cat_tbl d1 = c.DataContext as pic_donation_sub_cat_tbl;
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == d1.sub_cat_name)
                {
                    d[i] = "";
                }
            }
        }

        private void needorg_btn_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            int donate_cat_id = 2;
            string x = "";
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] != "")
                {
                    if (x == "")
                    {
                        x = d[i];
                    }
                    else
                    {
                        x += "," + d[i];


                    }

                }
            }
            sc.insert_request_organCompleted += sc_insert_request_organCompleted;
            sc.insert_request_organAsync(mail_block.Text, donate_cat_id, x, dt);
        }

        void sc_insert_request_organCompleted(object sender, insert_request_organCompletedEventArgs e)
        {
            if (e.Result == 1)
            {
                MessageBox.Show("Your request has been updated.");
            }
            else
            {

            }
        }

      

      
    }
}