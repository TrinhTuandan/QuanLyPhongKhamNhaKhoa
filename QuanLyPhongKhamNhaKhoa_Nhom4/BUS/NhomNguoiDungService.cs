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
    public class NhomNguoiDungService
    {
        private Model1 context;

        public NhomNguoiDungService()
        {
            context = new Model1();
        }

        public NhomNguoiDung GetNhomNguoiDungByMaNhom(string maNhom)
        {
            return context.NhomNguoiDung.FirstOrDefault(n => n.MaNhom == maNhom);
        }

        public List<NhomNguoiDung> GetAllNhomNguoiDung()
        {
            return context.NhomNguoiDung.ToList();
        }

        public void AddNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            context.NhomNguoiDung.Add(nhomNguoiDung);
            context.SaveChanges();
        }

        public void UpdateNhomNguoiDung(NhomNguoiDung nhomNguoiDung)
        {
            var existingNhom = context.NhomNguoiDung.Find(nhomNguoiDung.MaNhom);
            if (existingNhom != null)
            {
                context.Entry(existingNhom).CurrentValues.SetValues(nhomNguoiDung);
                context.SaveChanges();
            }
        }

        public void DeleteNhomNguoiDung(string maNhom)
        {
            var nhomNguoiDung = context.NhomNguoiDung.Find(maNhom);
            if (nhomNguoiDung != null)
            {
                context.NhomNguoiDung.Remove(nhomNguoiDung);
                context.SaveChanges();
            }
        }
//======================================================================================================
        public NhomNguoiDung GetNhomNguoiDungById(string maNhom)
        {
            return context.NhomNguoiDung.FirstOrDefault(n => n.MaNhom == maNhom);
        }

        public bool NhomNguoiDungExists(string maNhom)
        {
            return context.NhomNguoiDung.Any(n => n.MaNhom == maNhom);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
