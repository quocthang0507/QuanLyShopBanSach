using System;
using System.Data;
using System.Windows.Forms;

namespace DTO
{
    /// <summary>
    /// Tầng Data Transfer Objects: Sách
    /// </summary>
    public class SachDTO
    {
        public int Id { get; }
        public string LoaiSach { get; }
        public string TenSach { get; }
        public string TacGia { get; }
        public string NhaXuatBan { get; }
        public int SoLuong { get; set; }
        public decimal GiaTien { get; }

        /// <summary>
        /// This constructor for DataGridView's column names
        /// </summary>
        /// <param name="row"></param>
        public SachDTO(DataGridViewRow row) : this(((DataRowView)row.DataBoundItem).Row)
        {
        }

        /// <summary>
        /// This constructor for SQL table's column names
        /// </summary>
        /// <param name="row"></param>
        public SachDTO(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"].ToString());
            LoaiSach = row["LoaiSach"].ToString();
            TenSach = row["TenSach"].ToString();
            TacGia = row["TacGia"].ToString();
            NhaXuatBan = row["NhaXuatBan"].ToString();
            SoLuong = Convert.ToInt32(row["SoLuong"].ToString());
            GiaTien = Convert.ToInt32(row["GiaTien"].ToString());
        }

        public SachDTO(int id, string loaiSach, string tenSach, string tacGia, string nhaXuatBan, int soLuong, int giaTien)
        {
            Id = id;
            LoaiSach = loaiSach;
            TenSach = tenSach;
            TacGia = tacGia;
            NhaXuatBan = nhaXuatBan;
            SoLuong = soLuong;
            GiaTien = giaTien;
        }

        public SachDTO(string loaiSach, string tenSach, string tacGia, string nhaXuatBan, int soLuong, int giaTien)
        {
            LoaiSach = loaiSach;
            TenSach = tenSach;
            TacGia = tacGia;
            NhaXuatBan = nhaXuatBan;
            SoLuong = soLuong;
            GiaTien = giaTien;
        }
    }
}
