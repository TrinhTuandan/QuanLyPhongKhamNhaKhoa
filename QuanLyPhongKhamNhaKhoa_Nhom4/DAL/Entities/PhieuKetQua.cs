namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKetQua")]
    public partial class PhieuKetQua
    {
        [Key]
        [StringLength(10)]
        public string SoPhieuKQ { get; set; }

        [StringLength(100)]
        public string TenDV { get; set; }

        [Required]
        [StringLength(10)]
        public string SoPhieuDV { get; set; }

        [Column(TypeName = "text")]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string KetLuan { get; set; }

        public virtual PhieuDichVu PhieuDichVu { get; set; }
    }
}
