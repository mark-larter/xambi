﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.DTO
{
	public class IspDto
	{
		public string status { get; set; }
		public string country { get; set; }
		public string countryCode { get; set; }
		public string region { get; set; }
		public string regionName { get; set; }
		public string city { get; set; }
		public string zip { get; set; }
		public string lat { get; set; }
		public string lon { get; set; }
		public string timezone { get; set; }
		public string isp { get; set; }
		public string org { get; set; }
		public string @as { get; set; }
		public string query { get; set; }
	}
}
