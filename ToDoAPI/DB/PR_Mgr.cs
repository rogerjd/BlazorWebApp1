using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ToDoAPI.DB
{
    public class PR_Mgr
    {
        string connStr;
        SqlConnection sqlConnection;
        public PR_Mgr()
        {
            connStr = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\ROGER\SOURCE\REPOS\GITHUB.COM\ROGERJD\WINFORMSAPP1\WINFORMSAPP1\BIN\DEBUG\PAYROLL.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connStr);

            //Microsoft.Extensions.Configuration.IConfiguration.     IConfiguration.GetConnectionString();
        }

        public DataTable GetEmp()
        {
            DataTable tbl = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Employees");
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            return tbl;

            tbl.Columns.Add("FName");
            tbl.Columns.Add("LName");

            tbl.Rows.Add("Joe", "Mklq");

            return tbl;
        }
    }
}
