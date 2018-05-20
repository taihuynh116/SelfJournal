using SelfJournal.Constant;
using SelfJournal.Database.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SelfJournal.Database.Dao
{
    public class GoalTimeDao
    {
        public static GoalTime GetGoalTime()
        {
            var res = SelfJournalDbContext.Instance.GoalTimes;
            if (res.Count() == 0) return null;
            return res.OrderByDescending(x => x.LastUpdate).First();
        }
        public static int GetId(string name)
        {
            var res = SelfJournalDbContext.Instance.GoalTimes.Where(x => x.Name == name);
            if (res.Count() == 0) return -1;
            return res.First().ID;
        }
        public static void Update(int id)
        {
            DatabaseDao.Update(ConstantValue.GoalTime, id, new List<string> { "LastUpdate" }, new List<object> { DateTime.Now });
        }
        public static void Update(string name)
        {
            Update(GetId(name));
        }
    }
}