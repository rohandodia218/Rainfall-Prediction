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
            bind3();
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
    public void bind2()
    {
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("select distinct(place) from dataset where islands=@islands", con);
        cmd.Parameters.AddWithValue("islands", ddstate.SelectedValue);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddcity.DataSource = dt;
        ddcity.DataBind();
        ddcity.DataTextField = "place";
        ddcity.DataValueField = "place";
        ddcity.DataBind(); 
    }
    public void bind3()
    {
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand("Select DISTINCT year from dataset order by year", con);
        //cmd.Parameters.AddWithValue("islands", ddstate.SelectedValue);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddyear.DataSource = dt;
        ddyear.DataBind();
        ddyear.DataTextField = "year";
        ddyear.DataValueField = "year";
        ddyear.DataBind(); 
    }

    protected void ddstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind2();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(cs);
        using (SqlCommand cmd1 = new SqlCommand("select dmy,avg(rain) from dbo.dataset where islands=@islands and place=@place and year=@year group by dmy", conn))
        {

            DataTable dt1 = new DataTable();
            cmd1.Parameters.AddWithValue("@islands", ddstate.SelectedValue);
            cmd1.Parameters.AddWithValue("@place", ddcity.SelectedValue);
            cmd1.Parameters.AddWithValue("@year", ddyear.SelectedValue);
            //cmd1.Parameters.AddWithValue("@c_ward_id", DropDownList1.SelectedValue);
            using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
            {
                adp1.Fill(dt1);
            }
            string[] x = { "January", "Febuary", "March", "April","May","June","July","August","September","October","November","December" };

            
            double[] y = new double[dt1.Rows.Count];
            
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //x[i] = 
                y[i] = Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                Chart3.ChartAreas[0].AxisX.Interval = 1;
                Chart3.Series["Series1"].Points.DataBindXY(x, y);

            }
        }
    }
}