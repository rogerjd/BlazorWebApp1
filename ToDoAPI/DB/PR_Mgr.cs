using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.DB
{
    public class PR_Mgr
    {
        public DataTable GetEmp()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("FName");
            tbl.Columns.Add("LName");

            tbl.Rows.Add("Joe", "Mklq");

            return tbl;
        }
    }
}
