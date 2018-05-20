using Android.App;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.Database.Dao;
using SelfJournal.Utilities;

namespace SelfJournal.SingleData.EF
{
    public class GoalContext
    {
        public int ID { get; set; }
        public bool IsViewCreated { get { return tvContent != null; } }
        public TextView tvContent { get; set; }
        public LinearLayout LinearLayout { get; set; }
        public GoalFragment GoalFragment { get; set; }
        public void UpdateTextView()
        {
            switch (GoalTimeDao.GetGoalTime().Name)
            {
                case "Year":
                    tvContent.Text = GoalUtils.GetGoalsYear();
                    break;
                case "Month":
                    tvContent.Text = GoalUtils.GetGoalsMonth(ID + 1);
                    break;
                case "Day":
                    tvContent.Text = GoalUtils.GetGoalsDay(MonthDao.GetSelectedMonth().ID, ID + 1);
                    break;
            }
        }
    }
}