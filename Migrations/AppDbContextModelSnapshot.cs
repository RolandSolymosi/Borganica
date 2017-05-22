using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Borganica.Models;
using Borganica.Models;

namespace Borganica.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Borganica.Domain.GeoLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Borganica.Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("Creator");

                    b.Property<string>("Name");

                    b.Property<decimal>("Profit");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Borganica.Domain.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Creator");

                    b.Property<DateTimeOffset>("Deadline");

                    b.Property<int?>("OwnerTaskId");

                    b.Property<int>("ProjectId");

                    b.Property<DateTimeOffset>("Started");

                    b.HasKey("Id");

                    b.HasIndex("OwnerTaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Borganica.Domain.GeoLocation", b =>
                {
                    b.HasOne("Borganica.Domain.Project", "Project")
                        .WithOne("Location")
                        .HasForeignKey("Borganica.Domain.GeoLocation", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Borganica.Domain.ProjectTask", b =>
                {
                    b.HasOne("Borganica.Domain.ProjectTask", "OwnerTask")
                        .WithMany("SubTasks")
                        .HasForeignKey("OwnerTaskId");

                    b.HasOne("Borganica.Domain.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
