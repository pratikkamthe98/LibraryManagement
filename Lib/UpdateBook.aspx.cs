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
    public partial class UpdateBook : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBookDetails();
            }


        }
        private void getBookDetails()
        {

            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("procBookDetails ", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@BookID", Session["BookID"]);
            cmd.Parameters.Add(p1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                txtBookName.Text = dt.Rows[0]["BookName"].ToString();
                txtAuthorName.Text = dt.Rows[0]["AuthorName"].ToString();
                ddlLanguageList.SelectedValue = dt.Rows[0]["Language"].ToString();
                ddlGenreList.SelectedValue = dt.Rows[0]["Genre"].ToString();
                txtPublisherName.Text = dt.Rows[0]["PublisherName"].ToString();
                txtPublishDate.Text = dt.Rows[0]["PublishDate"].ToString();
                txtBookEdition.Text = dt.Rows[0]["BookEdition"].ToString();
                txtBookDescription.Text = dt.Rows[0]["BookDescription"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No Data');</script>");

            }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("procUpdateBookDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@BookID", Session["BookID"]);
            cmd.Parameters.Add(p1);
            cmd.Parameters.AddWithValue("@BookName", txtBookName.Text.Trim());
            cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text.Trim());
            cmd.Parameters.AddWithValue("@Language", ddlLanguageList.SelectedValue);
            cmd.Parameters.AddWithValue("@Genre", ddlGenreList.SelectedValue);
            cmd.Parameters.AddWithValue("@PublisherName", txtPublisherName.Text.Trim());
            cmd.Parameters.AddWithValue("@PublishDate", txtPublishDate.Text.Trim());
            cmd.Parameters.AddWithValue("@BookEdition", txtBookEdition.Text.Trim());
            cmd.Parameters.AddWithValue("@BookDescription", txtBookDescription.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Book Updated Successfully');</script>");
            Response.Redirect("~/BookManagement.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookManagement.aspx");
        }

        void addBook()
        {


            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procAddBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookName", txtBookName.Text.Trim());
            cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text.Trim());
            cmd.Parameters.AddWithValue("@Language", ddlLanguageList.SelectedValue);
            cmd.Parameters.AddWithValue("@Genre", ddlGenreList.SelectedValue);
            cmd.Parameters.AddWithValue("@PublisherName", txtPublisherName.Text.Trim());
            cmd.Parameters.AddWithValue("@PublishDate", txtPublishDate.Text.Trim());
            cmd.Parameters.AddWithValue("@BookEdition", txtBookEdition.Text.Trim());
            cmd.Parameters.AddWithValue("@BookDescription", txtBookDescription.Text.Trim());


            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Book Added Successfully');</script>");



        }


    }
}