using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xambi.Client.Core
{
	public abstract class ConnectivityMonitor : IConnectivityMonitor
	{
		#region Constructors

		public ConnectivityMonitor()
		{
			this.State = ConnectivityType.Unknown;
			CheckConnectivity();
		}

		#endregion Constructors

		#region Methods

		public abstract void CheckConnectivity();

		#endregion Methods

		#region Properties

		public ConnectivityType State { get; protected set; }

		#endregion Properties
	}
}