using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            toolTip1.SetToolTip(pictureBox1, "Instagram Blue logo");
            toolTip1.SetToolTip(progressBar1, "Instagram Blue logo");

            this.BackColor = Color.FromArgb(255, 0, 100);

        }
        Timer timer = new Timer();
        public ToolStripProgressBar PB { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in statusStrip1.Items)
            {
                if (item is ToolStripProgressBar obj)
                {
                    PB = obj;
                    PB.PerformStep();
                    break;
                }
            }
            progressBar1.Step = 5;
            progressBar1.PerformStep();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PB.PerformStep();
            progressBar1.PerformStep();
            label1.Text = progressBar1.Value.ToString();
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer.Stop();
                this.BackColor = Color.Red;
                MessageBox.Show("Finished");
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "You Clicked to FILE";
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "You Clicked to CHANGE";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "You Clicked to COPY";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var value = numericUpDown1.Value;
            label1.Text = value.ToString();

            if (value < 100 && value >= 20)
            {
                pictureBox1.Width = Convert.ToInt32(value);
                pictureBox1.Height = Convert.ToInt32(value);
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(trackBar1.Value,trackBar2.Value,trackBar3.Value);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

        }
        int scrollV = 0;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (scrollV >= vScrollBar1.Value)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y-5);
            }
            else
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y+5);
            }

            scrollV = vScrollBar1.Value;
        }
        int scrollH = 0;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (scrollH >= hScrollBar1.Value)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X-5, pictureBox1.Location.Y);
            }
            else
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X+5, pictureBox1.Location.Y);
            }

            scrollH = hScrollBar1.Value;
        }
    }
}
