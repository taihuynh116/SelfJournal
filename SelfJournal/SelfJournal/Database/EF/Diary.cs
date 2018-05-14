using System;

namespace SelfJournal.Database.EF
{
    public class Diary
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public int IDMonth { get; set; }
        public int IDDay { get; set; }
    }
}