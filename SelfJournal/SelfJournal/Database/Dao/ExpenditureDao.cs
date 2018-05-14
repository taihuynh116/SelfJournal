using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class ExpenditureDao
    {
        public static List<Expenditure> GetExpenditures(int idMonth, int idDay)
        {
            var res = SelfJournalDbContext.Instance.Expenditures.Where(x => x.IDMonth == idMonth && x.IDDay == idDay);
            if (res.Count() == 0) return new List<Expenditure>();
            return res.ToList();
        }
        public static List<Expenditure> GetExpenditures()
        {
            var res = SelfJournalDbContext.Instance.Expenditures;
            res.Sort();
            return res;
        }
    }
}