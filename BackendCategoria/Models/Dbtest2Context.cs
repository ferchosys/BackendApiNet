using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendCategoria.Models;

public partial class Dbtest2Context : DbContext
{
    public Dbtest2Context()
    {
    }

    public Dbtest2Context(DbContextOptions<Dbtest2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TmCategorium> TmCategoria { get; set; }

    public virtual DbSet<TmTipo> TmTipos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TmCategorium>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.ToTable("TM_CATEGORIA");

            entity.Property(e => e.CatId).HasColumnName("CAT_ID");
            entity.Property(e => e.CatFec)
                .HasColumnType("date")
                .HasColumnName("CAT_FEC");
            entity.Property(e => e.CatMon)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CAT_MON");
            entity.Property(e => e.CatObs)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CAT_OBS");
            entity.Property(e => e.CatTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAT_TIPO");
        });

        modelBuilder.Entity<TmTipo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TM_TIPO");

            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.NomTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_TIPO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
