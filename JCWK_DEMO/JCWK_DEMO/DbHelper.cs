using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JCWK_DEMO
{
    public class DbHelper
    {
        private string _strConn = null;

        public DbHelper(string strServer, string strUser, string strPwd, string strDBName)
        {
            _strConn = $@"server={strServer};User Id = {strUser};Password={strPwd};Initial Catalog={strDBName}";
        }

        public void ExcuteSql(string strSql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_strConn))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strSql;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.ExecuteNonQuery();
            }

        }
        public T Query<T>(string strSql)
        {
            T t = Activator.CreateInstance<T>();
            using (SqlConnection sqlConnection = new SqlConnection(_strConn))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strSql;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    foreach (PropertyInfo propertyInfo in t.GetType().GetProperties())
                    {
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            if (sqlDataReader.GetName(i) == propertyInfo.Name && sqlDataReader.GetValue(i) != DBNull.Value)
                            {
                                if (propertyInfo.PropertyType == typeof(string))
                                {
                                    propertyInfo.SetValue(t, Convert.ToString(sqlDataReader[propertyInfo.Name]),null);
                                }
                                if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                                {
                                    propertyInfo.SetValue(t, Convert.ToInt32(sqlDataReader[propertyInfo.Name]),null);
                                }
                            }
                        }
                    }
                }
            }
            return t;
        }

        public List<T> QueryList<T>(string strSql)
        {
            List<T> list = new List<T>();
            using (SqlConnection sqlConnection = new SqlConnection(_strConn))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strSql;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    T t = Activator.CreateInstance<T>();

                    foreach (PropertyInfo propertyInfo in t.GetType().GetProperties())
                    {
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            if (sqlDataReader.GetName(i) == propertyInfo.Name && sqlDataReader.GetValue(i) != DBNull.Value)
                            {
                                if (propertyInfo.PropertyType == typeof(string))
                                {
                                    propertyInfo.SetValue(t, Convert.ToString(sqlDataReader[propertyInfo.Name]),null);
                                }
                                if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                                {
                                    propertyInfo.SetValue(t, Convert.ToInt32(sqlDataReader[propertyInfo.Name]),null);
                                }
                            }
                        }
                    }
                    list.Add(t);
                }
            }
            return list;
        }




    }
}
