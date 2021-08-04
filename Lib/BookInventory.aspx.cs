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
    public partial class BookInventory : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                displayData();
            }

        }

        protected void GetDetails_Click(object sender, EventArgs e)
        {
            getNames();

        }

        protected void IssueBook_Click(object sender, EventArgs e)
        {

            if (checkUser() && checkBook())
            {

                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This User already has this book');</script>");
                }
                else
                {
                    issueBook();
                    displayData();
                }


            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or User ID');</script>");
            }

        }


        void displayData()
        {

            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            SqlCommand cmd = new SqlCommand("procIssuedBookList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grdIssuedBookList.DataSource = dt;
            grdIssuedBookList.DataBind();

        }
        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("procCheckIfIssueEntryExist", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@UserID", txtUserID.Text.Trim());
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@BookID", txtBookID.Text.Trim());
                cmd.Parameters.Add(p2);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        bool checkBook()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procGetBookName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@BookID", txtBookID.Text.Trim());
            cmd.Parameters.Add(p);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool checkUser()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procGetUserName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@UserID", txtUserID.Text.Trim());
            cmd.Parameters.Add(p);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        void issueBook()
        {

            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("procIssueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", txtUserID.Text.Trim());
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
            cmd.Parameters.AddWithValue("@BookID", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@BookName", txtBookName.Text.Trim());
            cmd.Parameters.AddWithValue("@IssueDate", txtIssueDate.Text.Trim());
            cmd.Parameters.AddWithValue("@ReturnDate", txtReturnDate.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Book Issued Successfully');</script>");

        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("procReturnBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@UserID", Session["IssuedUserID"]);
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@BookID", Session["IssuedBookID"]);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Book Returned Successfully');</script>");
                con.Close();
                grdIssuedBookList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("procGetBookName", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@BookID", txtBookID.Text.Trim());
                cmd1.Parameters.Add(p1);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count >= 1)
                {
                    txtBookName.Text = dt1.Rows[0]["BookName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }

                SqlCommand cmd = new SqlCommand("procGetUserName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p2 = new SqlParameter("@UserID", txtUserID.Text.Trim());
                cmd.Parameters.Add(p2);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");
                }


            }
            catch (Exception ex)
            {

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdIssuedBookList.Rows[rowIndex];

                Session["IssuedUserID"] = Convert.ToInt32(((Label)row.FindControl("grdlblUserID")).Text.ToString());
                Session["IssuedBookID"] = Convert.ToInt32(((Label)row.FindControl("grdlblBookID")).Text.ToString());
                returnBook();
                displayData();

            }
        }

    }
}