using SelfJournal.Constant;
using SelfJournal.Database.EF;
using System;
using System.Collections.Generic;
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
        public static int GetIdByTitle(string title)
        {
            var res = SelfJournalDbContext.Instance.Months.Where(x => x.Title == title);
            if (res.Count() == 0) return -1;
            return res.First().ID;
        }
        public static Month GetMonth(int id)
        {
            var res = SelfJournalDbContext.Instance.Months.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
        public static void UpdateByTitle(string title)
        {
            int id = GetIdByTitle(title);
            Update(id);
        }
        public static void Update(int id)
        {
            DatabaseDao.Update(ConstantValue.Month, id, new List<string> { "LastSelected" }, new List<object> { DateTime.Now });
        }
        public static Month GetSelectedMonth()
        {
            var res = SelfJournalDbContext.Instance.Months;
            if (res.Count() == 0) return null;
            return res.OrderByDescending(x => x.LastSelected).First();
        }
    }
}