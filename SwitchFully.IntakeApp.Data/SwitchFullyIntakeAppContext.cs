using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Users;

namespace SwitchFully.IntakeApp.Data
{
	public class SwitchFullyIntakeAppContext : DbContext
	{
		private readonly ILoggerFactory _logger;

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Campaign> Campaigns { get; set; }

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
				.HasOne(u => u.Role)
				.WithMany()
				.HasForeignKey(u => u.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Campaign>()
                .ToTable("Campaign")
                .HasKey(key => key.CampaignId);

            modelBuilder.Entity<Campaign>()
                .Property(prop => prop.CampaignId).HasColumnName("CampaignId");
            modelBuilder.Entity<Campaign>()
                .Property(prop => prop.Name).HasColumnName("CampaignName");
            modelBuilder.Entity<Campaign>()
                .Property(prop => prop.StartDate).HasColumnName("CampaignStartDate");
            modelBuilder.Entity<Campaign>()
                .Property(prop => prop.EndDate).HasColumnName("CampaignEndDate");
            modelBuilder.Entity<Campaign>()
                .Property(prop => prop.Client).HasColumnName("ClientName");
            modelBuilder.Entity<Campaign>()
                .Ignore(prop => prop.Status);

			base.OnModelCreating(modelBuilder);

		}
	}
}
