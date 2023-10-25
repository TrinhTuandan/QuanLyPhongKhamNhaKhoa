namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaNhom { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaManHinh { get; set; }

        public bool CoQuyen { get; set; }

        public virtual ManHinh ManHinh { get; set; }

        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
    }
}
