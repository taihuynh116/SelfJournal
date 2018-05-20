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
using Android.Support.V4.View;
using Android.Support.V4.App;
using SelfJournal.Constant;
using SelfJournal.SingleData.EF;
using SelfJournal.SingleData.Dao;
using Java.Lang;

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
            Singleton.Instance.GoalSpinner = (Spinner)FindViewById(Resource.Id.spinner);
            Singleton.Instance.tvGoalTitle = (TextView)FindViewById(Resource.Id.tvGoalTitle);
            Singleton.Instance.GoalViewPager = FindViewById<ViewPager>(Resource.Id.goalViewPager);
            Singleton.Instance.MonthSpinner = FindViewById<Spinner>(Resource.Id.monthSpinner);
            #endregion

            ToolbarV7 toolbar = (ToolbarV7)FindViewById(Resource.Id.toolbar);
            Singleton.Instance.GoalActivity.SetSupportActionBar(toolbar);
            Singleton.Instance.GoalActivity.SupportActionBar.Title = "Goal of";

            List<string> values = SelfJournalDbContext.Instance.GoalTimes.Select(x => x.Name).ToList();
            List<string> months = SelfJournalDbContext.Instance.Months.Select(x => x.Title).ToList();

            ArrayAdapter<string> myAdapter = new ArrayAdapter<string>(Singleton.Instance.GoalActivity,
                Android.Resource.Layout.SimpleListItem1, values);
            myAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);

            //ArrayAdapter<string> myAdapter = new ArrayAdapter<string>(Singleton.Instance.GoalActivity,
            //    Resource.Layout.SpinnerLook, values);
            //myAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);


            Singleton.Instance.GoalSpinner.Adapter = myAdapter;
            Singleton.Instance.GoalSpinner.SetSelection(1);
            Singleton.Instance.GoalSpinner.OnItemSelectedListener = new SpinnerOnItemSelectedListener();

            ArrayAdapter<string> monthAdapter = new ArrayAdapter<string>(Singleton.Instance.GoalActivity, Android.Resource.Layout.SimpleListItem1, months);
            monthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);

            Singleton.Instance.MonthSpinner.Adapter = monthAdapter;
            Singleton.Instance.MonthSpinner.OnItemSelectedListener = new MonthSpinnerOnItemSelectedListener();


            Singleton.Instance.GoalViewPager.Adapter = new GoalFragmentAdapter(SupportFragmentManager);
            Singleton.Instance.GoalViewPager.AddOnPageChangeListener(new GoalFragmentPagerChangeListener());

            Singleton.Instance.tvGoalTitle.Text = "Jan";
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.addGoalToolbarMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    if (item.ItemId == Resource.Id.addGoalItem)
        //    {
        //        new AddGoalDialogFragment().Show(Singleton.Instance.GoalActivity.FragmentManager, "Add Goal");
        //    }
        //    else if (item.ItemId == Resource.Id.deleteGoalItem)
        //    {
        //        new DeleteGoalDialogFragment().Show(Singleton.Instance.GoalActivity.FragmentManager, "Delete Goal");
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
    }
    public class GoalFragmentAdapter : FragmentPagerAdapter
    {
        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
        }
        public GoalFragmentAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            switch (GoalTimeDao.GetGoalTime().Name)
            {
                case "Year":
                    Singleton.Instance.tvGoalTitle.Text = "2018";
                    break;
                case "Month":
                    Singleton.Instance.tvGoalTitle.Text = "Jan";
                    break;
                case "Day":
                    Singleton.Instance.tvGoalTitle.Text = "1";
                    break;
            }
        }

        public override int Count
        {
            get
            {
                switch (GoalTimeDao.GetGoalTime().Name)
                {
                    case "Year":
                        return 1;
                    case "Month":
                        return 12;
                    case "Day":
                        return MonthDao.GetMonth(5).DayCount;
                }
                return 0;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            //return Singleton.Instance.GoalFragment;
            return GoalContextDao.GetGoalContext(position).GoalFragment;
        }
    }

    public class GoalFragmentPagerChangeListener : Java.Lang.Object, ViewPager.IOnPageChangeListener
    {
        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageSelected(int position)
        {
            switch (GoalTimeDao.GetGoalTime().Name)
            {
                case "Year":
                    Singleton.Instance.tvGoalTitle.Text = "2018";
                    break;
                case "Month":
                    Singleton.Instance.tvGoalTitle.Text = MonthDao.GetMonth(position + 1).Title;
                    break;
                case "Day":
                    Singleton.Instance.tvGoalTitle.Text = (position + 1).ToString();
                    break;
            }
        }
    }
    public class SpinnerOnItemSelectedListener : Java.Lang.Object, AdapterView.IOnItemSelectedListener
    {
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            string goalTime = (string)Singleton.Instance.GoalSpinner.SelectedItem;
            if (goalTime == "Day") { Singleton.Instance.MonthSpinner.Visibility = ViewStates.Visible; }
            else { Singleton.Instance.MonthSpinner.Visibility = ViewStates.Gone; }

            GoalTimeDao.Update(goalTime);
            var obj = new GoalFragmentAdapter(Singleton.Instance.GoalActivity.SupportFragmentManager);
            Singleton.Instance.GoalViewPager.Adapter = obj;
            Singleton.Instance.GoalViewPager.AddOnPageChangeListener(new GoalFragmentPagerChangeListener());
            var instance = Singleton.Instance;

            for (int i = 0; i < obj.Count; i++)
            {
                GoalContext goalContext = GoalContextDao.GetGoalContext(i);
                if (goalContext.IsViewCreated)
                {
                    goalContext.UpdateTextView();
                }
                else
                {
                    break;
                }
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {

        }
    }
    public class MonthSpinnerOnItemSelectedListener : Java.Lang.Object, AdapterView.IOnItemSelectedListener
    {
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            MonthDao.UpdateByTitle((string)Singleton.Instance.MonthSpinner.SelectedItem);

            for (int i = 0; i < 28; i++)
            {
                GoalContext goalContext = GoalContextDao.GetGoalContext(i);
                if (goalContext.IsViewCreated)
                {
                    goalContext.UpdateTextView();
                }
                else
                {
                    break;
                }
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {

        }
    }
}