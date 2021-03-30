using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class atttDBContext : DbContext
    {
        public atttDBContext()
            : base("name=atttDBContext")
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionDetail> ActionDetails { get; set; }
        public virtual DbSet<Question1> Question1 { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .Property(e => e.ActionName)
                .IsUnicode(false);

            modelBuilder.Entity<Action>()
                .HasMany(e => e.ActionDetails)
                .WithRequired(e => e.Action)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.ActionDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
