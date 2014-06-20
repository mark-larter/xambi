using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xambi.Client.Core;
using Net = Android.Net;

namespace Xambi.Client.Android.Ui
{
	public class ConnectivityMonitor : Xambi.Client.Core.ConnectivityMonitor
	{
		#region Constructors

		public ConnectivityMonitor() : base() { }

		#endregion Constructors

		#region Methods

		public override void CheckConnectivity()
		{
			Net.ConnectivityManager cm = Application.Context.GetSystemService(Context.ConnectivityService) as Net.ConnectivityManager;
			Net.NetworkInfo info = cm.ActiveNetworkInfo;
			NetworkSsid = null;
			if (info == null)
			{
				State = ConnectivityType.Unknown;
			}
			else if (info.IsConnectedOrConnecting)
			{
				State = (info.Type == Net.ConnectivityType.Wifi) ? ConnectivityType.Wifi : ConnectivityType.Data;
				if (State == ConnectivityType.Wifi)
				{
					string extraInfo = info.ExtraInfo;
					if (!String.IsNullOrWhiteSpace(extraInfo))
					{
						var tokens = extraInfo.Split('"').Where((item, index) => index % 2 != 0);
						if (tokens != null)
						{
							if (tokens.ToList().Count > 0)
							{
								NetworkSsid = tokens.First();
							}
						}
					}
				}
			}
			else
			{
				State = ConnectivityType.None;
			}
		}

		#endregion Methods

		#region Properties

		#endregion Properties
	}
}