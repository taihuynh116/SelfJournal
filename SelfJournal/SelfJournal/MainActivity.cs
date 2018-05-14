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
using Android.Views;

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
            Singleton.Instance.tvExpenditure = (TextView)this.FindViewById(Resource.Id.tvExpdenditure);
            Singleton.Instance.tvEmotion = (TextView)this.FindViewById(Resource.Id.tvEmotion);
            Singleton.Instance.tvHabbit = (TextView)this.FindViewById(Resource.Id.tvHabbit);
            Singleton.Instance.tvDiary = (TextView)this.FindViewById(Resource.Id.tvDiary);
            #endregion

            Singleton.Instance.tvExpenditure.SetOnClickListener(new ExpenditureClickListener());
            Singleton.Instance.tvEmotion.SetOnClickListener(new EmotionClickListener());
            Singleton.Instance.tvHabbit.SetOnClickListener(new HabbitClickListener());
            Singleton.Instance.tvDiary.SetOnClickListener(new DiaryClickListener());

            GoalUtils.GetGoalOfYear();
            GoalUtils.GetGoalOfMonth();
            GoalUtils.GetGoalOfDay();
        }
    }
    public class ExpenditureClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public void OnClick(View v)
        {
            ExpenditureUtils.StartExpenditureActivity();
        }
    }
    public class EmotionClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public void OnClick(View v)
        {
            EmotionUtils.StartEmotionActivity();
        }
    }
    public class HabbitClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public void OnClick(View v)
        {
            HabbitUtils.StartHabbitActivity();
        }
    }
    public class DiaryClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public void OnClick(View v)
        {
            DiaryUtils.StartDiaryAcitivy();
        }
    }
}

