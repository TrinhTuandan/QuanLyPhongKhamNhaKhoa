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
    public partial class ChonBenhNhan : Form
    {
        private readonly BenhNhanService BenhNhanService = new BenhNhanService();

        private string selectedMaBenhNhan = "";
        private string selectedMaTheBenhNhan = "";
        private string selectedTenBenhNhan = "";
        private string selectedGioiTinhBenhNhan = "";
        private string selectedNgaySinhBenhNhan = "";
        private string selectedSDTBenhNhan = "";
        private string selectedDiaChiBenhNhan = "";

        public ChonBenhNhan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var listBenhNhan = BenhNhanService.GetAllBenhNhan();
            BindGrid(listBenhNhan);
        }

        private void BindGrid(List<BenhNhan> listBenhNhan)
        {
            dgvBenhNhan.Rows.Clear();
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

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedMaTheBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedTenBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[1].Value.ToString();
                selectedGioiTinhBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedNgaySinhBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[3].Value.ToString();
                //selectedEmailBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[6].Value.ToString();
                selectedSDTBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[5].Value.ToString();
                selectedDiaChiBenhNhan = dgvBenhNhan.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void btnChonBenhNhan_Click(object sender, EventArgs e)
        {
            if (AreFieldsFilled())
            {
                DataTiepDonBenhNhan dataTiepDonBenhNhan = (DataTiepDonBenhNhan)Application.OpenForms["DataTiepDonBenhNhan"];
                if (dataTiepDonBenhNhan != null)
                {
                    dataTiepDonBenhNhan.SetBenhNhan(selectedMaBenhNhan, selectedMaTheBenhNhan,
                        selectedTenBenhNhan, selectedGioiTinhBenhNhan, selectedNgaySinhBenhNhan,
                        selectedSDTBenhNhan, selectedDiaChiBenhNhan);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Bệnh Nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(selectedMaBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedMaTheBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedTenBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedGioiTinhBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedNgaySinhBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedSDTBenhNhan)
                && !string.IsNullOrWhiteSpace(selectedDiaChiBenhNhan);
        }
    }
}
