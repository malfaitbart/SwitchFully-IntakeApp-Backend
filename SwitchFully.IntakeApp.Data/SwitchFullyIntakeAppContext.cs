using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.FileManagement;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
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
		public virtual DbSet<File> FileUploads { get; set; }
		public virtual DbSet<Screening> Screenings { get; set; }

		public SwitchFullyIntakeAppContext(DbContextOptions<SwitchFullyIntakeAppContext> options) : base(options)
		{
		}

		public SwitchFullyIntakeAppContext(DbContextOptions<SwitchFullyIntakeAppContext> options, ILoggerFactory logger) : base(options)
		{
			_logger = logger;
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

			//modelBuilder.Entity<User>(u =>
			//{
			//	u.HasData(new
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "test",
			//		LastName = "user",
			//		RoleId = 1
			//	});
			//	var testadddress = new MailAddress("test@user.be");
			//	u.OwnsOne(m => m.Email).HasData(new
			//	{
			//		UserId = Guid.NewGuid(),
			//		Email = testadddress
			//	});
			//	u.OwnsOne(us => us.SecurePassword).HasData(new
			//	{
			//		UserId = Guid.NewGuid(),
			//		PassWord = "r5iPEDa9yVsW9s1Jr7j3fEpepSjT+oLu+4gUG6o7sMI=",
			//		SecPass = "nhSRFAcAR6lgnY40PZi4iw==",
			//	});
			//});

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
				.HasData(
					Campaign.CreateNewCampaign("asp.net", "CM", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30)),
					Campaign.CreateNewCampaign("java", "Cegeka", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30)),
					Campaign.CreateNewCampaign("asp.net", "OZ", new DateTime(2019, 01, 01), new DateTime(2019, 05, 30))
				);

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

			modelBuilder.Entity<JobApplication>()
				.HasOne(jp => jp.CV)
				.WithMany()
				.HasForeignKey(jp => jp.CvId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<JobApplication>()
				.HasOne(jp => jp.Motivation)
				.WithMany()
				.HasForeignKey(jp => jp.MotivationId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<File>()
				.ToTable("Files")
				.HasKey(fu => fu.Id);

			modelBuilder.Entity<Status>()
				 .HasData(
					new Status(1, "Inactive"),
					new Status(2, "active"),
					new Status(3, "Rejected")
				);

			modelBuilder.Entity<Screening>()
				.ToTable("Screening")
				.HasKey(screeningKey => new
				{
					screeningKey.JobApplicationId,
					screeningKey.Name
				});

			modelBuilder.Entity<Screening>()
				.HasDiscriminator<string>("screeningType");

			modelBuilder.Entity<CV_Screening>();
			modelBuilder.Entity<FinalDecision_Screening>();
			modelBuilder.Entity<FirstInterview_Screening>();
			modelBuilder.Entity<GroupInterview_Screening>();
			modelBuilder.Entity<Phone_Screening>();
			modelBuilder.Entity<TestResults_Screening>();

			modelBuilder.Entity<Screening>()
			   .HasOne(scr => scr.JobApplication)
			   .WithMany(jp => jp.Screening)
			   .HasForeignKey(j => j.JobApplicationId);

			base.OnModelCreating(modelBuilder);
		}
	}
}