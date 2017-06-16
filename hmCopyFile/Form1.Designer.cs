namespace hmCopyFile
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_from = new System.Windows.Forms.TextBox();
            this.tb_to = new System.Windows.Forms.TextBox();
            this.but_from = new System.Windows.Forms.Button();
            this.but_to = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.but_copy = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lab_speed = new System.Windows.Forms.ToolStripStatusLabel();
            this.but_speedunits = new System.Windows.Forms.ToolStripDropDownButton();
            this.bsecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBsecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kBsecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_copyspeed = new System.Windows.Forms.ToolStripProgressBar();
            this.lab_timeleft = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.but_cancel = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_from
            // 
            this.tb_from.Location = new System.Drawing.Point(12, 12);
            this.tb_from.Name = "tb_from";
            this.tb_from.Size = new System.Drawing.Size(319, 20);
            this.tb_from.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tb_from, "file-source which will be copied");
            this.tb_from.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // tb_to
            // 
            this.tb_to.Location = new System.Drawing.Point(12, 38);
            this.tb_to.Name = "tb_to";
            this.tb_to.Size = new System.Drawing.Size(319, 20);
            this.tb_to.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tb_to, "folder-destination when file will be copied");
            this.tb_to.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // but_from
            // 
            this.but_from.Location = new System.Drawing.Point(337, 12);
            this.but_from.Name = "but_from";
            this.but_from.Size = new System.Drawing.Size(61, 21);
            this.but_from.TabIndex = 0;
            this.but_from.Text = "Browse...";
            this.toolTip1.SetToolTip(this.but_from, "add a file-source");
            this.but_from.UseVisualStyleBackColor = true;
            this.but_from.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_to
            // 
            this.but_to.Location = new System.Drawing.Point(337, 39);
            this.but_to.Name = "but_to";
            this.but_to.Size = new System.Drawing.Size(61, 21);
            this.but_to.TabIndex = 3;
            this.but_to.Text = "Browse..";
            this.toolTip1.SetToolTip(this.but_to, "add a folder-destination");
            this.but_to.UseVisualStyleBackColor = true;
            this.but_to.Click += new System.EventHandler(this.button2_Click);
            // 
            // but_copy
            // 
            this.but_copy.Location = new System.Drawing.Point(12, 64);
            this.but_copy.Name = "but_copy";
            this.but_copy.Size = new System.Drawing.Size(319, 23);
            this.but_copy.TabIndex = 6;
            this.but_copy.Text = "Copy";
            this.toolTip1.SetToolTip(this.but_copy, "start to copy");
            this.but_copy.UseVisualStyleBackColor = true;
            this.but_copy.Click += new System.EventHandler(this.button3_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_speed,
            this.but_speedunits,
            this.pb_copyspeed,
            this.lab_timeleft});
            this.status.Location = new System.Drawing.Point(0, 98);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(406, 27);
            this.status.SizingGrip = false;
            this.status.TabIndex = 7;
            this.status.Text = "statusStrip1";
            // 
            // lab_speed
            // 
            this.lab_speed.AutoSize = false;
            this.lab_speed.Name = "lab_speed";
            this.lab_speed.Size = new System.Drawing.Size(70, 22);
            this.lab_speed.Text = "Speed";
            this.lab_speed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lab_speed.ToolTipText = "speed of copying";
            // 
            // but_speedunits
            // 
            this.but_speedunits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.but_speedunits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bsecToolStripMenuItem,
            this.mBsecToolStripMenuItem,
            this.kBsecToolStripMenuItem});
            this.but_speedunits.Image = ((System.Drawing.Image)(resources.GetObject("but_speedunits.Image")));
            this.but_speedunits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_speedunits.Name = "but_speedunits";
            this.but_speedunits.Size = new System.Drawing.Size(60, 25);
            this.but_speedunits.Text = "MB/sec";
            // 
            // bsecToolStripMenuItem
            // 
            this.bsecToolStripMenuItem.Name = "bsecToolStripMenuItem";
            this.bsecToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bsecToolStripMenuItem.Text = "B/sec";
            this.bsecToolStripMenuItem.ToolTipText = "B/sec";
            this.bsecToolStripMenuItem.Click += new System.EventHandler(this.bsecToolStripMenuItem_Click);
            // 
            // mBsecToolStripMenuItem
            // 
            this.mBsecToolStripMenuItem.Checked = true;
            this.mBsecToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mBsecToolStripMenuItem.Name = "mBsecToolStripMenuItem";
            this.mBsecToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mBsecToolStripMenuItem.Text = "MB/sec";
            this.mBsecToolStripMenuItem.Click += new System.EventHandler(this.bsecToolStripMenuItem_Click);
            // 
            // kBsecToolStripMenuItem
            // 
            this.kBsecToolStripMenuItem.Name = "kBsecToolStripMenuItem";
            this.kBsecToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kBsecToolStripMenuItem.Text = "KB/sec";
            this.kBsecToolStripMenuItem.ToolTipText = "KB/sec";
            this.kBsecToolStripMenuItem.Click += new System.EventHandler(this.bsecToolStripMenuItem_Click);
            // 
            // pb_copyspeed
            // 
            this.pb_copyspeed.AutoToolTip = true;
            this.pb_copyspeed.Name = "pb_copyspeed";
            this.pb_copyspeed.Size = new System.Drawing.Size(150, 21);
            this.pb_copyspeed.ToolTipText = "progress of copying";
            // 
            // lab_timeleft
            // 
            this.lab_timeleft.Name = "lab_timeleft";
            this.lab_timeleft.Size = new System.Drawing.Size(51, 22);
            this.lab_timeleft.Text = "Timeleft";
            this.lab_timeleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // but_cancel
            // 
            this.but_cancel.Enabled = false;
            this.but_cancel.Location = new System.Drawing.Point(337, 64);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(61, 23);
            this.but_cancel.TabIndex = 8;
            this.but_cancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.but_cancel, "cancel the copying and delete the copyed part of the file");
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // icon
            // 
            this.icon.BalloonTipText = "Click on icon for maximize";
            this.icon.BalloonTipTitle = "Copying files";
            this.icon.ContextMenuStrip = this.contextMenu;
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "Copying...";
            this.icon.Visible = true;
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(406, 125);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.status);
            this.Controls.Add(this.but_copy);
            this.Controls.Add(this.but_to);
            this.Controls.Add(this.but_from);
            this.Controls.Add(this.tb_to);
            this.Controls.Add(this.tb_from);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Copying";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_from;
        private System.Windows.Forms.TextBox tb_to;
        private System.Windows.Forms.Button but_from;
        private System.Windows.Forms.Button but_to;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button but_copy;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripDropDownButton but_speedunits;
        private System.Windows.Forms.ToolStripMenuItem bsecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mBsecToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lab_speed;
        private System.Windows.Forms.ToolStripProgressBar pb_copyspeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem kBsecToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.ToolStripStatusLabel lab_timeleft;
        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

