using System;
using System.Collections.Generic;

namespace Symbi.Core.Dto.Auth
{
	public class Auth0Identity
	{
		public string AccessToken { get; set; }
		public string Provider { get; set; }

		public string User_id { get; set; }
		public string Connection { get; set; }
		public bool IsSocial { get; set; }
	}

	public class Auth0Profile
	{
		public string Email { get; set; }
		public string Family_name { get; set; }
		public string Gender { get; set; }
		public string Given_name { get; set; }
		public List<Auth0Identity> Identities { get; set; }
		public string Locale { get; set; }
		public string Name { get; set; }
		public string Nickname { get; set; }
		public string Picture { get; set; }
		public string User_id { get; set; }
	}
}
		