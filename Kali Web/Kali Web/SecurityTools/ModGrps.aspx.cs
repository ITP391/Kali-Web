using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Kali_Web.SecurityTools
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Uses global variable to check for session. This part checks if permission is lect, if it is student,
            // redirect to Student's Home Page
            String permission = Kali_Web.Account.Login.globaldbpermission;

            if (permission == null || permission == "")
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else if (permission == "student")
            {
                Response.Redirect("HomeStud.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row1 in GridView1.Rows)
            {
                CheckBox checkBox1 = row1.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = row1.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = row1.FindControl("PWA") as CheckBox;
                String ModGrp = row1.Cells[0].Text; ;
                Boolean IGAccess = checkBox1.Checked;
                Boolean VAAccess = checkBox2.Checked;
                Boolean PWAccess = checkBox3.Checked;

                int IGA = 0;
                int VAA = 0;
                int PWA = 0;

                if (IGAccess == true)
                {
                    IGA = 1;
                    checkBox1.Checked = true;

                    if (VAAccess == true)
                    {
                        VAA = 1;

                        if (PWAccess == true)
                        {
                            PWA = 1;
                        }
                    }
                }


                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();

                    string query = "UPDATE [User] SET [IGAccess] = @IGAccess, [VAAccess] = @VAAccess, [PWAccess] = @PWAccess WHERE [ModGrp] = @ModGrp";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@ModGrp", ModGrp);
                    myCommand.Parameters.AddWithValue("IGAccess", checkBox1.Checked);
                    myCommand.Parameters.AddWithValue("@VAAccess", checkBox2.Checked);
                    myCommand.Parameters.AddWithValue("@PWAccess", checkBox3.Checked);

                    myCommand.ExecuteNonQuery();
                }
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox1 = e.Row.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = e.Row.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = e.Row.FindControl("PWA") as CheckBox;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
        }
    }
}