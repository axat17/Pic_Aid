using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for doctor_tbl
/// </summary>
public class pic_doctor_tbl
{
	public pic_doctor_tbl()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int doc_id
    { get; set; }

    public string doc_name
    { get; set; }

    public int doc_cat_id
    { get; set; }

    public string doc_hos_add
    { get; set; }

    public string contact
    { get; set; }

    public string email_id
    { get; set; }

    public string city_doc
    { get; set; }

    public string area
    { get; set; }

    public string doc_for
    { get; set; }
}