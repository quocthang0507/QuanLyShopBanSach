using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
    /// <summary>
    /// Tầng Data Access: Sách
    /// </summary>
    public class SachDAO
    {
        private static SachDAO instance;

        public static SachDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SachDAO();
                return instance;
            }
        }

        /// <summary>
        /// Get all items from table KhoSach
        /// </summary>
        /// <returns>
        /// A list of SachDTO contains all items from KhoSach <br/>
        /// null if there was an error when querying
        /// </returns>
        public List<SachDTO> GetAllAsList()
        {
            DataTable dt = GetAllAsDataTable();
            if (dt != null)
            {
                try
                {
                    return (from row in dt.AsEnumerable() select new SachDTO(row)).ToList();
                }
                catch { return null; }
            }
            return null;
        }

        /// <summary>
        /// Get all items from table KhoSach
        /// </summary>
        /// <returns>
        /// A DataTable contains all items from KhoSach <br/>
        /// null if there was an error when querying
        /// </returns>
        public DataTable GetAllAsDataTable()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM KhoSach"
            };

            return SQLDataAccess.Instance.ExecuteQuery(cmd);
        }

        /// <summary>
        /// Find KhoSach by TacGia
        /// </summary>
        /// <returns>
        /// A DataTable contains KhoSach <br/>
        /// null if there was an error when querying
        /// </returns>
        public DataTable FindByTacGia(string tacGia)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM KhoSach WHERE TacGia LIKE @tacGia"
            };
            cmd.Parameters.AddWithValue("@tacGia", $"%{tacGia}%");

            return SQLDataAccess.Instance.ExecuteQuery(cmd);
        }

        /// <summary>
        /// Find KhoSach by LoaiSach
        /// </summary>
        /// <returns>
        /// A DataTable contains KhoSach <br/>
        /// null if there was an error when querying
        /// </returns>
        public DataTable FindByLoaiSach(string loaiSach)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM KhoSach WHERE LoaiSach LIKE @loaiSach"
            };
            cmd.Parameters.AddWithValue("@loaiSach", $"%{loaiSach}%");

            return SQLDataAccess.Instance.ExecuteQuery(cmd);
        }

        /// <summary>
        /// Find KhoSach by LoaiSach
        /// </summary>
        /// <returns>
        /// A DataTable contains KhoSach <br/>
        /// null if there was an error when querying
        /// </returns>
        public DataTable Find(string loaiSach, string tacGia)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM KhoSach WHERE LoaiSach LIKE @loaiSach AND TacGia LIKE @tacGia"
            };
            cmd.Parameters.AddWithValue("@loaiSach", $"%{loaiSach}%");
            cmd.Parameters.AddWithValue("@tacGia", $"%{tacGia}%");

            return SQLDataAccess.Instance.ExecuteQuery(cmd);
        }

        /// <summary>
        /// Insert a SachDTO to database
        /// </summary>
        /// <param name="sach"></param>
        /// <returns>
        /// true if it was inserted successfully<br/>
        /// false if it wasn't inserted<br/>
        /// null if there was an error when executing
        /// </returns>
        public bool? Insert(SachDTO sach)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "INSERT INTO KhoSach " +
                "VALUES(@ls, @tenSach, @tacGia, @nxb, @soLuong, @giaTien)"
            };

            cmd.Parameters.AddWithValue("@ls", sach.LoaiSach);
            cmd.Parameters.AddWithValue("@tenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@tacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@nxb", sach.TacGia);
            cmd.Parameters.AddWithValue("@soLuong", sach.SoLuong);
            cmd.Parameters.AddWithValue("@giaTien", sach.GiaTien);

            return SQLDataAccess.Instance.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Delete a SachDTO from table KhoSach
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true if it was deleted successfully<br/>
        /// false if it wasn't deleted<br/>
        /// null if there was an error when executing
        /// </returns>
        public bool? Delete(int id)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "DELETE FROM KhoSach WHERE Id = @id"
            };

            cmd.Parameters.AddWithValue("@id", id);

            return SQLDataAccess.Instance.ExecuteNonQuery(cmd);
        }

        public bool? Update(SachDTO sach)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "UPDATE KhoSach SET LoaiSach = @LoaiSach, TenSach = @TenSach, TacGia = @TacGia, NhaXuatBan = @NXB, SoLuong = @SoLuong, GiaTien = @GiaTien WHERE Id = @id"
            };

            cmd.Parameters.AddWithValue("@LoaiSach", sach.LoaiSach);
            cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@NXB", sach.NhaXuatBan);
            cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(sach.SoLuong));
            cmd.Parameters.AddWithValue("@GiaTien", Convert.ToInt32(sach.GiaTien));
            cmd.Parameters.AddWithValue("@id", sach.Id);

            return SQLDataAccess.Instance.ExecuteNonQuery(cmd);
        }
    }
}
