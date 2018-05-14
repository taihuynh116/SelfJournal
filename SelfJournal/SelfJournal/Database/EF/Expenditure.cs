using System;

namespace SelfJournal.Database.EF
{
    public class Expenditure:IComparable<Expenditure>
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDExpenditure { get; set; }
        public double Amount { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }

        public int CompareTo(Expenditure other)
        {
            if (IDMonth != other.IDMonth) return IDMonth.CompareTo(other.IDMonth);
            return IDDay.CompareTo(other.IDDay);
        }
    }
}