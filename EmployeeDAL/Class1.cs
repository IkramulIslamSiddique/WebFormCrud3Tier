using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EmployeeSchema;
namespace EmployeeDAL
{
    public class Class1
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4UGD1CG;Initial Catalog=Employee;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        public int InsertData(EmployeeSchema.Class1 objSchema)
        {
            try
            {
                using (cmd = new SqlCommand("Insert_User_Data", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "ADD");
                    cmd.Parameters.AddWithValue("@Name", objSchema.Name);
                    cmd.Parameters.AddWithValue("@Address", objSchema.Address);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(objSchema.Age));
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public int UpdateData(EmployeeSchema.Class1 objSchema, int Id)
        {
            try
            {
                using (cmd = new SqlCommand("Insert_User_Data", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Update");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", objSchema.Name);
                    cmd.Parameters.AddWithValue("@Address", objSchema.Address);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(objSchema.Age));
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public int DeleteData(int Id)
        {
            try
            {
                using (cmd = new SqlCommand("Insert_User_Data", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Delete");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable BindGrid()
        {
            using (cmd = new SqlCommand("Insert_User_Data", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Get_For_Grid");
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable GetById(int Id)
        {
            using (cmd = new SqlCommand("Insert_User_Data", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Para", "Get_By_Id");
                    cmd.Parameters.AddWithValue("@Id", Id);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}