namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emotion")]
    public partial class Emotion
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int Ranking { get; set; }
    }
}
