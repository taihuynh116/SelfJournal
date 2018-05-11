using System;

namespace SelfJournal.Database.EF
{
    public class GoalOfDay
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDGoalOfMonth { get; set; }
        public int Day { get; set; }
    }
}