using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Kali_Web.Announcements
{
    public partial class ConfigureAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var announcementList = new List<Announcement>();

            SqlConnection myConnection;
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
                    // Create a list of 'QuizQuestion', in the 'categoryQuestions' variable.
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
        }

        protected void DeleteAnnouncement(object sender, EventArgs e)
        {
            var announcementId = int.Parse(((HtmlAnchor) sender).Attributes["announcement-id"]);
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // Query for inserting the question
                string query =
                    "DELETE [dbo].[Announcements]" +
                    "WHERE Id = @Id";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("Id", announcementId);

                myCommand.ExecuteNonQuery();
            }

            // Redirect to the page where we show all questions
            Response.Redirect("ConfigureAnnouncement.aspx");
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            var announcementAnswerList = new List<AnnouncementAnswer>();

            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                var announcementId = ((Announcement)args.Item.DataItem).Id;
                Repeater childRepeater = (Repeater)args.Item.FindControl("AnnouncementAnswersRepeater");

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                    .ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {

                    myConnection.Open();

                    // Query for inserting the question
                    string query =
                        "SELECT UserId, FName, LName, Response " +
                        "FROM [dbo].[AnnouncementAnswer] " +
                        "JOIN [dbo].[User] ON [dbo].[AnnouncementAnswer].UserId = [dbo].[User].Id " +
                        "WHERE ANNOUNCEMENTID = @Id";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.Parameters.AddWithValue("Id", announcementId);
                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Create a list of 'QuizQuestion', in the 'categoryQuestions' variable.
                        while (reader.Read())
                        {
                            // Read da
                            var userId = int.Parse(reader["UserId"].ToString());
                            var response = reader["Response"].ToString();
                            var firstName = reader["FName"].ToString();
                            var lastName = reader["LName"].ToString();

                            announcementAnswerList.Add(new AnnouncementAnswer(userId, firstName, lastName, response));
                        }
                    }
                }

                childRepeater.DataSource = announcementAnswerList;
                childRepeater.DataBind();
            }
        }
    }
}