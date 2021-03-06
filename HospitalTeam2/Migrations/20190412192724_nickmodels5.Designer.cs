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
    [Migration("20190412192724_nickmodels5")]
    partial class nickmodels5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalTeam2.Models.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlertMessage")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AlertTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("HospitalID");

                    b.HasKey("AlertId");

                    b.HasIndex("HospitalID");

                    b.ToTable("Alert");
                });

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

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("HospitalID");

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

                    b.Property<string>("StaffFirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("StaffID");

                    b.Property<string>("StaffLastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TypeDoctor")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("BookingID");

                    b.HasIndex("HospitalID");

                    b.HasIndex("StaffID");

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

                    b.Property<int>("HospitalID");

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

                    b.HasIndex("HospitalID");

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("HospitalID");

                    b.HasKey("DepartmentID");

                    b.HasIndex("HospitalID");

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

            modelBuilder.Entity("HospitalTeam2.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbacksId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FeedbacksEmail")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FeedbacksMessage")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FeedbacksSubject")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("FeedbacksId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasMaxLength(2147483647);

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

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("JobPostingID");

                    b.Property<string>("JobPostingTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("JobApplicationID");

                    b.HasIndex("JobPostingID");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("HospitalTeam2.Models.JobPosting", b =>
                {
                    b.Property<int>("JobPostingID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentID");

                    b.Property<int>("HospitalID");

                    b.Property<string>("JobPostingDesc");

                    b.Property<string>("JobPostingReq");

                    b.Property<string>("JobPostingTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("JobPostingType")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("JobPostingID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("HospitalID");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("HospitalTeam2.Models.NavMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsShown");

                    b.Property<int?>("NavMenuItemId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("NavMenuItemId");

                    b.ToTable("NavMenus");
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

                    b.Property<int>("StaffId");

                    b.Property<DateTime>("StartShift")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ScheduleId");

                    b.HasIndex("StaffId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentID");

                    b.Property<int?>("HospitalID");

                    b.Property<string>("StaffFirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("StaffLastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TypeDoctor")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("StaffId");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("HospitalID");

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

                    b.Property<int>("HospitalID");

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

                    b.HasIndex("HospitalID");

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

            modelBuilder.Entity("HospitalTeam2.Models.Alert", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Hospital")
                        .WithMany("Alerts")
                        .HasForeignKey("HospitalID");
                });

            modelBuilder.Entity("HospitalTeam2.Models.BookingRequest", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Hospital", "Hospital")
                        .WithMany("BookingRequests")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalTeam2.Models.Staff", "Staff")
                        .WithMany("BookingRequests")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.ContactForm", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.Department", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Hospital", "Hospital")
                        .WithMany("Departments")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.JobApplication", b =>
                {
                    b.HasOne("HospitalTeam2.Models.JobPosting", "JobPosting")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostingID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.JobPosting", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Department", "Department")
                        .WithMany("JobPostings")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalTeam2.Models.Hospital", "Hospital")
                        .WithMany("JobPostings")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.NavMenu", b =>
                {
                    b.HasOne("HospitalTeam2.Models.NavMenu", "NavMenuItem")
                        .WithMany("ChildMenuItems")
                        .HasForeignKey("NavMenuItemId");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Schedule", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Staff", "Staff")
                        .WithMany("schedules")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalTeam2.Models.Staff", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Department", "Departments")
                        .WithMany("Staff")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalTeam2.Models.Hospital")
                        .WithMany("Staffs")
                        .HasForeignKey("HospitalID");
                });

            modelBuilder.Entity("HospitalTeam2.Models.Volunteer", b =>
                {
                    b.HasOne("HospitalTeam2.Models.Hospital", "Hospital")
                        .WithMany("Volunteers")
                        .HasForeignKey("HospitalID")
                        .OnDelete(DeleteBehavior.Cascade);
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
