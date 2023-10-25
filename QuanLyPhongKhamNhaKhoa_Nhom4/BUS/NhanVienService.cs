using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class NhanVienService
    {
        private Model1 context;

        public NhanVienService()
        {
            context = new Model1();
        }
        // Lấy danh sách tất cả các Nhân Viên
        public List<NhanVien> GetAllNhanVien()
        {
            return context.NhanVien.ToList();
        }
        // Lấy Mã Nhân Viên tất cả các Nhân Viên
        public NhanVien GetNhanVienByMaNhanVien(string maNhanVien)
        {
            return context.NhanVien.Find(maNhanVien);
        }
        // thêm một nhân viên mới vào cơ sở dữ liệu
        public void AddNhanVien(NhanVien nhanVien)
        {
            context.NhanVien.Add(nhanVien);
            context.SaveChanges();
        }
        // cập nhật thông tin của một nhân viên
        public void UpdateNhanVien(NhanVien nhanVien)
        {
            context.Entry(nhanVien).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        // xóa một nhân viên dựa trên mã nhân viên
        public void DeleteNhanVien(string maNhanVien)
        {
            var nhanVien = context.NhanVien.Find(maNhanVien);
            if (nhanVien != null)
            {
                context.NhanVien.Remove(nhanVien);
                context.SaveChanges();
            }
        }
    }
}
