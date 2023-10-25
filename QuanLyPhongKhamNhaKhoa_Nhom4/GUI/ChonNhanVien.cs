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
    public partial class ChonNhanVien : Form
    {
        private readonly NhanVienService nhanVienService = new NhanVienService();
        public ChonNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<NhanVien> listNhanVien = nhanVienService.GetAllNhanVien();
            BindGrid(listNhanVien);
        }

        private void BindGrid(List<NhanVien> listNhanVien)
        {
            dgvNhanVien.Rows.Clear();
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


       
        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedMaNhanVien) && !string.IsNullOrWhiteSpace(selectedTenNhanVien))
            {
                DataNguoiDung dataNguoiDung = (DataNguoiDung)Application.OpenForms["DataNguoiDung"];
                if (dataNguoiDung != null)
                {
                    dataNguoiDung.SetNhanVien(selectedMaNhanVien, selectedTenNhanVien);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string selectedMaNhanVien = "";
        private string selectedTenNhanVien = "";
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaNhanVien = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedTenNhanVien = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
