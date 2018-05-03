namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Emotion
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int Ranking { get; set; }
    }
}
