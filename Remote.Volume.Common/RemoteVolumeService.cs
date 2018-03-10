using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Remote.Volume.Common
{
	public class RemoteVolumeService
	{
		private readonly HttpClient _httpClient;

		public RemoteVolumeService(Uri baseUri)
		{
			_httpClient = new HttpClient
			{
				BaseAddress = baseUri
			};
		}

		public async Task<double> GetVolume()
		{
			return double.Parse(await _httpClient.GetStringAsync("/api/volume"));
		}

		public async Task SetVolume(double volume)
		{
			if (volume > 100)
			{
				volume = 100;
			}

			if (volume < 0)
			{
				volume = 0;
			}

			await _httpClient.PostAsync("/api/volume", new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("volume", $"{volume}") }));
		}

		public Task Mute()
		{
			return _httpClient.PostAsync("/api/volume/mute", new StringContent(string.Empty));
		}

		public Task Unmute()
		{
			return _httpClient.PostAsync("/api/volume/unmute", new StringContent(string.Empty));
		}
	}
}