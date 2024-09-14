﻿// <auto-generated />
using System;
using APIMercancías_JyC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIMercancías_JyC.Migrations
{
    [DbContext(typeof(MercanciasJyCContext))]
    [Migration("20240913025049_AjusteDecimalTotal")]
    partial class AjusteDecimalTotal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIMercancías_JyC.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Entrega", b =>
                {
                    b.Property<int>("EntregaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntregaId"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("EntregaId");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.PedidoProducto", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("PedidoProductos");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Entrega", b =>
                {
                    b.HasOne("APIMercancías_JyC.Models.Pedido", "Pedido")
                        .WithOne("Entrega")
                        .HasForeignKey("APIMercancías_JyC.Models.Entrega", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Pedido", b =>
                {
                    b.HasOne("APIMercancías_JyC.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.PedidoProducto", b =>
                {
                    b.HasOne("APIMercancías_JyC.Models.Pedido", "Pedido")
                        .WithMany("PedidoProductos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMercancías_JyC.Models.Producto", "Producto")
                        .WithMany("PedidosProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Pedido", b =>
                {
                    b.Navigation("Entrega")
                        .IsRequired();

                    b.Navigation("PedidoProductos");
                });

            modelBuilder.Entity("APIMercancías_JyC.Models.Producto", b =>
                {
                    b.Navigation("PedidosProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
