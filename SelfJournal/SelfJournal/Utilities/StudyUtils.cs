using Android.Content;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Database.Dao;
using SelfJournal.SingleData;

namespace SelfJournal.Utilities
{
    public static class StudyUtils
    {
        public static void StartStudyActivity()
        {
            Intent i = new Intent(Singleton.Instance.MainActivity, typeof(StudyActivity));
            Singleton.Instance.MainActivity.StartActivity(i);
        }
    }
}