namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDichVu")]
    public partial class PhieuDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDichVu()
        {
            PhieuKetQua = new HashSet<PhieuKetQua>();
            DichVu = new HashSet<DichVu>();
        }

        [Key]
        [StringLength(10)]
        public string SoPhieuDV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBenhNhan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string SoPhieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? TongTien { get; set; }

        [StringLength(20)]
        public string ThanhToan { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }

        public virtual PhongKham PhongKham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKetQua> PhieuKetQua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichVu> DichVu { get; set; }
    }
}
