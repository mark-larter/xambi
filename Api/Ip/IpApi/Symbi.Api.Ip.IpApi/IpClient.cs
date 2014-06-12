using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Symbi.Core.Http;
using Symbi.Core.Text;

namespace Symbi.Api.Ip.IpApi
{
	public class IpClient
	{
		#region Constructors
		public IpClient(IRestClient client)
		{
			this.Client = client;
		}

		#endregion Constructors

		#region Properties

		private const string UrlBase = "http://ip-api.com/json/";

		private readonly IRestClient Client;

		#endregion Properties

		#region Methods

		public async Task<string> Get()
		{
			return await this.Client.GetAsync<string>(UrlBase, Format.Json);
		}

		#endregion Methods
	}
}
