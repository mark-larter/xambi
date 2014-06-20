using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;

namespace Xambi.Client.Android.Ui
{
	[BroadcastReceiver()]
	public class ConnectivityBroadcastReceiver : BroadcastReceiver
	{
		public event EventHandler ConnectionStatusChanged;

		public override void OnReceive(Context context, Intent intent)
		{
			if (ConnectionStatusChanged != null)
				ConnectionStatusChanged(this, EventArgs.Empty);
		}
	}
}
