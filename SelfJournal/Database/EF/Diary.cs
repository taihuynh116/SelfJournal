namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diary")]
    public partial class Diary
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
