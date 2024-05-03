using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    /// <summary>
    /// Tầng Data Access: Đơn hàng
    /// </summary>
    public class DonHangDAO
    {
        private static DonHangDAO instance;

        private string connectionString;
        private SqlConnection sqlConnection;

        public static DonHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonHangDAO();
                return instance;
            }
        }

        public DonHangDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Insert a DonHangDTO to database
        /// </summary>
        /// <param name="donHang"></param>
        /// <returns>
        /// true if it was inserted successfully<br/>
        /// false if it wasn't inserted<br/>
        /// null if there was an error when executing
        /// </returns>
        public bool? Insert(DonHangDTO donHang)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO DonHang " +
                "VALUES(@idSach, @tenSach, @soLuong, @giaTien, @ngayMua)";

            cmd.Parameters.AddWithValue("@idSach", donHang.IdSach);
            cmd.Parameters.AddWithValue("@tenSach", donHang.TenSach);
            cmd.Parameters.AddWithValue("@soLuong", donHang.SoLuong);
            cmd.Parameters.AddWithValue("@giaTien", donHang.GiaTien);
            cmd.Parameters.AddWithValue("@ngayMua", donHang.NgayMua);

            return SQLDataAccess.Instance.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Get all items from table DonHang
        /// </summary>
        /// <returns>
        /// A DataTable contains all items from DonHang <br/>
        /// null if there was an error when querying
        /// </returns>
        public DataTable GetAllAsDataTable()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM DonHang"
            };

            return SQLDataAccess.Instance.ExecuteQuery(cmd);
        }
    }
}
