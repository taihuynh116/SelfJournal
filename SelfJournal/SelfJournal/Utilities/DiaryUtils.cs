using Android.Content;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Database.Dao;
using SelfJournal.SingleData;

namespace SelfJournal.Utilities
{
    public static class DiaryUtils
    {
        public static void StartDiaryAcitivy()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(DiaryActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
        public static void GetDiary()
        {
            var resDiary = DiaryDao.GetDiary(Singleton.Instance.IDMonth, Singleton.Instance.IDDay);
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            TextView tvMonthDayTitle = new TextView(Singleton.Instance.DiaryActivity);
            tvMonthDayTitle.LayoutParameters = lp;
            var resMonth = MonthDao.GetMonth(Singleton.Instance.IDMonth);
            if (resMonth != null)
            {
                tvMonthDayTitle.Text = "Month: " + resMonth.Name + "    Day: " + Singleton.Instance.IDDay;
            }
            tvMonthDayTitle.TextSize = 20;
            tvMonthDayTitle.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);
            Singleton.Instance.DLinearLayout.AddView(tvMonthDayTitle);

            TextView tvDiary = new TextView(Singleton.Instance.DiaryActivity);
            tvDiary.LayoutParameters = lp;
            tvDiary.Text = resDiary.Content;
            tvMonthDayTitle.TextSize = 17;
            tvMonthDayTitle.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Normal);
            Singleton.Instance.DLinearLayout.AddView(tvDiary);
        }
    }
}