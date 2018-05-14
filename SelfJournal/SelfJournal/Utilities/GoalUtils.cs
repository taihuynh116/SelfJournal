﻿using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;
using SelfJournal.SingleData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfJournal.Utilities
{
    public static class GoalUtils
    {
        public static void GetGoalOfYear()
        {
            List<Goal> goals = SelfJournalDbContext.Instance.Goals;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goals.Count; i++)
            {
                sb.Append("- " + goals[i].Name);
                if (i != goals.Count - 1)
                {
                    sb.Append("\n");
                }
            }
            Singleton.Instance.tvGoalOfYear.Text = sb.ToString();
        }
        public static void GetGoalOfMonth()
        {
            DateTime dt = DateTime.Now;
            Singleton.Instance.IDMonth = dt.Month;
            var resMonth = MonthDao.GetMonth(Singleton.Instance.IDMonth);
            if (resMonth != null)
            {
                Singleton.Instance.tvMonthTitle.Text += ": " + resMonth.Name;
            }

            List<GoalOfMonth> goms = GoalOfMonthDao.GetGoalOfMonths(Singleton.Instance.IDMonth);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goms.Count; i++)
            {
                AppendGoalOfMonth(ref sb, goms[i]);
                if (i != goms.Count - 1)
                {
                    sb.Append("\n");
                }
            }
            Singleton.Instance.tvGoalOfMonth.Text = sb.ToString();
        }
        public static void GetGoalOfDay()
        {
            DateTime dt = DateTime.Now;
            Singleton.Instance.IDDay = dt.Day;
            List<GoalOfDay> gods = GoalOfDayhDao.GetGoalOfDays(Singleton.Instance.IDDay);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gods.Count; i++)
            {
                var resGOM = GoalOfMonthDao.GetGoalOfMonth(gods[i].IDGoalOfMonth);
                AppendGoalOfMonth(ref sb, resGOM);
                if (i != gods.Count - 1)
                {
                    sb.Append("\n");
                }
            }
            Singleton.Instance.tvDayTitle.Text += ": " + Singleton.Instance.IDDay.ToString();
            Singleton.Instance.tvGoalOfDay.Text = sb.ToString();
        }
        public static void AppendGoalOfMonth(ref StringBuilder sb, GoalOfMonth gom)
        {
            if (gom != null)
            {
                var resGoal = GoalDao.GetGoal(gom.IDGoal);
                if (resGoal != null)
                {
                    sb.Append("- " + resGoal.Name);
                }
            }
        }
    }
}