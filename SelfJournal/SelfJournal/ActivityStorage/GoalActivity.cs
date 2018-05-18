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
            Singleton.Instance.GoalViewPager = FindViewById<ViewPager>(Resource.Id.goalViewPager);
            #endregion

            

            Singleton.Instance.GoalViewPager.Adapter = new GoalFragmentAdapter(SupportFragmentManager);
        }
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.addGoalToolbarMenu, menu);

        //    return base.OnCreateOptionsMenu(menu);
        //}
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
            return new GoalFragment(position);
        }
    }
    
}