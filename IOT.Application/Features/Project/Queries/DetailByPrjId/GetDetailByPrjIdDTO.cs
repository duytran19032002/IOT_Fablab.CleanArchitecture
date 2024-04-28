using IOT.Domain;

namespace IOT.Application.Features.Project.Queries.DetailByPrjId;

public class GetDetailByPrjIdDTO
{
	public string DetailId { get; set; } = string.Empty;
	public string DetailName { get; set; } = string.Empty;
	public DateTime StartTimePre { get; set; }
	public DateTime EndTimePre { get; set; }
	public string NoteLog { get; set; } = string.Empty;

	public DetailStatus DetailStatus { get; set; }

	public string? DetailPicture { get; set; } = string.Empty;
}
