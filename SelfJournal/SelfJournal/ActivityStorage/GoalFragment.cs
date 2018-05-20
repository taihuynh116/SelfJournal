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
using SelfJournal.SingleData.Dao;
using SelfJournal.Utilities;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

namespace SelfJournal.ActivityStorage
{
    public class GoalFragment : Android.Support.V4.App.Fragment
    {
        public int Index;
        public GoalFragment(int index)
        {
            this.Index = index;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //HasOptionsMenu = true;
            //Activity.SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.Goal_Fragment, container, false);

            #region Get Layout Controls
            GoalContextDao.Update(Index, v.FindViewById<TextView>(Resource.Id.tvGoalContent), v.FindViewById<LinearLayout>(Resource.Id.overallLayout));

            GoalContextDao.GetGoalContext(Index).UpdateTextView();
            #endregion

            return v;
        }

    }

}