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
    public partial class FormHome : Form
    {
        private Timer timer;
        public FormHome()
        {
            InitializeComponent();

            // Tạo một đối tượng Timer với khoảng thời gian là 1000 milliseconds (1 giây)
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            // Bắt đầu timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;

            // Định dạng thời gian theo 24 giờ
            string time = now.ToString(" HH:mm:ss ");
            // Định dạng ngày, tháng, năm
            string date = now.ToString(" dd/MM/yyyy ");

            // Gán thời gian vào label labTime
            labTime.Text = time;
            labDate.Text = date;
        }




        // khởi tạo công việc của form 
        private Form currentFormChild;
        private void OpenChildForm(Form dataForm)
        { 
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = dataForm;
            dataForm.TopLevel = false; // Đặt Data không phải là top-level control
            dataForm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền của Data (nếu cần)
            dataForm.Dock = DockStyle.Fill; // Đảm bảo Data lấp đầy panelBody
            panelBody.Controls.Add(dataForm); // Thêm Data vào panelBody
            panelBody.Tag = dataForm;
            dataForm.BringToFront();
            dataForm.Show();

        }

        // menu mở form DataKhachHang
        private void tsmHoSoKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataBenhNhan());
            labelHomee.Text = tsmHoSoKH.Text;
        }
        // menu mở form DataNhanVien
        private void tsmDanhSachNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataNhanVien());
            labelHomee.Text = tsmDanhSachNV.Text;
        }
        // menu mở Chức năng thoát
        private void tsmThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataNguoiDung());
            labelHomee.Text = tsmQuanLyNguoiDung.Text;
        }

        //==========================================================================================================


        // button mở form DataTiepDonBenhNhan
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataTiepDonBenhNhan());
            labelHomee.Text = "Tiếp Đón Bệnh Nhân";
     
        }
        // button mở form DataBenhNhan
        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataBenhNhan());
            labelHomee.Text = "Danh Sách Bệnh Nhân";
        }
        // button mở form DataLichHen
        private void btnLichHen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataLichHen());
            labelHomee.Text = "Danh Sách Lịch Hẹn";
        }
        // button mở form DataKhamChua
        private void btnKhamChua_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataPhieuKhamChua());
            labelHomee.Text = "Danh Sách Khám Chữa";
        }
        // button mở form DataDichVu
        private void btnDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataDichVu());
            labelHomee.Text = "Danh Sách Dịch Vụ";
        } 
        // button mở form DataNhanVien
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataNhanVien());
            labelHomee.Text = "Danh Sách Bệnh Nhân";
        }
        // button mở form DataHoSo     
        private void btnHoSo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataHoSo());
            labelHomee.Text = "Danh Sách Hồ Sơ";
        }
        // button mở form DataQuanLyThuChi
        private void btnThuChi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataQuanLyThuChi());
            labelHomee.Text = "Danh Sách Quản Lý Thu Chi";
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DataNguoiDung());
            labelHomee.Text = "Cài Đặt";
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            labelHomee.Text = "Trợ Giúp";
            TroGiup f = new TroGiup();
            f.ShowDialog();

        }

        private void FormHome_Load(object sender, EventArgs e)
        {
           
        }


        private void labTime_Click(object sender, EventArgs e)
        {
            
        }
    }
}
