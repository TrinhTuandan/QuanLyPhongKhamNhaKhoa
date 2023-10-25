namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            PhieuDichVu = new HashSet<PhieuDichVu>();
        }

        [Key]
        [StringLength(10)]
        public string MaDV { get; set; }

        [StringLength(100)]
        public string TenDV { get; set; }

        public int? DonGia { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDichVu> PhieuDichVu { get; set; }
    }
}
