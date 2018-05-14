using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class ExpenditureTypeDao
    {
        public static ExpenditureType GetExpenditureType(int id)
        {
            var res = SelfJournalDbContext.Instance.ExpenditureTypes.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
    }
}