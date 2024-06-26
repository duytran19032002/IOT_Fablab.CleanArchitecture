﻿// <auto-generated />
using System;
using IOT.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IOT.Persistence.Migrations
{
    [DbContext(typeof(IOTDbContext))]
    partial class IOTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IOT.Domain.Area", b =>
                {
                    b.Property<string>("AreaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("IOT.Domain.Detail", b =>
                {
                    b.Property<string>("DetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetailStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTimePre")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteLog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTimePre")
                        .HasColumnType("datetime2");

                    b.HasKey("DetailId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Detail");
                });

            modelBuilder.Entity("IOT.Domain.DetailLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"), 1L, 1);

                    b.Property<string>("DetailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndTagging")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTagging")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LogId");

                    b.HasIndex("DetailId");

                    b.HasIndex("MachineId");

                    b.HasIndex("WorkerId");

                    b.ToTable("DetailLog");
                });

            modelBuilder.Entity("IOT.Domain.DetailPicture", b =>
                {
                    b.Property<Guid>("DetailPictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("DetailPictureId", "DetailId");

                    b.HasIndex("DetailId");

                    b.ToTable("DetailPicture");
                });

            modelBuilder.Entity("IOT.Domain.ElectronicLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"), 1L, 1);

                    b.Property<DateTime?>("EndTagging")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTagging")
                        .HasColumnType("datetime2");

                    b.HasKey("LogId");

                    b.HasIndex("MachineId");

                    b.ToTable("ElectronicLog");
                });

            modelBuilder.Entity("IOT.Domain.Machine", b =>
                {
                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AreaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MotorMaintenanceTime")
                        .HasColumnType("float");

                    b.Property<double>("MotorOperationTime")
                        .HasColumnType("float");

                    b.HasKey("MachineId");

                    b.HasIndex("AreaId");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("IOT.Domain.MachineError", b =>
                {
                    b.Property<int>("MachineErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachineErrorId"), 1L, 1);

                    b.Property<string>("ErrorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ErrorTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MachineErrorId");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineError");
                });

            modelBuilder.Entity("IOT.Domain.MachinePicture", b =>
                {
                    b.Property<Guid>("MachinePictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("MachinePictureId", "MachineName");

                    b.HasIndex("MachineName");

                    b.ToTable("MachinePicture");
                });

            modelBuilder.Entity("IOT.Domain.OEE", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("IdleTime")
                        .HasColumnType("real");

                    b.Property<float>("Oee")
                        .HasColumnType("real");

                    b.Property<float>("OperationTime")
                        .HasColumnType("real");

                    b.Property<float>("ShiftTime")
                        .HasColumnType("real");

                    b.HasKey("TimeStamp", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("OEE");
                });

            modelBuilder.Entity("IOT.Domain.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("IOT.Domain.Worker", b =>
                {
                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<string>("NoteArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("IOT.Domain.WorkerPicture", b =>
                {
                    b.Property<Guid>("WorkerPictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("WorkerPictureId", "WorkerId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerPicture");
                });

            modelBuilder.Entity("IOT.Domain.Detail", b =>
                {
                    b.HasOne("IOT.Domain.Project", "Project")
                        .WithMany("Details")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("IOT.Domain.DetailLog", b =>
                {
                    b.HasOne("IOT.Domain.Detail", "Detail")
                        .WithMany("Logs")
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IOT.Domain.Machine", "Machine")
                        .WithMany("Logs")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IOT.Domain.Worker", "Worker")
                        .WithMany("Logs")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");

                    b.Navigation("Machine");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("IOT.Domain.DetailPicture", b =>
                {
                    b.HasOne("IOT.Domain.Detail", "Detail")
                        .WithMany("DetailPictures")
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");
                });

            modelBuilder.Entity("IOT.Domain.ElectronicLog", b =>
                {
                    b.HasOne("IOT.Domain.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("IOT.Domain.Machine", b =>
                {
                    b.HasOne("IOT.Domain.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("IOT.Domain.MachineError", b =>
                {
                    b.HasOne("IOT.Domain.Machine", "Machine")
                        .WithMany("MachineErrors")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("IOT.Domain.MachinePicture", b =>
                {
                    b.HasOne("IOT.Domain.Machine", "Machine")
                        .WithMany("MachinePictures")
                        .HasForeignKey("MachineName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("IOT.Domain.OEE", b =>
                {
                    b.HasOne("IOT.Domain.Machine", "machine")
                        .WithMany("OEEs")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("machine");
                });

            modelBuilder.Entity("IOT.Domain.WorkerPicture", b =>
                {
                    b.HasOne("IOT.Domain.Worker", "Worker")
                        .WithMany("WorkerPictures")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("IOT.Domain.Detail", b =>
                {
                    b.Navigation("DetailPictures");

                    b.Navigation("Logs");
                });

            modelBuilder.Entity("IOT.Domain.Machine", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("MachineErrors");

                    b.Navigation("MachinePictures");

                    b.Navigation("OEEs");
                });

            modelBuilder.Entity("IOT.Domain.Project", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("IOT.Domain.Worker", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("WorkerPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
