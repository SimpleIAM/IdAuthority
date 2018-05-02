﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SimpleIAM.OpenIdAuthority.Entities;
using System;

namespace SimpleIAM.OpenIdAuthority.Migrations.Migrations
{
    [DbContext(typeof(OpenIdAuthorityDbContext))]
    partial class OpenIdAuthorityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleIAM.OpenIdAuthority.Entities.OneTimeCode", b =>
                {
                    b.Property<string>("SentTo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(254);

                    b.Property<DateTime>("ExpiresUTC");

                    b.Property<int>("FailedAttemptCount");

                    b.Property<string>("LongCodeHash");

                    b.Property<string>("RedirectUrl")
                        .HasMaxLength(2048);

                    b.Property<string>("ShortCodeHash");

                    b.HasKey("SentTo");

                    b.ToTable("OneTimeCodes");
                });

            modelBuilder.Entity("SimpleIAM.OpenIdAuthority.Entities.PasswordHash", b =>
                {
                    b.Property<string>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<int>("FailedAttemptCount");

                    b.Property<string>("Hash")
                        .IsRequired();

                    b.Property<DateTime>("LastChangedUTC");

                    b.Property<DateTime?>("TempLockUntilUTC");

                    b.HasKey("SubjectId");

                    b.ToTable("PasswordHashes");
                });

            modelBuilder.Entity("SimpleIAM.OpenIdAuthority.Entities.Subject", b =>
                {
                    b.Property<string>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.HasKey("SubjectId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}