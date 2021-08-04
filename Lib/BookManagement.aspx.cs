using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lib
{
    public partial class BookManagement : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                displayBooks();
            }
        }
        void displayBooks()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            SqlCommand cmd = new SqlCommand("procBookList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grdBookList.DataSource = dt;
            grdBookList.DataBind();
        }








        void deleteBook()
        {

            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procDeleteBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@BooKID", Session["BookID"]);
            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Book Deleted Successfully');</script>");
            con.Close();
            grdBookList.DataBind();
        }







        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdBookList.Rows[rowIndex];

                Session["BookID"] = Convert.ToInt32(((Label)row.FindControl("grdlblBookID")).Text.ToString());
                Response.Redirect("~/UpdateBook.aspx");

            }
            else if (e.CommandName == "Return")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdBookList.Rows[rowIndex];

                Session["BookID"] = Convert.ToInt32(((Label)row.FindControl("grdlblBookID")).Text.ToString());

                deleteBook();

            }
        }














    }

}