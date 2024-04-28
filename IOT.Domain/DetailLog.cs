using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Domain;

public class DetailLog
{
	public int LogId { get; set; }
	public DateTime StartTagging { get; set; }
	public DateTime? EndTagging { get; set;}

	//
	public string DetailId { get; set; } = string.Empty;
	public Detail? Detail { get; set; }

	public string MachineId { get; set; }= string.Empty;
	public Machine? Machine { get; set; }
	public string WorkerId { get; set; } = string.Empty;
	public Worker? Worker { get; set; }
}
