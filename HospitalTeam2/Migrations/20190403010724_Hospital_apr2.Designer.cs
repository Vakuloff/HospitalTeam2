﻿// <auto-generated />
using HospitalTeam2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HospitalTeam2.Migrations
{
    [DbContext(typeof(HospitalCMSContext))]
    [Migration("20190403010724_Hospital_apr2")]
    partial class Hospital_apr2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalTeam2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HospitalTeam2.Models.BookingRequest", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("HospitalTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TypeDoctor")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("BookingID");

                    b.ToTable("BookingRequests");
                });

            modelBuilder.Entity("HospitalTeam2.Models.ContactForm", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminReply")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MessageStatus")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ContactId");

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Donor", b =>
                {
                    b.Property<int>("DonorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DonorMessage")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("DonorID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("HospitalTeam2.Models.FAQ", b =>
                {
                    b.Property<int>("FaqID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FaqAns")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FaqQues")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("FaqID");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("HospitalTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("HospitalID");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("JobID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("HospitalTeam2.Models.JobApplication", b =>
                {
                    b.Property<int>("JobApplicationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("JobApplicationID");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("HospitalTeam2.Models.JobPosting", b =>
                {
                    b.Property<int>("JobPostingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HospitalTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("JobPostingDesc")
                        .HasMaxLength(2147483647);

                    b.Property<string>("JobPostingReq")
                        .HasMaxLength(2147483647);

                    b.Property<string>("JobPostingTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("JobPostingType")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("JobPostingID");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Parking", b =>
                {
                    b.Property<int>("ParkingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ParkingContact")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ParkingPurpose")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("VisitoCarNo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("VisitorName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ParkingID");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("EndShift")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("StartShift")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StaffFirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("StaffLastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("HealthCondition")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Middle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone_em")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("VolunteerID");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HospitalTeam2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HospitalTeam2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalTeam2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HospitalTeam2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
