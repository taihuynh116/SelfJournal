﻿using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Text;
using SelfJournal.Database.EF;

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

            TextView tvGoalOfYear = (TextView)this.FindViewById(Resource.Id.tvGoalOfYear);

            SelfJournalDbContext.Instance.UpdateDiary("Ngày 3");
            SelfJournalDbContext.Instance.UpdateDiary("Ngày 10");
        }
        public List<string> GetData()
        {
            List<string> data = new List<string>();
            string conn = "data source=103.252.252.163;initial catalog=SelfJournal;persist security info=True;user id=misery;password=Skarner116!;MultipleActiveResultSets=True;App=EntityFramework";
            using (SqlConnection connection = new SqlConnection(conn))
            {

                SqlCommand command = new SqlCommand("select Name from Goal", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return data;
        }
    }
    
}

