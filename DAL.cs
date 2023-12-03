using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class DAL
    {
        public ConnectionState Connection = ConnectionState.Closed;
        public bool isProCall = false;  // for store procedure 
        // generic list
        List<SqlParameter> paralist= new List<SqlParameter>();
        public SqlConnection GetConnection()
        {
            string ConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            return con;
        }
        public void ClearParameters()
        {
            paralist.Clear();
        }
        public void addParameters(string paraname,string value)
        {
            paralist.Add(new SqlParameter(paraname, value));  //value=action
        }
        public SqlCommand GetCommand(string query)
        {
            SqlCommand cmd = new SqlCommand();
            if (isProCall)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paralist.ToArray());
            }
           
            else
                cmd.CommandType = CommandType.Text;
                cmd.CommandText=query;
                cmd.Connection=GetConnection();
                return cmd;
        }

        public DataSet gettables(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(GetCommand(query));
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable gettable(string query)
        {
            DataTable dt=new DataTable();
            SqlCommand cmd = GetCommand(query);

            cmd.Connection.Open();
            SqlDataReader rdr=cmd.ExecuteReader();
            if(rdr!=null && rdr.HasRows)
            {
                dt.Load(rdr);
                cmd.Connection.Close();
            }
            return dt;
        }

        public object GetId(string query)
        {
            SqlCommand cmd=GetCommand(query);
            cmd.Connection.Open();
            object retval=cmd.ExecuteScalar();
            cmd.Connection.Close();
            return retval;
        }

        public int ExecuteQuery(string query)  //for update del insert 
        {
            SqlCommand cmd=GetCommand(query);
            cmd.Connection.Open();
            int retval=cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return retval;
        }

        public SqlDataReader getreader(string query)
        {
            SqlCommand cmd=GetCommand(query);
            cmd.Connection.Open();
            SqlDataReader rdr=cmd.ExecuteReader(CommandBehavior.CloseConnection); // commandbehaviour is used to close the command
            return rdr;
        }
    }
