using System;

namespace SelfJournal.Database.EF
{
    public class GoalTime
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}