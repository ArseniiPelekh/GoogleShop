﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDBContent))]
    partial class AppDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Model.AvatarFileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("FileType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AvatarFiles");
                });

            modelBuilder.Entity("Data.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("Desc");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Data.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Img");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Data.Model.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("DateTimeDownload");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<long>("Size");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Data.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("OrderTime");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Data.Model.OrderDitail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("OrderId");

                    b.Property<long>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDitails");
                });

            modelBuilder.Entity("Data.Model.ShopCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<int>("Price");

                    b.Property<string>("ShopCartId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("ShopCourseItems");
                });

            modelBuilder.Entity("Data.Model.Course", b =>
                {
                    b.HasOne("Data.Model.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Data.Model.OrderDitail", b =>
                {
                    b.HasOne("Data.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.Order", "Order")
                        .WithMany("OrderDitails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ShopCartItem", b =>
                {
                    b.HasOne("Data.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
