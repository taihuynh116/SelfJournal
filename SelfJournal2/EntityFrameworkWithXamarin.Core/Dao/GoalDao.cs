using Database.EF;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Goal> GetGoals()
        {
            return db.Goals;
        }
        public static GoalDao Instance { get { return new GoalDao(); } }
    }
}
