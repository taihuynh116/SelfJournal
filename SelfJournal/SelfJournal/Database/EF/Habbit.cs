using System;

namespace SelfJournal.Database.EF
{
    public class Habbit:IComparable<Habbit>
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDHabbitType { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }

        public int CompareTo(Habbit other)
        {
            if (IDMonth != other.IDMonth) return IDMonth.CompareTo(other.IDMonth);
            if (IDDay != other.IDDay) return IDDay.CompareTo(other.IDDay);
            return IDHabbitType.CompareTo(other.IDHabbitType);
        }
    }
}