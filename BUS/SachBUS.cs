using DAO;
using DTO;
using System.Data;

namespace BUS
{
    /// <summary>
    /// Tầng Business: Sách
    /// </summary>
    public class SachBUS
    {
        private static SachBUS instance;

        public static SachBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SachBUS();
                return instance;
            }
        }

        public bool? Insert(SachDTO sach)
        {
            if (sach.IsNullOrEmpty())
                return false;
            return SachDAO.Instance.Insert(sach);
        }

        public bool? Delete(int id)
        {
            return SachDAO.Instance.Delete(id);
        }

        public bool? Update(SachDTO sach)
        {
            if (sach.IsNullOrEmpty())
                return false;
            return SachDAO.Instance.Update(sach);
        }

        public DataTable GetAll()
        {
            return SachDAO.Instance.GetAllAsDataTable();
        }

        public DataTable FindSach(string loaiSach = null, string tacGia = null)
        {
            if (!string.IsNullOrEmpty(loaiSach) && !string.IsNullOrEmpty(tacGia))
            {
                return SachDAO.Instance.Find(loaiSach.Trim(), tacGia.Trim());
            }
            else if (!string.IsNullOrEmpty(loaiSach))
            {
                return SachDAO.Instance.FindByLoaiSach(loaiSach.Trim());
            }
            else if (!string.IsNullOrEmpty(tacGia))
            {
                return SachDAO.Instance.FindByTacGia(tacGia.Trim());
            }
            else
                return GetAll();
        }
    }
}
