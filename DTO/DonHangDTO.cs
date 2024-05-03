using System;

namespace DTO
{
    public class DonHangDTO
    {
        public int Id { get; }
        public int IdSach { get; }
        public string TenSach { get; }
        public int SoLuong { get; }
        public decimal GiaTien { get; }
        public DateTime NgayMua { get; }

        public DonHangDTO(int idSach, string tenSach, int soLuong, decimal giaTien, DateTime ngayMua)
        {
            IdSach = idSach;
            TenSach = tenSach;
            SoLuong = soLuong;
            GiaTien = giaTien;
            NgayMua = ngayMua;
        }

    }
}
