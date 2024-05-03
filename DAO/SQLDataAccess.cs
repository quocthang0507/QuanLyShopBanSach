using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class SQLDataAccess
    {
        private static SQLDataAccess instance;

        private string connectionString;
        private SqlConnection sqlConnection;

        public static SQLDataAccess Instance
        {
            get
            {
                if (instance == null)
                    instance = new SQLDataAccess();
                return instance;
            }
        }

        public SQLDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Execute non query, such as: create, insert, update statements
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool? ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int num = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return num > 0;
            }
            catch { return null; }
            finally { sqlConnection.Close(); }
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(SqlCommand cmd)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            try
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                dataAdapter.Fill(dt);
                sqlConnection.Close();

                return dt;
            }
            catch { return null; }
            finally { sqlConnection.Close(); }
        }
    }
}
