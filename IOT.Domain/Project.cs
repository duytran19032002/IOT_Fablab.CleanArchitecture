namespace IOT.Domain
{
	public class Project
	{
		public string ProjectId { get; set; } = string.Empty;
		public string ProjectName { get; set; } = string.Empty;



		public List<Detail> Details { get; set; }

	}
}
