namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDungNhomNguoiDung")]
    public partial class NguoiDungNhomNguoiDung
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaNhom { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
    }
}
