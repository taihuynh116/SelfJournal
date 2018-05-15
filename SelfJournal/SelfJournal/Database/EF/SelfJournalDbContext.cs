using SelfJournal.Constant;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;

namespace SelfJournal.Database.EF
{
    public class SelfJournalDbContext
    {
        public List<Diary> Diaries
        {
            get
            {
                return GetDataTable(typeof(Diary), ConstantValue.Diary).Cast<Diary>().ToList();
            }
        }
        public List<Emotion> Emotions
        {
            get
            {
                return GetDataTable(typeof(Emotion), ConstantValue.Emotion).Cast<Emotion>().ToList();
            }
        }
        public List<Expenditure> Expenditures
        {
            get
            {
                return GetDataTable(typeof(Expenditure), ConstantValue.Expenditure).Cast<Expenditure>().ToList();
            }
        }
        public List<ExpenditureType> ExpenditureTypes
        {
            get
            {
                return GetDataTable(typeof(ExpenditureType), ConstantValue.ExpenditureType).Cast<ExpenditureType>().ToList();
            }
        }
        public List<Goal> Goals
        {
            get
            {
                return GetDataTable(typeof(Goal), ConstantValue.Goal).Cast<Goal>().ToList();
            }
        }
        public List<GoalOfDay> GoalOfDays
        {
            get
            {
                return GetDataTable(typeof(GoalOfDay), ConstantValue.GoalOfDay).Cast<GoalOfDay>().ToList();
            }
        }
        public List<GoalOfMonth> GoalOfMonths
        {
            get
            {
                return GetDataTable(typeof(GoalOfMonth), ConstantValue.GoalOfMonth).Cast<GoalOfMonth>().ToList();
            }
        }
        public List<Habbit> Habbits
        {
            get
            {
                return GetDataTable(typeof(Habbit), ConstantValue.Habbit).Cast<Habbit>().ToList();
            }
        }
        public List<HabbitType> HabbitTypes
        {
            get
            {
                return GetDataTable(typeof(HabbitType), ConstantValue.HabbitType).Cast<HabbitType>().ToList();
            }
        }
        public List<Month> Months
        {
            get
            {
                return GetDataTable(typeof(Month), ConstantValue.Month).Cast<Month>().ToList();
            }
        }
        public List<GoalTime> GoalTimes
        {
            get {
                return GetDataTable(typeof(GoalTime), ConstantValue.GoalTime).Cast<GoalTime>().ToList();
            }
        }
        public SelfJournalDbContext()
        {

        }
        private static SelfJournalDbContext instance;
        public static SelfJournalDbContext Instance
        {
            get
            {
                if (instance == null) instance = new SelfJournalDbContext();
                return instance;
            }
        }
        private List<object> GetDataTable(Type type, string tableName)
        {
            List<object> objs = new List<object>();
            List<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            using (SqlConnection connection = new SqlConnection(ConstantValue.ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from " + tableName, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        object o = Activator.CreateInstance(type);
                        for (int i = 0; i < props.Count; i++)
                        {
                            props[i].SetValue(o, reader[i]);
                        }
                        objs.Add(o);
                    }
                }
                catch
                {
                    throw;
                }
            }
            return objs;
        }
        public void UpdateDiary(string content)
        {
            using (SqlConnection connection = new SqlConnection(ConstantValue.ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into " + ConstantValue.Diary +" (Content)"+ " values (\'"+ content+"\');", connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //insert into Diary(Content) values('Ngày 5');
            }
        }
    }
}