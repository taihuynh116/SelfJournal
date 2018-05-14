using SelfJournal.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfJournal.Database.Dao
{
    public class EmotionDao
    {
        public static Emotion GetEmotion(int idMonth, int idDay)
        {
            var res = SelfJournalDbContext.Instance.Emotions.Where(x => x.IDMonth == idMonth && x.IDDay == idDay);
            if (res.Count() == 0) return null;
            return res.First();
        }
        public static List<Emotion> GetEmotions()
        {
            var res = SelfJournalDbContext.Instance.Emotions;
            res.Sort();
            return res;
        }
    }
}