using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ToDoAPI.DB
{
    public static class DBUtil
    {
        public static List<T> BindList<T>(DataTable dt)
        {
            var fields = typeof(T).GetProperties(BindingFlags.Public); // GetFields();
            List<T> lst = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                var ob = Activator.CreateInstance<T>();
                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (fieldInfo.Name == column.ColumnName)
                        {
                            object val = row[column.ColumnName];
                            fieldInfo.SetValue(ob, val);
                            break;
                        }
                    }
                }
                lst.Add(ob);
            }

            return lst;
        }
    }
}
