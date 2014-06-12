using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Symbi.Core.Text;

namespace Symbi.Core.Http
{
	public interface IRestClient
	{
		TimeSpan Timeout { get; set; }

		Uri UrlBase { get; set; }

		void AddHeader(string key, string value);

		void RemoveHeader(string key);

		Task<T> PostAsync<T>(string address, object dto, Format format);

		Task<T> GetAsync<T>(string address, Format format);

		Task<T> GetAsync<T>(string address, Dictionary<string, string> values, Format format);
	}
}
