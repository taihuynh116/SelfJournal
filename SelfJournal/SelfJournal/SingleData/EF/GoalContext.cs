using Android.App;
using Android.Widget;
using SelfJournal.ActivityStorage;

namespace SelfJournal.SingleData.EF
{
    public class GoalContext
    {
        public int ID { get; set; }
        public TextView tvContent { get; set; }
        public LinearLayout LinearLayout { get; set; }
        public GoalFragment GoalFragment { get; set; }
    }
}