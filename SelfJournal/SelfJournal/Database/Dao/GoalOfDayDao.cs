using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using SelfJournal.Constant;

namespace SelfJournal.Database.Dao
{
    public class GoalOfDayDao
    {
        public static List<GoalOfDay> GetGoalOfDays(int idMonth, int idDay)
        {
            var res = SelfJournalDbContext.Instance.GoalOfDays.Where(x => x.IDMonth == idMonth && x.IDDay == idDay);
            if (res.Count() == 0) return new List<GoalOfDay>();
            return res.ToList();
        }
        public static List<GoalOfDay> GetGoalOfDaysWithIDMonth(int idGoalOfMonth)
        {
            var res = SelfJournalDbContext.Instance.GoalOfDays.Where(x => x.IDGoalOfMonth == idGoalOfMonth);
            if (res.Count() == 0) return new List<GoalOfDay>();
            return res.ToList();
        }
        public static void Insert(int idGoalOfMonth, int idDay)
        {
            DatabaseDao.Insert(ConstantValue.GoalOfDay, new List<string> { "IDGoalOfMonth", "idDay" }, new List<object> { idGoalOfMonth, idDay });
        }
        public static void Delete(int id)
        {
            DatabaseDao.Delete(ConstantValue.GoalOfDay, new List<string> { "ID" }, new List<object> { id });
        }
    }
}