using System;

namespace SelfJournal.Database.EF
{
    public class Month
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int DayCount { get; set; }
        public DateTime LastSelected { get; set; }
    }
}