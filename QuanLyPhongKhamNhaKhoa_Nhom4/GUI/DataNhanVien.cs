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
    public partial class DataNhanVien : Form
    {
        private readonly NhanVienService NhanVienService = new NhanVienService();
        public DataNhanVien()
        {
            InitializeComponent();
            LoadData();
            clean();
        }

        //chọn mặc định cho form ban đầu
        private void DataNhanVien_Load(object sender, EventArgs e)
        {
            cboLocGioiTinh.SelectedIndex = 0;

            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgaylam.Value = DateTime.Now;

            txtSumNam.Text = "0"; // Đặt giá trị mặc định
            txtSumNu.Text = "0";
            UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ

        }

        //Load lại thông tin trên dataGridview
        private void LoadData()
        {
            var danhSachNhanVien = NhanVienService.GetAllNhanVien();
            BenhNhanCombobox(danhSachNhanVien);
        }



        private void BenhNhanCombobox(List<NhanVien> danhSachNhanVien)
        {
            BindGrid(danhSachNhanVien);
            FillComboBoxes(danhSachNhanVien);
        }



        //Phương thức BindGrid được sử dụng để hiển thị danh sách sinh viên lên DataGridView 
        private void BindGrid(List<NhanVien> listNhanVien)
        {
            // Xóa dữ liệu cũ trên DataGridView
            dgvNhanVien.Rows.Clear();
            // Duyệt qua danh sách bệnh nhân và hiển thị thông tin lên DataGridView
            foreach (var item in listNhanVien)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvNhanVien.Rows[index].Cells[1].Value = item.HoTen;
                dgvNhanVien.Rows[index].Cells[2].Value = item.Phai;
                dgvNhanVien.Rows[index].Cells[3].Value = item.NgaySinh;
                dgvNhanVien.Rows[index].Cells[4].Value = item.DiaChi;
                dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                dgvNhanVien.Rows[index].Cells[6].Value = item.NgayVaoLam;
                dgvNhanVien.Rows[index].Cells[7].Value = item.LuongCoBan;
            }
        }



        private void FillComboBoxes(List<NhanVien> listNhanVien)
        {
            // Tạo một danh sách các giới tính cố định
            // Đặt danh sách giới tính cố định làm nguồn dữ liệu cho ComboBox cboGioiTinh
            List<string> gioiTinhList = new List<string> { "Nam", "Nữ" };
            cboGioiTinh.DataSource = gioiTinhList;
        } 
        


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được chọn trong DataGridView và hiển thị lên các TextBox và ComboBox
                DataGridViewRow     selectedRow = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text =      selectedRow.Cells[0].Value?.ToString();
                txtHoTen.Text =     selectedRow.Cells[1].Value?.ToString();
                cboGioiTinh.Text =  selectedRow.Cells[2].Value?.ToString();
                dtpNgaySinh.Text =  selectedRow.Cells[3].Value?.ToString();
                txtDiaChi.Text =    selectedRow.Cells[4].Value?.ToString();
                txtSDT.Text =       selectedRow.Cells[5].Value?.ToString();
                dtpNgaylam.Text =   selectedRow.Cells[6].Value?.ToString();
                txtLuong.Text =     selectedRow.Cells[7].Value?.ToString();
            }
        }



//================================================================================================
        private void clean()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dtpNgaylam.Value = DateTime.Now;
            txtLuong.Text = "";
        }
        // Tự Động Tạo Mã mới cho nhân viên
        public string LayMaNVTuTang()
        {
            int count = dgvNhanVien.Rows.Count;
            string ma = "";
            string mamoi = "";
            int manv = 0;
            ma = Convert.ToString(dgvNhanVien.Rows[count - 1].Cells[0].Value);
            manv = Convert.ToInt32((ma.Remove(0, 2)));
            if (manv + 1 < 10)
            {
                mamoi = "NV00" + (manv + 1).ToString();
            }
            else if (manv + 1 < 100)
            {
                mamoi = "NV0" + (manv + 1).ToString();
            }
            else if (manv + 1 < 1000)
            {
                mamoi = "NV" + (manv + 1).ToString();
            }
            return mamoi;
        }


        private bool KiemTraTenNVTonTai(string tenNhanVien)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                string tenDaTonTai = row.Cells[1].Value?.ToString();
                if (tenDaTonTai == tenNhanVien)
                {
                    return true;
                }
            }
            return false;
        }
        // button chức năng  Thêm 
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenNhanVienMoi = txtHoTen.Text;

            // Kiểm tra xem tên nhân viên đã tồn tại trong DataGridView hay chưa
            if (KiemTraTenNVTonTai(tenNhanVienMoi))
            {
                MessageBox.Show("Tên nhân viên đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không thêm nữa nếu tên nhân viên đã tồn tại
            }

            NhanVien newNhanVien = new NhanVien
            {
                MaNhanVien = LayMaNVTuTang(),
                HoTen = tenNhanVienMoi,
                Phai = cboGioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                NgayVaoLam = dtpNgaylam.Value,
                LuongCoBan = int.Parse(txtLuong.Text)
            };

            NhanVienService.AddNhanVien(newNhanVien);
            LoadData();
            clean();
            UpdateGenderCounts();

            MessageBox.Show("Nhân viên đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // button chức năng  Xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maBenhNhan = txtMaNV.Text;

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                NhanVienService.DeleteNhanVien(maBenhNhan);
                LoadData();
                clean();
                UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ

                // Hiển thị thông báo xóa thành công
                MessageBox.Show("Nhân Viên đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // button chức năng Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNV.Text;
            NhanVien existingNhanVien = NhanVienService.GetNhanVienByMaNhanVien(maNhanVien);

            if (existingNhanVien != null)
            {
                existingNhanVien.HoTen = txtHoTen.Text;
                existingNhanVien.Phai = cboGioiTinh.SelectedItem.ToString();
                existingNhanVien.NgaySinh = dtpNgaySinh.Value;
                existingNhanVien.DiaChi = txtDiaChi.Text;
                existingNhanVien.SDT = txtSDT.Text;
                existingNhanVien.NgayVaoLam = dtpNgaylam.Value;
                existingNhanVien.LuongCoBan = int.Parse(txtLuong.Text);

                NhanVienService.UpdateNhanVien(existingNhanVien);
                LoadData();
                clean();
                UpdateGenderCounts();

                MessageBox.Show("Nhân viên đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // button chức năng Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // button chức năng Reload 
        private void btnReload_Click(object sender, EventArgs e)
        {
            clean();
        }



//================================================================================================
        // chức năng Tìm kiếm
        private void ThucHienTimKiem()
        {
            string keyword = txtTimKiem.Text;
            List<NhanVien> filteredList = NhanVienService.GetAllNhanVien()
                .Where(NhanVien => NhanVien.HoTen.Contains(keyword))
                .ToList();

            BindGrid(filteredList);

            // Kiểm tra nếu ô tìm kiếm trống rỗng, thì load lại toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
            }
        }
        // Tải lại toàn bộ danh sách bệnh nhân.
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }
        // tìm kiếm danh sách bệnh nhân dựa trên từ khóa này và cập nhật DataGridView
        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự Enter xuất hiện trong ô tìm kiếm
                ThucHienTimKiem();
            }
        }

//================================================================================================



        //chức năng Lọc Giới Tính     
        private void cboLocGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Thực hiện lọc dựa trên lựa chọn từ ComboBox
            string gioiTinhFilter = cboLocGioiTinh.SelectedItem.ToString();
            List<NhanVien> danhSachLoc;

            if (gioiTinhFilter == "Tất cả")
            {
                danhSachLoc = NhanVienService.GetAllNhanVien();
            }
            else
            {
                danhSachLoc = NhanVienService.GetAllNhanVien()
                    .Where(NhanVien => NhanVien.Phai == gioiTinhFilter)
                    .ToList();
            }
            BenhNhanCombobox(danhSachLoc);
        }


        //Tạo Classs đê đếm số Nam và Nữ
        private void UpdateGenderCounts()
        {
            int countNam = 0;
            int countNu = 0;

            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                string gioiTinh = row.Cells[2].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    countNam++;
                }
                else if (gioiTinh == "Nữ")
                {
                    countNu++;
                }
            }
            txtSumNam.Text = countNam.ToString();
            txtSumNu.Text = countNu.ToString();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
