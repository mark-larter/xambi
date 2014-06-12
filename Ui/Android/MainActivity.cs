using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Auth0.SDK;

using Symbi.Core.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Symbi.Core.DTO;

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
            InitView();

			// Check authentication.
			Authenticate();
		}

		#endregion Event Handlers

		#region Private

		private void InitView()
		{
			SetContentView(Resource.Layout.Main);

			this.ProgressDialog = new ProgressDialog(this);
			this.ProgressDialog.SetMessage("Loading...");

            TextUsername = FindViewById<TextView>(Resource.Id.textUsername);
            EditNickname = FindViewById<EditText>(Resource.Id.editNickname);
			TextIsp = FindViewById<TextView>(Resource.Id.textIsp);

			Button button = FindViewById<Button>(Resource.Id.buttonTest);
			button.Click += delegate {
				button.Text = String.Format("Wow {0} clicks!", ++ClickCount);

				// Check ISP.
				GetIsp()
					.ContinueWith(async t =>
					{
						var response = t.Result;
						if (response.IsSuccessStatusCode)
						{
							string json = await response.Content.ReadAsStringAsync();
							IspDto dto = JsonConvert.DeserializeObject<IspDto>(json);
							RunOnUiThread(() =>
							{
								TextIsp.Text = dto.isp;
							});
						}
					});
			};
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
							EditNickname.Text = Profile.Given_name;
						});
					}
				});
		}

		private async Task<HttpResponseMessage> GetIsp()
		{
			var client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://ip-api.com/json/");
			var response = await client.SendAsync(request);
			return response;
		}		

		#endregion Private

		#endregion Methods

		#region Properties

		int ClickCount = 0;

		Auth0User User;

		Auth0Profile Profile;

		Auth0Client Auth0 = new Auth0Client("symbi.auth0.com", "aE5N7Tjw3t0lPl2w6I4tku0HeqdZgadx");

		ProgressDialog ProgressDialog;
        TextView TextUsername;
		TextView TextIsp;
		EditText EditNickname;

		#endregion Properties
	}
}


