namespace Remote.Volume.WinForms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnMute = new System.Windows.Forms.Button();
			this.btnUnmute = new System.Windows.Forms.Button();
			this.tbVolume = new System.Windows.Forms.TrackBar();
			this.txtVolume = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslbWarning = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnMute
			// 
			this.btnMute.Location = new System.Drawing.Point(12, 12);
			this.btnMute.Name = "btnMute";
			this.btnMute.Size = new System.Drawing.Size(75, 23);
			this.btnMute.TabIndex = 0;
			this.btnMute.Text = "Mute";
			this.btnMute.UseVisualStyleBackColor = true;
			this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
			// 
			// btnUnmute
			// 
			this.btnUnmute.Location = new System.Drawing.Point(12, 41);
			this.btnUnmute.Name = "btnUnmute";
			this.btnUnmute.Size = new System.Drawing.Size(75, 23);
			this.btnUnmute.TabIndex = 0;
			this.btnUnmute.Text = "Unmute";
			this.btnUnmute.UseVisualStyleBackColor = true;
			this.btnUnmute.Click += new System.EventHandler(this.btnUnmute_Click);
			// 
			// tbVolume
			// 
			this.tbVolume.Location = new System.Drawing.Point(93, 17);
			this.tbVolume.Maximum = 100;
			this.tbVolume.Name = "tbVolume";
			this.tbVolume.Size = new System.Drawing.Size(208, 45);
			this.tbVolume.SmallChange = 5;
			this.tbVolume.TabIndex = 1;
			this.tbVolume.TickFrequency = 10;
			this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.tbVolume.ValueChanged += new System.EventHandler(this.tbVolume_ValueChanged);
			this.tbVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbVolume_MouseDown);
			this.tbVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVolume_MouseUp);
			this.tbVolume.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tbVolume_MouseWheel);
			// 
			// txtVolume
			// 
			this.txtVolume.Location = new System.Drawing.Point(307, 29);
			this.txtVolume.Name = "txtVolume";
			this.txtVolume.ReadOnly = true;
			this.txtVolume.Size = new System.Drawing.Size(38, 20);
			this.txtVolume.TabIndex = 2;
			this.txtVolume.Text = "0";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbWarning});
			this.statusStrip1.Location = new System.Drawing.Point(0, 67);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(358, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslbWarning
			// 
			this.tslbWarning.BackColor = System.Drawing.Color.Red;
			this.tslbWarning.Name = "tslbWarning";
			this.tslbWarning.Size = new System.Drawing.Size(0, 17);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 89);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.txtVolume);
			this.Controls.Add(this.tbVolume);
			this.Controls.Add(this.btnUnmute);
			this.Controls.Add(this.btnMute);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Remote Volume";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnMute;
		private System.Windows.Forms.Button btnUnmute;
		private System.Windows.Forms.TrackBar tbVolume;
		private System.Windows.Forms.TextBox txtVolume;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tslbWarning;
	}
}

