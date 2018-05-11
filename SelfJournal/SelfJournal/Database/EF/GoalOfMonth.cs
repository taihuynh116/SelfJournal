using System;

namespace SelfJournal.Database.EF
{
    public class GoalOfMonth
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDGoal { get; set; }
        public int Month { get; set; }
    }
}