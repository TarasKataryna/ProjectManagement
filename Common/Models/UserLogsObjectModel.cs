using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class UserLogsObjectModel
	{
		public UserModel User { get; set; }

		public List<LogModel> Logs { get; set; }
	}
}
