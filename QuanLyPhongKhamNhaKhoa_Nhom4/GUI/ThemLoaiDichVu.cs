using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemLoaiDichVu : Form
    {
        private readonly LoaiDichVuService LoaiDichVuService = new LoaiDichVuService();
        public ThemLoaiDichVu()

        {
            InitializeComponent();
        }

        private void ThemLoaiDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            Clean();
        }

        //Load lại thông tin trên dataGridview
        private void LoadData()
        {
            List<LoaiDichVu> listLoaiDichVu = LoaiDichVuService.GetAllLoaiDichVu();
            BindGrid(listLoaiDichVu);
        }

        //Phương thức BindGrid được sử dụng để hiển thị danh sách lên DataGridView 
        private void BindGrid(List<LoaiDichVu> listLoaiDichVu)
        {
            // Xóa dữ liệu cũ trên DataGridView
            dgvAddLoaiDV.Rows.Clear();
            // Duyệt qua danh sách bệnh nhân và hiển thị thông tin lên DataGridView
            foreach (var item in listLoaiDichVu)
            {
                int index = dgvAddLoaiDV.Rows.Add();
                dgvAddLoaiDV.Rows[index].Cells[0].Value = item.MaLoai;
                dgvAddLoaiDV.Rows[index].Cells[1].Value = item.TenLoai;
               
            }
        }
        private void dgvAddLoaiDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvAddLoaiDV.Rows[e.RowIndex];
                txtMaLoai.Text = selectedRow.Cells[0].Value?.ToString();
                txtTenLoai.Text = selectedRow.Cells[1].Value?.ToString();
            }
        }



        //===============================================================================================
        private void Clean()
        {
            txtMaLoai.Text = LayMaLoaiTuTang();
            txtTenLoai.Text = "";

        }
        // Tự Động Tạo Mã mới cho nhân viên
        public string LayMaLoaiTuTang()
        {
            int count = dgvAddLoaiDV.Rows.Count;
            string ma = "";
            string mamoi = "";
            int manv = 0;
            ma = Convert.ToString(dgvAddLoaiDV.Rows[count - 1].Cells[0].Value);
            manv = Convert.ToInt32((ma.Remove(0, 2)));
            if (manv + 1 < 10)
            {
                mamoi = "L00" + (manv + 1).ToString();
            }
            else if (manv + 1 < 100)
            {
                mamoi = "L0" + (manv + 1).ToString();
            }
            else if (manv + 1 < 1000)
            {
                mamoi = "L" + (manv + 1).ToString();
            }
            return mamoi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenLoaiDichVu = txtTenLoai.Text;

            if (string.IsNullOrWhiteSpace(tenLoaiDichVu))
            {
                MessageBox.Show("Vui lòng nhập tên loại dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoaiDichVu newLoaiDichVu = new LoaiDichVu
            {
                MaLoai = txtMaLoai.Text,
                TenLoai = tenLoaiDichVu
            };

            LoaiDichVuService.AddLoaiDichVu(newLoaiDichVu);
            LoadData();
            Clean();

            MessageBox.Show("Loại dịch vụ đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một loại dịch vụ để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maLoai = txtMaLoai.Text;

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                LoaiDichVuService.DeleteLoaiDichVu(maLoai);
                LoadData();
                Clean();
                MessageBox.Show("Loại dịch vụ đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một loại dịch vụ để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maLoai = txtMaLoai.Text;
            string tenLoaiDichVu = txtTenLoai.Text;

            if (string.IsNullOrWhiteSpace(tenLoaiDichVu))
            {
                MessageBox.Show("Vui lòng nhập tên loại dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoaiDichVu existingLoaiDichVu = LoaiDichVuService.GetLoaiDichVuByMaLoai(maLoai);

            if (existingLoaiDichVu != null)
            {
                existingLoaiDichVu.TenLoai = tenLoaiDichVu;

                LoaiDichVuService.UpdateLoaiDichVu(existingLoaiDichVu);
                LoadData();
                Clean();

                MessageBox.Show("Loại dịch vụ đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

//================================================================================================

        private void ThucHienTimKiem()
        {
            string keyword = txtTimKiem.Text;
            List<LoaiDichVu> filteredList = LoaiDichVuService.GetAllLoaiDichVu()
                .Where(loaiDichVu => loaiDichVu.TenLoai.Contains(keyword))
                .ToList();

            BindGrid(filteredList);

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự Enter xuất hiện trong ô tìm kiếm
                ThucHienTimKiem();
            }
        }
    }
}
