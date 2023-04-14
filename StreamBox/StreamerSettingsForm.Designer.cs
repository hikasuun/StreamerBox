namespace StreamBox
{
    partial class StreamerSettingsForm
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
            this.StreamerCheckBoxes = new System.Windows.Forms.CheckedListBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.JPBtn = new System.Windows.Forms.Button();
            this.ENBtn = new System.Windows.Forms.Button();
            this.IDBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.alltoggle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StreamerCheckBoxes
            // 
            this.StreamerCheckBoxes.FormattingEnabled = true;
            this.StreamerCheckBoxes.Location = new System.Drawing.Point(6, 15);
            this.StreamerCheckBoxes.Name = "StreamerCheckBoxes";
            this.StreamerCheckBoxes.Size = new System.Drawing.Size(393, 424);
            this.StreamerCheckBoxes.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(433, 415);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(112, 36);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Save Changes";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(433, 373);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 36);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel Changes";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // JPBtn
            // 
            this.JPBtn.Location = new System.Drawing.Point(6, 19);
            this.JPBtn.Name = "JPBtn";
            this.JPBtn.Size = new System.Drawing.Size(106, 36);
            this.JPBtn.TabIndex = 4;
            this.JPBtn.Text = "Hololive";
            this.JPBtn.UseVisualStyleBackColor = true;
            this.JPBtn.Click += new System.EventHandler(this.JPBtn_Click);
            // 
            // ENBtn
            // 
            this.ENBtn.Location = new System.Drawing.Point(6, 71);
            this.ENBtn.Name = "ENBtn";
            this.ENBtn.Size = new System.Drawing.Size(106, 36);
            this.ENBtn.TabIndex = 5;
            this.ENBtn.Text = "HoloEN";
            this.ENBtn.UseVisualStyleBackColor = true;
            this.ENBtn.Click += new System.EventHandler(this.ENBtn_Click);
            // 
            // IDBtn
            // 
            this.IDBtn.Location = new System.Drawing.Point(6, 124);
            this.IDBtn.Name = "IDBtn";
            this.IDBtn.Size = new System.Drawing.Size(106, 36);
            this.IDBtn.TabIndex = 6;
            this.IDBtn.Text = "HoloID";
            this.IDBtn.UseVisualStyleBackColor = true;
            this.IDBtn.Click += new System.EventHandler(this.IDBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StreamerCheckBoxes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 459);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toggles Visibility for Talents in Schedule";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.alltoggle);
            this.groupBox2.Controls.Add(this.JPBtn);
            this.groupBox2.Controls.Add(this.ENBtn);
            this.groupBox2.Controls.Add(this.IDBtn);
            this.groupBox2.Location = new System.Drawing.Point(427, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 234);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group Toggles";
            // 
            // alltoggle
            // 
            this.alltoggle.Location = new System.Drawing.Point(6, 177);
            this.alltoggle.Name = "alltoggle";
            this.alltoggle.Size = new System.Drawing.Size(106, 36);
            this.alltoggle.TabIndex = 7;
            this.alltoggle.Text = "Toggle All";
            this.alltoggle.UseVisualStyleBackColor = true;
            this.alltoggle.Click += new System.EventHandler(this.alltoggle_Click);
            // 
            // StreamerSettingsForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(558, 490);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StreamerSettingsForm";
            this.ShowIcon = false;
            this.Text = "Streamer Display Toggle Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox StreamerCheckBoxes;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button JPBtn;
        private System.Windows.Forms.Button ENBtn;
        private System.Windows.Forms.Button IDBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button alltoggle;
    }
}