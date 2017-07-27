﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NotLoggedIn.Visible = false;
            LoggedInStud.Visible = false;
            LoggedInLect.Visible = false;

            if (Session["email"] != null)
            {
                String permission = "";
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();
                    string query = "SELECT * FROM [User] WHERE [Email_Address] = @Email";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@Email", (String)Session["email"]);


                    SqlDataReader reader = myCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        permission = reader["Permission"].ToString();
                    }
                }

                if (permission.Equals("student"))
                {
                    LoggedInStud.Visible = true;
                }
                else if (permission.Equals("lecturer"))
                {
                    LoggedInLect.Visible = true;
                }
            }
            else
            {
                NotLoggedIn.Visible = true;
            }
        }
    }
}