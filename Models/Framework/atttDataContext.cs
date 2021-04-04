using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class atttDataContext : DbContext
    {
        public atttDataContext()
            : base("name=atttDataContext")
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionDetail> ActionDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Question1> Question1 { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponClass> WeaponClasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .Property(e => e.ActionName)
                .IsUnicode(false);

            modelBuilder.Entity<Action>()
                .HasMany(e => e.ActionDetails)
                .WithRequired(e => e.Action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Question1>()
                .Property(e => e.Question11)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Answer1)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ActionDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<Weapon>()
                .Property(e => e.NameWea)
                .IsUnicode(false);

            modelBuilder.Entity<Weapon>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Weapon>()
                .Property(e => e.Ammunition)
                .IsUnicode(false);

            modelBuilder.Entity<Weapon>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Weapon)
                .HasForeignKey(e => e.MaSung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeaponClass>()
                .HasMany(e => e.Weapons)
                .WithRequired(e => e.WeaponClass)
                .WillCascadeOnDelete(false);
        }
    }
}
