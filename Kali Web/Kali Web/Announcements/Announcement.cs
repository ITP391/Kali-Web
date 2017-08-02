using System;
using System.Collections.Generic;

namespace Kali_Web.Announcements
{
    public class Announcement
    {
        public Announcement(int id, string description, string startDate, string endDate)
        {
            Id = id;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}