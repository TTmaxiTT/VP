namespace WindowsFormsApp7
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=demoEntities")
        {
        }

        public virtual DbSet<groups> groups { get; set; }
        public virtual DbSet<lectors> lectors { get; set; }
        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<subjects> subjects { get; set; }
        public virtual DbSet<progress> progress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<lectors>()
                .HasMany(e => e.progress)
                .WithRequired(e => e.lectors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<students>()
                .HasMany(e => e.progress)
                .WithRequired(e => e.students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<subjects>()
                .HasMany(e => e.progress)
                .WithRequired(e => e.subjects)
                .WillCascadeOnDelete(false);
        }
    }
}
