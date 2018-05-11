using System;

namespace SelfJournal.Database.EF
{
    public class Expenditure
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDExpenditure { get; set; }
        public double Amount { get; set; }
    }
}