using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TodoApp.Models
{
    public partial class TodoAppContext : DbContext
    {
        public TodoAppContext()
        {
        }

        public TodoAppContext(DbContextOptions<TodoAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<MitarbeiterTodo> MitarbeiterTodo { get; set; }
        public virtual DbSet<Projekte> Projekte { get; set; }
        public virtual DbSet<Todos> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=TodoApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>(entity =>
            {
                entity.Property(e => e.MitarbeiterId).HasColumnName("Mitarbeiter_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MitarbeiterTodo>(entity =>
            {
                entity.ToTable("Mitarbeiter_Todo");

                entity.Property(e => e.MitarbeiterTodoId).HasColumnName("Mitarbeiter_Todo_ID");

                entity.Property(e => e.MitarbeiterId).HasColumnName("Mitarbeiter_ID");

                entity.Property(e => e.TodoId).HasColumnName("Todo_ID");

                entity.HasOne(d => d.Mitarbeiter)
                    .WithMany(p => p.MitarbeiterTodo)
                    .HasForeignKey(d => d.MitarbeiterId)
                    .HasConstraintName("FK__Mitarbeit__Mitar__3F466844");

                entity.HasOne(d => d.Todo)
                    .WithMany(p => p.MitarbeiterTodo)
                    .HasForeignKey(d => d.TodoId)
                    .HasConstraintName("FK__Mitarbeit__Todo___403A8C7D");
            });

            modelBuilder.Entity<Projekte>(entity =>
            {
                entity.HasKey(e => e.ProjektId)
                    .HasName("PK__Projekte__2A616A8C03EE7200");

                entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MitarbeiterId).HasColumnName("Mitarbeiter_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mitarbeiter)
                    .WithMany(p => p.Projekte)
                    .HasForeignKey(d => d.MitarbeiterId)
                    .HasConstraintName("FK__Projekte__Mitarb__398D8EEE");
            });

            modelBuilder.Entity<Todos>(entity =>
            {
                entity.HasKey(e => e.TodoId)
                    .HasName("PK__Todos__9F16E3C586F26595");

                entity.Property(e => e.TodoId).HasColumnName("Todo_ID");

                entity.Property(e => e.Beschreibung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProjektId).HasColumnName("Projekt_ID");

                entity.HasOne(d => d.Projekt)
                    .WithMany(p => p.Todos)
                    .HasForeignKey(d => d.ProjektId)
                    .HasConstraintName("FK__Todos__Projekt_I__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
