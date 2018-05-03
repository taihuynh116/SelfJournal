using Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dao
{
    public class GoalDao
    {
        SelfJournalDbContext db = new SelfJournalDbContext();
        public List<Goal> GetGoals()
        {
            return db.Goals.ToList();
        }
        public static GoalDao Instance { get { return new GoalDao(); } }
    }
}
