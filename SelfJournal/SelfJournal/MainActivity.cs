using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Text;
using SelfJournal.Database.EF;
using SelfJournal.Database.Dao;
using SelfJournal.Constant;
using SelfJournal.SingleData;
using SelfJournal.Utilities;

namespace SelfJournal
{
    [Activity(Label = "SelfJournal", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            #region Get Layout Controls
            Singleton.Instance.MainActivity = this;
            Singleton.Instance.tvGoalOfYear = (TextView)this.FindViewById(Resource.Id.tvGoalOfYear);
            Singleton.Instance.tvMonthTitle = (TextView)this.FindViewById(Resource.Id.tvMonthTitle);
            Singleton.Instance.tvGoalOfMonth = (TextView)this.FindViewById(Resource.Id.tvGoalOfMonth);
            Singleton.Instance.tvDayTitle = (TextView)this.FindViewById(Resource.Id.tvDayTitle);
            Singleton.Instance.tvGoalOfDay = (TextView)this.FindViewById(Resource.Id.tvGoalOfDay);
            #endregion

            GoalUtils.GetGoalOfYear();
            GoalUtils.GetGoalOfMonth();
            GoalUtils.GetGoalOfDay();
        }
    }
    
}

