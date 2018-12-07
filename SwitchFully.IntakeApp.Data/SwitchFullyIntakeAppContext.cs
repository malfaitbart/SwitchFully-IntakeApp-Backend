using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchFully.IntakeApp.Domain.Users;

namespace SwitchFully.IntakeApp.Data
{
	public class SwitchFullyIntakeAppContext : DbContext
	{
		private readonly ILoggerFactory _logger;

		public virtual DbSet<User> Users { get; set; }

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

			base.OnModelCreating(modelBuilder);

		}
	}
}
