using Microsoft.AspNetCore.Mvc;
using NAudio.CoreAudioApi;

namespace Remote.Volume.Controllers
{
	[Produces("application/json")]
	public class VolumeController : Controller
	{
		private readonly MMDevice _defaultDevice;

		public VolumeController()
		{
			_defaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
		}

		/// <summary>
		/// Mutes the default audio device
		/// </summary>
		/// <response code="200">The default device was muted</response>
		[HttpPost]
		[Route("/api/volume/mute")]
		[ProducesResponseType(200)]
		public IActionResult Mute()
		{
			_defaultDevice.AudioEndpointVolume.Mute = true;
			return Ok();
		}

		/// <summary>
		/// Unmutes the default audio device
		/// </summary>
		/// <response code="200">The default device was unmuted</response>
		[HttpPost]
		[Route("/api/volume/unmute")]
		[ProducesResponseType(200)]
		public IActionResult Unmute()
		{
			_defaultDevice.AudioEndpointVolume.Mute = false;
			return Ok();
		}

		/// <summary>
		/// Gets the default playback device volume
		/// </summary>
		/// <returns>The default playback device volume between 0 and 100</returns>
		/// <response code="200">The default audio device volume</response>
		[HttpGet]
		[Route("/api/volume")]
		[ProducesResponseType(200)]
		public double Volume()
		{
			return _defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100;
		}

		/// <summary>
		/// Sets the default playback device volume to the provided volume
		/// </summary>
		/// <param name="volume">The volume for the default playback device between 0 and 100</param>
		/// <response code="200">The default playback device volume was changed</response>
		/// <response code="400">The provided volume was outside the bounds of 0 to 100</response>
		[HttpPost]
		[Route("/api/volume")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult Volume(double volume)
		{
			if (volume < 0 || volume > 100)
			{
				return BadRequest("Volume must be between 0 and 100");
			}

			_defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = (float)volume / 100f;
			return Ok();
		}
	}
}
