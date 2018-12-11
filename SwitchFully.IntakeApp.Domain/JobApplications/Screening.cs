namespace SwitchFully.IntakeApp.Domain.JobApplications
{
	public class Screening
	{
		public int Id { get; private set; }
		public string Type { get; private set; }
		public string Comment { get; private set; }
		public bool IsActive { get; private set; }
		public int Order { get; private set; }

		private Screening()
		{

		}

		public Screening(string type, string comment, bool isActive, int order)
		{
			Type = type;
			Comment = comment;
			IsActive = isActive;
			Order = order;
		}

		public Screening(int id, string type, string comment, bool isActive, int order)
		{
			Id = id;
			Type = type;
			Comment = comment;
			IsActive = isActive;
			Order = order;
		}
	}
}