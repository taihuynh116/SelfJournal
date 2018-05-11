using System;

namespace SelfJournal.Database.EF
{
    public class Emotion
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int Ranking { get; set; }
    }
}