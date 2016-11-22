namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiLam")]
    public partial class BaiLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKQ { get; set; }

        [StringLength(400)]
        public string TraLoi { get; set; }

        [StringLength(400)]
        public string DapAn { get; set; }

        public virtual KetQuaKiemTra KetQuaKiemTra { get; set; }
    }
}
