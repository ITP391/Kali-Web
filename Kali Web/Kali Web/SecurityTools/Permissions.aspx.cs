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
            if (!IsPostBack)
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
                            checkBox1.Checked = (Boolean)reader["VAAccess"];
                            checkBox2.Checked = (Boolean)reader["IGAccess"];
                            checkBox3.Checked = (Boolean)reader["PWAccess"];
                        }
                    }

                }

            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row2 in GridView1.Rows)
            {
                CheckBox checkBox1 = row2.FindControl("IGAcc") as CheckBox;
                CheckBox checkBox2 = row2.FindControl("VAA") as CheckBox;
                CheckBox checkBox3 = row2.FindControl("PWA") as CheckBox;
                String Id = row2.Cells[0].Text;
                bool IGAccess1 = checkBox1.Checked;
                bool VAAccess2 = checkBox2.Checked;
                bool PWAccess3 = checkBox3.Checked;
                
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();

                    string query = "UPDATE [User] SET [IGAccess] = @IGAccess, [VAAccess] = @VAAccess, [PWAccess] = @PWAccess WHERE [Id] = @Id";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@Id", Id);
                    myCommand.Parameters.AddWithValue("IGAccess", IGAccess1);
                    myCommand.Parameters.AddWithValue("@VAAccess", VAAccess2);
                    myCommand.Parameters.AddWithValue("@PWAccess", PWAccess3);

                    myCommand.ExecuteNonQuery();
                }
            }
        }
    }
}