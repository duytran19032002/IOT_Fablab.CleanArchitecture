namespace IOT.Api.MQTTModels
{
	public class DetailUpdate
	{
		public string name { get; set; }
		public string value { get; set; }
		public string operatorid { get; set; } = string.Empty;
		public DateTime timestamp { get; set; }

	}
}
