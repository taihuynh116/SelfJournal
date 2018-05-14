using System;

namespace SelfJournal.Database.EF
{
    public class Emotion:IComparable<Emotion>
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int Ranking { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }

        public int CompareTo(Emotion other)
        {
            if (IDMonth != other.IDMonth) return IDMonth.CompareTo(other.IDMonth);
            return IDDay.CompareTo(other.IDDay);
        }
    }
}