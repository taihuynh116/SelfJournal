using Android.Widget;
using SelfJournal.SingleData.EF;

namespace SelfJournal.SingleData.Dao
{
    public class GoalContextDao
    {
        public static GoalContext GetGoalContext(int id)
        {
            if (Singleton.Instance.GoalContexts == null)
            {
            }
            else
            {
                if (Singleton.Instance.GoalContexts.Count - 1 < id)
                {
                }
                else return Singleton.Instance.GoalContexts[id];
            }
            Insert(new GoalContext() { ID = id, GoalFragment = new ActivityStorage.GoalFragment(id) });
            return Singleton.Instance.GoalContexts[id];
        }
        public static void Insert(GoalContext goalContext)
        {
            if (Singleton.Instance.GoalContexts == null) Singleton.Instance.GoalContexts = new System.Collections.Generic.List<GoalContext>();
            Singleton.Instance.GoalContexts.Add(goalContext);
        }
        public static void Update(int id, TextView tvContent, LinearLayout linearLayout)
        {
            GoalContext goalContext = GetGoalContext(id);
            goalContext.tvContent = tvContent;
            goalContext.LinearLayout = linearLayout;
        }
    }
}