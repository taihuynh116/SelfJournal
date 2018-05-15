using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

using SelfJournal.SingleData;
using SelfJournal.Utilities;
using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;

namespace SelfJournal.ActivityStorage
{
    [Activity(Label = "GoalActivity")]
    public class GoalActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Goal);

            #region Get Layout Controls
            Singleton.Instance.GoalActivity = this;
            Singleton.Instance.GLinearLayout = (LinearLayout)FindViewById(Resource.Id.overallLayout);
            Singleton.Instance.tvGoalContent = (TextView)FindViewById(Resource.Id.tvGoalContent);
            Singleton.Instance.GoalSpinner = (Spinner)FindViewById(Resource.Id.spinner);
            Singleton.Instance.tvGoalTitle = (TextView)FindViewById(Resource.Id.tvGoalTitle);
            #endregion

            ToolbarV7 toolbar =(ToolbarV7)FindViewById(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Goal of";

            List<string> values = SelfJournalDbContext.Instance.GoalTimes.Select(x => x.Name).ToList();

            ArrayAdapter<String> myAdapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItem1, values);
            myAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);

            Singleton.Instance.GoalSpinner.Adapter = myAdapter;
            Singleton.Instance.GoalSpinner.OnItemSelectedListener = new SpinnerOnItemSelectedListener();
            Singleton.Instance.GoalSpinner.SetSelection(0);
        }
    }
    public class SpinnerOnItemSelectedListener :Java.Lang.Object, AdapterView.IOnItemSelectedListener
    {
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            string s= (String)Singleton.Instance.GoalSpinner.GetItemAtPosition(position);
            Singleton.Instance.IDGoalTime = GoalTimeDao.GetId(s);
            GoalTimeDao.Update(Singleton.Instance.IDGoalTime);
            GoalUtils.GetGoal();
        }

        public void OnNothingSelected(AdapterView parent)
        {
            
        }
    }
}