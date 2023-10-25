using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<BenhNhan> BenhNhan { get; set; }
        public virtual DbSet<DichVu> DichVu { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVu { get; set; }
        public virtual DbSet<ManHinh> ManHinh { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NguoiDungNhomNguoiDung> NguoiDungNhomNguoiDung { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDung { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<PhieuDichVu> PhieuDichVu { get; set; }
        public virtual DbSet<PhieuKetQua> PhieuKetQua { get; set; }
        public virtual DbSet<PhieuKhamBenh> PhieuKhamBenh { get; set; }
        public virtual DbSet<PhongKham> PhongKham { get; set; }
        public virtual DbSet<TiepDonBenhNhan> TiepDonBenhNhan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaBenhNhan)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.MaThe)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.PhieuDichVu)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.TiepDonBenhNhan)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.PhieuDichVu)
                .WithMany(e => e.DichVu)
                .Map(m => m.ToTable("CTPhieuDichVu").MapLeftKey("MaDV").MapRightKey("SoPhieuDV"));

            modelBuilder.Entity<LoaiDichVu>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.DichVu)
                .WithRequired(e => e.LoaiDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ManHinh>()
                .Property(e => e.MaManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<ManHinh>()
                .HasMany(e => e.PhanQuyen)
                .WithRequired(e => e.ManHinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.NguoiDungNhomNguoiDung)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDungNhomNguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDungNhomNguoiDung>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.TiepDonBenhNhan)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.BacSi);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.TiepDonBenhNhan1)
                .WithRequired(e => e.NhanVien1)
                .HasForeignKey(e => e.NhanVienTiepDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.NguoiDungNhomNguoiDung)
                .WithRequired(e => e.NhomNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.PhanQuyen)
                .WithRequired(e => e.NhomNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDichVu>()
                .Property(e => e.SoPhieuDV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDichVu>()
                .Property(e => e.MaBenhNhan)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDichVu>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDichVu>()
                .Property(e => e.SoPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDichVu>()
                .HasMany(e => e.PhieuKetQua)
                .WithRequired(e => e.PhieuDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuKetQua>()
                .Property(e => e.SoPhieuKQ)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKetQua>()
                .Property(e => e.SoPhieuDV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKetQua>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhamBenh>()
                .Property(e => e.SoPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhamBenh>()
                .HasMany(e => e.PhieuDichVu)
                .WithRequired(e => e.PhieuKhamBenh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKham>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhongKham>()
                .HasMany(e => e.PhieuDichVu)
                .WithRequired(e => e.PhongKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKham>()
                .HasMany(e => e.TiepDonBenhNhan)
                .WithRequired(e => e.PhongKham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .Property(e => e.SoPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .Property(e => e.MaBenhNhan)
                .IsUnicode(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .Property(e => e.NhanVienTiepDon)
                .IsUnicode(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .Property(e => e.BacSi)
                .IsUnicode(false);

            modelBuilder.Entity<TiepDonBenhNhan>()
                .HasOptional(e => e.PhieuKhamBenh)
                .WithRequired(e => e.TiepDonBenhNhan);
        }
    }
}
