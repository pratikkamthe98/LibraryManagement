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
    public partial class UserManagement : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            displayUserData();
        }


        void displayUserData()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            SqlCommand cmd = new SqlCommand("procUsersList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grdUserList.DataSource = dt;
            grdUserList.DataBind();

        }





        void deleteUser()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procDeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@UserID", Session["UserID"]);
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('User Deleted Successfully');</script>");
            con.Close();
            grdUserList.DataBind();
            displayUserData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdUserList.Rows[rowIndex];

                Session["UserID"] = Convert.ToInt32(((Label)row.FindControl("grdlblUserID")).Text.ToString());
                Response.Redirect("~/UpdateUser.aspx");

            }
            else if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdUserList.Rows[rowIndex];

                Session["UserID"] = Convert.ToInt32(((Label)row.FindControl("grdlblUserID")).Text.ToString());
                deleteUser();

            }
        }
    }
}