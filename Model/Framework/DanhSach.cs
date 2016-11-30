namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSach")]
    public partial class DanhSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSach()
        {
            KetQuaKiemTras = new HashSet<KetQuaKiemTra>();
            Permissions = new HashSet<Permission>();
        }

        [Key]
        public int IDQN { get; set; }

        [Required]
        [StringLength(200)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(5)]
        public string CB { get; set; }

        [Required]
        [StringLength(5)]
        public string CV { get; set; }

        [Required]
        [StringLength(20)]
        public string DonVi { get; set; }

        [Required]
        [StringLength(5)]
        public string ThanhPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQuaKiemTra> KetQuaKiemTras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
