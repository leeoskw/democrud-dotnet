using System;
using System.Collections.Generic;
using democrud.Models;
using Microsoft.EntityFrameworkCore;

namespace democrud.DataContext;

public partial class DatabaseFirstCrudDemoContext : DbContext
{
    public DatabaseFirstCrudDemoContext()
    {
    }

    public DatabaseFirstCrudDemoContext(DbContextOptions<DatabaseFirstCrudDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbPedido> TbPedidos { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HUFFLEPUFF;Database=databaseFirstCrudDemo;Trusted_Connection=True; Encrypt=false; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_clien__3213E83F177F0FFB");

            entity.ToTable("tb_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<TbPedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__tb_pedid__BAF07B048D983C74");

            entity.ToTable("tb_pedido");

            entity.Property(e => e.PedidoId).HasColumnName("pedidoId");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.DataPedido)
                .HasColumnType("datetime")
                .HasColumnName("dataPedido");

            entity.HasOne(d => d.Cliente).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__tb_pedido__clien__3B75D760");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_produ__3213E83F9C2F7A7F");

            entity.ToTable("tb_produto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
