﻿// <auto-generated />
using System;
using ContentManager.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContentManager.Infrastructure.Migrations
{
    [DbContext(typeof(ContentManagerDbContext))]
    partial class ContentManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContentManager.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("User", "User");
                });

            modelBuilder.Entity("ContentManager.Domain.Users.User", b =>
                {
                    b.OwnsOne("ContentManager.Domain.Users.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Salt")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("Password_Salt");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password_Value");

                            b1.HasKey("UserId");

                            b1.ToTable("User", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
