using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class GoalOfDayhDao
    {
        public static List<GoalOfDay> GetGoalOfDays(int idDay)
        {
            var res = SelfJournalDbContext.Instance.GoalOfDays.Where(x => x.IDDay == idDay);
            if (res.Count() == 0) return new List<GoalOfDay>();
            return res.ToList();
        }
    }
}