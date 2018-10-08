using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JCWK_DEMO
{
    public static class SqlHelper<T>
    {
        private static string _strSQL = string.Empty;

        static SqlHelper()
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            _strSQL = $"SELECT {string.Join(",", type.GetProperties().Select(p => p.Name))} FROM {type.Name}";
        }

        public static string GetSearchSql(string strJCLSH)
        {
            return string.Format($"{_strSQL} WHERE JCLSH = '{{0}}'", strJCLSH);
        }

        public static string GetSearchSql()
        {
            return _strSQL;
        }
    }
}
