using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DataDichVu : Form
    {

        private readonly DichVuService DichVuService = new DichVuService();
        private List<DichVu> filteredDichVuList;

        public DataDichVu()
        {
            InitializeComponent();
            LoadData();
            Clean();
        }

        private void DataDichVu_Load(object sender, EventArgs e)
        {
            cboDonViTinh.SelectedIndex = -1;    
            cboLoaiDichVu.SelectedIndex = -1;
            // Tải dữ liệu ban đầu
            LoadData();
            Clean();
        }

        private void LoadData()
        {
            var listDichVu = DichVuService.GetAllDichVu();
            BindGrid(listDichVu);
            LoadCboLocLoaiDichVu(); // Đảm bảo gọi phương thức này

            using (var context = new Model1()) 
            {
                var LoaidichvuList = context.LoaiDichVu.ToList();


                cboLoaiDichVu.DataSource = LoaidichvuList;
                cboLoaiDichVu.DisplayMember = "TenLoai";
                cboLoaiDichVu.ValueMember = "MaLoai"; 

                
            }
        }

        private void BindGrid(List<DichVu> listDichVu)
        {
            dgvDichVu.Rows.Clear();
            foreach (var item in listDichVu)
            {
                int index = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[index].Cells[0].Value = item.MaDV;
                dgvDichVu.Rows[index].Cells[1].Value = item.TenDV;
                dgvDichVu.Rows[index].Cells[2].Value = item.DonGia;
                dgvDichVu.Rows[index].Cells[3].Value = item.DonViTinh;
                dgvDichVu.Rows[index].Cells[4].Value = item.LoaiDichVu.TenLoai; // Hiển thị tên loại dịch vụ
            }
        }


        private void LoadCboLocLoaiDichVu()
        {
            var listLoaiDichVu = DichVuService.GetAllLoaiDichVu().Select(loai => loai.TenLoai).ToList();
            listLoaiDichVu.Insert(0, "Tất cả"); // Thêm tùy chọn "Tất cả" vào đầu danh sách
            cboLocLoaiDichVu.DataSource = listLoaiDichVu;
        }
 
        


        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = selectedRow.Cells[0].Value?.ToString();
                txtTenDV.Text = selectedRow.Cells[1].Value?.ToString();
                txtDonGia.Text = selectedRow.Cells[2].Value?.ToString();
                cboDonViTinh.Text = selectedRow.Cells[3].Value?.ToString();
                cboLoaiDichVu.Text = selectedRow.Cells[4].Value?.ToString();
            }
        } 
//=================================================================================================        
        private void Clean()
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtDonGia.Text = "";
            cboDonViTinh.SelectedIndex = -1;
            cboLoaiDichVu.SelectedIndex = 0;
            cboLocLoaiDichVu.SelectedIndex = 0;
        }

        public string LayMaDVTuTang()
        {
            int count = dgvDichVu.Rows.Count;
            string ma = "";
            string mamoi = "";
            int manv = 0;
            ma = Convert.ToString(dgvDichVu.Rows[count - 1].Cells[0].Value);
            manv = Convert.ToInt32((ma.Remove(0, 2)));

            if (manv + 1 < 10)
            {
                mamoi = "DV00" + (manv + 1).ToString();
            }
            else if (manv + 1 < 100)
            {
                mamoi = "DV0" + (manv + 1).ToString();
            }
            else if (manv + 1 < 1000)
            {
                mamoi = "DV" + (manv + 1).ToString();
            }
            return mamoi;
        }

        private bool KiemTraTenDVTonTai(string tenDichVu)
        {
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                string tenDaTonTai = row.Cells[1].Value?.ToString();
                if (tenDaTonTai == tenDichVu)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDVMoi = txtTenDV.Text;
            if (KiemTraTenDVTonTai(tenDVMoi))
            {
                MessageBox.Show("Tên dịch vụ đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DichVu newDichVu = new DichVu
            {
                MaDV = LayMaDVTuTang(),
                TenDV = tenDVMoi,
                DonGia = int.Parse(txtDonGia.Text),
                DonViTinh = cboDonViTinh.Text,
                MaLoai = DichVuService.GetMaLoaiDichVuTheoTen(cboLoaiDichVu.Text)
            };

            DichVuService.AddDichVu(newDichVu);
            LoadData();
            Clean();
            MessageBox.Show("Dịch vụ đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDV.Text;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                DichVuService.DeleteDichVu(maDichVu);
                LoadData();
                Clean();
                MessageBox.Show("Dịch vụ đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDV.Text;
            DichVu existingDichVu = DichVuService.GetDichVuByMaDV(maDichVu);

            if (existingDichVu != null)
            {
                existingDichVu.TenDV = txtTenDV.Text;
                existingDichVu.DonGia = int.Parse(txtDonGia.Text);
                existingDichVu.DonViTinh = cboDonViTinh.Text;
                existingDichVu.MaLoai = DichVuService.GetMaLoaiDichVuTheoTen(cboLoaiDichVu.Text);

                DichVuService.UpdateDichVu(existingDichVu);
                LoadData();
                Clean();
                MessageBox.Show("Dịch vụ đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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


//=================================================================================================   
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ThucHienTimKiem();
            }
        }
        private void ThucHienTimKiem()
        {
            string keyword = txtTimKiem.Text;
            List<DichVu> filteredList = DichVuService.GetAllDichVu()
                .Where(dv => dv.TenDV.Contains(keyword))
                .ToList();

            BindGrid(filteredList);

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
            }
        }
//=================================================================================================   


        private void cboLocLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
             string selectedLoaiDichVu = cboLocLoaiDichVu.Text;

            if (selectedLoaiDichVu == "Tất cả")
            {
                // Nếu "Tất cả" được chọn, hiển thị toàn bộ danh sách dịch vụ
                LoadData();
            }
            else
            {
                // Lọc danh sách dịch vụ theo loại dịch vụ được chọn
                var filteredDichVu = DichVuService.GetDichVuByLoaiDichVu(selectedLoaiDichVu);
                BindGrid(filteredDichVu);
            }
        }

        private void btnThemLoaiDV_Click(object sender, EventArgs e)
        {
            ThemLoaiDichVu f = new ThemLoaiDichVu();
            f.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
