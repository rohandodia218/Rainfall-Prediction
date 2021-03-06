﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ResultGraph : System.Web.UI.Page
{
    public string year;
    public string predict;
    public string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_id"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            bind1();
            //bind2();
            //bind4();
        }
    }
    public void bind1()
    {
        SqlConnection con = new SqlConnection(cs);
        
        SqlCommand cmd = new SqlCommand("Select DISTINCT islands from dataset", con);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddstate.DataSource = dt;
        ddstate.DataBind();
        ddstate.DataTextField = "islands";
        ddstate.DataValueField = "islands";
        ddstate.DataBind();  
    }
   // public void bind2() { }
    //{
    //    SqlConnection con = new SqlConnection(cs);
    //    SqlCommand cmd = new SqlCommand("select distinct(year) from dataset", con);
    //    cmd.Parameters.AddWithValue("islands", ddstate.SelectedValue);
    //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adpt.Fill(dt);
    //    ddyear.DataSource = dt;
    //    ddyear.DataBind();
    //    ddyear.DataTextField = "year";
    //    ddyear.DataValueField ="year";
    //    ddyear.DataBind(); 
    //}
    //public void bind3()
    //{
    //    SqlConnection con = new SqlConnection(cs);
    //    SqlCommand cmd = new SqlCommand("Select DISTINCT month from dataset", con);
    //    //cmd.Parameters.AddWithValue("islands", ddstate.SelectedValue);
    //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adpt.Fill(dt);
    //    ddmonth.DataSource = dt;
    //    ddmonth.DataBind();
    //    ddmonth.DataTextField = "month";
    //    ddmonth.DataValueField = "month";
    //    ddmonth.DataBind(); 
    //}
    //public void bind4()
    //{
    //    SqlConnection con = new SqlConnection(cs);
    //    SqlCommand cmd = new SqlCommand("Select DISTINCT year from dataset", con);
    //    //cmd.Parameters.AddWithValue("islands", ddstate.SelectedValue);
    //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adpt.Fill(dt);
    //    ddyear.DataSource = dt;
    //    ddyear.DataBind();
    //    ddyear.DataTextField = "year";
    //    ddyear.DataValueField = "year";
    //    ddyear.DataBind();
    //}

    protected void ddstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind2();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(cs);
        using (SqlCommand cmd1 = new SqlCommand("select year,sum(rain) as rain from dbo.dataset where islands=@islands  group by year order by year", conn))
        {
            
            DataTable dt1 = new DataTable();
            cmd1.Parameters.AddWithValue("@islands", ddstate.SelectedValue);
           // cmd1.Parameters.AddWithValue("@year", ddyear.SelectedValue);
            //cmd1.Parameters.AddWithValue("@month", ddmonth.SelectedValue);
            //cmd1.Parameters.AddWithValue("@c_ward_id", DropDownList1.SelectedValue);
            using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
            {
                adp1.Fill(dt1);
            }
            double su = 0;
            year = dt1.Rows[0]["year"].ToString();
            
            string[] x = new string[dt1.Rows.Count];
            double[] y = new double[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                su = su + Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                x[i] = dt1.Rows[i].ItemArray[0].ToString();
                y[i] = Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                    //Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                Chart2.ChartAreas[0].AxisX.Interval = 1;
                Chart2.Series["Series1"].Points.DataBindXY(x, y);
              


            }
            su = su / dt1.Rows.Count;
            predict = su.ToString();

        }
    }
}