using SelfJournal.Database.EF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SelfJournal.Database.Dao
{
    public class HabbitDao
    {
        public static List<Habbit> GetHabbits(int idMonth)
        {
            var res = SelfJournalDbContext.Instance.Habbits.Where(x => x.IDMonth == idMonth);
            if (res.Count() == 0) return new List<Habbit>();
            var list = res.ToList(); list.Sort();
            return list;
        }
    }
}