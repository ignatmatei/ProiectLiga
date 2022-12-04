using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMeme;

public partial class MemeDbContext : DbContext
{
    public MemeDbContext()
    {
    }

    public MemeDbContext(DbContextOptions<MemeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Meme> Memes { get; set; }

    public virtual DbSet<Useri> Useris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MemeDB;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meme>(entity =>
        {
            entity.ToTable("Meme");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Memes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Meme_Useri");
        });

        modelBuilder.Entity<Useri>(entity =>
        {
            entity.ToTable("Useri");

            entity.HasIndex(e => e.Email, "IX_Useri_Email").IsUnique();

            entity.HasIndex(e => e.Username, "IX_Useri_Username").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(8);
            entity.Property(e => e.Username).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
