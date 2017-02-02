using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for patient_tbl
/// </summary>
public class pic_patient_tbl
{
	public pic_patient_tbl()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int patient_id
    { get; set; }

    public string email_id
    { get; set; }

    public int cat_id
    { get; set; }

    public string type_of_need
    { get; set; }

    public DateTime date_request
    { get; set; }
}