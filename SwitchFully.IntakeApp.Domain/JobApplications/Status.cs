namespace SwitchFully.IntakeApp.Domain.JobApplications
{
	public class Status
	{
		public int Id { get; private set; }
		public string Description { get; private set; }

		private Status()
		{
		}

		public Status(string description)
		{
			Description = description;
		}

		public Status(int id, string description)
		{
			Id = id;
			Description = description;
		}
	}
}