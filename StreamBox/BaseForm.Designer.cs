﻿namespace StreamBox
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStreamsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStreamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToastNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.streamsListView = new System.Windows.Forms.ListView();
            this.streamsTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.streamsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.streamsLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TimeZoneStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.UsernameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.StreamerBoxTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Resize += new System.EventHandler(this.sendToTray);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStreamsToolStripMenuItem1,
            this.addNewStreamerToolStripMenuItem,
            this.sendToastNotificationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Streams";
            // 
            // refreshStreamsToolStripMenuItem1
            // 
            this.refreshStreamsToolStripMenuItem1.Name = "refreshStreamsToolStripMenuItem1";
            this.refreshStreamsToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.refreshStreamsToolStripMenuItem1.Text = "Manually Refresh Streams";
            this.refreshStreamsToolStripMenuItem1.Click += new System.EventHandler(this.refreshStreamsToolStripMenuItem1_Click);
            // 
            // addNewStreamerToolStripMenuItem
            // 
            this.addNewStreamerToolStripMenuItem.Name = "addNewStreamerToolStripMenuItem";
            this.addNewStreamerToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addNewStreamerToolStripMenuItem.Text = "Streamer Display Toggles";
            this.addNewStreamerToolStripMenuItem.Click += new System.EventHandler(this.addNewStreamerToolStripMenuItem_Click);
            // 
            // sendToastNotificationToolStripMenuItem
            // 
            this.sendToastNotificationToolStripMenuItem.Name = "sendToastNotificationToolStripMenuItem";
            this.sendToastNotificationToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.sendToastNotificationToolStripMenuItem.Text = "Check Nearest Stream";
            this.sendToastNotificationToolStripMenuItem.Click += new System.EventHandler(this.sendToastNotificationToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "Settings";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.settingsToolStripMenuItem.Text = "Change Username";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About Developer";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "Exit Program";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 674);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(533, 674);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.streamsListView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 307);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Streams";
            // 
            // streamsListView
            // 
            this.streamsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.streamsTime,
            this.streamsName,
            this.streamsLink});
            this.streamsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streamsListView.HideSelection = false;
            this.streamsListView.Location = new System.Drawing.Point(3, 16);
            this.streamsListView.Name = "streamsListView";
            this.streamsListView.Size = new System.Drawing.Size(527, 288);
            this.streamsListView.TabIndex = 0;
            this.streamsListView.UseCompatibleStateImageBehavior = false;
            this.streamsListView.View = System.Windows.Forms.View.Details;
            this.streamsListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.streamsListView_ColumnWidthChanging);
            this.streamsListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.streamsListView_DrawColumnHeader);
            this.streamsListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.streamsListView_DrawItem);
            this.streamsListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.streamsListView_DrawSubItem);
            this.streamsListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.streamsListView_MouseMove);
            this.streamsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.streamsListView_MouseUp);
            // 
            // streamsTime
            // 
            this.streamsTime.Text = "Stream Time";
            this.streamsTime.Width = 104;
            // 
            // streamsName
            // 
            this.streamsName.Text = "Streamer";
            this.streamsName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.streamsName.Width = 151;
            // 
            // streamsLink
            // 
            this.streamsLink.Text = "Stream Link";
            this.streamsLink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.streamsLink.Width = 261;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calendar";
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar.Location = new System.Drawing.Point(45, 25);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.TodayDate = new System.DateTime(2023, 4, 25, 0, 0, 0, 0);
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeZoneStatus,
            this.TimeStatus,
            this.UsernameStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(533, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TimeZoneStatus
            // 
            this.TimeZoneStatus.Name = "TimeZoneStatus";
            this.TimeZoneStatus.Size = new System.Drawing.Size(101, 17);
            this.TimeZoneStatus.Text = "Current Timezone";
            // 
            // TimeStatus
            // 
            this.TimeStatus.Name = "TimeStatus";
            this.TimeStatus.Size = new System.Drawing.Size(76, 17);
            this.TimeStatus.Text = "Current Time";
            // 
            // UsernameStatus
            // 
            this.UsernameStatus.Name = "UsernameStatus";
            this.UsernameStatus.Size = new System.Drawing.Size(94, 17);
            this.UsernameStatus.Text = "Hello, Username";
            // 
            // StreamerBoxTray
            // 
            this.StreamerBoxTray.BalloonTipText = "The application is still running in the background";
            this.StreamerBoxTray.BalloonTipTitle = "Application Minimized";
            this.StreamerBoxTray.Icon = ((System.Drawing.Icon)(resources.GetObject("StreamerBoxTray.Icon")));
            this.StreamerBoxTray.Text = "StreamerBox";
            this.StreamerBoxTray.Visible = true;
            this.StreamerBoxTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StreamerBoxTray_MouseDoubleClick);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 698);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StreamerBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStreamerToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TimeZoneStatus;
        private System.Windows.Forms.ToolStripStatusLabel TimeStatus;
        private System.Windows.Forms.ToolStripStatusLabel UsernameStatus;
        private System.Windows.Forms.ColumnHeader streamsTime;
        private System.Windows.Forms.ColumnHeader streamsName;
        private System.Windows.Forms.ColumnHeader streamsLink;
        public System.Windows.Forms.ListView streamsListView;
        private System.Windows.Forms.ToolStripMenuItem sendToastNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon StreamerBoxTray;
        private System.Windows.Forms.ToolStripMenuItem refreshStreamsToolStripMenuItem1;
    }
}