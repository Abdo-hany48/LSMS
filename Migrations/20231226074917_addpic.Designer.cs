﻿// <auto-generated />
using LSMS.data_access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LSMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231226074917_addpic")]
    partial class addpic
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LSMS.Models.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("LSMS.Models.Course", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("departmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("hours")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("departmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LSMS.Models.Department", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LSMS.Models.Enrollment", b =>
                {
                    b.Property<string>("studentSSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lectureId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("studentSSN", "lectureId");

                    b.HasIndex("lectureId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("LSMS.Models.Hall", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("LSMS.Models.Intersection", b =>
                {
                    b.Property<string>("departmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lectureId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("departmentId", "lectureId");

                    b.ToTable("Intersections");
                });

            modelBuilder.Entity("LSMS.Models.Lecture", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("courseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("hallId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("lectureNum")
                        .HasColumnType("int");

                    b.Property<string>("professorSSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("hallId");

                    b.HasIndex("professorSSN");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("LSMS.Models.Professor", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("departmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.HasIndex("departmentId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("LSMS.Models.Student", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("academicEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.HasIndex("departmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LSMS.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LSMS.Models.Course", b =>
                {
                    b.HasOne("LSMS.Models.Department", "department")
                        .WithMany("courses")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("LSMS.Models.Enrollment", b =>
                {
                    b.HasOne("LSMS.Models.Lecture", "lecture")
                        .WithMany("enrollments")
                        .HasForeignKey("lectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSMS.Models.Student", "student")
                        .WithMany("enrollments")
                        .HasForeignKey("studentSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lecture");

                    b.Navigation("student");
                });

            modelBuilder.Entity("LSMS.Models.Lecture", b =>
                {
                    b.HasOne("LSMS.Models.Course", "course")
                        .WithMany("lectures")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSMS.Models.Hall", "hall")
                        .WithMany("lectures")
                        .HasForeignKey("hallId");

                    b.HasOne("LSMS.Models.Professor", "professor")
                        .WithMany("lectures")
                        .HasForeignKey("professorSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("hall");

                    b.Navigation("professor");
                });

            modelBuilder.Entity("LSMS.Models.Professor", b =>
                {
                    b.HasOne("LSMS.Models.Department", "department")
                        .WithMany("professores")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("LSMS.Models.Student", b =>
                {
                    b.HasOne("LSMS.Models.Department", "department")
                        .WithMany("students")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("LSMS.Models.Course", b =>
                {
                    b.Navigation("lectures");
                });

            modelBuilder.Entity("LSMS.Models.Department", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("professores");

                    b.Navigation("students");
                });

            modelBuilder.Entity("LSMS.Models.Hall", b =>
                {
                    b.Navigation("lectures");
                });

            modelBuilder.Entity("LSMS.Models.Lecture", b =>
                {
                    b.Navigation("enrollments");
                });

            modelBuilder.Entity("LSMS.Models.Professor", b =>
                {
                    b.Navigation("lectures");
                });

            modelBuilder.Entity("LSMS.Models.Student", b =>
                {
                    b.Navigation("enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
