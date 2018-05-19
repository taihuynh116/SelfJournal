using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Constant;
using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;
using SelfJournal.SingleData;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static string GetGoalsYear()
        {
            List<Goal> goals = SelfJournalDbContext.Instance.Goals;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goals.Count; i++)
            {
                sb.Append("- " + goals[i].Name);
                if (i != goals.Count - 1) sb.Append("\n");
            }
            return sb.ToString();
        }
        public static string GetGoalsMonth(int idMonth)
        {
            List<Goal> goals = new List<Goal>();

            var resGoalOfMonths = GoalOfMonthDao.GetGoalOfMonths(idMonth);
            for (int i = 0; i < resGoalOfMonths.Count; i++)
            {
                var resGoal = GoalDao.GetGoal(resGoalOfMonths[i].IDGoal);
                if (resGoal != null) goals.Add(resGoal);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goals.Count; i++)
            {
                sb.Append("- " + goals[i].Name);
                if (i != goals.Count - 1) sb.Append("\n");
            }
            return sb.ToString();
        }
        public static string GetGoalsDay(int idMonth, int idDay)
        {
            List<Goal> goals = new List<Goal>();

            var resGoalOfDays = GoalOfDayDao.GetGoalOfDays(id);
            for (int i = 0; i < resGoalOfDays.Count; i++)
            {
                var resGoalOfMonth = GoalOfMonthDao.GetGoalOfMonth(resGoalOfDays[i].IDGoalOfMonth);
                if (resGoalOfMonth != null)
                {
                    var resGoal = GoalDao.GetGoal(resGoalOfMonth.IDGoal);
                    if (resGoal != null) goals.Add(resGoal);
                }
            }
        }
        public static string GetGoalContent(int id)
        {
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return "";

            List<Goal> goals = new List<Goal>();
            switch (resGoalTime.Name)
            {
                case "Year":
                    Singleton.Instance.tvGoalTitle.Text = "";
                    goals = SelfJournalDbContext.Instance.Goals;
                    break;
                case "Month":
                    //var resMonth = MonthDao.GetMonth(id);
                    //if (resMonth != null)
                    //{
                    //    Singleton.Instance.tvGoalTitle.Text = ": " + resMonth.Name;
                    //}

                    var resGoalOfMonths = GoalOfMonthDao.GetGoalOfMonths(id);
                    for (int i = 0; i < resGoalOfMonths.Count; i++)
                    {
                        var resGoal = GoalDao.GetGoal(resGoalOfMonths[i].IDGoal);
                        if (resGoal != null) goals.Add(resGoal);
                    }
                    break;
                case "Day":
                    var resGoalOfDays = GoalOfDayDao.GetGoalOfDays(id);
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
            return sb.ToString();
        }
        public static void AddGoal()
        {
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return;
            switch (resGoalTime.Name)
            {
                case "Year":
                    Singleton.Instance.AddGoalDialog.SetTitle("Goal of Year");
                    Singleton.Instance.AddGoalEditText = new EditText(Singleton.Instance.GoalActivity)
                    {
                        LayoutParameters = lp,
                    };
                    Singleton.Instance.AddGoalEditText.OnFocusChangeListener = new GoalEditTextOnFocusChangeListener();
                    Singleton.Instance.AGLinearLayout.AddView(Singleton.Instance.AddGoalEditText);

                    break;
                case "Month":
                    Singleton.Instance.AddGoalDialog.SetTitle("Goal of Month");
                    Singleton.Instance.GoalCheckBoxs = new List<ProjectData.GoalCheckBox>();
                    var resGoals = GoalDao.GetGoalsNotSetInMonth(Singleton.Instance.IDMonth);
                    for (int i = 0; i < resGoals.Count; i++)
                    {
                        RelativeLayout rl = new RelativeLayout(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lp
                        };
                        Singleton.Instance.AGLinearLayout.AddView(rl);

                        RelativeLayout.LayoutParams lpTv = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpTv.AddRule(LayoutRules.AlignParentLeft);
                        TextView tv = new TextView(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpTv,
                            Text = resGoals[i].Name,
                            TextSize = 15
                        };
                        rl.AddView(tv);

                        RelativeLayout.LayoutParams lpChk = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpChk.AddRule(LayoutRules.AlignParentRight);
                        CheckBox chk = new CheckBox(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpChk,
                        };
                        rl.AddView(chk);

                        Singleton.Instance.GoalCheckBoxs.Add(new ProjectData.GoalCheckBox { IDGoal = resGoals[i].ID, CheckBox = chk });
                    }
                    break;
                case "Day":
                    Singleton.Instance.AddGoalDialog.SetTitle("Goal of Day");
                    Singleton.Instance.GoalCheckBoxs = new List<ProjectData.GoalCheckBox>();
                    var resGoalOfMonths = GoalOfMonthDao.GetGoalsNotSetInDay(Singleton.Instance.IDDay);
                    for (int i = 0; i < resGoalOfMonths.Count; i++)
                    {
                        RelativeLayout rl = new RelativeLayout(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lp
                        };
                        Singleton.Instance.AGLinearLayout.AddView(rl);

                        RelativeLayout.LayoutParams lpTv = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpTv.AddRule(LayoutRules.AlignParentLeft);
                        TextView tv = new TextView(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpTv,
                            Text = GoalDao.GetGoal(resGoalOfMonths[i].IDGoal).Name,
                            TextSize = 15
                        };
                        rl.AddView(tv);

                        RelativeLayout.LayoutParams lpChk = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpChk.AddRule(LayoutRules.AlignParentRight);
                        CheckBox chk = new CheckBox(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpChk
                        };
                        rl.AddView(chk);

                        Singleton.Instance.GoalCheckBoxs.Add(new ProjectData.GoalCheckBox { IDGoal = resGoalOfMonths[i].ID, CheckBox = chk });
                    }
                    break;
            }
        }
        public static void DeleteGoal()
        {
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return;
            switch (resGoalTime.Name)
            {
                case "Year":
                    Singleton.Instance.GoalCheckBoxs = new List<ProjectData.GoalCheckBox>();
                    Singleton.Instance.DeleteGoalDialog.SetTitle("Goal of Month");
                    var resGoals = SelfJournalDbContext.Instance.Goals;
                    for (int i = 0; i < resGoals.Count; i++)
                    {
                        RelativeLayout rl = new RelativeLayout(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lp
                        };
                        Singleton.Instance.DGLinearLayout.AddView(rl);

                        RelativeLayout.LayoutParams lpTv = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpTv.AddRule(LayoutRules.AlignParentLeft);
                        TextView tv = new TextView(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpTv,
                            Text = resGoals[i].Name,
                            TextSize = 15
                        };
                        rl.AddView(tv);

                        RelativeLayout.LayoutParams lpChk = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpChk.AddRule(LayoutRules.AlignParentRight);
                        CheckBox chk = new CheckBox(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpChk
                        };
                        rl.AddView(chk);

                        Singleton.Instance.GoalCheckBoxs.Add(new ProjectData.GoalCheckBox { IDGoal = resGoals[i].ID, CheckBox = chk });
                    }
                    break;
                case "Month":
                    Singleton.Instance.GoalCheckBoxs = new List<ProjectData.GoalCheckBox>();
                    Singleton.Instance.DeleteGoalDialog.SetTitle("Goal of Month");
                    var resGoalOfMonths = GoalOfMonthDao.GetGoalOfMonths(Singleton.Instance.IDMonth);
                    for (int i = 0; i < resGoalOfMonths.Count; i++)
                    {
                        RelativeLayout rl = new RelativeLayout(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lp
                        };
                        Singleton.Instance.DGLinearLayout.AddView(rl);

                        RelativeLayout.LayoutParams lpTv = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpTv.AddRule(LayoutRules.AlignParentLeft);
                        TextView tv = new TextView(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpTv,
                            Text = GoalDao.GetGoal(resGoalOfMonths[i].IDGoal).Name,
                            TextSize = 15
                        };
                        rl.AddView(tv);

                        RelativeLayout.LayoutParams lpChk = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpChk.AddRule(LayoutRules.AlignParentRight);
                        CheckBox chk = new CheckBox(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpChk
                        };
                        rl.AddView(chk);

                        Singleton.Instance.GoalCheckBoxs.Add(new ProjectData.GoalCheckBox { IDGoal = resGoalOfMonths[i].ID, CheckBox = chk });
                    }
                    break;
                case "Day":
                    Singleton.Instance.GoalCheckBoxs = new List<ProjectData.GoalCheckBox>();
                    Singleton.Instance.DeleteGoalDialog.SetTitle("Goal of Day");
                    var resGoalOfDays = GoalOfDayDao.GetGoalOfDays(Singleton.Instance.IDDay);
                    for (int i = 0; i < resGoalOfDays.Count; i++)
                    {
                        RelativeLayout rl = new RelativeLayout(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lp
                        };
                        Singleton.Instance.DGLinearLayout.AddView(rl);

                        RelativeLayout.LayoutParams lpTv = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpTv.AddRule(LayoutRules.AlignParentLeft);
                        TextView tv = new TextView(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpTv,
                            Text = GoalDao.GetGoal(GoalOfMonthDao.GetGoalOfMonth(resGoalOfDays[i].IDGoalOfMonth).IDGoal).Name,
                            TextSize = 15
                        };
                        rl.AddView(tv);

                        RelativeLayout.LayoutParams lpChk = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
                        lpChk.AddRule(LayoutRules.AlignParentRight);
                        CheckBox chk = new CheckBox(Singleton.Instance.GoalActivity)
                        {
                            LayoutParameters = lpChk
                        };
                        rl.AddView(chk);

                        Singleton.Instance.GoalCheckBoxs.Add(new ProjectData.GoalCheckBox { IDGoal = resGoalOfDays[i].ID, CheckBox = chk });
                    }
                    break;
            }
            }
    }

    public class GoalEditTextOnFocusChangeListener : Java.Lang.Object, View.IOnFocusChangeListener
    {
        public void OnFocusChange(View v, bool hasFocus)
        {
            if (hasFocus)
            {
                InputMethodManager imm = (InputMethodManager)Singleton.Instance.GoalActivity.GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(Singleton.Instance.AddGoalView, ShowFlags.Forced);
                imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            }
        }
    }
    public class AddGoalDialogOnClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        public void OnClick(IDialogInterface dialog, int which)
        {
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return;
            switch (resGoalTime.Name)
            {
                case "Year":
                    InputMethodManager imm = (InputMethodManager)Singleton.Instance.GoalActivity.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(Singleton.Instance.AddGoalView.WindowToken, HideSoftInputFlags.None);

                    GoalDao.Insert(Singleton.Instance.AddGoalEditText.Text);
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
                case "Month":
                    foreach (var item in Singleton.Instance.GoalCheckBoxs)
                    {
                        CheckBox chk = item.CheckBox;
                        if (chk.Checked)
                        {
                            GoalOfMonthDao.Insert(item.IDGoal, Singleton.Instance.IDMonth);
                        }
                    }
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
                case "Day":
                    foreach (var item in Singleton.Instance.GoalCheckBoxs)
                    {
                        CheckBox chk = item.CheckBox;
                        if (chk.Checked)
                        {
                            GoalOfDayDao.Insert(item.IDGoal, Singleton.Instance.IDDay);
                        }
                    }
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
            }

        }
    }
    public class DeleteGoalDialogOnClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        public void OnClick(IDialogInterface dialog, int which)
        {
            var resGoalTime = GoalTimeDao.GetGoalTime();
            if (resGoalTime == null) return;
            switch (resGoalTime.Name)
            {
                case "Year":
                    foreach (var item in Singleton.Instance.GoalCheckBoxs)
                    {
                        CheckBox chk = item.CheckBox;
                        if (chk.Checked)
                        {
                            GoalDao.Delete(item.IDGoal);
                        }
                    }
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
                case "Month":
                    foreach (var item in Singleton.Instance.GoalCheckBoxs)
                    {
                        CheckBox chk = item.CheckBox;
                        if (chk.Checked)
                        {
                            GoalOfMonthDao.Delete(item.IDGoal);
                        }
                    }
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
                case "Day":
                    foreach (var item in Singleton.Instance.GoalCheckBoxs)
                    {
                        CheckBox chk = item.CheckBox;
                        if (chk.Checked)
                        {
                            GoalOfDayDao.Delete(item.IDGoal);
                        }
                    }
                    GoalUtils.GetGoal();
                    dialog.Dismiss();
                    break;
            }

        }
    }
}