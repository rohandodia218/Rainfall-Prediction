using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Data.OleDb;

public partial class File_upload : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand comm;
    public SqlDataAdapter da;
    public DataSet ds;
    public System.IO.StreamReader sr;
    public string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
    public int user_id;
    public int D_id;
    public string filename;
    public string filepath;
    public int paragraphsEntered = 0;
    string wholeline = "";
    string[] line;
    OleDbConnection Econ;
    SqlConnection con;

    string constr, Query, sqlconn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_id"] == null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        conn.Open();
        SqlCommand comm = new SqlCommand("truncate table [dataset] ", conn);
        comm.ExecuteNonQuery();
        conn.Close();
        string ExcelContentType = "application/vnd.ms-excel";
        string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        if (FileUpload1.HasFile)
        {
            //Check the Content Type of the file 
            if (FileUpload1.PostedFile.ContentType == ExcelContentType || FileUpload1.PostedFile.ContentType == Excel2010ContentType)
            {
                //Save file path 
                string path = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName);
                //Save File as Temp then you can delete it if you want 
                FileUpload1.SaveAs(path);
                //string path = @"C:\Users\Johnney\Desktop\ExcelData.xls"; 
                //For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e 
                string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

                // Create Connection to Excel Workbook 
                using (OleDbConnection connection1 =
                             new OleDbConnection(excelConnectionString))
                {
                    OleDbCommand command = new OleDbCommand("Select [islands],[place],[year],[month],[rain]  FROM [Sheet1$]", connection1);

                    connection1.Open();
                    DataSet ds = new DataSet();
                    OleDbDataAdapter oda = new OleDbDataAdapter(command);
                    connection1.Close();
                    oda.Fill(ds);
                    DataTable Exceldt = ds.Tables[0];
                    connection();
                    SqlBulkCopy objbulk = new SqlBulkCopy(con);
                    //assigning Destination table name    
                    objbulk.DestinationTableName = "dataset";
                    //Mapping Table column    
                    objbulk.ColumnMappings.Add("islands", "islands");
                    objbulk.ColumnMappings.Add("place", "place");
                    objbulk.ColumnMappings.Add("year", "year");
                    objbulk.ColumnMappings.Add("month", "month");
                    objbulk.ColumnMappings.Add("rain", "rain");
                    //inserting Datatable Records to DataBase    
                    con.Open();
                    objbulk.WriteToServer(Exceldt);
                    con.Close();
                }
            }
        }
    }

    private void connection()
    {
        sqlconn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con = new SqlConnection(sqlconn);

    }


    //private void InsertExcelRecords(string FilePath)
    //{
    //    ExcelConn(FilePath);

    //    Query = string.Format("Select [islands],[place],[year],[month],[rain] FROM [{0}]", "Sheet1$");
    //    OleDbCommand Ecom = new OleDbCommand(Query, Econ);
    //    Econ.Open();

    //    DataSet ds = new DataSet();
    //    OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
    //    Econ.Close();
    //    oda.Fill(ds);
    //    DataTable Exceldt = ds.Tables[0];
    //    connection();
    //    //creating object of SqlBulkCopy    
    //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
    //    //assigning Destination table name    
    //    objbulk.DestinationTableName = "dataset";
    //    //Mapping Table column    
    //    objbulk.ColumnMappings.Add("islands", "islands");
    //    objbulk.ColumnMappings.Add("place", "place");
    //    objbulk.ColumnMappings.Add("year", "year");
    //    objbulk.ColumnMappings.Add("month", "month");
    //    objbulk.ColumnMappings.Add("rain", "rain");

    //    //inserting Datatable Records to DataBase    
    //    con.Open();
    //    objbulk.WriteToServer(Exceldt);
    //    con.Close();

    //}  
}