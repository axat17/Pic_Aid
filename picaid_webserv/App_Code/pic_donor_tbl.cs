using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for donate_tbl
/// </summary>
public class pic_donor_tbl
{
	public pic_donor_tbl()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int donor_id
    { get; set; }

    public string email_id
    { get; set; }

    public int cat_id
    { get; set; }

    public string type_of_donation
    { get; set; }

    public DateTime date_donation
    { get; set; }
}