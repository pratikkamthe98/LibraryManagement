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
    public partial class UpdateUser : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserDetails();
            }
        }
        void getUserDetails()
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@UserID", Session["UserID"]);
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtFullName.Text = dt.Rows[0]["FullName"].ToString();
            txtDateOfBirth.Text = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]).ToString("yyyy-MM-dd");
            txtMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtPassword.Text = dt.Rows[0]["Password"].ToString();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("procUpdateUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@UserID", Session["UserID"]);
            cmd.Parameters.Add(p);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
            cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text.Trim());
            cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('User Details Updated Successfully...!!!');</script>");

            Response.Redirect("~/UserManagement.aspx");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement.aspx");
        }

    }
}