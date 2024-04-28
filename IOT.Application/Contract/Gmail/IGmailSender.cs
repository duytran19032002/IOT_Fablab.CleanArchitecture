﻿using IOT.Application.Models.Email;
using IOT.Application.Models.Gmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Contract.Gmail
{
	public interface IGmailSender
	{
		Task<bool> SendGmail(GmailMessage gmail);
	}
}
