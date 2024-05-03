using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace QuanLyShopBanSach
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Load_Tab1()
        {
            dgvKho.DataSource = SachBUS.Instance.GetAll();
        }

        private void Load_Tab2()
        {
            dgvTimKiem.DataSource = SachBUS.Instance.GetAll();
            dgvMua.DataSource = DonHangBUS.Instance.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Tab1();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                Load_Tab2();
            else Load_Tab1();
        }

        #region Events_Tab1

        private void btnThem_Click(object sender, EventArgs e)
        {
            var ls = txtLoaiSach.Text;
            var tenSach = txtTenSach.Text;
            var tacGia = txtTacGia.Text;
            var nxb = txtNXB.Text;
            var soLuong = Convert.ToInt32(numSoLuong.Value);
            var giaTien = Convert.ToInt32(txtGiaTien.Text);

            var sach = new SachDTO(ls, tenSach, tacGia, nxb, soLuong, giaTien);
            var kq = SachBUS.Instance.Insert(sach);

            if (kq == null)
                MessageBox.Show("Có lỗi khi thêm sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (kq == true)
            {
                MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Tab1();
            }
            else MessageBox.Show("Thêm sách không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKho.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKho.SelectedRows[0].Cells[0].Value);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                             "Xác nhận xóa!",
                                             MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var kq = SachBUS.Instance.Delete(id);

                    if (kq == null)
                        MessageBox.Show("Có lỗi khi xoá sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (kq == true)
                    {
                        MessageBox.Show("Xóa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_Tab1();
                    }
                    else MessageBox.Show("Xóa sách không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (dgvKho.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKho.SelectedRows[0].Cells[0].Value);
                var ls = txtLoaiSach.Text;
                var tenSach = txtTenSach.Text;
                var tacGia = txtTacGia.Text;
                var nxb = txtNXB.Text;
                var soLuong = Convert.ToInt32(numSoLuong.Value);
                var giaTien = Convert.ToInt32(txtGiaTien.Text);

                var sach = new SachDTO(id, ls, tenSach, tacGia, nxb, soLuong, giaTien);
                var kq = SachBUS.Instance.Update(sach);

                if (kq == null)
                    MessageBox.Show("Có lỗi khi cập nhật sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (kq == true)
                {
                    MessageBox.Show("Cập nhật sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Tab1();
                }
                else MessageBox.Show("Cập nhật sách không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKho.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKho.SelectedRows[0];
                SachDTO sach = new SachDTO(row);
                txtLoaiSach.Text = sach.LoaiSach;
                txtTenSach.Text = sach.TenSach;
                txtTacGia.Text = sach.TacGia;
                txtNXB.Text = sach.NhaXuatBan;
                numSoLuong.Text = sach.SoLuong.ToString();
                txtGiaTien.Text = sach.GiaTien.ToString();
            }
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventsBUS.DigitTextBox_KeyPress(sender, e);
        }

        #endregion

        #region Events_Tab2

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (chkLoaiSach.Checked && chkTacGia.Checked)
            {
                dgvTimKiem.DataSource = SachBUS.Instance.FindSach(txtTimLoaiSach.Text, txtTimTacGia.Text);
            }
            else if (chkLoaiSach.Checked)
            {
                dgvTimKiem.DataSource = SachBUS.Instance.FindSach(txtTimLoaiSach.Text, null);
            }
            else if (chkTacGia.Checked)
            {
                dgvTimKiem.DataSource = SachBUS.Instance.FindSach(null, txtTimTacGia.Text);
            }
            else
                dgvTimKiem.DataSource = SachBUS.Instance.GetAll();
        }

        private void chkLoaiSach_CheckedChanged(object sender, EventArgs e)
        {
            txtTimLoaiSach.Enabled = chkLoaiSach.Checked;
        }

        private void chkTacGia_CheckedChanged(object sender, EventArgs e)
        {
            txtTimTacGia.Enabled = chkTacGia.Checked;
        }

        private void dgvTimKiem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTimKiem.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTimKiem.SelectedRows[0];
                SachDTO sach = new SachDTO(row);

                DonHangBUS.Instance.SelectedItem = sach;

                txtMuaTenSach.Text = sach.TenSach;
                txtMuaGiaTien.Text = sach.GiaTien.ToString();
                txtGiaBan.Text = sach.GiaTien.ToString();
                numSoLuongMua.Maximum = sach.SoLuong;
                numSoLuongMua.Value = 1;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventsBUS.DigitTextBox_KeyPress(sender, e);
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            var tenSach = txtMuaTenSach.Text;
            var idSach = DonHangBUS.Instance.SelectedItem.Id;
            var soLuong = Convert.ToInt32(numSoLuongMua.Value);
            var giaTien = Convert.ToInt32(txtGiaBan.Text);
            var ngayMua = dateNgayMua.Value;

            var donHang = new DonHangDTO(idSach, tenSach, soLuong, giaTien, ngayMua);
            var kq = DonHangBUS.Instance.Insert(donHang);

            if (kq == null)
                MessageBox.Show("Có lỗi khi thêm đơn hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (kq == true)
            {
                MessageBox.Show("Thêm đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Tab2();
            }
            else MessageBox.Show("Thêm đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        #endregion

    }
}