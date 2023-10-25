namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TiepDonBenhNhan")]
    public partial class TiepDonBenhNhan
    {
        [Key]
        [StringLength(10)]
        public string SoPhieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKham { get; set; }

        [StringLength(50)]
        public string LoaiKham { get; set; }

        [StringLength(50)]
        public string LyDoKham { get; set; }

        [StringLength(20)]
        public string TieuDuong { get; set; }

        [StringLength(20)]
        public string BenhTimMach { get; set; }

        [StringLength(20)]
        public string HuyetAp { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBenhNhan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string NhanVienTiepDon { get; set; }

        [StringLength(10)]
        public string BacSi { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }

        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }

        public virtual PhongKham PhongKham { get; set; }
    }
}
