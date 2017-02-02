using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for user_tbl
/// </summary>
public class pic_user_tbl
{
	public pic_user_tbl()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string email_id
    { get; set; }

    public string f_name
    { get; set; }

    public string pwd
    { get; set; }

    public string mobile
    { get; set; }

    public string  gen
    { get; set; }

    public byte[]  img
    { get; set; }

    public string city
    { get; set; }

    public string dob
    { get; set; }

}