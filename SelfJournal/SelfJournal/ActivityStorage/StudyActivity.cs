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
using SelfJournal.StudyDatabase.EF;

namespace SelfJournal.ActivityStorage
{
    [Activity(Label = "StudyActiviy")]
    public class StudyActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Study);

            #region Get Layout Controls
            //Singleton.Instance.HabbitActivity = this;
            //Singleton.Instance.HLinearLayout = (LinearLayout)FindViewById(Resource.Id.overallLayout);
            #endregion

            TextView tvStudy = FindViewById<TextView>(Resource.Id.tvStudy);
            tvStudy.Text = StudyDbContext.Instance.Contents[1].content;
        }
    }
}