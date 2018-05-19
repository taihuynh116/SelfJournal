using System;

namespace SelfJournal.Database.EF
{
    public class GoalOfDay
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDGoalOfMonth { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }
    }
}