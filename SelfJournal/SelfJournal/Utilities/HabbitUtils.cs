using Android.Content;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;
using SelfJournal.SingleData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfJournal.Utilities
{
    public static class HabbitUtils
    {
        public static void StartHabbitActivity()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(HabbitActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
        public static void GetHabbit()
        {
            var resHabbits = HabbitDao.GetHabbits(Singleton.Instance.IDMonth);
            var resHabbitTypes = SelfJournalDbContext.Instance.HabbitTypes;
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            TextView tvMonthTitle = new TextView(Singleton.Instance.HabbitActivity);
            tvMonthTitle.LayoutParameters = lp;
            var resMonth = MonthDao.GetMonth(Singleton.Instance.IDMonth);
            if (resMonth != null)
            {
                tvMonthTitle.Text = "Month: " + resMonth.Name;
            }
            tvMonthTitle.TextSize = 20;
            tvMonthTitle.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);
            Singleton.Instance.HLinearLayout.AddView(tvMonthTitle);

            TextView tvHabbit = new TextView(Singleton.Instance.HabbitActivity);
            tvHabbit.LayoutParameters = lp;
            tvHabbit.TextSize = 17;
            tvHabbit.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);
            for (int j = 0; j < resHabbitTypes.Count; j++)
            {
                if (j != 0) tvHabbit.Text += "\n";
                StringBuilder sb = new StringBuilder(resHabbitTypes[j].Name+": ");
                for (int i = 0; i < resHabbits.Count; i++)
                {
                    if (resHabbits[i].IDHabbitType == resHabbitTypes[j].ID)
                    {
                        sb.Append(resHabbits[i].IDDay +"   ");
                    }
                }
                tvHabbit.Text += sb.ToString();
            }
            Singleton.Instance.HLinearLayout.AddView(tvHabbit);
        }
    }
}