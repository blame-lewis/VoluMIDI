using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using Sanford.Multimedia.Midi;

namespace VoluMIDI
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
            voluMIDIToolStripMenuItem.Text = "VoluMIDI " + Application.ProductVersion;
            this.Text = voluMIDIToolStripMenuItem.Text;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
        }
        NAudio.CoreAudioApi.MMDevice currentAudioDevice = null;
        Dictionary<string, NAudio.CoreAudioApi.MMDevice> audioDevices = new Dictionary<string, MMDevice>();
        Dictionary<string, int> midiDevices = new Dictionary<string, int>();

        OutputDevice currentMidiDevice = null;
        private void SetupForm_Shown(object sender, EventArgs e)
        {
            
            HorribleAudio.SoundDrivers.NAudioInterface.NAudioDriver d = new HorribleAudio.SoundDrivers.NAudioInterface.NAudioDriver(HorribleAudio.SoundDrivers.NAudioInterface.NAudioDriverType.WASAPI);

            d.startUp();


            //Enumerate all audio endpoints/devices
            NAudio.CoreAudioApi.MMDeviceEnumerator DevEnum = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            foreach (NAudio.CoreAudioApi.MMDevice x in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                audioDevices[x.DeviceFriendlyName + " " + x.FriendlyName] = x;

            foreach (string s in audioDevices.Keys)
                audioDeviceBox.Items.Add(s);

            //Enumerate all MIDI out devices
            for (int i = 0; i < OutputDevice.DeviceCount; i++)
            {
                MidiOutCaps c = OutputDevice.GetDeviceCapabilities(i);
                midiDevices[c.name] = i;
            }
            foreach (string s in midiDevices.Keys)
                midiDeviceBox.Items.Add(s);

            //Make some default selections
            if (midiDeviceBox.Items.Count > 0)
                midiDeviceBox.SelectedIndex = 0;
            if (audioDeviceBox.Items.Count > 0)
                audioDeviceBox.SelectedIndex = 0;
            commandTypeInputBox.SelectedIndex = 0;
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetupForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        delegate void VoidCall();
        void trigger()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new VoidCall(delegate()
                {
                    Color c = triggerLabel.BackColor;
                    triggerLabel.BackColor = triggerLabel.ForeColor;
                    triggerLabel.ForeColor = c;
                }));
            }
        }
        int commandMode;
        bool infinite = false;
        bool enabled = true;
        void volumeChanged(AudioVolumeNotificationData data)
        {
            float nextLevel = data.MasterVolume;

            if (enabled)
            {
                float difference = nextLevel - lastLevel;

                lastLevel = nextLevel;
                if (Math.Abs(nextLevel - 0.5f) < 0.01f)
                    return;


                currentAudioDevice.AudioEndpointVolume.MasterVolumeLevelScalar = 0.5f;
                total += difference;
                if (infinite)
                {
                    while (total >= 1.0)
                        total -= 1.0f;
                    while (total < 0.0)
                        total += 1.0f;
                }
                else
                {
                    if(total > 1.0)
                        total = 1.0f;
                    if(total < 0.0)
                        total = 0.0f;
                }
                if (currentMidiDevice != null)
                {
                    trigger();
                    if (commandMode == 0)
                        currentMidiDevice.Send(new ChannelMessage(ChannelCommand.ChannelPressure, (int)channelInputBox.Value, (int)(total * 127)));
                    if (commandMode == 1)
                        currentMidiDevice.Send(new ChannelMessage(ChannelCommand.PitchWheel, (int)channelInputBox.Value, 0, (int)(total * 127)));
                }
            }
        }
        float total = 0;
        float lastLevel=0.5f;
        private void audioDeviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentAudioDevice != null)
                currentAudioDevice.AudioEndpointVolume.OnVolumeNotification -= volumeChanged;
            currentAudioDevice = audioDevices[(string)audioDeviceBox.SelectedItem];
            currentAudioDevice.AudioEndpointVolume.OnVolumeNotification += volumeChanged;
            lastLevel = currentAudioDevice.AudioEndpointVolume.MasterVolumeLevel;
        }

        private void midiDeviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMidiDevice != null)
            {
                currentMidiDevice.Dispose();
                currentMidiDevice = null;
            }
            currentMidiDevice = new OutputDevice(midiDevices[(string)midiDeviceBox.SelectedItem]);
        }

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (currentMidiDevice != null)
                    currentMidiDevice.Dispose();
            }
            catch
            {
            }
            try
            {
                if (currentAudioDevice != null)
                    currentAudioDevice.AudioEndpointVolume.OnVolumeNotification -= volumeChanged;
            }
            catch
            {
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void commandTypeInputBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            commandMode = commandTypeInputBox.SelectedIndex;
        }

        private void infiniteBox_CheckedChanged(object sender, EventArgs e)
        {
            infinite = infiniteBox.Checked;
        }

        private void enableBox_CheckedChanged(object sender, EventArgs e)
        {
            enabled = enableBox.Checked;
        }
    }
}
