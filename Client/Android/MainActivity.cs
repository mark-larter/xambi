using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Auth0.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Symbi.Core.Dto.Auth;
using Symbi.Core.Dto.Network;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xambi.Client.Core;
using Net = Android.Net;

namespace Xambi.Client.Android.Ui
{
	[Activity (MainLauncher = true)]
	public class MainActivity : Activity
	{
		#region Methods

		#region Event Handlers

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Setup connectivity monitoring.
			cm = new ConnectivityMonitor();

			InitView();

			// Check authentication.
			if (User == null)
				Authenticate();
		}

		protected override void OnResume()
		{
			base.OnResume();

			// Resume connectivity monitoring.
			cbr = new ConnectivityBroadcastReceiver();
			cbr.ConnectionStatusChanged += OnConnectivityStateChange;
			RegisterReceiver(cbr, new IntentFilter(Net.ConnectivityManager.ConnectivityAction));

			GetIsp();
		}

		protected override void OnPause()
		{
			if (cbr != null)
			{
				UnregisterReceiver(cbr);
				cbr.ConnectionStatusChanged -= OnConnectivityStateChange;
				cbr = null;
			}

			base.OnPause();
		}

		#endregion Event Handlers

		#region Private

		private void InitView()
		{
			SetContentView(Resource.Layout.Main);

			this.ProgressDialog = new ProgressDialog(this);
			this.ProgressDialog.SetMessage("Loading...");

            TextUsername = FindViewById<TextView>(Resource.Id.textUsername);
			TextNickname = FindViewById<TextView>(Resource.Id.textNickname);
			TextIsp = FindViewById<TextView>(Resource.Id.textIsp);
			TextNetworks = FindViewById<TextView>(Resource.Id.textNetworks);

			Button button = FindViewById<Button>(Resource.Id.buttonGetNetworks);
			button.Click += delegate
			{
				// Get networks.
				TextNetworks.Text = null;
				GetNetworks();
			};
		}

		private void OnConnectivityStateChange(object sender, EventArgs e)
		{
			ConnectivityType state = cm.State;
			cm.CheckConnectivity();
			if (state != cm.State)
			{
				GetIsp();
			}
		}

		private void Authenticate()
		{
			Auth0
				.LoginAsync(this)
				.ContinueWith(t =>
				{
					if (this.ProgressDialog.IsShowing)
					{
						this.ProgressDialog.Hide();
					}

					User = t.Result;
					if (User != null)
					{
						JObject p = User.Profile;
						Profile = (p == null) ? null : p.ToObject<Auth0Profile>();
						RunOnUiThread(() =>
						{
							TextUsername.Text = Profile.Email;
							TextNickname.Text = Profile.Given_name;
						});
					}
				});
		}

		private async void GetIsp()
		{
			ConnectivityType ct = cm.State;
			if (ct == ConnectivityType.Data || ct == ConnectivityType.Wifi)
			{
				var client = new HttpClient();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://dev.socsuite.com/api-ss/netLocation/");
				var response = await client.SendAsync(request);
				if (response != null && response.IsSuccessStatusCode)
				{
					string json = await response.Content.ReadAsStringAsync();
					NetworkLocationDto dto = JsonConvert.DeserializeObject<NetworkLocationDto>(json);
					RunOnUiThread(() =>
					{
						TextIsp.Text = dto.Isp;
					});
				}
			}
		}

		private async void GetNetworks()
		{
			ConnectivityType ct = cm.State;
			if (ct == ConnectivityType.Data || ct == ConnectivityType.Wifi)
			{
				var client = new HttpClient();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://dev.socsuite.com/api-ss/networks/");
				var response = await client.SendAsync(request);
				if (response != null && response.IsSuccessStatusCode)
				{
					string json = await response.Content.ReadAsStringAsync();
					List<NetworkDto> dtoList = JsonConvert.DeserializeObject<List<NetworkDto>>(json);
					if (dtoList != null)
					{
						RunOnUiThread(() =>
						{
							int networkIndex = 0;
							bool ssidMatched = false;
							StringBuilder networks = new StringBuilder();
							dtoList.ForEach(l =>
							{
								if (networkIndex > 0)
								{
									networks.AppendLine();
								}

								++networkIndex;
								networks.Append(l.FriendlyName);
								if (!ssidMatched)
								{
									string ssid = l.NetworkSsid;
									if (ssid != null)
									{
										if (ssid.Equals(cm.NetworkSsid, StringComparison.OrdinalIgnoreCase))
										{
											ssidMatched = true;
											networks.Append(" *");
										}
									}
								}
							});

							TextNetworks.Text = networks.ToString();
						});
					}
				}
			}
		}		

		#endregion Private

		#endregion Methods

		#region Properties

		private IConnectivityMonitor cm;
		private ConnectivityBroadcastReceiver cbr;

		Auth0User User;

		Auth0Profile Profile;

		Auth0Client Auth0 = new Auth0Client("symbi.auth0.com", "aE5N7Tjw3t0lPl2w6I4tku0HeqdZgadx");

		ProgressDialog ProgressDialog;
        TextView TextUsername;
		TextView TextNickname;
		TextView TextIsp;
		TextView TextNetworks;

		#endregion Properties
	}
}


