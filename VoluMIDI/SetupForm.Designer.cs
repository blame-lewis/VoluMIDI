namespace VoluMIDI
{
    partial class SetupForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.voluMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.triggerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.commandTypeInputBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.channelInputBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.midiDeviceBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.audioDeviceBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hideButton = new System.Windows.Forms.Button();
            this.infiniteBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.routeContextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelInputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VoluMIDI";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voluMIDIToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 76);
            // 
            // voluMIDIToolStripMenuItem
            // 
            this.voluMIDIToolStripMenuItem.Enabled = false;
            this.voluMIDIToolStripMenuItem.Name = "voluMIDIToolStripMenuItem";
            this.voluMIDIToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.voluMIDIToolStripMenuItem.Text = "VoluMIDI";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.setupToolStripMenuItem.Text = "Setup...";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triggerLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 168);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(382, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // triggerLabel
            // 
            this.triggerLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.triggerLabel.Name = "triggerLabel";
            this.triggerLabel.Size = new System.Drawing.Size(45, 17);
            this.triggerLabel.Text = "Trigger";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(382, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.minimizeToolStripMenuItem.Text = "Hide";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // routeContextMenu
            // 
            this.routeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.routeContextMenu.Name = "routeContextMenu";
            this.routeContextMenu.Size = new System.Drawing.Size(106, 70);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.editToolStripMenuItem.Text = "Edit...";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // enableBox
            // 
            this.enableBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableBox.AutoSize = true;
            this.enableBox.Checked = true;
            this.enableBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableBox.Location = new System.Drawing.Point(268, 140);
            this.enableBox.Name = "enableBox";
            this.enableBox.Size = new System.Drawing.Size(111, 23);
            this.enableBox.TabIndex = 6;
            this.enableBox.Text = "Enable MIDI Output";
            this.enableBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableBox.UseVisualStyleBackColor = true;
            this.enableBox.CheckedChanged += new System.EventHandler(this.enableBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.commandTypeInputBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.channelInputBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.midiDeviceBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(0, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 86);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MIDI";
            // 
            // commandTypeInputBox
            // 
            this.commandTypeInputBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commandTypeInputBox.FormattingEnabled = true;
            this.commandTypeInputBox.Items.AddRange(new object[] {
            "Channel Pressure",
            "Pitch Bend"});
            this.commandTypeInputBox.Location = new System.Drawing.Point(94, 58);
            this.commandTypeInputBox.Name = "commandTypeInputBox";
            this.commandTypeInputBox.Size = new System.Drawing.Size(277, 21);
            this.commandTypeInputBox.TabIndex = 7;
            this.commandTypeInputBox.SelectedIndexChanged += new System.EventHandler(this.commandTypeInputBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Command Type:";
            // 
            // channelInputBox
            // 
            this.channelInputBox.Location = new System.Drawing.Point(94, 35);
            this.channelInputBox.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.channelInputBox.Name = "channelInputBox";
            this.channelInputBox.Size = new System.Drawing.Size(38, 20);
            this.channelInputBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channel:";
            // 
            // midiDeviceBox
            // 
            this.midiDeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midiDeviceBox.FormattingEnabled = true;
            this.midiDeviceBox.Location = new System.Drawing.Point(94, 13);
            this.midiDeviceBox.Name = "midiDeviceBox";
            this.midiDeviceBox.Size = new System.Drawing.Size(276, 21);
            this.midiDeviceBox.TabIndex = 1;
            this.midiDeviceBox.SelectedIndexChanged += new System.EventHandler(this.midiDeviceBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "MIDI Device:";
            // 
            // audioDeviceBox
            // 
            this.audioDeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioDeviceBox.FormattingEnabled = true;
            this.audioDeviceBox.Location = new System.Drawing.Point(80, 31);
            this.audioDeviceBox.Name = "audioDeviceBox";
            this.audioDeviceBox.Size = new System.Drawing.Size(299, 21);
            this.audioDeviceBox.TabIndex = 0;
            this.audioDeviceBox.SelectedIndexChanged += new System.EventHandler(this.audioDeviceBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Audio Device:";
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(2, 140);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(50, 23);
            this.hideButton.TabIndex = 8;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // infiniteBox
            // 
            this.infiniteBox.AutoSize = true;
            this.infiniteBox.Location = new System.Drawing.Point(59, 143);
            this.infiniteBox.Name = "infiniteBox";
            this.infiniteBox.Size = new System.Drawing.Size(52, 17);
            this.infiniteBox.TabIndex = 10;
            this.infiniteBox.Text = "Wrap";
            this.infiniteBox.UseVisualStyleBackColor = true;
            this.infiniteBox.CheckedChanged += new System.EventHandler(this.infiniteBox_CheckedChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 190);
            this.Controls.Add(this.infiniteBox);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.audioDeviceBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.enableBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Setup VoluMIDI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupForm_FormClosing);
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.Shown += new System.EventHandler(this.SetupForm_Shown);
            this.Resize += new System.EventHandler(this.SetupForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.routeContextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelInputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voluMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip routeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel triggerLabel;
        private System.Windows.Forms.CheckBox enableBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox audioDeviceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox commandTypeInputBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown channelInputBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox midiDeviceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.CheckBox infiniteBox;
    }
}

