namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQuaKiemTra")]
    public partial class KetQuaKiemTra
    {
        [Key]
        public int IDKQ { get; set; }

        public int IDQN { get; set; }

        public DateTime NgayKT { get; set; }

        public decimal? KQ { get; set; }

        [StringLength(2)]
        public string XepLoai { get; set; }

        public int? DeSo { get; set; }

        [StringLength(400)]
        public string TraLoi { get; set; }

        [StringLength(400)]
        public string DapAn { get; set; }

        public virtual DanhSach DanhSach { get; set; }
    }
}
