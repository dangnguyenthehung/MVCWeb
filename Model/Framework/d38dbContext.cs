namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class d38dbContext : DbContext
    {
        public d38dbContext()
            : base("name=d38dbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DanhSach> DanhSaches { get; set; }
        public virtual DbSet<KetQuaKiemTra> KetQuaKiemTras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSach>()
                .HasMany(e => e.KetQuaKiemTras)
                .WithRequired(e => e.DanhSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KetQuaKiemTra>()
                .Property(e => e.KQ)
                .HasPrecision(2, 1);

            modelBuilder.Entity<KetQuaKiemTra>()
                .Property(e => e.TraLoi)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
