namespace StreamerBox
{
    partial class StreamerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StreamerInfo));
            this.TalentNameLabel = new System.Windows.Forms.Label();
            this.TalentYouTubeChannelLabel = new System.Windows.Forms.LinkLabel();
            this.TalentImage = new System.Windows.Forms.PictureBox();
            this.TalentBranchLabel = new System.Windows.Forms.Label();
            this.TalentTwitterAccountLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.TalentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TalentNameLabel
            // 
            this.TalentNameLabel.AutoSize = true;
            this.TalentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TalentNameLabel.Name = "TalentNameLabel";
            this.TalentNameLabel.Size = new System.Drawing.Size(202, 37);
            this.TalentNameLabel.TabIndex = 1;
            this.TalentNameLabel.Text = "Tokino Sora";
            // 
            // TalentYouTubeChannelLabel
            // 
            this.TalentYouTubeChannelLabel.AutoSize = true;
            this.TalentYouTubeChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentYouTubeChannelLabel.Location = new System.Drawing.Point(12, 428);
            this.TalentYouTubeChannelLabel.Name = "TalentYouTubeChannelLabel";
            this.TalentYouTubeChannelLabel.Size = new System.Drawing.Size(137, 20);
            this.TalentYouTubeChannelLabel.TabIndex = 2;
            this.TalentYouTubeChannelLabel.TabStop = true;
            this.TalentYouTubeChannelLabel.Text = "YouTube Channel";
            this.TalentYouTubeChannelLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TalentYouTubeChannelLabel_LinkClicked);
            // 
            // TalentImage
            // 
            this.TalentImage.Location = new System.Drawing.Point(12, 74);
            this.TalentImage.Name = "TalentImage";
            this.TalentImage.Size = new System.Drawing.Size(340, 340);
            this.TalentImage.TabIndex = 0;
            this.TalentImage.TabStop = false;
            // 
            // TalentBranchLabel
            // 
            this.TalentBranchLabel.AutoSize = true;
            this.TalentBranchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentBranchLabel.Location = new System.Drawing.Point(12, 46);
            this.TalentBranchLabel.Name = "TalentBranchLabel";
            this.TalentBranchLabel.Size = new System.Drawing.Size(80, 25);
            this.TalentBranchLabel.TabIndex = 3;
            this.TalentBranchLabel.Text = "Branch";
            // 
            // TalentTwitterAccountLabel
            // 
            this.TalentTwitterAccountLabel.AutoSize = true;
            this.TalentTwitterAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentTwitterAccountLabel.Location = new System.Drawing.Point(155, 428);
            this.TalentTwitterAccountLabel.Name = "TalentTwitterAccountLabel";
            this.TalentTwitterAccountLabel.Size = new System.Drawing.Size(119, 20);
            this.TalentTwitterAccountLabel.TabIndex = 4;
            this.TalentTwitterAccountLabel.TabStop = true;
            this.TalentTwitterAccountLabel.Text = "Twitter Account";
            this.TalentTwitterAccountLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TalentTwitterAccountLabel_LinkClicked);
            // 
            // StreamerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 464);
            this.Controls.Add(this.TalentTwitterAccountLabel);
            this.Controls.Add(this.TalentBranchLabel);
            this.Controls.Add(this.TalentYouTubeChannelLabel);
            this.Controls.Add(this.TalentNameLabel);
            this.Controls.Add(this.TalentImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StreamerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StreamerName";
            this.Load += new System.EventHandler(this.StreamerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TalentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TalentImage;
        private System.Windows.Forms.Label TalentNameLabel;
        private System.Windows.Forms.LinkLabel TalentYouTubeChannelLabel;
        private System.Windows.Forms.Label TalentBranchLabel;
        private System.Windows.Forms.LinkLabel TalentTwitterAccountLabel;
    }
}