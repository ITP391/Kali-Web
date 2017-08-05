using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Announcements
{
    public partial class AnswerAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myConnection = new SqlConnection();

            var announcementId = Request.QueryString["announcementId"];

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = " SELECT *" +
                               " FROM [dbo].[Announcements] a" +
                               " WHERE a.Id = @Id";

                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("Id", announcementId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = int.Parse(reader["Id"].ToString());
                        var description = reader["Description"].ToString();
                        var startDate = DateTime.Parse(reader["StartDate"].ToString()).ToShortDateString();
                        var endDate = DateTime.Parse(reader["EndDate"].ToString()).ToShortDateString();

                        AnnouncementDescription.Text = description + "( from " + startDate + " until " + endDate + ")";
                    }
                }
            }
        }

        protected void AnswerAnnouncement_Callback(object sender, EventArgs e)
        {
            var announcementId = Request.QueryString["announcementId"];

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                // Query for inserting the question
                string query =
                    "INSERT INTO [dbo].[AnnouncementAnswer]" +
                    "(UserId, AnnouncementId, Response)";
                query += " VALUES (@UserId, @AnnouncementId, @Response)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("UserId", Session["id"].ToString());
                myCommand.Parameters.AddWithValue("AnnouncementId", announcementId);
                myCommand.Parameters.AddWithValue("Response", AnswerTextBox.Text);

                myCommand.ExecuteNonQuery();
            }

            // Redirect to the page where we show all questions
            Response.Redirect("/SecurityTools/HomeStud.aspx");
        }
    }
}