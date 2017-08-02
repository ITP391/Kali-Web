
namespace Kali_Web.Announcements
{
    public class AnnouncementAnswer
    {
        public AnnouncementAnswer(
            int userId, 
            string firstName, 
            string lastName,
            string response)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Response = response;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserId { get; set; }

        public string Response { get; set; }
    }
}