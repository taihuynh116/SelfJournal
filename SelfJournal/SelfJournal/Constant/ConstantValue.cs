using System;

namespace SelfJournal.Constant
{
    public class ConstantValue
    {
        public static string ConnectionString = "data source=103.252.252.163;initial catalog=SelfJournal;persist security info=True;user id=misery;password=Skarner116!;MultipleActiveResultSets=True;App=EntityFramework";

        public static string Diary = "Diary";
        public static string Emotion = "Emotion";
        public static string Expenditure = "Expenditure";
        public static string ExpenditureType = "ExpenditureType";
        public static string Goal = "Goal";
        public static string GoalOfMonth = "GoalOfMonth";
        public static string GoalOfDay = "GoalOfDay";
        public static string Habbit = "Habbit";
        public static string HabbitType = "HabbitType";
        public static string Month = "Month";
        public static string GoalTime = "GoalTime";

        public static string GoalOfYearTitle = "Goal of Year";
        public static string GoalOfMonthTitle = "Goal of Month: ";
        public static string GoalOfDayTitle = "Goal of Day: ";

        public static int TestCount = 5;
        public static bool isSet = false;
        public static bool isSetYear = false;
    }
    public enum MonthEnum
    {
        January=1,
        February=2,
        March=3,
        April=4,
        May=5,
        June=6,
        July=7,
        August=8,
        September=9,
        October=10,
        November=11,
        December=12
    }
}