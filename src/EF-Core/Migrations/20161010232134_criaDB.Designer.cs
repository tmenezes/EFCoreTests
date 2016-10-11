using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.Repository;

namespace EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20161010232134_criaDB")]
    partial class criaDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressType");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EFCore.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EFCore.Domain.Address", b =>
                {
                    b.HasOne("EFCore.Domain.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");
                });
        }
    }
}
