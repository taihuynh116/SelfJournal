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

namespace SelfJournal.StudyDatabase.EF
{
    public class Subject
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}