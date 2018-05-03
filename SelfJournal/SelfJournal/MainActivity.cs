using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkWithXamarin;
using EntityFrameworkWithXamarin.Core;
using System.Collections.Generic;
using Database.Dao;

namespace SelfJournal
{
    [Activity(Label = "SelfJournal", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var res = GoalDao.Instance.GetGoals();
        }
    }
}

