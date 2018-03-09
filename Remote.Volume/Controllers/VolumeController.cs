using AudioSwitcher.AudioApi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Remote.Volume.Controllers
{
	[Produces("application/json")]
	[Route("api/volume/[action]")]
	public class VolumeController : Controller
	{
		private readonly IAudioController _audioController;

		public VolumeController(IAudioController audioController)
		{
			_audioController = audioController;
		}

		public async Task<IActionResult> Mute()
		{
			await _audioController.DefaultPlaybackDevice.SetMuteAsync(true);
			return Ok();
		}

		public async Task<IActionResult> Unmute()
		{
			await _audioController.DefaultPlaybackDevice.SetMuteAsync(false);
			return Ok();
		}

		public async Task<IActionResult> SetVolume(double volume)
		{
			await _audioController.DefaultPlaybackDevice.SetVolumeAsync(volume);
			return Ok();
		}
	}
}