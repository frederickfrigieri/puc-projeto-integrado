﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CurrentContext))]
    partial class CurrentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Armazem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Chave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Armazens","WMS");
                });

            modelBuilder.Entity("Domain.Entities.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArmazemId")
                        .HasColumnType("int");

                    b.Property<Guid>("Chave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChaveParceiro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemPedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PosicaoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmazemId");

                    b.HasIndex("ItemPedidoId");

                    b.HasIndex("PosicaoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques","WMS");
                });

            modelBuilder.Entity("Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArmazemId")
                        .HasColumnType("int");

                    b.Property<Guid>("Chave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChaveParceiro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChavePedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmazemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Domain.Entities.Posicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArmazemId")
                        .HasColumnType("int");

                    b.Property<Guid>("Chave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Letra")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmazemId");

                    b.ToTable("Posicoes","WMS");
                });

            modelBuilder.Entity("Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Chave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChaveParceiro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(256);

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("varchar(13)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Produtos","WMS");
                });

            modelBuilder.Entity("Infrastructure.Processing.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("Varchar(Max)")
                        .HasMaxLength(8000);

                    b.Property<bool>("Executando")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("Varchar(250)")
                        .HasMaxLength(8000);

                    b.HasKey("Id");

                    b.ToTable("InternalCommands","Jobs");
                });

            modelBuilder.Entity("Infrastructure.Processing.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(8000)")
                        .HasMaxLength(8000)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages","Jobs");
                });

            modelBuilder.Entity("Domain.Entities.Estoque", b =>
                {
                    b.HasOne("Domain.Entities.Armazem", "Armazem")
                        .WithMany("Estoques")
                        .HasForeignKey("ArmazemId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.ItemPedido", "ItemPedido")
                        .WithMany()
                        .HasForeignKey("ItemPedidoId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Posicao", "Posicao")
                        .WithMany()
                        .HasForeignKey("PosicaoId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("Domain.Entities.Armazem", "Armazem")
                        .WithMany("Itens")
                        .HasForeignKey("ArmazemId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Produto", "Produto")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Posicao", b =>
                {
                    b.HasOne("Domain.Entities.Armazem", null)
                        .WithMany("Posicoes")
                        .HasForeignKey("ArmazemId");
                });
#pragma warning restore 612, 618
        }
    }
}
