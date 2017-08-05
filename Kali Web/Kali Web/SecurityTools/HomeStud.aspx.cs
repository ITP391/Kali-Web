using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kali_Web.Announcements;
using System.Web.UI.HtmlControls;

namespace Kali_Web.SecurityTools.ToolUI
{
    public partial class HomeStud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var announcementList = new List<Announcement>();

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

            String sessionemail = (String) Session["email"];


            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", sessionemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    VAA.Visible = (Boolean) reader["VAAccess"];
                    IGA.Visible = (Boolean) reader["IGAccess"];
                    PWA.Visible = (Boolean) reader["PWAccess"];
                }
            }

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = " SELECT *" +
                               " FROM [dbo].[Announcements] a";

                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = int.Parse(reader["Id"].ToString());
                        var description = reader["Description"].ToString();
                        var startDate = DateTime.Parse(reader["StartDate"].ToString()).ToShortDateString();
                        var endDate = DateTime.Parse(reader["EndDate"].ToString()).ToShortDateString();

                        announcementList.Add(new Announcement(id, description, startDate, endDate));
                    }
                }

                AnnouncementRepeater.DataSource = announcementList;
                AnnouncementRepeater.DataBind();
            }

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT COUNT(DISTINCT Category) AS Count FROM [QuizzResult] WHERE [UserId] = (SELECT Id FROM [User] WHERE [Email_Address]= @email)";
                //string query = "SELECT COUNT(DISTINCT Category) AS Count FROM [QuizzResult] WHERE [UserId] = 4";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", sessionemail);
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    double noOfTest = double.Parse(reader["Count"].ToString());
                    double percentage = (noOfTest / 3) * 100;
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("id", "bar");
                    div.Attributes.Add("Style", "background-color: #0a0; width:"+percentage+"% ; text-align:center; text-color:#000;");

                    HtmlGenericControl divTxt = new HtmlGenericControl("div");
                    divTxt.Attributes.Add("id", "barTxt");
                    divTxt.InnerHtml = Math.Truncate(percentage) + "%";
                    divTxt.Attributes.Add("Style", "text=align:center;");
                    div.Controls.Add(divTxt);
                    meter.Controls.Add(div);
                }
            }
        }
    }
}  