using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for pic_src
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class pic_src : System.Web.Services.WebService
{

    public pic_src()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";

    }
    SqlConnection cnn;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;

    [WebMethod]
    public int sign_up(string email_id, string f_name, string pwd, string mobile, string gen, string city,string dob)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into pic_user_tbl(email_id,pwd,f_name,mobile,gen,city,dob) values (@email_id,@pwd,@f_name,@mobile,@gen,@city,@dob)";
        cmd.Parameters.AddWithValue("@email_id", email_id);
        cmd.Parameters.AddWithValue("@pwd", pwd);
        cmd.Parameters.AddWithValue("@f_name", f_name);
        cmd.Parameters.AddWithValue("@mobile", mobile);
        cmd.Parameters.AddWithValue("@gen", gen);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@dob", dob);

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        return flag = 1;
    }
    [WebMethod]
    public int chk_usr_pass(string pwd, string email_id)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_user_tbl where email_id='" + email_id + "' AND pwd='" + pwd + "' ";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        if (dt.Rows.Count == 1)
        {
            flag = 1;
        }
        return flag;
    }
    [WebMethod]
    public List<pic_user_tbl>user_detail(string email_id)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_user_tbl where email_id='" + email_id + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_user_tbl> s = new List<pic_user_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_user_tbl()
            {
                email_id = dt.Rows[i]["email_id"].ToString(),
                f_name = dt.Rows[i]["f_name"].ToString(),
                mobile = dt.Rows[i]["mobile"].ToString(),
                gen = dt.Rows[i]["gen"].ToString(),
                city = dt.Rows[i]["city"].ToString(),
                dob = dt.Rows[i]["dob"].ToString()
            });

        }
        return s;
    }
    [WebMethod]
    public List<pic_hos_cat_tbl> get_hos_cat()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_hos_cat";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_hos_cat_tbl> s = new List<pic_hos_cat_tbl>();
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_hos_cat_tbl()
            {
                hos_cat_name = dt.Rows[i]["hos_cat_name"].ToString(),
                hos_cat_id =Convert.ToInt32(dt.Rows[i]["hos_cat_id"].ToString())
            });
        }
        return s;
    }
    [WebMethod]
    public List<pic_doc_cat_tbl> get_doc_cat()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_doc_cat";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_doc_cat_tbl> s = new List<pic_doc_cat_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_doc_cat_tbl()
            {
                doc_cat_name = dt.Rows[i]["doc_cat_name"].ToString(),
                doc_cat_id = Convert.ToInt32(dt.Rows[i]["doc_cat_id"].ToString())
            });
        }
        return s;
    }
    [WebMethod]
    public List<pic_hospital_tbl> get_hos_by_id(string hos_cat_id)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_hospital where hos_cat_id='" + hos_cat_id + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_hospital_tbl> s = new List<pic_hospital_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_hospital_tbl()
            {
                hos_id = Convert.ToInt32(dt.Rows[i]["hos_id"].ToString()),
                hos_name = dt.Rows[i]["hos_name"].ToString(),
                hos_for = dt.Rows[i]["hos_for"].ToString(),
            });

        }
        return s;
    }

    [WebMethod]
    public List<pic_hospital_tbl> get_hos_for_multi()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_hospital where hos_cat_id='" + 1 + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_hospital_tbl> s = new List<pic_hospital_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_hospital_tbl()
            {
                hos_id = Convert.ToInt32(dt.Rows[i]["hos_id"].ToString()),
                hos_name = dt.Rows[i]["hos_name"].ToString(),
                hos_for = dt.Rows[i]["hos_for"].ToString(),
            });

        }
        return s;
    }
    [WebMethod]
    public List<pic_doctor_tbl> get_doc_by_id(string doc_cat_id)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_doctor where doc_cat_id='" + doc_cat_id + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_doctor_tbl> s = new List<pic_doctor_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_doctor_tbl()
            {
                doc_id = Convert.ToInt32(dt.Rows[i]["doc_id"].ToString()),
                doc_name = dt.Rows[i]["doc_name"].ToString(),
                doc_for = dt.Rows[i]["doc_for"].ToString(),

            });

        }
        return s;
    }

    [WebMethod]
    public List<pic_hospital_tbl> hos_dtl_by_list(string hos_id)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_hospital where hos_id='" + hos_id + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_hospital_tbl> s = new List<pic_hospital_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_hospital_tbl()
            {
                hos_id = Convert.ToInt32(dt.Rows[i]["hos_id"].ToString()),
                hos_name = dt.Rows[i]["hos_name"].ToString(),
                hos_for = dt.Rows[i]["hos_for"].ToString(),
                address = dt.Rows[i]["address"].ToString(),
                area = dt.Rows[i]["area"].ToString(),
                city = dt.Rows[i]["city"].ToString(),
                contact_1 = dt.Rows[i]["contact_1"].ToString(),
                contact_2 = dt.Rows[i]["contact_2"].ToString(),
                email_id = dt.Rows[i]["email_id"].ToString(),
                
            });

        }
        return s;
    }

    [WebMethod]
    public List<pic_doctor_tbl> doc_dtl_by_list(string doc_id)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_doctor where doc_id='" + doc_id + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_doctor_tbl> s = new List<pic_doctor_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_doctor_tbl()
            {
                doc_id = Convert.ToInt32(dt.Rows[i]["doc_id"].ToString()),
                doc_name = dt.Rows[i]["doc_name"].ToString(),
                doc_for = dt.Rows[i]["doc_for"].ToString(),
                doc_hos_add = dt.Rows[i]["doc_hos_add"].ToString(),
                area = dt.Rows[i]["area"].ToString(),
                city_doc = dt.Rows[i]["city_doc"].ToString(),
                contact = dt.Rows[i]["contact"].ToString(),
                email_id = dt.Rows[i]["email_id"].ToString(),

            });

        }
        return s;
    }
    [WebMethod]
    public List<pic_donation_sub_cat_tbl> get_donation_type()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "select * from pic_donation_sub_cat where cat_id='" + 2 + "'";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<pic_donation_sub_cat_tbl> s = new List<pic_donation_sub_cat_tbl>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            s.Add(new pic_donation_sub_cat_tbl()
            {
                sub_cat_id = Convert.ToInt32(dt.Rows[i]["sub_cat_id"].ToString()),
                sub_cat_name = dt.Rows[i]["sub_cat_name"].ToString(),
                cat_id = Convert.ToInt32(dt.Rows[i]["cat_id"].ToString()),             
            });

        }
        return s;
    }
    [WebMethod]
    public int insert_blood(string email_id, int cat_id, string type_of_donation,DateTime date_donation)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into pic_donor_tbl(email_id,cat_id,type_of_donation,date_donation) values (@email_id,@cat_id, @type_of_donation,@date_donation)";
        cmd.Parameters.AddWithValue("@email_id", email_id);
        cmd.Parameters.AddWithValue("@cat_id", cat_id);
        cmd.Parameters.AddWithValue("@type_of_donation", type_of_donation);
        cmd.Parameters.AddWithValue("@date_donation",date_donation);
      
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        return flag = 1;
    }
    [WebMethod]
    public int insert_organ(string email_id, int cat_id, string type_of_donation,DateTime date_donation)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into pic_donor_tbl(email_id,cat_id,type_of_donation,date_donation) values (@email_id,@cat_id, @type_of_donation,@date_donation)";
        cmd.Parameters.AddWithValue("@email_id", email_id);
        cmd.Parameters.AddWithValue("@cat_id", cat_id);
        cmd.Parameters.AddWithValue("@type_of_donation", type_of_donation);
        cmd.Parameters.AddWithValue("@date_donation", date_donation);

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        return flag = 1;
    }
    [WebMethod]
    public int insert_request_blood(string email_id, int cat_id, string type_of_need, DateTime date_request)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into pic_patient_tbl(email_id,cat_id,type_of_need,date_request) values (@email_id,@cat_id, @type_of_need,@date_request)";
        cmd.Parameters.AddWithValue("@email_id", email_id);
        cmd.Parameters.AddWithValue("@cat_id", cat_id);
        cmd.Parameters.AddWithValue("@type_of_need", type_of_need);
        cmd.Parameters.AddWithValue("@date_request", date_request);

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        return flag = 1;
    }
    [WebMethod]
    public int insert_request_organ(string email_id, int cat_id, string type_of_need, DateTime date_request)
    {
        int flag = 0;
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into pic_patient_tbl(email_id,cat_id,type_of_need,date_request) values (@email_id,@cat_id, @type_of_need,@date_request)";
        cmd.Parameters.AddWithValue("@email_id", email_id);
        cmd.Parameters.AddWithValue("@cat_id", cat_id);
        cmd.Parameters.AddWithValue("@type_of_need", type_of_need);
        cmd.Parameters.AddWithValue("@date_request", date_request);

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        return flag = 1;
    }


    //[WebMethod]
    //public int blood_dtl(string email_id, string type_of_blood, string donate_cat_id="1")
    //{
    //    int flag = 0;
    //    cnn = new SqlConnection();
    //    cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
    //    cmd = new SqlCommand();
    //    cmd.Connection = cnn;
    //    cmd.CommandText = "insert into donor_blood(email_id, type_of_blood,donate_cat_id) values (@email_id,@type_of_blood,@donate_cat_id)";
    //    cmd.Parameters.AddWithValue("@email_id", email_id);
    //    cmd.Parameters.AddWithValue("@type_of_blood", type_of_blood);
    //    cmd.Parameters.AddWithValue("@donate_cat_id", donate_cat_id);

    //    cnn.Open();
    //    cmd.ExecuteNonQuery();
    //    cnn.Close();
    //    return flag = 1;
    //}

    //[WebMethod]

    //public int (string email_id, string pwd, string mobile,string gen,string city)
    //{
    //    int flag = 0;
    //    cnn = new SqlConnection();
    //    cnn.ConnectionString = ConfigurationManager.ConnectionStrings["picaid_dbConnectionString1"].ConnectionString;
    //    cmd = new SqlCommand();
    //    cmd.Connection = cnn;
    //    cmd.CommandText = "update user_tbl set pwd = @pwd, mobile = @mobile,gen=@gen,city=@city where email_id= '"+ email_id +"' ";
    //    cmd.Parameters.AddWithValue("@pwd", pwd);
    //    cmd.Parameters.AddWithValue("@mobile", mobile);
    //    cmd.Parameters.AddWithValue("@gen", gen);
    //    //cmd.Parameters.AddWithValue("@image", img);
    //    cmd.Parameters.AddWithValue("@city", city);
    //    cnn.Open();
    //    cmd.ExecuteNonQuery();
    //    cnn.Close();
    //    return flag = 1;
    //}

    //}    

}