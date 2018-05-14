using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class HabbitTypeDao
    {
        public static HabbitType GetHabbitType(int id)
        {
            var res = SelfJournalDbContext.Instance.HabbitTypes.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
    }
}