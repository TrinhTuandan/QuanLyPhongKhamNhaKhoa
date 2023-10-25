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
    public partial class DataNhomNguoiDung : Form
    {
        private readonly NhomNguoiDungService NhomNguoiDungService = new NhomNguoiDungService();
        private NhomNguoiDung selectedNhomNguoiDung;

        public DataNhomNguoiDung()
        {
            InitializeComponent();
            LoadData();
            Clean();
        }

        private void LoadData()
        {
            List<NhomNguoiDung> listNhomNguoiDung = NhomNguoiDungService.GetAllNhomNguoiDung();
            BindGrid(listNhomNguoiDung);
        }

        private void BindGrid(List<NhomNguoiDung> listNhomNguoiDung)
        {
            dgvNhomNguoiDung.Rows.Clear();
            foreach (var item in listNhomNguoiDung)
            {
                int index = dgvNhomNguoiDung.Rows.Add();
                dgvNhomNguoiDung.Rows[index].Cells[0].Value = item.MaNhom;
                dgvNhomNguoiDung.Rows[index].Cells[1].Value = item.TenNhom;
                dgvNhomNguoiDung.Rows[index].Cells[2].Value = item.GhiChu;
            }
        }
        private void dgvNhomNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvNhomNguoiDung.Rows[e.RowIndex];
                txtMaNhom.Text = selectedRow.Cells[0].Value?.ToString();
                txtTenNhom.Text = selectedRow.Cells[1].Value?.ToString();
                txtGhiChu.Text = selectedRow.Cells[2].Value?.ToString();
                selectedNhomNguoiDung = new NhomNguoiDung
                {
                    MaNhom = txtMaNhom.Text,
                    TenNhom = txtTenNhom.Text,
                    GhiChu = txtGhiChu.Text
                };
            }
        }
 

        private void Clean()
        {
            txtMaNhom.Text = "";
            txtTenNhom.Text = "";
            txtGhiChu.Text = "";
        }

        // Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenNhom = txtTenNhom.Text;

            if (string.IsNullOrWhiteSpace(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhomNguoiDung newNhomNguoiDung = new NhomNguoiDung
            {
                MaNhom = txtMaNhom.Text,
                TenNhom = tenNhom,
                GhiChu = txtGhiChu.Text
            };

            NhomNguoiDungService.AddNhomNguoiDung(newNhomNguoiDung);
            LoadData();
            Clean();

            MessageBox.Show("Nhóm người dùng đã được thêm thành công.", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedNhomNguoiDung == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm người dùng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                NhomNguoiDungService.DeleteNhomNguoiDung(selectedNhomNguoiDung.MaNhom);
                LoadData();
                Clean();
                MessageBox.Show("Nhóm người dùng đã được xóa thành công.", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedNhomNguoiDung == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm người dùng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenNhom = txtTenNhom.Text;

            if (string.IsNullOrWhiteSpace(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedNhomNguoiDung.TenNhom = tenNhom;
            selectedNhomNguoiDung.GhiChu = txtGhiChu.Text;

            NhomNguoiDungService.UpdateNhomNguoiDung(selectedNhomNguoiDung);
            LoadData();
            Clean();

            MessageBox.Show("Nhóm người dùng đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataNhomNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
