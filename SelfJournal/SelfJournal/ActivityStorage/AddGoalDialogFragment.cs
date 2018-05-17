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
using Android.Views.InputMethods;
using Android.Widget;
using SelfJournal.Database.Dao;
using SelfJournal.SingleData;
using SelfJournal.Utilities;

namespace SelfJournal.ActivityStorage
{
    public class AddGoalDialogFragment : DialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Singleton.Instance.AddGoalView = LayoutInflater.From(Singleton.Instance.GoalActivity)
                .Inflate(Resource.Layout.AddGoal, null);

            Singleton.Instance.AGLinearLayout = (LinearLayout)Singleton.Instance.AddGoalView.FindViewById(Resource.Id.overallLayout);
            GoalUtils.AddGoal();

            Singleton.Instance.AddGoalDialog = new AlertDialog.Builder(Singleton.Instance.GoalActivity)
                .SetView(Singleton.Instance.AddGoalView)
                .SetTitle("Goal of Year")
                .SetPositiveButton("OK", new AddGoalDialogOnClickListener()).Create();
            
            return Singleton.Instance.AddGoalDialog;
        }
    }
}