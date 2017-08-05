using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.SecurityTools
{
    public partial class QuizDetails : System.Web.UI.Page
    {
        int totalMarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                //String sessionemail = (String)Session["email"];
                String sessionemail = Kali_Web.Account.Login.globalinputemail;
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    string query = "SELECT COUNT(DISTINCT Category) AS Count FROM [QuizzResult] WHERE [UserId] = (SELECT Id FROM [User] WHERE [Email_Address]= @email)";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@email", sessionemail);
                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (totalMarks < 4)
                    {
                        grade.Text = "F";
                    }
                    if ((totalMarks > 3) && (totalMarks < 6))
                    {
                        grade.Text = "C";
                    }
                    if ((totalMarks > 5) && (totalMarks < 8))
                    {
                        grade.Text = "B";
                    }
                    else
                    {
                        grade.Text = "A";
                    }
                }
            }
        }
    }
}