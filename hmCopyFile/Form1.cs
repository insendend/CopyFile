using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace hmCopyFile
{
    public partial class Form1 : Form
    {
        // help message for textboxs
        private string strFilePathHelp = "Enter a path to the file";
        private string strDirPathHelp = "Enter a path to the folder";

        // source file and destination folder
        private string strSourceFile = null;
        private string strDestFile = null;

        // event for canceling copying
        private AutoResetEvent areStop = new AutoResetEvent(false);

        // count of timer ticks
        private int iTicks = 0;

        // count of written bytes in the copy file
        private long lSizeWritten = 0;

        // value of size of file
        private long lSizeOfFile = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Copying";
            this.tb_from.Text = strFilePathHelp;
            this.tb_to.Text = strDirPathHelp;
        }

        // catch the messages from OS
        protected override void WndProc(ref Message msg)
        {
            try
            {
                // help for textbox while textbox is empty
                if (string.IsNullOrEmpty(this.tb_from.Text) && !this.tb_from.Focused)
                    this.tb_from.Text = strFilePathHelp;

                if (string.IsNullOrEmpty(this.tb_to.Text) && !this.tb_to.Focused)
                    this.tb_to.Text = strDirPathHelp;

                base.WndProc(ref msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // find a file with an explorer
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ofd.ShowDialog();
                this.tb_from.Text = ofd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // find a directory with an explorer
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.fbd.ShowDialog();
                this.tb_to.Text = fbd.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // clearing textbox's content when clicking
        private void textBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text == strFilePathHelp ||
                    ((TextBox)sender).Text == strDirPathHelp)

                    ((TextBox)sender).Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // check for correction paths
        private bool isCorrectPaths()
        {
            try
            {
                // check for existing source
                if (!File.Exists(this.tb_from.Text))
                    throw new Exception(string.Format("\"{0}\" does not exist", this.tb_from.Text));

                // check for existing dest
                if (!Directory.Exists(this.tb_to.Text))
                    throw new Exception(string.Format("\"{0}\" does not exist", this.tb_to.Text));

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // copy-button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // check for correcting paths
                if (!this.isCorrectPaths())
                    return;

                // init paths of source and destination
                if (!this.isInitializedPaths())
                    return;
                
                // switch to enabled components
                this.BlockComp(true);

                // starting copying
                Action asyncCopy = this.AsyncCopy;
                asyncCopy.BeginInvoke(FinishCopying, asyncCopy);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // initialization source and destination paths
        private bool isInitializedPaths()
        {
            // source file path
            this.strSourceFile = this.tb_from.Text;

            // forming destination file path
            this.strDestFile = Path.Combine(this.tb_to.Text, Path.GetFileName(this.tb_from.Text));

            // asking a user for replace or ignore
            if (File.Exists(this.strDestFile))
            {
                string strText = string.Format("Threre are already exists file {0} in the destination folder", Path.GetFileName(this.tb_from.Text));
                DialogResult dr = MessageBox.Show(strText, "Replace or Cancel", MessageBoxButtons.YesNo);

                // actions depend of user choice
                if (dr != DialogResult.Yes)
                    return false;

                else
                    while (File.Exists(this.strDestFile))
                        this.strDestFile = this.strDestFile.Insert(this.strDestFile.LastIndexOf('.'), " - COPY");
            }
            return true; 
        }

        // choosing speed showing on window 
        private void bsecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // changing flags when choosing the type of speed output
            if (((ToolStripMenuItem)sender).GetHashCode() == this.bsecToolStripMenuItem.GetHashCode())
            {
                this.bsecToolStripMenuItem.Checked = true;
                this.mBsecToolStripMenuItem.Checked = false;
                this.kBsecToolStripMenuItem.Checked = false;
            }
            else if (((ToolStripMenuItem)sender).GetHashCode() == this.mBsecToolStripMenuItem.GetHashCode())
            {
                this.mBsecToolStripMenuItem.Checked = true;
                this.kBsecToolStripMenuItem.Checked = false;
                this.bsecToolStripMenuItem.Checked = false;
            }
            else
            {
                this.kBsecToolStripMenuItem.Checked = true;
                this.mBsecToolStripMenuItem.Checked = false;
                this.bsecToolStripMenuItem.Checked = false;
            }

            // text on dropbutton
            if (this.bsecToolStripMenuItem.Checked)
                this.but_speedunits.Text = "B/sec";
            else if (this.mBsecToolStripMenuItem.Checked)
                this.but_speedunits.Text = "MB/sec";
            else
                this.but_speedunits.Text = "KB/sec";
        }

        // change access of the components
        private void BlockComp(bool isBlock)
        {
            // components on the form
            Control[] comps = new Control[]
            {
                this.tb_from,
                this.tb_to,
                this.but_from,
                this.but_to,
                this.but_copy
            };

            // delegate for regulation activity of components
            Action<int, bool> act = (int i, bool b) => comps[i].Enabled = b;

            // delegate for regulation activity of Cancel-button
            Action<bool> act2 = (bool b) => this.but_cancel.Enabled = b;

            // setting property "Enabled"
            for (int i = 0; i < comps.Length; i++)
                this.Invoke(act, i, !isBlock);

            // setting property "Enabled"
            this.Invoke(act2, isBlock);
        }

        // running copying
        private void AsyncCopy()
        {
            try
            {
                // open one stream for the reading and second for the writting
                using (FileStream fsRead = new FileStream(this.tb_from.Text, FileMode.Open, FileAccess.Read),
                    fsWrite = new FileStream(this.strDestFile, FileMode.Create, FileAccess.Write))
                {
                    // buffer of copy-block
                    const int iBuffSize = 4096;
                    var bBuff = new byte[iBuffSize];

                    // size of file
                    this.lSizeOfFile = fsRead.Length;

                    // for activation a timer
                    Action<bool> startTimer = (bool b) => this.timer1.Enabled = b;
                    this.Invoke(startTimer, false);
                    
                    // starting timer
                    this.Invoke(startTimer, true);

                    // reading and writting by 4096 bytes blocks
                    while (this.lSizeWritten < fsRead.Length)
                    {
                        if (this.areStop.WaitOne(0))
                        {
                            // copying has been canceled
                            fsWrite.Close();
                            
                            // deleting file 
                            File.Delete(this.strDestFile);

                            // clear the fields for retrying using programm
                            this.ClearAllFileds();

                            break;
                        }

                        // reading
                        int iRead = fsRead.Read(bBuff, 0, bBuff.Length);
                        if (iRead == 0)
                            break;

                        // writting
                        fsWrite.Write(bBuff, 0, iRead);
                        this.lSizeWritten += (long)iRead;

                        // changing value of progressbar
                        Action<int> act1 = (int i) => this.pb_copyspeed.Value = i;
                        this.Invoke(act1, (int)(this.lSizeWritten * 100 / fsRead.Length));
                    }

                    // stopping timer
                    this.Invoke(startTimer, false);

                    // changing finaly text on label
                    Action<string> act2 = (string s) => this.lab_speed.Text = s;
                    this.Invoke(act2, "Finished!");

                    // clear the fields for retrying using programm
                    this.ClearAllFileds();           
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // clear the fields for retrying using programm
        private void ClearAllFileds()
        {
            this.iTicks = 0;
            this.lSizeWritten = 0;

            Action<int> act1 = (int i) => this.pb_copyspeed.Value = i;
            this.Invoke(act1, 0);
        }

        // from bytes to mbytes
        private double BytesToMBytes(double dBytes)
        {
            return Math.Round(dBytes / (1024 * 1024), 2);
        }

        // from bytes to kbytes
        private double BytesToKBytes(double dBytes)
        {
            return Math.Round(dBytes / 1024, 2);
        }

        // showing speed in statusbar
        private void ShowSpeed()
        {
            try
            {
                // calcing speed
                double dSpeed = Math.Round((double)(this.lSizeWritten) / this.iTicks, 2);

                // changing outputting text in a label1
                Action<string> act = (string s) => this.lab_speed.Text = s;

                // showing type of speed (b/sec or mb/sec)
                if (this.bsecToolStripMenuItem.Checked)
                    this.Invoke(act, dSpeed.ToString());
                else if (this.mBsecToolStripMenuItem.Checked)
                    this.Invoke(act, this.BytesToMBytes(dSpeed).ToString());
                else
                    this.Invoke(act, this.BytesToKBytes(dSpeed).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // showing timeleft in statusbar
        private void ShowTimeLeft()
        {
            try
            {
                // calcing ~timeleft in seconds
                TimeSpan timeLeft = TimeSpan.FromSeconds((this.lSizeOfFile - this.lSizeWritten) / (this.lSizeWritten / this.iTicks));
                
                // changing outputting text int the label2
                Action<string> act = (string s) => this.lab_timeleft.Text = s;
                this.Invoke(act, string.Format("Timeleft: ~ {0}", timeLeft.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // callback method for async-copying
        private void FinishCopying(IAsyncResult res)
        {
            try
            {
                Action act = (Action)res.AsyncState;
                act.EndInvoke(res);

                // switch to enabled components
                this.BlockComp(false);

                Action<string> clrstr = (string s) => this.lab_timeleft.Text = s;
                this.Invoke(clrstr, "Timeleft");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // timer work
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // seconds left
                ++this.iTicks;

                // outputting speed
                this.ShowSpeed();

                // outputting timeleft
                this.ShowTimeLeft();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // canceling copying
        private void button4_Click(object sender, EventArgs e)
        {
            this.areStop.Set();
        }

        // minimize window to tray
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // hide in taskbar
                this.Hide();
                
                // show in tray
                this.icon.Visible = true;
                this.icon.ShowBalloonTip(3000);
            }
        }

        // choosing "Exit" on contextmenu in tray
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // choosing "Show" on contextmenu in tray
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.icon.Visible = false;
        }

        // click on icon in the tray
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.showToolStripMenuItem_Click(sender, e);
        }
    }
}