using Android.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using SelfJournal.ActivityStorage;
using SelfJournal.ProjectData;
using System;
using System.Collections.Generic;

namespace SelfJournal.SingleData
{
    public class Singleton
    {
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null) instance = new Singleton();
                return instance;
            }
        }

        #region Day Data
        public int IDMonth { get; set; }
        public int IDDay { get; set; }
        public int IDGoalTime { get; set; }
        public List<GoalCheckBox> GoalCheckBoxs { get; set; }
        #endregion

        #region Main Activity and its controls
        public MainActivity MainActivity { get; set; }
        public TextView tvGoal { get; set; }
        public TextView tvExpenditure { get; set; }
        public TextView tvEmotion { get; set; }
        public TextView tvHabbit { get; set; }
        public TextView tvDiary { get; set; }
        #endregion

        #region Expenditure Activity and its controls
        public ExpenditureActivity ExpenditureActivity { get; set; }
        public LinearLayout ELinearLayout { get; set; }
        #endregion

        #region Emotion Activity and its controls
        public EmotionActivity EmotionActivity { get; set; }
        public LinearLayout EmLinearLayout { get; set; }
        #endregion

        #region Habbit Activity and its controls
        public HabbitActivity HabbitActivity { get; set; }
        public LinearLayout HLinearLayout { get; set; }
        #endregion

        #region Diary Activity and its controls
        public DiaryActivity DiaryActivity { get; set; }
        public LinearLayout DLinearLayout { get; set; }
        #endregion

        #region Goal Activity and its controls
        public GoalActivity GoalActivity { get; set; }
        private GoalFragment goalFragment;
        public GoalFragment GoalFragment
        {
            get
            {
                if (goalFragment == null) goalFragment = new GoalFragment(100);
                return goalFragment;
            }
        }
        public ViewPager GoalViewPager { get; set; }
        public LinearLayout GLinearLayout { get; set; }
        public TextView tvGoalTitle { get; set; }
        public TextView tvGoalContent { get; set; }
        public Spinner GoalSpinner { get; set; }
        #endregion

        #region Add Goal Dialog and its controls
        public AlertDialog AddGoalDialog { get; set; }
        public View AddGoalView { get; set; }
        public EditText AddGoalEditText { get; set; }
        public LinearLayout AGLinearLayout { get; set; }

        public AlertDialog DeleteGoalDialog { get; set; }
        public View DeleteGoalView { get; set; }
        public LinearLayout DGLinearLayout { get; set; }
        #endregion
    }
}