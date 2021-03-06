﻿using SelfJournal.Database.EF;
using System;
using System.Linq;

namespace SelfJournal.Database.Dao
{
    public class DiaryDao
    {
        public static Diary GetDiary(int idMonth, int idDay)
        {
            var res = SelfJournalDbContext.Instance.Diaries.Where(x => x.IDMonth == idMonth && x.IDDay == idDay);
            if (res.Count() == 0) return null;
            return res.First();
        }
    }
}