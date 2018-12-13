using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.Uploads;
using SwitchFully.IntakeApp.Domain.Users;

namespace SwitchFully.IntakeApp.Data
{
	public partial class SwitchFullyIntakeAppContext : DbContext
	{
		private readonly ILoggerFactory _logger;

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Candidate> Candidates { get; set; }
		public virtual DbSet<Campaign> Campaigns { get; set; }
		public virtual DbSet<JobApplication> JobApplications { get; set; }
		public virtual DbSet<FileUpload> FileUploads { get; set; }

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
				.Ignore(prop => prop.Status);

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

			modelBuilder.Entity<FileUpload>()
				.ToTable("Files")
				.HasKey(fu => fu.Id);

			base.OnModelCreating(modelBuilder);
		}
	}
}
