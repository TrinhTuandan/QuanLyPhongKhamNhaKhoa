using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DataNguoiDung : Form
    {
        private readonly NguoiDungService NguoiDungService = new NguoiDungService();
        private readonly NhomNguoiDungService NhomNguoiDungService = new NhomNguoiDungService();
        private readonly object tenNhom;


        public DataNguoiDung()
        {
            InitializeComponent();
        }

        //=================================================================================
        // lấy dữ liệu mã nhân viên và tên nhân viên từ form Chọn Người Dùng
        public void SetNhanVien(string maNhanVien, string tenNhanVien)
        {
            txtNV.Text = maNhanVien;
            txtHoTen.Text = tenNhanVien;
        }
        //=================================================================================

        private void DataNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
            Clean();
        }



        private void LoadData()
        {
            List<NguoiDung> listNguoiDung = NguoiDungService.GetAllNguoiDung();
            BindGrid(listNguoiDung);

            List<NhomNguoiDung> listNhomNguoiDung = NhomNguoiDungService.GetAllNhomNguoiDung();
            BindNhomNguoiDungComboBox(listNhomNguoiDung);
        }

        private void BindNhomNguoiDungComboBox(List<NhomNguoiDung> listNhomNguoiDung)
        {
            cboTenNhom.DataSource = listNhomNguoiDung;
            cboTenNhom.DisplayMember = "TenNhom"; // Hiển thị tên nhóm người dùng trong ComboBox
            cboTenNhom.ValueMember = "MaNhom"; // Sử dụng MaNhom làm giá trị khi chọn một nhóm người dùng
        }

        //Phương thức BindGrid được sử dụng để hiển thị danh sách lên DataGridView 
        private void BindGrid(List<NguoiDung> listNguoiDung)
        {
            // Xóa dữ liệu cũ trên DataGridView
            dgvQuanLyNguoiDung.Rows.Clear();

            foreach (var item in listNguoiDung)
            {
                string tenNhom = "";
                var nguoiDungNhom = item.NguoiDungNhomNguoiDung.FirstOrDefault();
                if (nguoiDungNhom != null)
                {
                    tenNhom = nguoiDungNhom.NhomNguoiDung?.TenNhom ?? "";
                }

                int index = dgvQuanLyNguoiDung.Rows.Add();
                dgvQuanLyNguoiDung.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvQuanLyNguoiDung.Rows[index].Cells[1].Value = item.NhanVien?.HoTen ?? "";
                dgvQuanLyNguoiDung.Rows[index].Cells[2].Value = item.TenDangNhap;
                dgvQuanLyNguoiDung.Rows[index].Cells[3].Value = item.MatKhau;
                dgvQuanLyNguoiDung.Rows[index].Cells[4].Value = item.TrangThai;
                dgvQuanLyNguoiDung.Rows[index].Cells[5].Value = tenNhom;
            }
        }

        private void dgvQuanLyNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvQuanLyNguoiDung.Rows[e.RowIndex];
                txtNV.Text = selectedRow.Cells[0].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value?.ToString();
                txtTenDangNhap.Text = selectedRow.Cells[2].Value?.ToString();
                txtPass.Text = selectedRow.Cells[3].Value?.ToString();
                cboTrangThai.Text = selectedRow.Cells[4].Value?.ToString();
                cboTenNhom.Text = selectedRow.Cells[5].Value?.ToString();

            }
        }


        //======================================================================================================================================================
        // nút button btnPhanNhomNguoiDung để mở form DataQuanLyNguoiDung
        private void Clean()
        {
            txtNV.Text = "";
            txtHoTen.Text = "";
            txtTenDangNhap.Text = "";
            txtPass.Text = "";
            cboTenNhom.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }

        private bool KiemTraTenDVTonTai(string tenDichVu)
        {
            foreach (DataGridViewRow row in dgvQuanLyNguoiDung.Rows)
            {
                string tenDaTonTai = row.Cells[0].Value?.ToString();
                if (tenDaTonTai == tenDichVu)
                {
                    return true;
                }
            }
            return false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và ComboBox
            string maNhanVien = txtNV.Text;
            string TenNhanVien = txtHoTen.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtPass.Text;
            string trangThai = cboTrangThai.SelectedItem.ToString();

            // Kiểm tra xem cboTenNhom đã được chọn
            if (cboTenNhom.SelectedItem != null)
            {
                string maNhom = cboTenNhom.SelectedValue.ToString();
                string hoTen = txtHoTen.Text;

                // Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrWhiteSpace(maNhanVien) || string.IsNullOrWhiteSpace(TenNhanVien) || string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin Người Dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra nếu Người Dùng đã tồn tại
                if (NguoiDungService.GetNguoiDungByMaNhanVien(maNhanVien) != null)
                {
                    MessageBox.Show("Người Dùng đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một đối tượng NguoiDung mới
                NguoiDung nguoiDungMoi = new NguoiDung
                {
                    MaNhanVien = maNhanVien,
                    TenDangNhap = tenDangNhap,
                    MatKhau = matKhau,
                    TrangThai = trangThai,
                };

                // Thêm người dùng vào nhóm người dùng
                nguoiDungMoi.NguoiDungNhomNguoiDung.Add(new NguoiDungNhomNguoiDung { MaNhom = maNhom });

                // Lưu người dùng mới vào cơ sở dữ liệu
                NguoiDungService.AddNguoiDung(nguoiDungMoi);

                // Thêm tên người dùng vào DataGridView
                int index = dgvQuanLyNguoiDung.Rows.Add();
                dgvQuanLyNguoiDung.Rows[index].Cells[0].Value = maNhanVien;
                dgvQuanLyNguoiDung.Rows[index].Cells[1].Value = hoTen; // Cập nhật tên nhân viên vào cột 1
                dgvQuanLyNguoiDung.Rows[index].Cells[2].Value = tenDangNhap;
                dgvQuanLyNguoiDung.Rows[index].Cells[3].Value = matKhau;
                dgvQuanLyNguoiDung.Rows[index].Cells[4].Value = trangThai;
                dgvQuanLyNguoiDung.Rows[index].Cells[5].Value = cboTenNhom.Text; // Hiển thị tên nhóm thay vì maNhom

                // Cập nhật lại danh sách và làm sạch các trường nhập liệu
                LoadData();
                Clean();

                MessageBox.Show("Người Dùng đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhóm trước khi thêm Người Dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //====================================================================================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtNV.Text; // Lấy mã người dùng từ trường nhập liệu
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Người Dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                NguoiDungService.DeleteNguoiDung(maNhanVien); // Gọi phương thức DeleteNguoiDung
                LoadData();
                Clean();
                MessageBox.Show("Người Dùng đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        //==================================================================================================================================================

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtNV.Text;
            string tenNhanVien = txtHoTen.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtPass.Text;
            string trangThai = cboTrangThai.SelectedItem.ToString();         

            if (string.IsNullOrWhiteSpace(maNhanVien) || string.IsNullOrWhiteSpace(tenNhanVien) || string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Người Dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the user with the specified maNhanVien exists
            NguoiDung existingUser = NguoiDungService.GetNguoiDungByMaNhanVien(maNhanVien);

            if (existingUser != null)
            {
                // Update user information
                existingUser.NhanVien.HoTen = tenNhanVien;
                existingUser.TenDangNhap = tenDangNhap;
                existingUser.MatKhau = matKhau;
                existingUser.TrangThai = trangThai;
          

                // Save the changes to the database
                NguoiDungService.UpdateNguoiDung(existingUser);

                // Update the DataGridView to reflect the changes
                LoadData();

                MessageBox.Show("Thông tin Người Dùng đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Người Dùng không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
//========================================================================================================
        private void btnReload_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        //======================================================================================================
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            ChonNhanVien f = new ChonNhanVien();
            f.ShowDialog();
        }

        private void btnPhanNhomNguoiDung_Click(object sender, EventArgs e)
        {
            DataNhomNguoiDung f = new DataNhomNguoiDung();
            f.ShowDialog();
        }

    }
}
