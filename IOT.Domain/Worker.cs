namespace IOT.Domain
{
	public class Worker
	{
		public string WorkerId { get; set; } = string.Empty;
		public string WorkerName { get; set; } = string.Empty;
		public string NoteArea {  get; set; }= string.Empty;
		public string RFID { get; set; } = string.Empty;
		public bool IsWorking { get; set; }= true;

		public List<WorkerPicture>? WorkerPictures { get; set; }
		public List<DetailLog>? Logs { get; set; }

		
	}
}
