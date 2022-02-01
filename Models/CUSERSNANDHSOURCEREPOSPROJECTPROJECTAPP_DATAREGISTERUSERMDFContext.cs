using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EchoBotDB.Models
{
    public partial class REGISTERUSERContext : DbContext
    {
        public REGISTERUSERContext()
        {
        }

        public REGISTERUSERContext(DbContextOptions<REGISTERUSERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Queries> Queries { get; set; }
        public virtual DbSet<Userquery> Userquery { get; set; }
        //public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("RegisterUserConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Queries>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Queries__CA1EE04C6F79B769");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.Keyword1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Request)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userquery>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__tmp_ms_x__CA1EE04C23469A80");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.UserReq).HasMaxLength(100).IsUnicode(false);



            });

            //modelBuilder.Entity<Users>(entity =>
            //{
            //    entity.HasKey(e => e.UserId)
            //        .HasName("PK__Users__1788CC4C301F9BDA");

            //    entity.Property(e => e.Email).HasMaxLength(50);

            //    entity.Property(e => e.FirstName).HasMaxLength(50);

            //    entity.Property(e => e.LastName).HasMaxLength(50);

            //    entity.Property(e => e.Password).HasMaxLength(50);

            //    entity.Property(e => e.Role)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .HasDefaultValueSql("('user')");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        internal Task SayAsync(string text, string speak)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
