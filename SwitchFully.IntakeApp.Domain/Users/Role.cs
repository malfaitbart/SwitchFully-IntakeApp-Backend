namespace SwitchFully.IntakeApp.Domain.Users
{
	public class Role
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public Role(string description)
		{
			Description = description;
		}
	}
}
