using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Kali_Web.Security_Tools
{
    public partial class StudList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Permission] = @Permission";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@Permission", "student");


                SqlDataReader reader = myCommand.ExecuteReader();

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row1 in GridView1.Rows)
            {
                CheckBox checkBox1 = row1.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = row1.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = row1.FindControl("PWA") as CheckBox;
                String Id = row1.Cells[0].Text; ;
                Boolean IGAccess = checkBox1.Checked;
                Boolean VAAccess = checkBox2.Checked;
                Boolean PWAccess = checkBox3.Checked;

                int IGA = 0;
                int VAA = 0;
                int PWA = 0;

                if (checkBox1.Checked == true)
                {
                    IGA = 1;
                }
                else if (checkBox2.Checked == true)
                {
                    VAA = 1;
                }
                else if (checkBox3.Checked == true)
                {
                    PWA = 1;
                }
                

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();

                    string query = "UPDATE [User] SET [IGAccess] = @IGAccess, [VAAccess] = @VAAccess, [PWAccess] = @PWAccess WHERE [Id] = @Id";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@Id", Id);
                    myCommand.Parameters.AddWithValue("IGAccess", IGA);
                    myCommand.Parameters.AddWithValue("@VAAccess", VAA);
                    myCommand.Parameters.AddWithValue("@PWAccess", PWA);
                }
            }
        }
    }
}