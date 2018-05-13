using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class GoalDao
    {
        public static Goal GetGoal(int id)
        {
            var res = SelfJournalDbContext.Instance.Goals.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
    }
}