namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Diary
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public string Content { get; set; }
    }
}
