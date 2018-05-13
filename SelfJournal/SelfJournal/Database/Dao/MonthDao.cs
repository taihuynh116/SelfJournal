using SelfJournal.Database.EF;
using System;
using System.Linq;

namespace SelfJournal.Database.Dao
{
    public class MonthDao
    {
        public static int GetId(string name)
        {
            var res = SelfJournalDbContext.Instance.Months.Where(x => x.Name == name);
            if (res.Count() == 0) return -1;
            return res.First().ID;
        }
        public static Month GetMonth(int id)
        {
            var res = SelfJournalDbContext.Instance.Months.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
    }
}