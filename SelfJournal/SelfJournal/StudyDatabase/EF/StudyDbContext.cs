using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SelfJournal.Constant;

namespace SelfJournal.StudyDatabase.EF
{
    public class StudyDbContext
    {
        public List<Subject> Subjects
        {
            get
            {
                return GetDataTable(typeof(Subject), ConstantValue.Subject).Cast<Subject>().ToList();
            }
        }
        public List<Class> Classes
        {
            get
            {
                return GetDataTable(typeof(Class), ConstantValue.Class).Cast<Class>().ToList();
            }
        }
        public List<Content> Contents
        {
            get
            {
                return GetDataTable(typeof(Content), ConstantValue.Content).Cast<Content>().ToList();
            }
        }

        public StudyDbContext()
        {

        }
        private static StudyDbContext instance;
        public static StudyDbContext Instance
        {
            get
            {
                if (instance == null) instance = new StudyDbContext();
                return instance;
            }
        }
        private List<object> GetDataTable(Type type, string tableName)
        {
            List<object> objs = new List<object>();
            List<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            using (SqlConnection connection = new SqlConnection(ConstantValue.StudyConnectionString))
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
    }
}