using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SelfJournal.SingleData;
using SelfJournal.Utilities;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

namespace SelfJournal.ActivityStorage
{
    [Activity(Label = "Expenditure")]
    public class ExpenditureActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Expenditure);

            #region Get Layout Controls
            Singleton.Instance.ExpenditureActivity = this;
            Singleton.Instance.ELinearLayout = (LinearLayout)this.FindViewById(Resource.Id.overallLayout);
            #endregion

            ExpenditureUtils.GetExpenditure();
        }
    }
}