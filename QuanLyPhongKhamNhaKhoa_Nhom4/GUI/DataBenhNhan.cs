using BUS; // Thay 'BUS' 
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
    public partial class DataBenhNhan : Form
    {   
        private readonly BenhNhanService BenhNhanService = new BenhNhanService();
        public DataBenhNhan()
        {
    
            InitializeComponent();
            LoadData();
            clean();
        }


        //chọn mặc định cho form ban đầu
        private void DataBenhNhan_Load(object sender, EventArgs e)
        {
            cboLocGioiTinh.SelectedIndex = 0;

            cboGioiTinh.SelectedIndex = 0;
            cboNgaySinh.Value = DateTime.Now;
            
            txtSumNam.Text = "0"; // Đặt giá trị mặc định
            txtSumNu.Text = "0";
            UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ
        }



        //Load lại thông tin trên dataGridview
        private void LoadData()
        {
            var listBenhNhan = BenhNhanService.GetAllBenhNhan();
            BindGrid(listBenhNhan);
            FillComboBoxes(listBenhNhan);
        }



        // BenhNhanCombobox được sử dụng để đổ danh sách Bênh Nhân vào combobox cboLocGioiTinh.
        private void BenhNhanCombobox(List<BenhNhan> danhSachBenhNhan)
        {
            BindGrid(danhSachBenhNhan);
            FillComboBoxes(danhSachBenhNhan);
        }



        //Phương thức BindGrid được sử dụng để hiển thị danh sách sinh viên lên DataGridView 
        private void BindGrid(List<BenhNhan> listBenhNhan)
        {
            // Xóa dữ liệu cũ trên DataGridView
            dgvBenhNhan.Rows.Clear();
            // Duyệt qua danh sách bệnh nhân và hiển thị thông tin lên DataGridView
            foreach (var item in listBenhNhan)
            {
                int index = dgvBenhNhan.Rows.Add();
                dgvBenhNhan.Rows[index].Cells[0].Value = item.MaBenhNhan;
                dgvBenhNhan.Rows[index].Cells[1].Value = item.MaThe;
                dgvBenhNhan.Rows[index].Cells[2].Value = item.HoTen;
                dgvBenhNhan.Rows[index].Cells[3].Value = item.GioiTinh;
                dgvBenhNhan.Rows[index].Cells[4].Value = item.NgaySinh;
                dgvBenhNhan.Rows[index].Cells[5].Value = item.SDT;
                dgvBenhNhan.Rows[index].Cells[6].Value = item.Email;
                dgvBenhNhan.Rows[index].Cells[7].Value = item.DiaChi;
            }
        }



        private void FillComboBoxes(List<BenhNhan> listBenhNhan)
        {
            // Tạo một danh sách các giới tính cố định
            // Đặt danh sách giới tính cố định làm nguồn dữ liệu cho ComboBox cboGioiTinh
            List<string> gioiTinhList = new List<string> { "Nam", "Nữ" };         
            cboGioiTinh.DataSource = gioiTinhList;
        }



        //click DataGridView
        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được chọn trong DataGridView và hiển thị lên các TextBox và ComboBox
                DataGridViewRow selectedRow = dgvBenhNhan.Rows[e.RowIndex];
                txtMaBN.Text = selectedRow.Cells[0].Value?.ToString();
                txtMaThe.Text = selectedRow.Cells[1].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells[2].Value?.ToString();
                cboGioiTinh.Text = selectedRow.Cells[3].Value?.ToString();
                cboNgaySinh.Text = selectedRow.Cells[4].Value?.ToString();
                TxtSDT.Text = selectedRow.Cells[5].Value?.ToString();
                txtMail.Text = selectedRow.Cells[6].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells[7].Value?.ToString();
            }
        }



//==========================================================================================================================
         private void clean()
         {
            txtMaBN.Text = "";
            txtMaThe.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            cboNgaySinh.Value = DateTime.Now;
            TxtSDT.Text = "";
            txtMail.Text = "";
            txtDiaChi.Text = "";
         }


        
        // Tự Động Tạo Mã mới 
        public string LayMaBNTuTang()
        {
            int count = dgvBenhNhan.Rows.Count;
            string ma = "";
            string mamoi = "";
            int manv = 0;
            ma = Convert.ToString(dgvBenhNhan.Rows[count - 1].Cells[0].Value);
            manv = Convert.ToInt32((ma.Remove(0, 2)));
            if (manv + 1 < 10)
            {
                mamoi = "BN00" + (manv + 1).ToString();
            }
            else if (manv + 1 < 100)
            {
                mamoi = "BN0" + (manv + 1).ToString();
            }
            else if (manv + 1 < 1000)
            {
                mamoi = "BN" + (manv + 1).ToString();
            }
            return mamoi;
        }



        private bool KiemTraTenBNTonTai(string tenBenhNhan)
        {
            foreach (DataGridViewRow row in dgvBenhNhan.Rows)
            {
                string tenDaTonTai = row.Cells[1].Value?.ToString();
                if (tenDaTonTai == tenBenhNhan)
                {
                    return true;
                }
            }
            return false;
        }
        // button chức năng  Thêm 
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenBenhNhanMoi = txtHoTen.Text;

            // Kiểm tra xem tên bệnh nhân đã tồn tại trong DataGridView hay chưa
            if (KiemTraTenBNTonTai(tenBenhNhanMoi))
            {
                MessageBox.Show("Tên bệnh nhân đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không thêm nữa nếu tên bệnh nhân đã tồn tại
            }

            BenhNhan newBenhNhan = new BenhNhan
            {
                MaBenhNhan = LayMaBNTuTang(),
                MaThe = txtMaThe.Text,
                HoTen = tenBenhNhanMoi,
                GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                NgaySinh = cboNgaySinh.Value,
                SDT = TxtSDT.Text,
                Email = txtMail.Text,
                DiaChi = txtDiaChi.Text
            };

            BenhNhanService.AddBenhNhan(newBenhNhan);
            LoadData();
            clean();
            UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ

            MessageBox.Show("Bệnh nhân đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // button chức năng  Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maBenhNhan = txtMaBN.Text;

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                BenhNhanService.DeleteBenhNhan(maBenhNhan);
                LoadData();
                clean();
                UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ

                // Hiển thị thông báo xóa thành công
                MessageBox.Show("Bệnh nhân đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        // button chức năng  Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maBenhNhan = txtMaBN.Text;
            BenhNhan existingBenhNhan = BenhNhanService.GetBenhNhanByMaBenhNhan(maBenhNhan);

            if (existingBenhNhan != null)
            {
                existingBenhNhan.MaThe = txtMaThe.Text;
                existingBenhNhan.HoTen = txtHoTen.Text;
                existingBenhNhan.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                existingBenhNhan.NgaySinh = cboNgaySinh.Value;
                existingBenhNhan.SDT = TxtSDT.Text;
                existingBenhNhan.Email = txtMail.Text;
                existingBenhNhan.DiaChi = txtDiaChi.Text;

                BenhNhanService.UpdateBenhNhan(existingBenhNhan);
                LoadData();
                clean();
                UpdateGenderCounts(); // Cập nhật đếm số lượng nam và nữ
                MessageBox.Show("Bệnh nhân đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // button chức năng  Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            clean();
        }



        // button chức năng thoát 
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


//================================================================================================
        // button chức năng Tìm kiếm
        private void ThucHienTimKiem()
        {
            string keyword = txtTimKiem.Text;
            List<BenhNhan> filteredList = BenhNhanService.GetAllBenhNhan()
                .Where(benhNhan => benhNhan.HoTen.Contains(keyword))
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
            List<BenhNhan> danhSachLoc;

            if (gioiTinhFilter == "Tất cả")
            {
                danhSachLoc = BenhNhanService.GetAllBenhNhan();
            }
            else
            {
                danhSachLoc = BenhNhanService.GetAllBenhNhan()
                    .Where(benhNhan => benhNhan.GioiTinh == gioiTinhFilter)
                    .ToList();
            }
            BenhNhanCombobox(danhSachLoc);
        }



        //Tạo Classs đê đếm số Nam và Nữ
        private void UpdateGenderCounts()
        {
            int countNam = 0;
            int countNu = 0;

            foreach (DataGridViewRow row in dgvBenhNhan.Rows)
            {
                string gioiTinh = row.Cells[3].Value.ToString();
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
    }
}
