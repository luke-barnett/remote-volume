using Remote.Volume.Common;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote.Volume.WinForms
{
	public partial class MainForm : Form
	{
		private readonly RemoteVolumeService _remoteVolume;
		private readonly System.Windows.Forms.Timer _volumeTimer;
		private int _volume;
		private bool _updatingVolume;

		public MainForm()
		{
			InitializeComponent();

			_remoteVolume = new RemoteVolumeService(new Uri(ConfigurationManager.AppSettings["RemoteEndpoint"]));
			_volumeTimer = new System.Windows.Forms.Timer();
			_volumeTimer.Interval = 1000;
			_volumeTimer.Tick += async (s, e) => await _volumeTimer_Tick(s, e);
		}

		private async Task _volumeTimer_Tick(object sender, EventArgs e)
		{
			if (!_updatingVolume)
			{
				await UpdateVolume();
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_volumeTimer.Enabled = true;
		}

		private void btnMute_Click(object sender, EventArgs e)
		{
			try
			{
				_remoteVolume.Mute();
			}
			catch
			{
				tslbWarning.Text = "Failed to connect to remote";
			}
		}

		private void btnUnmute_Click(object sender, EventArgs e)
		{
			try
			{
				_remoteVolume.Unmute();
			}
			catch
			{
				tslbWarning.Text = "Failed to connect to remote";
			}
		}

		private void tbVolume_ValueChanged(object sender, System.EventArgs e)
		{
			txtVolume.Text = tbVolume.Value.ToString();
		}

		private async Task UpdateVolume()
		{
			try
			{
				_volume = (int)(await _remoteVolume.GetVolume());
				ClearWarning();
			}
			catch
			{
				tslbWarning.Text = "Failed to connect to remote";
			}
			finally
			{
				if (!_updatingVolume)
				{
					tbVolume.Value = _volume;
				}
			}
		}

		private void tbVolume_MouseDown(object sender, MouseEventArgs e)
		{
			_updatingVolume = true;
		}

		private void tbVolume_MouseUp(object sender, MouseEventArgs e)
		{
			if (_volume != tbVolume.Value)
			{
				try
				{
					var volume = tbVolume.Value;
					Task.Run(async () =>
					{
						await _remoteVolume.SetVolume(volume);
						_updatingVolume = false;
					});
				}
				catch
				{
					_updatingVolume = false;
					tslbWarning.Text = "Failed to connect to remote";
				}
			}
		}

		private void tbVolume_MouseWheel(object sender, MouseEventArgs e)
		{
			((HandledMouseEventArgs)e).Handled = true;
		}

		private void ClearWarning()
		{
			tslbWarning.Text = string.Empty;
		}
	}
}