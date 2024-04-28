namespace IOT.Domain
{
	public class Detail
	{
		public string DetailId { get; set; } = string.Empty;
		public string DetailName { get; set; } = string.Empty;
		public DateTime StartTimePre { get; set; }
		public DateTime EndTimePre { get; set; }
		public string NoteLog { get; set; } = string.Empty;





		public DetailStatus DetailStatus { get; set; }
		public List<DetailPicture>? DetailPictures { get; set; }

		public List<DetailLog>? Logs { get; set; }	

		public Project? Project { get; set; }
		public string ProjectId { get; set; } = string.Empty;


	}
}
