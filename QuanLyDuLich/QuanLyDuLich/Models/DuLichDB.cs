using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDuLich.Models
{
    public partial class DuLichDB : DbContext
    {
        public DuLichDB()
            : base("name=DuLichDB")
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Tour_image> Tour_image { get; set; }
        public virtual DbSet<TourManagement> TourManagement { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Tour>()
                .Property(e => e.price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Tour>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
