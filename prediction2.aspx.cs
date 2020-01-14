using System;
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
    public string a,cr,soil,crops,crp="",l1,l2;
    public int len1, len2, i, j,l=0;
    double ans=0;
    string[] cro = new string[100];
    string[] cros = new string[12];
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
        //ddyear.DataSource = dt;
        //ddyear.DataBind();
        //ddyear.DataTextField = "year";
        //ddyear.DataValueField = "year";
        //ddyear.DataBind(); 
    }
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
        bind2();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(cs);
        using (SqlCommand cmd1 = new SqlCommand("select year,sum(rain) as rain from dbo.dataset where islands=@islands and place=@place and (month='june' or month='july' or month='august' or month='september' or month='october' or month='november' or month='december')   group by year", conn))
        {
            
            DataTable dt1 = new DataTable();
            cmd1.Parameters.AddWithValue("@islands", ddstate.SelectedValue);
            cmd1.Parameters.AddWithValue("@place", ddcity.SelectedValue);
            //cmd1.Parameters.AddWithValue("@year", ddyear.SelectedValue);
            //cmd1.Parameters.AddWithValue("@c_ward_id", DropDownList1.SelectedValue);
            using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
            {
                adp1.Fill(dt1);
            }
            year = dt1.Rows[0]["year"].ToString();
           // predict = dt1.Rows[0]["rain"].ToString();
            string[] x = new string[dt1.Rows.Count];
            double[] y = new double[dt1.Rows.Count];
            double su = 0;
            
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                su = su + Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                x[i] = dt1.Rows[i].ItemArray[0].ToString();
                y[i] = Convert.ToDouble(dt1.Rows[i].ItemArray[1]);
                x[dt1.Rows.Count - 1] = "2018";
                y[dt1.Rows.Count - 1] = ans;
                //Convert.ToDouble(dt1.Rows[i].ItemArray[1]);

                Chart2.ChartAreas[0].AxisX.Interval = 1;
                Chart2.Series["Series1"].Points.DataBindXY(x, y);

            }
            su = su / dt1.Rows.Count;
            predict = su.ToString();
            int su1 = Convert.ToInt32(su);
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            //double ssY = 0;
            double sumCodeviates = 0;
            //double sCo = 0;
            double count = dt1.Rows.Count;
            //double rsquared,yintercept,slope;
            double aa, b;
            for (int ctr = 0; ctr < dt1.Rows.Count; ctr++)
            {
                double xa = Double.Parse(dt1.Rows[ctr].ItemArray[0].ToString());
                double ya = Double.Parse(dt1.Rows[ctr].ItemArray[1].ToString());
                xa = xa % 2000;
                sumCodeviates += xa * ya;
                sumOfX += xa;
                sumOfY += ya;
                sumOfXSq += xa * xa;
                sumOfYSq += ya * ya;
            }

            aa = (((count * sumCodeviates) - (sumOfX * sumOfY)) / ((count * sumOfXSq) - (sumOfX * sumOfX)));
            b = ((1 / count) * (sumOfY - (aa * sumOfX)));
            ans = (aa * 18) + b;
            a = ans.ToString();
            ans = 0;
            
           
            //crop

            using (SqlCommand cmd2 = new SqlCommand("SELECT  [crop] FROM [rainfall_228].[dbo].[RSoil] where  [min rainfall]<=@est and [max rainfall]>=@est;", conn))
            {
                DataTable dt2 = new DataTable();
                cmd2.Parameters.Add("@est",a );
                using (SqlDataAdapter adp2 = new SqlDataAdapter(cmd2))  {
                    adp2.Fill(dt2);
                }
                 cr="";
                len1= dt2.Rows.Count;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    cro[i] = dt2.Rows[i].ItemArray[0].ToString();
                 
               cr = cr + cro[i];
               //cr = cr + " ";
                }
            }
            
            
            
            //soil
            using (SqlCommand cmd3 = new SqlCommand("SELECT  [soil] FROM [rainfall_228].[dbo].[CSoil] where state=@islands and city=@place  ;", conn))
            {
                DataTable dt3 = new DataTable();
                cmd3.Parameters.AddWithValue("@islands", ddstate.SelectedValue);
                cmd3.Parameters.AddWithValue("@place", ddcity.SelectedValue);
                using (SqlDataAdapter adp3 = new SqlDataAdapter(cmd3)){
                    adp3.Fill(dt3);
                }
                soil = dt3.Rows[0].ItemArray[0].ToString();
            }

//soil crop
            using (SqlCommand cmd4 = new SqlCommand("SELECT  [crop] FROM [rainfall_228].[dbo].[SCrop] where soil=@sol  ;", conn))
            {
                DataTable dt4 = new DataTable();
                cmd4.Parameters.AddWithValue("@sol", soil);
                using (SqlDataAdapter adp4 = new SqlDataAdapter(cmd4))
                {
                    adp4.Fill(dt4);
                }
            //    string[] cros = new string[10];
                crops = "";
                len2=dt4.Rows.Count;

                for (int i = 0; i < 12; i++)
                {
                    cros[i] = dt4.Rows[i].ItemArray[0].ToString();

                    crops = crops + ", " + cros[i];
                    
                }
                rptResults1.DataSource = cros;
                rptResults1.DataBind();

            }
            
            for (i = 0; i <len1 ; i++)
            {
                
                
                for (j = 0; j < 12; j++)
                {
                    string l1= cro[i];
                    string l2 = cros[j];
                   int  result = String.Compare(l1,l2);
                 
                    if (result==0)
                    {
                        crp = crp + cro[i];
                        crp = crp + ", ";
                        l++;
                        break;
                                              
                    }
                }
            } 









        }
    }
}