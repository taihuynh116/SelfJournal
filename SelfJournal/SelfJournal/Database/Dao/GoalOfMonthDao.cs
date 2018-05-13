using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class GoalOfMonthDao
    {
        public static GoalOfMonth GetGoalOfMonth(int id)
        {
            var res = SelfJournalDbContext.Instance.GoalOfMonths.Where(x => x.ID == id);
            if (res.Count() == 0) return null;
            return res.First();
        }
        public static List<GoalOfMonth> GetGoalOfMonths(int idMonth)
        {
            var res = SelfJournalDbContext.Instance.GoalOfMonths.Where(x => x.IDMonth == idMonth);
            if (res.Count() == 0) return new List<GoalOfMonth>();
            return res.ToList();
        }
    }
}