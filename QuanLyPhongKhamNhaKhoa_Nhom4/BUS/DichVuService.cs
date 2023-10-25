using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DichVuService
    {
        private readonly Model1 context;

        public DichVuService()
        {
            context = new Model1();
        }

        // Lấy danh sách tất cả các dịch vụ
        public List<DichVu> GetAllDichVu()
        {
            return context.DichVu.ToList();
        }
        //Lấy danh sách tất cả các loại dịch vụ 
        public List<LoaiDichVu> GetAllLoaiDichVu()
        {
            return context.LoaiDichVu.ToList();
        }
        // Lấy một dịch vụ theo mã
        public DichVu GetDichVuByMaDV(string maDV)
        {
            return context.DichVu.Find(maDV);
        }

        // Thêm một dịch vụ mới
        public void AddDichVu(DichVu dichVu)
        {
            context.DichVu.Add(dichVu);
            context.SaveChanges();
        }

        // Cập nhật thông tin dịch vụ
        public void UpdateDichVu(DichVu dichVu)
        {
            context.Entry(dichVu).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        // Xóa một dịch vụ
        public void DeleteDichVu(string maDV)
        {
            var dichVu = context.DichVu.Find(maDV);
            if (dichVu != null)
            {
                context.DichVu.Remove(dichVu);
                context.SaveChanges();
            }
        }
        // Phương thức này trả về mã của loại dịch vụ dựa trên tên loại dịch vụ
        public string GetMaLoaiDichVuTheoTen(string tenLoaiDichVu)
        {
            var loaiDichVu = context.LoaiDichVu.FirstOrDefault(l => l.TenLoai == tenLoaiDichVu);
            if (loaiDichVu != null)
            {
                return loaiDichVu.MaLoai;
            }
            return null;
        }
//========================================================================================================
        // Phương thức này trả về danh sách dịch vụ thuộc một loại dịch vụ cụ thể
        public List<DichVu> GetDichVuByLoaiDichVu(string loaiDichVu)    
        {
            return GetAllDichVu().Where(dv => dv.LoaiDichVu.TenLoai == loaiDichVu).ToList();
        }
    }
}
