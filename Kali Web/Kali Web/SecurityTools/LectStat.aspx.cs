using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.SecurityTools
{
    public partial class LectStat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();
                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();

                myConnection.Close();
                return;
            }
        }
    }
}