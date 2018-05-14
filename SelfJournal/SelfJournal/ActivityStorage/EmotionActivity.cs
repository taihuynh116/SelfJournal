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

namespace SelfJournal.ActivityStorage
{
    [Activity(Label = "EmotionActivity")]
    public class EmotionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Emotion);

            #region Get Layout Controls
            Singleton.Instance.EmotionActivity = this;
            Singleton.Instance.EmLinearLayout = (LinearLayout)this.FindViewById(Resource.Id.overallLayout);
            #endregion

            EmotionUtils.GetEmotion();
        }
    }
}