using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace BUS
{
    public class LoaiDichVuService
    {
        private Model1 context;

        public LoaiDichVuService()
        {
            context = new Model1();
        }

        public List<LoaiDichVu> GetAllLoaiDichVu()
        {
            return context.LoaiDichVu.ToList();
        }

        public LoaiDichVu GetLoaiDichVuByMaLoai(string maLoai)
        {
            return context.LoaiDichVu.Find(maLoai);
        }

        public void AddLoaiDichVu(LoaiDichVu loaiDichVu)
        {
            context.LoaiDichVu.Add(loaiDichVu);
            context.SaveChanges();
        }

        public void UpdateLoaiDichVu(LoaiDichVu loaiDichVu)
        {
            // Kiểm tra xem loại dịch vụ đã tồn tại trong cơ sở dữ liệu chưa
            var existingLoaiDichVu = context.LoaiDichVu.Find(loaiDichVu.MaLoai);
            if (existingLoaiDichVu != null)
            {
                context.Entry(existingLoaiDichVu).CurrentValues.SetValues(loaiDichVu);
                context.SaveChanges();
            }
        }

        public void DeleteLoaiDichVu(string maLoai)
        {
            var loaiDichVu = context.LoaiDichVu.Find(maLoai);
            if (loaiDichVu != null)
            {
                context.LoaiDichVu.Remove(loaiDichVu);
                context.SaveChanges();
            }
        }
    }
}
