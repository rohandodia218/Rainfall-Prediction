using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class login : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand comm;
    public SqlDataAdapter da;
    public DataSet ds;
    public string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
    public int user_id;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string u = Convert.ToString(txtUsername.Text);
        string p = Convert.ToString(txtPassword.Text);

        conn = new SqlConnection(cs);
        conn.Open();
        da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection = conn;
        da.SelectCommand.CommandText = "select * from admin_master where username=@u and password=@p";
        da.SelectCommand.CommandType = CommandType.Text;
        da.SelectCommand.Parameters.AddWithValue("@u", u);
        da.SelectCommand.Parameters.AddWithValue("@p", p);
        ds = new DataSet();
        da.Fill(ds, "admin_master");
        if (ds.Tables["admin_master"].Rows.Count == 0)
        {
            lblShow.Text = "Invalid Username and password";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }
        else
        {
            user_id = Convert.ToInt32(ds.Tables["admin_master"].Rows[0]["aid"]);
            Session["a_id"] = user_id;
            Response.Redirect("home.aspx");
        }

    }
}