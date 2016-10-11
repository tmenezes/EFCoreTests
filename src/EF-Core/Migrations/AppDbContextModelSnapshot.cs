using System;
using EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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