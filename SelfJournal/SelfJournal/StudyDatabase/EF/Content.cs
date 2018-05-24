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
    public class Content
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? ID2 { get; set; }
        public int IDClass { get; set;}
        public string content { get; set; }
    }
}