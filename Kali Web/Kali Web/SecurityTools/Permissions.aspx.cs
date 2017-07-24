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
            Boolean IGAccess = false;
            Boolean VAAccess = false;
            Boolean PAAccess = false;

            foreach (GridViewRow row1 in GridView1.Rows)
            {
                String Id = row1.Cells[0].Text;
                CheckBox checkBox1 = row1.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = row1.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = row1.FindControl("PWA") as CheckBox;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();
                    // get all user's data from db to populate table based on permission (student)
                    string query = "SELECT * FROM [User] WHERE [Id] = @Id";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@Id", Id);


                    SqlDataReader reader = myCommand.ExecuteReader();

                    // read values in db, then  store into the variable

                    // this section requires rework
                    if (reader.Read())
                    {
                        VAAccess = (Boolean)reader["VAAccess"];
                        IGAccess = (Boolean)reader["IGAccess"];
                        PAAccess = (Boolean)reader["PWAccess"];


                        if (VAAccess == true && IGAccess == true && PAAccess == true)
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = true;
                            checkBox3.Checked = true;
                        }
                        else if (VAAccess == true && IGAccess == true && PAAccess == false)
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = true;
                            checkBox3.Checked = false;
                        }
                        else if (VAAccess == true && IGAccess == false && PAAccess == false)
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = false;
                            checkBox3.Checked = false;
                        }
                        else if (VAAccess == false && IGAccess == false && PAAccess == false)
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            checkBox3.Checked = false;
                        }
                        else if (VAAccess == false && IGAccess == false && PAAccess == true)
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            checkBox3.Checked = true;
                        }
                        else if (VAAccess == false && IGAccess == true && PAAccess == true)
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = true;
                            checkBox3.Checked = true;
                        }
                        else if (VAAccess == false && IGAccess == true && PAAccess == false)
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = true;
                            checkBox3.Checked = false;
                        }
                        else if (VAAccess == true && IGAccess == false && PAAccess == true)
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = false;
                            checkBox3.Checked = true;
                        }
                    }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row1 in GridView1.Rows)
            {
                CheckBox checkBox1 = row1.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = row1.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = row1.FindControl("PWA") as CheckBox;
                String Id = row1.Cells[0].Text;
                Boolean IGAccess = checkBox1.Checked;
                Boolean VAAccess = checkBox2.Checked;
                Boolean PWAccess = checkBox3.Checked;

                int IGA = 0;
                int VAA = 0;
                int PWA = 0;

                if (IGAccess == true)
                {
                    IGA = 1;

                    
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

                    string query = "UPDATE [User] SET [IGAccess] = @IGAccess, [VAAccess] = @VAAccess, [PWAccess] = @PWAccess WHERE [Id] = @Id";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@Id", Id);
                    myCommand.Parameters.AddWithValue("IGAccess", checkBox1.Checked);
                    myCommand.Parameters.AddWithValue("@VAAccess", checkBox2.Checked);
                    myCommand.Parameters.AddWithValue("@PWAccess", checkBox3.Checked);

                    myCommand.ExecuteNonQuery();
                }
            }
        }
    }
}