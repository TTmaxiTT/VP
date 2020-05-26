namespace WindowsFormsApp5
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<deal> deal { get; set; }
        public virtual DbSet<realty> realty { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<realty>()
                .Property(e => e.area)
                .HasPrecision(19, 4);
        }
    }
}
