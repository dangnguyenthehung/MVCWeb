namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        public int ID { get; set; }

        public int? IDQN { get; set; }

        [Column("Permission")]
        public int? Permission1 { get; set; }

        public int? LogStatus { get; set; }

        public virtual DanhSach DanhSach { get; set; }
    }
}
