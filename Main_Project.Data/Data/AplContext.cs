using Main_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Main_Project.Data
{
    public class AplContext : DbContext
    {
        //public AplContext()
        //{
        //  Database.EnsureDeleted();   
        //  Database.EnsureCreated();   
        //}

        public AplContext()
        {
            Database.EnsureCreated();
        }

        public AplContext(DbContextOptions<AplContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Shag;Integrated Security=True;");
        }

        public DbSet<Vikladach> Vikladach { get; set; }
        public DbSet<Napryam> Napryam { get; set; }
        public DbSet<FormaNavch> FormaNavch { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudCourses> StudCourses { get; set; }

        //public AplContext(DbContextOptions<AplContext> options) : base(options)
        //{ }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= COMPUTER\\SQLEXPRESS;Database=Shag;Integrated Security=True;");
        }*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vikladach>(End =>
            {
                End.HasKey(t => t.VikladachID);
                End.Property(t => t.Nomer).HasMaxLength(12).IsRequired();
                End.Property(t => t.Fullname).HasMaxLength(40).IsRequired();
                End.Property(t => t.City).HasMaxLength(30).IsRequired();
                End.HasOne(t => t.Napryam).WithMany(sp => sp.Vikladach).HasForeignKey(t => t.NapryamID);
            });
            modelBuilder.Entity<Student>(End =>
            {
                End.HasKey(s => s.StudID);
                End.Property(t => t.Fullname).HasMaxLength(40).IsRequired();
                End.Property(t => t.City).HasMaxLength(30).IsRequired();
            });

            modelBuilder.Entity<Napryam>(End =>
            {
                End.HasKey(sp => sp.NapryamID);
                End.Property(sp => sp.Predmetna_obl).HasMaxLength(30).IsRequired();
            });

            modelBuilder.Entity<StudCourses>(End =>
            {
                End.Property(sc => sc.Id).IsRequired();
                End.Property(sc => sc.Grades).IsRequired();
            });

            modelBuilder.Entity<Student>(End =>
            {
                End.Property(st => st.Fullname).HasMaxLength(40).IsRequired();
                End.Property(st => st.City).HasMaxLength(30).IsRequired();
                End.Property(st => st.Birthdate).HasColumnType("date");
                End.HasOne(st => st.FormaNavch).WithMany(sf => sf.student).HasForeignKey(st => st.FormaNavchID);
            });

            modelBuilder.Entity<FormaNavch>(End =>
            {
                End.HasKey(sf => sf.StudID);
                End.Property(sf => sf.Form).HasMaxLength(30).IsRequired();
            });

            modelBuilder.Entity<Courses>(End =>
            {
                End.HasKey(c => c.CoursesID);
                End.Property(t => t.Price).HasColumnType("Price").IsRequired();
               End.Property(t => t.Description);
                End.HasMany(st => st.Students).WithMany(s => s.Courses).UsingEntity<StudCourses>(
                   j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.StudCourses)
                    .HasForeignKey(pt => pt.Id),
                j => j
                    .HasOne(pt => pt.Courses)
                    .WithMany(p => p.StudCourses)
                    .HasForeignKey(pt => pt.CoursesID),
                j =>
                {
                    j.Property(pt => pt.EnrollmentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.Property(pt => pt.Grades).HasDefaultValue(3);
                    j.HasKey(t => new { t.CoursesID, t.Id });
                    j.ToTable("StudCourses");
                });
            });
        }
    }
}