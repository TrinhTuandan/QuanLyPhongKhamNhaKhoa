namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKhamBenh")]
    public partial class PhieuKhamBenh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKhamBenh()
        {
            PhieuDichVu = new HashSet<PhieuDichVu>();
        }

        [Key]
        [StringLength(10)]
        public string SoPhieu { get; set; }

        [StringLength(225)]
        public string ChuanDoan { get; set; }

        [Required]
        [StringLength(225)]
        public string KetLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDichVu> PhieuDichVu { get; set; }

        public virtual TiepDonBenhNhan TiepDonBenhNhan { get; set; }
    }
}
