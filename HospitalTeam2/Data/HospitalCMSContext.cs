﻿using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}