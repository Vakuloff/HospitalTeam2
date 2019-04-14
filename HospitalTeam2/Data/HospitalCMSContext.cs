using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

//We are also using Entity Framework Core, so make sure you have these dependencies.
//https://learnentityframeworkcore.com
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

using HospitalTeam2.Models;
using HospitalNew.Models;

namespace HospitalTeam2.Data
{
    public class HospitalCMSContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalCMSContext(DbContextOptions<HospitalCMSContext> options)
        : base(options)
        {

        }
        public DbSet<BookingRequest> BookingRequests { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        // public DbSet<HospitalxDepartment> HospitalxDepartments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<NavMenu> NavMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //following the diagram on the notebook (picture included in assets folder)

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPosting)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(ja => ja.JobPostingID);

            //QUESTION FOR GROUP: IS SOMEONE DOING DEPARTMENTS? ans:No

            //eash job position references one hospital, one hospital has many job position

            modelBuilder.Entity<JobPosting>()
                .HasOne(jp => jp.Hospital)
                .WithMany(h => h.JobPostings)
                .HasForeignKey(jp => jp.HospitalID);

            //each volunteer references one hospital, one hospital has many volunteer

            modelBuilder.Entity<Volunteer>() //WE ARE TALKING ABOUT VOLUNTEERS
                .HasOne(v => v.Hospital) //WE ARE TALKING ABOUT HOSPITALS
                .WithMany(h => h.Volunteers)
                .HasForeignKey(v => v.HospitalID);

            //each job position has one department, each department has many job
            modelBuilder.Entity<JobPosting>()
                .HasOne(jp => jp.Department)
                .WithMany(d => d.JobPostings)
                .HasForeignKey(jp => jp.DepartmentID);

            //each bookingrequest has one hospital, one hospital has many bookingapp

            modelBuilder.Entity<BookingRequest>()
                .HasOne(br => br.Hospital)
                .WithMany(h => h.BookingRequests)
                .HasForeignKey(br => br.HospitalID);

            //each bookingrequest has one doctor, each doctor has many bookapp

            modelBuilder.Entity<BookingRequest>()
                .HasOne(s => s.Staff)
                .WithMany(b => b.BookingRequests)
                .HasForeignKey(s => s.StaffID);

            //each department has one hospital, each hospital has many departments
            modelBuilder.Entity<Department>()
                 .HasOne(d=> d.Hospital)
                 .WithMany(h => h.Departments)
                 .HasForeignKey(d => d.HospitalID);
            //each parking has one hospital, each hospital many parkings
            modelBuilder.Entity<Parking>()
                 .HasOne(d => d.hospital)
                 .WithMany(p => p.parking)
                 .HasForeignKey(d => d.HospitalID);


            //each staff has one department, each department has many staffs
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Departments)
                .WithMany(d => d.Staff)
                .HasForeignKey(s => s.DepartmentID);

            modelBuilder.Entity<Feedback>();


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookingRequest>().ToTable("BookingRequests");
            modelBuilder.Entity<ContactForm>().ToTable("ContactForms");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Donor>().ToTable("Donors");
            modelBuilder.Entity<FAQ>().ToTable("FAQs");
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            // modelBuilder.Entity<HospitalxDepartment>().ToTable("HospitalsxDepartments");
            modelBuilder.Entity<Job>().ToTable("Jobs");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplications");
            modelBuilder.Entity<JobPosting>().ToTable("JobPostings");
            modelBuilder.Entity<Parking>().ToTable("Parkings");
            modelBuilder.Entity<Schedule>().ToTable("Schedules");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteers");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<NavMenu>().ToTable("NavMenus");
        }
    }
}
