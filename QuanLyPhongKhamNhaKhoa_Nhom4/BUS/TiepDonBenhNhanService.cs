using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TiepDonBenhNhanService
    {
        private Model1 context;

        public TiepDonBenhNhanService()
        {
            context = new Model1();
        }

        public TiepDonBenhNhanService(Model1 context)
        {
            this.context = context;
        }

        public List<TiepDonBenhNhan> GetAllTiepDonBenhNhan()
        {
            return context.TiepDonBenhNhan.ToList();
        }

        public TiepDonBenhNhan GetTiepDonBenhNhanById(string soPhieu)
        {
            return context.TiepDonBenhNhan.FirstOrDefault(t => t.SoPhieu == soPhieu);
        }

        public void AddTiepDonBenhNhan(TiepDonBenhNhan tiepDonBenhNhan)
        {
            context.TiepDonBenhNhan.Add(tiepDonBenhNhan);
            context.SaveChanges();
        }

        public void UpdateTiepDonBenhNhan(TiepDonBenhNhan tiepDonBenhNhan)
        {
            context.Entry(tiepDonBenhNhan).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTiepDonBenhNhan(string soPhieu)
        {
            var tiepDonBenhNhan = context.TiepDonBenhNhan.FirstOrDefault(t => t.SoPhieu == soPhieu);
            if (tiepDonBenhNhan != null)
            {
                context.TiepDonBenhNhan.Remove(tiepDonBenhNhan);
                context.SaveChanges();
            }
        }

        public List<TiepDonBenhNhan> GetDanhSachTiepDon()
        {
            return context.TiepDonBenhNhan.ToList();
        }

        public List<TiepDonBenhNhan> LayDSTiepDonTheoPhong(string phong)
        {
            return context.TiepDonBenhNhan.Where(t => t.MaPhong == phong).ToList();
        }

        public List<TiepDonBenhNhan> GetTiepDonBenhNhanByNhanVien(string nhanVienId)
        {
            return context.TiepDonBenhNhan.Where(t => t.NhanVienTiepDon == nhanVienId).ToList();
        }

        // Add more methods if needed for specific business logic

        public NhanVien GetNhanVienById(string nhanVienId)
        {
            return context.NhanVien.FirstOrDefault(n => n.MaNhanVien == nhanVienId);
        }
        public NhanVien GetBacSiById(string bacSiId)
        {
            return context.NhanVien.FirstOrDefault(n => n.MaNhanVien == bacSiId);
        }

        public List<TiepDonBenhNhan> GetTiepDonBenhNhanByPhongKham(string PhongKham)
        {
            return GetAllTiepDonBenhNhan().Where(dv => dv.PhongKham.TenPhong == PhongKham).ToList();
        }

    }
}
