using System;

namespace SelfJournal.Database.EF
{
    public class ExpenditureType
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public bool Positive { get; set; }
    }
}