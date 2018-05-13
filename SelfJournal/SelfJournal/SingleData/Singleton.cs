using Android.Widget;
using System;

namespace SelfJournal.SingleData
{
    public class Singleton
    {
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null) instance = new Singleton();
                return instance;
            }
        }
        #region Main Activity and its controls
        public MainActivity MainActivity { get; set; }
        public TextView tvGoalOfYear { get; set; }
        public TextView tvMonthTitle { get; set; }
        public TextView tvGoalOfMonth { get; set; }
        public TextView tvDayTitle { get; set; }
        public TextView tvGoalOfDay { get; set; }
        #endregion


    }
}