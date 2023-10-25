using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NguoiDungService
    {
        private Model1 Context;

        public NguoiDungService()
        {
            Context = new Model1();
        }

        public NguoiDung GetNguoiDungByMaNhanVien(string maNhanVien)
        {
            return Context.NguoiDung.FirstOrDefault(u => u.MaNhanVien == maNhanVien);
        }

        public List<NguoiDung> GetAllNguoiDung()
        {
            return Context.NguoiDung.ToList();
        }

        public void AddNguoiDung(NguoiDung nguoiDung)
        {
            Context.NguoiDung.Add(nguoiDung);
            Context.SaveChanges();
        }
        //========================================================================
        // Cập nhật thông tin Người Dùng
        public void UpdateNguoiDung(NguoiDung nguoiDung)
        {
            // Attach the entity to the context if it's not already
            if (!Context.NguoiDung.Local.Any(e => e.MaNhanVien == nguoiDung.MaNhanVien))
            {
                Context.NguoiDung.Attach(nguoiDung);
            }

            Context.Entry(nguoiDung).State = EntityState.Modified;
        }


        //==========================================================================
        public void DeleteNguoiDung(string maNhanVien)
        {
            // Tìm người dùng theo mã người dùng
            var nguoiDung = Context.NguoiDung.FirstOrDefault(u => u.MaNhanVien == maNhanVien);

            if (nguoiDung != null)
            {
                // Xóa người dùng khỏi DbSet
                Context.NguoiDung.Remove(nguoiDung);
                Context.SaveChanges();
            }
        }

        public string GetTenNhanVienByMaNhanVien(string maNhanVien)
        {
            var nhanVien = Context.NhanVien.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);

            if (nhanVien != null)
            {
                return nhanVien.HoTen;
            }

            return string.Empty;
        }

        public void Dispose()
        {
            Context.Dispose();
        }


    }
}
