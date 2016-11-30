namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewKQ")]
    public partial class ViewKQ
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "IDQN")]
        public int IDQN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Đề số")]
        public int? DeSo { get; set; }

        [Display(Name = "Điểm")]
        public decimal? KQ { get; set; }

        [Display(Name = "Xếp loại")]
        [StringLength(2)]
        public string XepLoai { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Ngày kiểm tra")]
        public DateTime NgayKT { get; set; }
    }
}
