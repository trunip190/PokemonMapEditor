using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PokemonMapEditor
{
    public partial class SpritePicker : UserControl
    {
        List<string> spriteSheets = new List<string>();
        public string filepath = "";
        public string result = "";
        public Size PixelSize = new Size(32, 32);

        public SpritePicker()
        {
            InitializeComponent();
        }

        # region events & delegates
        public delegate void close();
        public event close closing;
        public event close saving;
        public event close cancelling;

        protected virtual void onClosing()
        {
            close handler = closing;
            if (handler != null)
            {
                handler();
            }
        }

        protected virtual void onSaving()
        {
            close handler = saving;
            if (handler != null)
            {
                handler();
            }
        }

        protected virtual void onCancelling()
        {
            close handler = cancelling;
            if (handler != null)
            {
                handler();
            }
        }
        # endregion

        /// <summary>
        /// Load sprite sheets to pick from
        /// </summary>
        public void loadSpriteSheets()
        {

            spriteSheets.Clear();
            comboBox1.Items.Clear();

            foreach (string s in Settings.Resources)
            {
                if (Path.GetExtension(s) == ".png")
                {
                    spriteSheets.Add(s);
                    comboBox1.Items.Add(Path.GetFileName(s));
                }
                else
                {
                    Debug.WriteLine(Path.GetExtension(s));
                }
            }
        }

        private void drawBox(int x, int y)
        {
            Debug.WriteLine("drawBox");

            if (comboBox1.SelectedIndex > -1)
            {
                string path = Settings.appPath + spriteSheets[comboBox1.SelectedIndex];
                Image basic = Image.FromFile(path);

                using (Graphics g = Graphics.FromImage(basic))
                {
                    Rectangle rect = new Rectangle(x, y, PixelSize.Width, PixelSize.Height);

                    g.DrawRectangle(new Pen(Color.Red), rect);
                }

                pictureBox1.Image = basic;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("comboBox1_SelectedIndexChanged");
            string path = spriteSheets[comboBox1.SelectedIndex];
            path = Settings.appPath + path;
            result = path;

            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.Size = pictureBox1.Image.Size;

            numX.Maximum = pictureBox1.Image.Width - PixelSize.Width;
            numY.Maximum = pictureBox1.Image.Height - PixelSize.Height;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int x = (int)numX.Value;// *PixelSize;
            int y = (int)numY.Value;// *PixelSize;

            procPos(x, y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("pictureBox1_MouseClick");
            double x = (int)e.X;
            double y = (int)e.Y;

            int ix = (int)Math.Floor(x / (PixelSize.Width + (int)numSpacer.Value)) * PixelSize.Width;
            int iy = (int)Math.Floor(y / (PixelSize.Height + (int)numSpacer.Value)) * PixelSize.Height;

            if (checkBox1.Checked)
            {
                x = ix;
                y = iy;
            }

            procPos(x, y);

            this.ActiveControl = null;
        }

        private void procPos(double x, double y)
        {
            Debug.WriteLine("procPos");

            int ix = (int)x;
            int iy = (int)y;

            # region cap x
            if (ix > numX.Maximum)
            {
                ix = (int)numX.Maximum;
            }
            numX.Value = ix;
            # endregion

            # region cap y
            if (iy > numY.Maximum)
            {
                iy = (int)numY.Maximum;
            }
            numY.Value = iy;
            # endregion

            drawBox(ix, iy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onSaving();
            onClosing();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numX.Increment = PixelSize.Width + numSpacer.Value;
                numY.Increment = PixelSize.Height + numSpacer.Value;
            }
            else
            {
                numX.Increment = 1;
                numY.Increment = 1;
            }
        }
    }
}
