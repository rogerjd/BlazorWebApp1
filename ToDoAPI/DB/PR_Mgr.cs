using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ClassLibrary2.Models;

namespace ToDoAPI.DB
{
    public class PR_Mgr: IDisposable
    {
        string connStr;
        SqlConnection sqlConnection;
        public PR_Mgr()
        {
            connStr = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\ROGER\SOURCE\REPOS\GITHUB.COM\ROGERJD\WINFORMSAPP1\WINFORMSAPP1\BIN\DEBUG\PAYROLL.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();

            //Microsoft.Extensions.Configuration.IConfiguration.     IConfiguration.GetConnectionString();
        }

        private SqlCommand GetSqlCommand(string cmdName)
        {
            SqlCommand cmd = new SqlCommand(cmdName, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public DataTable GetEmps()
        {
            DataTable tbl = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Employees");
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            sqlConnection.Close();
            return tbl;

            tbl.Columns.Add("FName");
            tbl.Columns.Add("LName");

            tbl.Rows.Add("Joe", "Mklq");

            return tbl;
        }

        public DataTable GetEmpByID(int id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetSqlCommand("EmpGet");   // new SqlCommand("EmpGet", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpID", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            sqlConnection.Close();
            return dt;
        }

        public int EmpUpdate(Emp emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("EmpUpdate", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", emp.ID);
                cmd.Parameters.AddWithValue("FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("LastName", emp.LastName);
                var n = cmd.ExecuteNonQuery();
                return n;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //sqlConnection.Close();
            }
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
