using Android.Content;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Constant;
using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;
using SelfJournal.SingleData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfJournal.Utilities
{
    public static class GoalUtils
    {
        public static void StartGoalActivity()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(GoalActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
        public static void GetGoal()
        {
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return;

            List<Goal> goals = new List<Goal>();
            switch (resGoalTime.Name)
            {
                case "Year":
                    Singleton.Instance.tvGoalTitle.Text = "";
                    goals = SelfJournalDbContext.Instance.Goals;
                    break;
                case "Month":
                    var resMonth = MonthDao.GetMonth(Singleton.Instance.IDMonth);
                    if (resMonth != null)
                    {
                        Singleton.Instance.tvGoalTitle.Text = ": " + resMonth.Name;
                    }

                    var resGoalOfMonths = GoalOfMonthDao.GetGoalOfMonths(Singleton.Instance.IDMonth);
                    for (int i = 0; i < resGoalOfMonths.Count; i++)
                    {
                        var resGoal = GoalDao.GetGoal(resGoalOfMonths[i].IDGoal);
                        if (resGoal != null) goals.Add(resGoal);
                    }
                    break;
                case "Day":
                    Singleton.Instance.tvGoalTitle.Text = ": " + Singleton.Instance.IDDay;
                    var resGoalOfDays = GoalOfDayDao.GetGoalOfDays(Singleton.Instance.IDDay);
                    for (int i = 0; i < resGoalOfDays.Count; i++)
                    {
                        var resGoalOfMonth = GoalOfMonthDao.GetGoalOfMonth(resGoalOfDays[i].IDGoalOfMonth);
                        if (resGoalOfMonth != null)
                        {
                            var resGoal = GoalDao.GetGoal(resGoalOfMonth.IDGoal);
                            if (resGoal != null) goals.Add(resGoal);
                        }
                    }
                    break;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goals.Count; i++)
            {
                sb.Append("- " + goals[i].Name);
                if (i != goals.Count - 1) sb.Append("\n");
            }
            Singleton.Instance.tvGoalContent.Text = sb.ToString();
        }
    }
}