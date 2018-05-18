using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SelfJournal.Constant;
using SelfJournal.Database.Dao;
using SelfJournal.Database.EF;
using SelfJournal.SingleData;
using SelfJournal.Utilities;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

namespace SelfJournal.ActivityStorage
{
    public class GoalFragment : Android.Support.V4.App.Fragment
    {
        public int Index;
        public GoalFragment(int index)
        {
            Index = index;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View v = inflater.Inflate(Resource.Layout.Goal_Fragment, container, false);
            
            #region Get Layout Controls
            Singleton.Instance.GLinearLayout = (LinearLayout)v.FindViewById(Resource.Id.overallLayout);
            Singleton.Instance.GoalSpinner = (Spinner)v.FindViewById(Resource.Id.spinner);
            Singleton.Instance.tvGoalTitle = (TextView)v.FindViewById(Resource.Id.tvGoalTitle);
            Singleton.Instance.tvGoalContent = (TextView)v.FindViewById(Resource.Id.tvGoalContent);
            #endregion

            ToolbarV7 toolbar = (ToolbarV7)v.FindViewById(Resource.Id.toolbar);
            Singleton.Instance.GoalActivity.SetSupportActionBar(toolbar);
            Singleton.Instance.GoalActivity.SupportActionBar.Title = "Goal of";

            List<string> values = SelfJournalDbContext.Instance.GoalTimes.Select(x => x.Name).ToList();

            ArrayAdapter<String> myAdapter = new ArrayAdapter<string>(Singleton.Instance.GoalActivity,
                Android.Resource.Layout.SimpleListItem1, values);
            myAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);

            Singleton.Instance.GoalSpinner.Adapter = myAdapter;
            Singleton.Instance.GoalSpinner.SetSelection(1);
            Singleton.Instance.GoalSpinner.OnItemSelectedListener = new SpinnerOnItemSelectedListener();

            if (Index + 1 <= 12)
            {
                Singleton.Instance.tvGoalTitle.Text = MonthDao.GetMonth(Index + 1).Name;
            }
            else
            {
                Singleton.Instance.tvGoalTitle.Text = "Day " + Index;
            }
            //TextView tvTitle = v.FindViewById<TextView>(Resource.Id.tvGoalTitle);
            //tvTitle.Text = MonthDao.GetMonth(Index+1).Name;

            return v;
        }
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);
            inflater.Inflate(Resource.Menu.addGoalToolbarMenu, menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addGoalItem:
                    break;
                case Resource.Id.deleteGoalItem:

                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
    public class SpinnerOnItemSelectedListener : Java.Lang.Object, AdapterView.IOnItemSelectedListener
    {
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            //string s = (String)Singleton.Instance.GoalSpinner.GetItemAtPosition(position);
            //Singleton.Instance.IDGoalTime = GoalTimeDao.GetId(s);
            //GoalTimeDao.Update(Singleton.Instance.IDGoalTime);
            //GoalUtils.GetGoal();

            string s = (String)Singleton.Instance.GoalSpinner.GetItemAtPosition(position);
            if (s == "Day" && !ConstantValue.isSet)
            {
                ConstantValue.isSet = true;
                ConstantValue.TestCount = 15;
                Singleton.Instance.GoalViewPager.Adapter = new GoalFragmentAdapter(Singleton.Instance.GoalActivity.SupportFragmentManager);
            }
            if (s == "Year" && !ConstantValue.isSetYear)
            {
                ConstantValue.isSetYear = true;
                ConstantValue.TestCount = 7;
                Singleton.Instance.GoalViewPager.Adapter = new GoalFragmentAdapter(Singleton.Instance.GoalActivity.SupportFragmentManager);
            }

            //ConstantValue.TestCount = 1;
        }

        public void OnNothingSelected(AdapterView parent)
        {

        }
    }
}