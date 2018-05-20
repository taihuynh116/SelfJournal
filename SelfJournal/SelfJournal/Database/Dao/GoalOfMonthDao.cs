using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using SelfJournal.Constant;

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
        public static List<GoalOfMonth> GetGoalOfMonthsWithIDGoal(int idGoal)
        {
            var res = SelfJournalDbContext.Instance.GoalOfMonths.Where(x => x.IDGoal == idGoal);
            if (res.Count() == 0) return new List<GoalOfMonth>();
            return res.ToList();
        }
        public static void Insert(int idGoal, int idMonth)
        {
            DatabaseDao.Insert(ConstantValue.GoalOfMonth, new List<string> { "IDGoal", "IDMonth" }, new List<object> { idGoal, idMonth });
        }
        public static List<GoalOfMonth> GetGoalsNotSetInDay(int idDay)
        {
            var resGoalOfDays = GoalOfDayDao.GetGoalOfDays(0, idDay);
            var res = SelfJournalDbContext.Instance.GoalOfMonths.Where(x => !resGoalOfDays.Select(y => y.IDGoalOfMonth).Contains(x.ID));
            return res.ToList();
        }
        public static void Delete(int id)
        {
            var resGoalOfDays = GoalOfDayDao.GetGoalOfDaysWithIDMonth(id);
            resGoalOfDays.ForEach(x => GoalOfDayDao.Delete(x.ID));
            DatabaseDao.Delete(ConstantValue.GoalOfMonth, new List<string> { "ID" }, new List<object> { id });
        }
    }
}