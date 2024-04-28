using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Domain;

public class ElectronicLog
{
	public int LogId { get; set; }
	public DateTime StartTagging { get; set; }
	public DateTime? EndTagging { get; set; }
	//
	public string MachineId { get; set; } 
	public Machine? Machine { get; set; }

}
