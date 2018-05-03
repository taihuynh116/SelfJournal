namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class GoalOfDay
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDGoalOfMonth { get; set; }

        public int Day { get; set; }

        public virtual GoalOfMonth GoalOfMonth { get; set; }
    }
}
