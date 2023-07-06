using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Consecionaria2.Model;

public partial class ConsecionariaContext : DbContext
{
    public ConsecionariaContext()
    {
    }

    public ConsecionariaContext(DbContextOptions<ConsecionariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogoAuto> CatalogoAutos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6TNSEQV\\SQLEXPRESS01;Initial Catalog=Consecionaria;Integrated Security=False;User ID=sa;Password=belarmino2491278322;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogoAuto>(entity =>
        {
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutoCNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdAutoC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__IdAutoC__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
