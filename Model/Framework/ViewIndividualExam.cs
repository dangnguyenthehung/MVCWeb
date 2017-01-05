namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewIndividualExam")]
    public partial class ViewIndividualExam
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDQN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string HoTen { get; set; }

        public int? IndividualExam { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string DonVi { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string ThanhPhan { get; set; }
    }
}
