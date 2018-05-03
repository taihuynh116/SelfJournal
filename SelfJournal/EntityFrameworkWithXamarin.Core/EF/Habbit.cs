namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Habbit
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDHabbitType { get; set; }

        public double Hour { get; set; }

        public virtual HabbitType HabbitType { get; set; }
    }
}
