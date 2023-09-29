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
        public virtual DbSet<Like_action> Like_action { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<News_comment> News_comment { get; set; }
        public virtual DbSet<News_image> News_image { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Tour_image> Tour_image { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.id_comment)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.id_tour)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Like_action>()
                .Property(e => e.id_likeaction)
                .IsUnicode(false);

            modelBuilder.Entity<Like_action>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Like_action>()
                .Property(e => e.id_news)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.id_news)
                .IsUnicode(false);

            modelBuilder.Entity<News_comment>()
                .Property(e => e.id_newscomment)
                .IsUnicode(false);

            modelBuilder.Entity<News_comment>()
                .Property(e => e.id_news)
                .IsUnicode(false);

            modelBuilder.Entity<News_comment>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<News_image>()
                .Property(e => e.id_newsiamge)
                .IsUnicode(false);

            modelBuilder.Entity<News_image>()
                .Property(e => e.id_news)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.id_orders)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.id_orderdetail)
                .IsUnicode(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.id_orders)
                .IsUnicode(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.id_tour)
                .IsUnicode(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Tour>()
                .Property(e => e.id_tour)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Tour>()
                .Property(e => e.rating)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tour_image>()
                .Property(e => e.id_tourimage)
                .IsUnicode(false);

            modelBuilder.Entity<Tour_image>()
                .Property(e => e.id_tour)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_role)
                .IsUnicode(false);
        }
    }
}
