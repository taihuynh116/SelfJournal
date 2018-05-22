using Android.Widget;
using SelfJournal.SingleData.EF;

namespace SelfJournal.SingleData.Dao
{
    public class CurrentTimeDao
    {
        public CurrentTime GetCurrentTime()
        {
            if (Singleton.Instance.CurrentTime == null) Singleton.Instance.CurrentTime = new CurrentTime();
            return Singleton.Instance.CurrentTime;
        }
        public void SetMonth(int idMonth)
        {
            GetCurrentTime().IDMonth = idMonth;
        }
        public void SetDay(int idDay)
        {
            GetCurrentTime().IDDay = idDay;
        }
        public void SetMonthAndDay(int idMonth, int idDay)
        {
            var obj = GetCurrentTime();
            obj.IDMonth = idMonth;
            obj.IDDay = idDay;
        }
    }
}