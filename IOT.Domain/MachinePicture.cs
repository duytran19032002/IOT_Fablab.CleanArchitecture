using System.ComponentModel.DataAnnotations.Schema;

namespace IOT.Domain;

public class MachinePicture
{

	[Column(TypeName = "VARBINARY(MAX)")]
	public byte[] FileData { get; set; }
	public Guid MachinePictureId { get; set; }

	public string MachineName { get; set; }
	public Machine? Machine { get; set; }
}	
