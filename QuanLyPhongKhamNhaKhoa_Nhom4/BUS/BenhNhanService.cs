using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class BenhNhanService
    {

        private Model1 context;

        // Phương thức này trả về danh sách tất cả bệnh nhân trong cơ sở dữ liệu
        public BenhNhanService()
        {
            context = new Model1();
        }
        // danh sách tất cả các dịch vụ
        public List<BenhNhan> GetAllBenhNhan()
        {
            return context.BenhNhan.ToList();
        }
        // Lấy thông tin của một bệnh nhân dựa trên mã bệnh nhân
        public BenhNhan GetBenhNhanByMaBenhNhan(string maBenhNhan)
        {
            return context.BenhNhan.Find(maBenhNhan);
        }
        // thêm một bệnh nhân mới vào cơ sở dữ liệu
        public void AddBenhNhan(BenhNhan benhNhan)
        {
            context.BenhNhan.Add(benhNhan);
            context.SaveChanges();
        }
        // Cập nhật thông tin  bệnh nhân 
        public void UpdateBenhNhan(BenhNhan benhNhan)
        {
            context.Entry(benhNhan).State = EntityState.Modified;
            context.SaveChanges();
        }
       // Xóa một bệnh nhân
        public void DeleteBenhNhan(string maBenhNhan)
        {
            var benhNhan = context.BenhNhan.Find(maBenhNhan);
            if (benhNhan != null)
            {
                context.BenhNhan.Remove(benhNhan);
                context.SaveChanges();
            }
        }
    }
}
