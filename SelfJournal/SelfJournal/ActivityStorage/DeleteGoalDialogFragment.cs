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
    public class DeleteGoalDialogFragment : DialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Singleton.Instance.DeleteGoalView = LayoutInflater.From(Singleton.Instance.GoalActivity)
                .Inflate(Resource.Layout.DeleteGoal, null);

            Singleton.Instance.DGLinearLayout = (LinearLayout)Singleton.Instance.DeleteGoalView.FindViewById(Resource.Id.overallLayout);
            Singleton.Instance.DeleteGoalDialog = new AlertDialog.Builder(Singleton.Instance.GoalActivity)
                .SetView(Singleton.Instance.DeleteGoalView)
                .SetPositiveButton("OK", new DeleteGoalDialogOnClickListener()).Create();

            GoalUtils.DeleteGoal();

            return Singleton.Instance.DeleteGoalDialog;
        }
    }
}