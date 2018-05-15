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
                    sb.Append("\'" + values[i] + "\' ");
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
    }
}