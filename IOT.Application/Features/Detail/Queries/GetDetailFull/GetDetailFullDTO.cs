using IOT.Domain;

namespace IOT.Application.Features.Detail.Queries.GetDetailFull;

public class GetDetailFullDTO
{
	public string DetailId { get; set; } = string.Empty;
	public string DetailName { get; set; } = string.Empty;
	public DateTime StartTimePre { get; set; }
	public DateTime EndTimePre { get; set; }
	public string NoteLog { get; set; } = string.Empty;
	public string ProjectId { get; set; } = string.Empty;
	public string ProjectName { get; set; } = string.Empty;
	public DetailStatus DetailStatus { get; set; }
	public string? DetailPicture { get; set; } = string.Empty;
	public List<LogForDetailFull> LogForDetailFull { get; set; } 
}
public class LogForDetailFull
{
	public DateTime StartTagging { get; set; }
	public DateTime? EndTagging { get; set; }

	//
	public string MachineId { get; set; } = string.Empty;
	public string WorkerId { get; set; } = string.Empty;

}
