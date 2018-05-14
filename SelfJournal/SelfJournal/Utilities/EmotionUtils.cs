using Android.Content;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Database.Dao;
using SelfJournal.SingleData;
using System.Text;

namespace SelfJournal.Utilities
{
    public static class EmotionUtils
    {
        public static void StartEmotionActivity()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(EmotionActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
        public static void GetEmotion()
        {
            var resEmotions = EmotionDao.GetEmotions(Singleton.Instance.IDMonth);
            LinearLayout linearLayout = null;
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            int idMonth = -1;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < resEmotions.Count; i++)
            {
                if (idMonth != resEmotions[i].IDMonth)
                {
                    if (idMonth != -1)
                    {
                        TextView tvDayExpenditure = new TextView(Singleton.Instance.EmotionActivity);
                        tvDayExpenditure.LayoutParameters = lp;
                        tvDayExpenditure.Text = sb.ToString();
                        tvDayExpenditure.TextSize = 17;
                        tvDayExpenditure.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);

                        linearLayout.AddView(tvDayExpenditure);

                        sb = new StringBuilder();
                    }

                    idMonth = resEmotions[i].IDMonth;

                    linearLayout = new LinearLayout(Singleton.Instance.EmotionActivity);
                    linearLayout.LayoutParameters = lp;
                    linearLayout.Orientation = Orientation.Vertical;

                    Singleton.Instance.EmLinearLayout.AddView(linearLayout);

                    TextView tvMonthTitle = new TextView(Singleton.Instance.EmotionActivity);
                    tvMonthTitle.LayoutParameters = lp;
                    var resMonth = MonthDao.GetMonth(idMonth);
                    if (resMonth != null)
                    {
                        tvMonthTitle.Text = "Month: " + resMonth.Name;
                    }
                    tvMonthTitle.TextSize = 20;
                    tvMonthTitle.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);

                    linearLayout.AddView(tvMonthTitle);
                }
                sb.Append(resEmotions[i].Ranking+"   ");
                if (i == resEmotions.Count - 1)
                {
                    TextView tvDayExpenditure = new TextView(Singleton.Instance.EmotionActivity);
                    tvDayExpenditure.LayoutParameters = lp;
                    tvDayExpenditure.Text = sb.ToString();
                    tvDayExpenditure.TextSize = 17;
                    tvDayExpenditure.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);

                    linearLayout.AddView(tvDayExpenditure);
                }
            }
        }
    }
}