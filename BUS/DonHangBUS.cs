using DAO;
using DTO;
using System.Data;

namespace BUS
{
    /// <summary>
    /// Tầng Business: Đơn hàng
    /// </summary>
    public class DonHangBUS
    {
        private static DonHangBUS instance;

        public SachDTO SelectedItem { get; set; }

        public static DonHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonHangBUS();
                return instance;
            }
        }

        public bool? Insert(DonHangDTO donHang)
        {
            if (donHang.IsNullOrEmpty())
                return false;
            
            if (SelectedItem.SoLuong >= donHang.SoLuong)
            {
                bool? kq = DonHangDAO.Instance.Insert(donHang);
                if (kq == true)
                {
                    SelectedItem.SoLuong -= donHang.SoLuong;
                    return SachDAO.Instance.Update(SelectedItem);
                }
            }
            return false;
        }

        public DataTable GetAll()
        {
            return DonHangDAO.Instance.GetAllAsDataTable();
        }
    }
}
