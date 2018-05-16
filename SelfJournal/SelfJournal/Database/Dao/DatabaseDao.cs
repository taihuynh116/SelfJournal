using SelfJournal.Constant;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SelfJournal.Database.Dao
{
    public class DatabaseDao
    {
        public static void Update(string tableName, int id, List<string> keys, List<object> values)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < keys.Count; i++)
            {
                sb.Append(keys[i] + "=");
                if (values[i] is string)
                {
                    sb.Append("N\'" + values[i] + "\' ");
                }
                else if (values[i] is DateTime)
                {
                    sb.Append("cast(\'" + ((DateTime)values[i]).ToString("yyyy-MM-dd HH:mm:ss") + "\' as datetime) ");
                }
                else
                {
                    sb.Append(values[i].ToString() + " ");
                }
            }
            using (SqlConnection connection = new SqlConnection(ConstantValue.ConnectionString))
            {
                SqlCommand command = new SqlCommand("update " + tableName + " set " + sb + "where ID=" + id, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Insert(string tableName, List<string> keys, List<object> values)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < keys.Count; i++)
            {
                sb1.Append(keys[i]);
                if (i != keys.Count - 1)
                {
                    sb1.Append(", ");
                }

                if (values[i] is string)
                {
                    sb2.Append("N\'" + values[i] + "\'");
                }
                else if (values[i] is DateTime)
                {
                    sb2.Append("cast(\'" + ((DateTime)values[i]).ToString("yyyy-MM-dd HH:mm:ss") + "\' as datetime)");
                }
                else
                {
                    sb2.Append(values[i].ToString());
                }
                if (i != keys.Count - 1)
                {
                    sb2.Append(", ");
                }
            }
            using (SqlConnection connection = new SqlConnection(ConstantValue.ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into "+tableName+" ("+ sb1+") values ("+sb2+");",connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}