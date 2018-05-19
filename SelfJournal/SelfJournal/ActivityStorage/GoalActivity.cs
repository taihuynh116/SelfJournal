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
            #endregion

            ToolbarV7 toolbar = (ToolbarV7)FindViewById(Resource.Id.toolbar);
            Singleton.Instance.GoalActivity.SetSupportActionBar(toolbar);
            Singleton.Instance.GoalActivity.SupportActionBar.Title = "Goal of";

            List<string> values = SelfJournalDbContext.Instance.GoalTimes.Select(x => x.Name).ToList();

            ArrayAdapter<string> myAdapter = new ArrayAdapter<string>(Singleton.Instance.GoalActivity,
                Android.Resource.Layout.SimpleListItem1, values);
            myAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);

            Singleton.Instance.GoalSpinner.Adapter = myAdapter;
            Singleton.Instance.GoalSpinner.SetSelection(1);
            Singleton.Instance.GoalSpinner.OnItemSelectedListener = new SpinnerOnItemSelectedListener();

            Singleton.Instance.GoalViewPager.Adapter = new GoalFragmentAdapter(SupportFragmentManager);
            Singleton.Instance.GoalViewPager.AddOnPageChangeListener(new GoalFragmentPagerChangeListener());

            Singleton.Instance.tvGoalTitle.Text = "Day 1";
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

        }

        public override int Count { get { /*return 12;*/ return ConstantValue.TestCount; } }

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
            //Singleton.Instance.tvGoalTitle.Text = "Day " + (position+1);
        }
    }
    public class SpinnerOnItemSelectedListener : Java.Lang.Object, AdapterView.IOnItemSelectedListener
    {
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
        }

        public void OnNothingSelected(AdapterView parent)
        {

        }
    }
}