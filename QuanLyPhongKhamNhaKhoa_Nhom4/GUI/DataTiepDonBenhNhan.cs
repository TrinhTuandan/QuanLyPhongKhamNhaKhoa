using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DataTiepDonBenhNhan : Form
    {
        private readonly TiepDonBenhNhanService TiepDonBenhNhanService = new TiepDonBenhNhanService();
        public DataTiepDonBenhNhan()
        {
            InitializeComponent();
        }
        private void DataTiepDonBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            // Triển khai mã để tải dữ liệu và gọi phương thức BindGrid để hiển thị lên DataGridView
            // List<TiepDonBenhNhan> listBenhNhan = TiepDonBenhNhanService.GetDanhSachTiepDon();
            var listTiepDonBenhNhan = TiepDonBenhNhanService.GetAllTiepDonBenhNhan();
            BindGrid(listTiepDonBenhNhan);

            // FillComboPhong(listTiepDonBenhNhan);
            using (var context = new Model1()) // Tạo một đối tượng DbContext
            {
                var phongKhamList = context.PhongKham.ToList(); // Truy vấn danh sách phòng khám

                // Đặt danh sách phòng khám làm nguồn dữ liệu cho ComboBox
                cboPhong.DataSource = phongKhamList;
                cboPhong.DisplayMember = "TenPhong"; // Hiển thị tên phòng khám trong ComboBox
                cboPhong.ValueMember = "MaPhong"; // Sử dụng MaPhong làm giá trị khi chọn một phòng

                var NhanvienList = context.NhanVien.ToList();
                cboTiepDon.DataSource = NhanvienList;
                cboTiepDon.DisplayMember = "Hoten";
                cboTiepDon.ValueMember = "MaNhanVien";
            }
        }



        //Phương thức BindGrid được sử dụng để hiển thị danh sách sinh viên lên DataGridView 
        private void BindGrid(List<TiepDonBenhNhan> listBenhNhan)
        {
            // Xóa dữ liệu cũ trên DataGridView
            dgvDanhSachTiepDon.Rows.Clear();
            // Duyệt qua danh sách bệnh nhân và hiển thị thông tin lên DataGridView
            foreach (var item in listBenhNhan)
            {
                int index = dgvDanhSachTiepDon.Rows.Add();
                dgvDanhSachTiepDon.Rows[index].Cells[0].Value = item.SoPhieu;
                dgvDanhSachTiepDon.Rows[index].Cells[1].Value = item.NgayKham;
                dgvDanhSachTiepDon.Rows[index].Cells[2].Value = item.LoaiKham;
                dgvDanhSachTiepDon.Rows[index].Cells[3].Value = item.LyDoKham;
                dgvDanhSachTiepDon.Rows[index].Cells[4].Value = item.TieuDuong;
                dgvDanhSachTiepDon.Rows[index].Cells[5].Value = item.BenhTimMach;
                dgvDanhSachTiepDon.Rows[index].Cells[6].Value = item.HuyetAp;
                dgvDanhSachTiepDon.Rows[index].Cells[7].Value = item.TinhTrang;
                dgvDanhSachTiepDon.Rows[index].Cells[8].Value = item.MaBenhNhan;
                dgvDanhSachTiepDon.Rows[index].Cells[9].Value = item.BenhNhan.HoTen;
                dgvDanhSachTiepDon.Rows[index].Cells[10].Value = item.PhongKham.TenPhong;
                dgvDanhSachTiepDon.Rows[index].Cells[11].Value = item.MaPhong;
                var nhanVien = TiepDonBenhNhanService.GetNhanVienById(item.NhanVienTiepDon);
                dgvDanhSachTiepDon.Rows[index].Cells[12].Value = nhanVien != null ? nhanVien.HoTen : string.Empty;
                var bacSi = TiepDonBenhNhanService.GetBacSiById(item.BacSi);
                dgvDanhSachTiepDon.Rows[index].Cells[13].Value = bacSi != null ? bacSi.HoTen : string.Empty;
            }
        }
        
        private void dgvDanhSachTiepDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachTiepDon.Rows[e.RowIndex];
                txtSoPhieu.Text = selectedRow.Cells[0].Value?.ToString();
                dtpNgayKham.Text = selectedRow.Cells[1].Value?.ToString();
                cboLoaiKham.Text = selectedRow.Cells[2].Value?.ToString();
                txtLyDo.Text = selectedRow.Cells[3].Value?.ToString();
                cboTieuDuong.Text = selectedRow.Cells[4].Value?.ToString();
                cboTimMach.Text = selectedRow.Cells[5].Value?.ToString();
                cbbHuyetAp.Text = selectedRow.Cells[6].Value?.ToString();
                cboTinhTrangKham.Text = selectedRow.Cells[7].Value?.ToString();
                cboMaBN.Text = selectedRow.Cells[8].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells[9].Value?.ToString();
                cboPhong.Text = selectedRow.Cells[10].Value?.ToString();
                cboTiepDon.Text = selectedRow.Cells[12].Value?.ToString();
                cboBacSi.Text = selectedRow.Cells[13].Value?.ToString();
            }
        }


        //=================================================================================
        // lấy dữ liệu mã nhân viên và tên nhân viên từ form Chọn Bệnh Nhân
        public void SetBenhNhan(string maBenhNhan, string hotenBenhNhan, string matheBenhNhan,
                            string ngaysinhBenhNhan, string gioitinhBenhNhan,
                            string sdtBenhNhan, string diachiBenhNhan)
        {
            cboMaBN.Text = maBenhNhan;
            txtHoTen.Text = hotenBenhNhan;
            txtMaThe.Text = matheBenhNhan;
            txtNgaySinh.Text = ngaysinhBenhNhan;
            cbbGioiTinh.Text = gioitinhBenhNhan;
            txtSDT.Text = sdtBenhNhan;
            txtDiaChi.Text = diachiBenhNhan;
        }
        //=================================================================================
        //===========================================================================================

        private void clean()
        {
            txtSoPhieu.Text = "";
            dtpNgayKham.Value = DateTime.Now;
            cboLoaiKham.SelectedIndex = -1;
            txtLyDo.Text = "";
            cboTieuDuong.SelectedIndex = -1;
            cboTimMach.SelectedIndex = -1;
            cbbHuyetAp.SelectedIndex = -1;
            cboTinhTrangKham.SelectedIndex = -1;
            cboMaBN.SelectedIndex = -1;
            txtHoTen.Text = "";
            txtMaThe.Text = "";
            txtNgaySinh.Text = "";
            cbbGioiTinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cboPhong.SelectedIndex = -1;
            cboTiepDon.SelectedIndex = -1;
            cboBacSi.SelectedIndex = -1;
        }


       private string LaySoPhieuTuDong(string pPhong)
        {
            var phieuKhamList = TiepDonBenhNhanService.LayDSTiepDonTheoPhong(pPhong);
            int count = phieuKhamList.Count;
            string phieu = "";
            string soPhieuMoi = "";
            int soPhieu = 0;
            if (count == 0)
            {
                return $"{pPhong}-001";
            }
            else
            {
                phieu = phieuKhamList[count - 1].SoPhieu;
                soPhieu = Convert.ToInt32(phieu.Split('-')[1]);

                if (soPhieu + 1 < 10)
                {
                    soPhieuMoi = $"{pPhong}-00{soPhieu + 1}";
                }
                else if (soPhieu + 1 < 100)
                {
                    soPhieuMoi = $"{pPhong}-0{soPhieu + 1}";
                }
                else if (soPhieu + 1 < 1000)
                {
                    soPhieuMoi = $"{pPhong}-{soPhieu + 1}";
                }

                return soPhieuMoi;
            }
        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập đủ thông tin cần thiết
            if (string.IsNullOrWhiteSpace(txtSoPhieu.Text) || cboLoaiKham.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtLyDo.Text) ||
                cboTieuDuong.SelectedIndex == -1 || cboTimMach.SelectedIndex == -1 || cbbHuyetAp.SelectedIndex == -1 ||
                cboTinhTrangKham.SelectedIndex == -1 || cboMaBN.SelectedIndex == -1 || cboPhong.SelectedIndex == -1 || cboTiepDon.SelectedIndex == -1 || cboBacSi.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy phòng khám được chọn
            string selectedPhong = cboPhong.SelectedValue.ToString();

            // Lấy số phiếu tự động
            string soPhieu = LaySoPhieuTuDong(selectedPhong);

            if (string.IsNullOrEmpty(soPhieu))
            {
                MessageBox.Show("Không thể tạo số phiếu tự động.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo một đối tượng TiepDonBenhNhan mới và điền thông tin cho nó
            TiepDonBenhNhan newRecord = new TiepDonBenhNhan
            {
                SoPhieu = soPhieu,
                NgayKham = dtpNgayKham.Value,
                LoaiKham = cboLoaiKham.Text,
                LyDoKham = txtLyDo.Text,
                TieuDuong = cboTieuDuong.Text,
                BenhTimMach = cboTimMach.Text,
                HuyetAp = cbbHuyetAp.Text,
                TinhTrang = cboTinhTrangKham.Text,
                MaBenhNhan = cboMaBN.SelectedValue.ToString(),
                MaPhong = selectedPhong,
                NhanVienTiepDon = cboTiepDon.SelectedValue.ToString(),
                BacSi = cboBacSi.SelectedValue.ToString()
            };

            // Gọi phương thức trong TiepDonBenhNhanService để thêm bản ghi vào cơ sở dữ liệu
            TiepDonBenhNhanService.AddTiepDonBenhNhan(newRecord);

            // Làm mới DataGridView và các trường nhập liệu
            LoadData();
            clean();
            MessageBox.Show("Bản ghi đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Triển khai mã để xóa bản ghi hồ sơ nhập viện đã chọn
            if (!string.IsNullOrEmpty(txtSoPhieu.Text))
            {
                string soPhieu = txtSoPhieu.Text;

                // Gọi phương thức trong TiepDonBenhNhanService để xóa bản ghi khỏi cơ sở dữ liệu
                TiepDonBenhNhanService.DeleteTiepDonBenhNhan(soPhieu);

                // Làm mới DataGridView
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoPhieu.Text))
            {
                string soPhieu = txtSoPhieu.Text;

                // Kiểm tra xem bản ghi tồn tại
                TiepDonBenhNhan existingRecord = TiepDonBenhNhanService.GetTiepDonBenhNhanById(soPhieu);

                if (existingRecord != null)
                {
                    // Cập nhật thông tin bản ghi
                    existingRecord.NgayKham = dtpNgayKham.Value;
                    existingRecord.LoaiKham = cboLoaiKham.Text;
                    existingRecord.LyDoKham = txtLyDo.Text;
                    existingRecord.TieuDuong = cboTieuDuong.Text;
                    existingRecord.BenhTimMach = cboTimMach.Text;
                    existingRecord.HuyetAp = cbbHuyetAp.Text;
                    existingRecord.TinhTrang = cboTinhTrangKham.Text;
                    existingRecord.MaBenhNhan = cboMaBN.SelectedValue.ToString();
                    existingRecord.MaPhong = cboPhong.SelectedValue.ToString();
                    existingRecord.NhanVienTiepDon = cboTiepDon.SelectedValue.ToString();
                    existingRecord.BacSi = cboBacSi.SelectedValue.ToString();

                    // Gọi phương thức trong TiepDonBenhNhanService để cập nhật bản ghi trong cơ sở dữ liệu
                    TiepDonBenhNhanService.UpdateTiepDonBenhNhan(existingRecord);

                    // Làm mới DataGridView và trường nhập liệu
                    LoadData();
                    clean();
                    MessageBox.Show("Bản ghi đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bản ghi không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clean();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //===========================================================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvDanhSachTiepDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemBN_Click(object sender, EventArgs e)
        {
            DataBenhNhan f = new DataBenhNhan();
            f.ShowDialog();
        }

        private void btnMoDanhSanhBN_Click(object sender, EventArgs e)
        {
            ChonBenhNhan f = new ChonBenhNhan();
            f.ShowDialog();
        }
    }
}
