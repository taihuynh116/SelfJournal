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

            Singleton.Instance.AddGoalEditText = (EditText)Singleton.Instance.AddGoalView.FindViewById(Resource.Id.etGoalOfYear);
            Singleton.Instance.AddGoalEditText.OnFocusChangeListener = new GoalEditTextOnFocusChangeListener();

            Singleton.Instance.AddGoalDialog = new AlertDialog.Builder(Singleton.Instance.GoalActivity)
                .SetView(Singleton.Instance.AddGoalView)
                .SetTitle("Goal of Year")
                .SetPositiveButton("OK", new AddGoalDialogOnClickListener()).Create();
            
            return Singleton.Instance.AddGoalDialog;
        }
    }
    public class AddGoalDialogOnClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        public void OnClick(IDialogInterface dialog, int which)
        {
            InputMethodManager imm = (InputMethodManager)Singleton.Instance.GoalActivity.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(Singleton.Instance.AddGoalView.WindowToken, HideSoftInputFlags.None);

            GoalDao.Insert(Singleton.Instance.AddGoalEditText.Text);
            GoalUtils.GetGoal();
            dialog.Dismiss();
        }
    }
    public class GoalEditTextOnFocusChangeListener : Java.Lang.Object, View.IOnFocusChangeListener
    {
        public void OnFocusChange(View v, bool hasFocus)
        {
            if (hasFocus)
            {
                InputMethodManager imm =(InputMethodManager) Singleton.Instance.GoalActivity.GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(Singleton.Instance.AddGoalView, ShowFlags.Forced);
                imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            }
        }
    }
}