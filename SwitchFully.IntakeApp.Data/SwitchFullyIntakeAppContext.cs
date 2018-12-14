using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.Net.Mail;

namespace SwitchFully.IntakeApp.Data
{
    public partial class SwitchFullyIntakeAppContext : DbContext
    {
        private readonly ILoggerFactory _logger;

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }

        public SwitchFullyIntakeAppContext(DbContextOptions<SwitchFullyIntakeAppContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var options = new DbContextOptionsBuilder<SwitchFullyIntakeAppContext>()
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(_logger)
                .Options;



            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Email,
                    email => { email.Property(prop => prop.Address).HasColumnName("Email"); }
                );

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.SecurePassword,
                    securePass =>
                    {
                        securePass.Property(prop => prop.PasswordHash).HasColumnName("PassWord");
                        securePass.Property(prop => prop.Salt).HasColumnName("SecPass");
                    });
                    

            modelBuilder.Entity<Candidate>()
                .ToTable("Candidates")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Candidate>()
                .OwnsOne(c => c.Email,
                    email => { email.Property(prop => prop.Address).HasColumnName("Email"); }
                );
               


            modelBuilder.Entity<Campaign>()
                .ToTable("Campaign")
                .HasKey(key => key.CampaignId);

            modelBuilder.Entity<Campaign>()
                .Ignore(prop => prop.Status)
                .HasData(Campaign.CreateNewCampaign("asp.net", "CM", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30)),
                Campaign.CreateNewCampaign("java", "Cegeka", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30)),
                Campaign.CreateNewCampaign("asp.net", "OZ", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30)));



            modelBuilder.Entity<JobApplication>()
                .ToTable("JobApplication")
                .HasKey(jp => jp.Id);

            modelBuilder.Entity<JobApplication>()
                .HasOne(jp => jp.Candidate)
                .WithMany()
                .HasForeignKey(jp => jp.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne(jp => jp.Campaign)
                .WithMany()
                .HasForeignKey(jp => jp.CampaignId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()

                .HasOne(jp => jp.Status)
                .WithMany()
                .HasForeignKey(jp => jp.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                 .HasData(new Status(1, "Inactive"), new Status(2, "active"), new Status(3, "Rejected"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
