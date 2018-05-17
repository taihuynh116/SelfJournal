using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using SelfJournal.Constant;

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
        public static void Insert(string name)
        {
            DatabaseDao.Insert(ConstantValue.Goal, new List<string> { "Name" }, new List<object> { name });
        }
        public static List<Goal> GetGoalsNotSetInMonth(int idMonth)
        {
            var resGoalOfMonths = GoalOfMonthDao.GetGoalOfMonths(idMonth);
            var res = SelfJournalDbContext.Instance.Goals.Where(x => !resGoalOfMonths.Select(y => y.IDGoal).Contains(x.ID));
            return res.ToList();
        }
    }
}