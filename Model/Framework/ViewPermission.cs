namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewPermission")]
    public partial class ViewPermission
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDQN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Quyền truy cập")]
        public int? Permission { get; set; }

        [Display(Name = "Lượt truy cập")]
        public int? LogStatus { get; set; }
    }
}
