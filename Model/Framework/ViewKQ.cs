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
        public int IDQN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string HoTen { get; set; }

        public int? DeSo { get; set; }

        public decimal? KQ { get; set; }

        [StringLength(2)]
        public string XepLoai { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime NgayKT { get; set; }
    }
}
