using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xambi.Client.Core
{
    public interface IConnectivityMonitor
	{
		#region Methods

		void CheckConnectivity();

		#endregion Methods

		#region Properties

		ConnectivityType State { get; }

		string NetworkSsid { get; }

		#endregion Properties
	}
}
