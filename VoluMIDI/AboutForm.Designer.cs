namespace VoluMIDI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prolapsoftButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "VoluMIDI";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(286, 404);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(52, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(130, 43);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(78, 13);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "Version 0.1.0.0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 162);
            this.label2.TabIndex = 3;
            this.label2.Text = "Turns any ordinary volume control into a MIDI controller.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prolapsoftButton
            // 
            this.prolapsoftButton.Location = new System.Drawing.Point(1, 404);
            this.prolapsoftButton.Name = "prolapsoftButton";
            this.prolapsoftButton.Size = new System.Drawing.Size(134, 23);
            this.prolapsoftButton.TabIndex = 4;
            this.prolapsoftButton.Text = "www.prolapsoft.com";
            this.prolapsoftButton.UseVisualStyleBackColor = true;
            this.prolapsoftButton.Click += new System.EventHandler(this.prolapsoftButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VoluMIDI.Properties.Resources.Main_Icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(338, 430);
            this.Controls.Add(this.prolapsoftButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "About VoluMIDI";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prolapsoftButton;
    }
}