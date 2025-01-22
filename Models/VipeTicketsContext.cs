using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vipe_Tickets.Models;

public partial class VipeTicketsContext : DbContext
{
    public VipeTicketsContext()
    {
    }

    public VipeTicketsContext(DbContextOptions<VipeTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketLog> TicketLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IAMVILLALONA\\IAMVILLALONA;Database=VipeTickets; User Id=sa;Password=admin23; Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK_dbo.Categories");

            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Comments");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.IdPriority).HasName("PK_dbo.Priorities");

            entity.Property(e => e.IdPriority).HasColumnName("Id_Priority");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK_dbo.Status");

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).HasColumnName("Id_Status");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK_dbo.Tickets");

            entity.HasIndex(e => e.AssignedToNavigationIdUser, "IX_AssignedToNavigation_Id_User");

            entity.HasIndex(e => e.CategoryIdNavigationIdCategory, "IX_CategoryIdNavigation_Id_Category");

            entity.Property(e => e.IdTicket).HasColumnName("Id_Ticket");
            entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");
            entity.Property(e => e.AssignedToNavigationIdUser).HasColumnName("AssignedToNavigation_Id_User");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryIdNavigationIdCategory).HasColumnName("CategoryIdNavigation_Id_Category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AssignedToNavigationIdUserNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AssignedToNavigationIdUser)
                .HasConstraintName("FK_dbo.Tickets_dbo.Users_AssignedToNavigation_Id_User");

            entity.HasOne(d => d.CategoryIdNavigationIdCategoryNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CategoryIdNavigationIdCategory)
                .HasConstraintName("FK_dbo.Tickets_dbo.Categories_CategoryIdNavigation_Id_Category");
        });

        modelBuilder.Entity<TicketLog>(entity =>
        {
            entity.HasKey(e => e.IdTicketLog).HasName("PK_dbo.Ticket_Log");

            entity.ToTable("Ticket_Log");

            entity.Property(e => e.IdTicketLog).HasColumnName("Id_Ticket_Log");
            entity.Property(e => e.ChangedAt)
                .HasColumnType("datetime")
                .HasColumnName("changed_at");
            entity.Property(e => e.ChangedBy).HasColumnName("changed_by");
            entity.Property(e => e.Field).HasMaxLength(100);
            entity.Property(e => e.NewValue).HasColumnName("new_value");
            entity.Property(e => e.OldValue).HasColumnName("old_value");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_dbo.Users");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ModifyAt)
                .HasColumnType("datetime")
                .HasColumnName("modify_at");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
