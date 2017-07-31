using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.SecurityTools.ToolUI
{
    public partial class HomeStud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String permission = (String)Session["permission"];
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else if (permission == "lecturer")
            {
                Response.Redirect("HomeLect.aspx");
            }

            String sessionemail = (String)Session["email"];


            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", sessionemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    VAA.Visible = (Boolean)reader["VAAccess"];
                    IGA.Visible = (Boolean)reader["IGAccess"];
                    PWA.Visible = (Boolean)reader["PWAccess"];
                }
            }
        }
    }
}