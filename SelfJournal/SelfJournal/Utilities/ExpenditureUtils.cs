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
    public static class ExpenditureUtils
    {
        public static void StartExpenditureActivity()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(ExpenditureActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
        public static void GetExpenditure()
        {
            var resExpenditures = ExpenditureDao.GetExpenditures(Singleton.Instance.IDMonth);
            LinearLayout linearLayout = null;
            LinearLayout bLinearLayout = null;
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            int idMonth = -1, idDay = -1;
            StringBuilder sbThu = new StringBuilder("Thu: ");
            StringBuilder sbChi = new StringBuilder("Chi: ");
            StringBuilder sbSum = new StringBuilder("Sum: ");
            double sum = 0;
            bool isChangedMonth = false;

            for (int i = 0; i < resExpenditures.Count; i++)
            {
                if (idMonth != resExpenditures[i].IDMonth)
                {
                    isChangedMonth = true;
                    idMonth = resExpenditures[i].IDMonth;

                    bLinearLayout = linearLayout;
                    linearLayout = new LinearLayout(Singleton.Instance.ExpenditureActivity);
                    linearLayout.LayoutParameters = lp;
                    linearLayout.Orientation = Orientation.Vertical;

                    if (i == 0) bLinearLayout = linearLayout;

                    Singleton.Instance.ELinearLayout.AddView(linearLayout);

                    TextView tvMonthTitle = new TextView(Singleton.Instance.ExpenditureActivity);
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
                if (idDay != resExpenditures[i].IDDay)
                {
                    if (idDay != -1)
                    {
                        TextView tvDayExpenditure = new TextView(Singleton.Instance.ExpenditureActivity);
                        tvDayExpenditure.LayoutParameters = lp;
                        tvDayExpenditure.Text = sbThu + "\n" + sbChi + "\n" + sbSum.Append(sum);
                        tvDayExpenditure.TextSize = 15;
                        tvDayExpenditure.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Normal);

                        if (isChangedMonth)
                        {
                            bLinearLayout.AddView(tvDayExpenditure);
                            isChangedMonth = false;
                        }
                        else
                        {
                            linearLayout.AddView(tvDayExpenditure);
                        }

                        sbThu = new StringBuilder("Thu: ");
                        sbChi = new StringBuilder("Chi: ");
                        sbSum = new StringBuilder("Sum: ");
                        sum = 0;
                    }

                    idDay = resExpenditures[i].IDDay;
                    TextView tvDayTitle = new TextView(Singleton.Instance.ExpenditureActivity);
                    tvDayTitle.LayoutParameters = lp;
                    tvDayTitle.Text = "Day: " + idDay;
                    tvDayTitle.TextSize = 17;
                    tvDayTitle.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);

                    linearLayout.AddView(tvDayTitle);
                }
                var resExpenditureType = ExpenditureTypeDao.GetExpenditureType(resExpenditures[i].IDExpenditure);
                if (resExpenditureType != null)
                {
                    switch (resExpenditureType.Positive)
                    {
                        case true:
                            sbThu.Append("   +" + resExpenditures[i].Amount);
                            sum += resExpenditures[i].Amount;
                            break;
                        case false:
                            sbChi.Append("   -" + resExpenditures[i].Amount);
                            sum += -resExpenditures[i].Amount;
                            break;
                    }
                }
                if (i == resExpenditures.Count - 1)
                {
                    TextView tvDayExpenditure = new TextView(Singleton.Instance.ExpenditureActivity);
                    tvDayExpenditure.LayoutParameters = lp;
                    tvDayExpenditure.Text = sbThu + "\n" + sbChi + "\n" + sbSum.Append(sum);
                    tvDayExpenditure.TextSize = 15;
                    tvDayExpenditure.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Normal);

                    linearLayout.AddView(tvDayExpenditure);
                }
            }
        }
    }
}