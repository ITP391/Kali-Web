using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Kali_Web.Announcements
{
    using System.Data.SqlClient;

    public partial class AddAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddAnnouncement_Callback(object sender, EventArgs e)
        {
            DateTime startDate, endDate;

            var validStartDateFormat =
                DateTime.TryParseExact(StartDateTextBox.Text, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out startDate);

            var validEndDateFormat =
                DateTime.TryParseExact(EndDateTextBox.Text, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out endDate);

            if (!validStartDateFormat)
            {
                LabelStartDateError.Text = "Start date must have correct format (dd-MM-yyyy)";
            }

            if (!validEndDateFormat)
            {
                LabelEndDateError.Text = "End date must have correct format (dd-MM-yyyy)";
            }

            if (!validEndDateFormat || !validStartDateFormat) return;

            // Open the connection to database
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager
                       .ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

                myConnection.Open();

                // Query for inserting the question
                string query =
                    "INSERT INTO [dbo].[Announcements]" +
                    "(Description, StartDate, EndDate)";
                query += " VALUES (@Description, @StartDate, @EndDate)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("Description", AnnouncementTextBox.Text);
                myCommand.Parameters.AddWithValue("StartDate", startDate.ToString("dd-MM-yyyy"));
                myCommand.Parameters.AddWithValue("EndDate", endDate.ToString("dd-MM-yyyy"));

                myCommand.ExecuteNonQuery();
            }

            // Redirect to the page where we show all questions
            Response.Redirect("ConfigureAnnouncement.aspx");
        }
    }
}