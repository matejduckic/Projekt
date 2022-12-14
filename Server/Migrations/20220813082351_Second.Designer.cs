// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Server.Data;

#nullable disable

namespace Projekt.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220813082351_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projekt.Shared.Vozilo", b =>
                {
                    b.Property<string>("VoznaLinijaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Km")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoznaLinijaId");

                    b.ToTable("Vozila");

                    b.HasData(
                        new
                        {
                            VoznaLinijaId = "1",
                            Km = "1234500",
                            Naziv = "autobus1",
                            Tip = "autobus"
                        },
                        new
                        {
                            VoznaLinijaId = "2",
                            Km = "3459800",
                            Naziv = "tramvaj1",
                            Tip = "tramvaj"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
