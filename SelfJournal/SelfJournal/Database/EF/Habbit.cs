using System;

namespace SelfJournal.Database.EF
{
    public class Habbit
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int IDHabbitType { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }
    }
}