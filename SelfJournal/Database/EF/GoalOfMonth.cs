namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoalOfMonth")]
    public partial class GoalOfMonth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoalOfMonth()
        {
            GoalOfDays = new HashSet<GoalOfDay>();
        }

        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDGoal { get; set; }

        public int Month { get; set; }

        public virtual Goal Goal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalOfDay> GoalOfDays { get; set; }
    }
}
