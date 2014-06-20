using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;

namespace Network
{
	[BroadcastReceiver()]
	public class ConnectivityBroadcastReceiver
	{
		public event EventHandler ConnectionStatusChanged;

		public override void OnReceive(Context context, Intent intent)
		{
			if (ConnectionStatusChanged != null)
				ConnectionStatusChanged(this, EventArgs.Empty);
		}
	}
}
