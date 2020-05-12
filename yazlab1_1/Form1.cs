using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlab1_1
{
    public partial class Form1 : Form
    {
        Bitmap resim;
        Color renk;
        string resimDosyaYolu;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && (e.KeyValue == 's' || e.KeyValue == 'S'))
            {
                saveAsToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'o' || e.KeyValue == 'O'))
            {
                openToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'z' || e.KeyValue == 'Z'))
            {
                reopenToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'ı' || e.KeyValue == 'I'))
            {
                negativeToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'm' || e.KeyValue == 'M'))
            {
                mirroringToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'l' || e.KeyValue == 'L'))
            {
                leftToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'r' || e.KeyValue == 'R'))
            {
                rightToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'g' || e.KeyValue == 'G'))
            {
                grayScaleToolStripMenuItem_Click(sender, null);
            }

            if (e.Control == true && (e.KeyValue == 'h' || e.KeyValue == 'H'))
            {
                histogramToolStripMenuItem_Click(sender, null);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFile.FileName;
                resimDosyaYolu = path;
                resim = new Bitmap(path);
            }
            pictureBox1.Image = resim;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resim != null) {
                string path;
                SaveFileDialog saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = saveFile.FileName;
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    resim.Save(path);
                }
            }
            else
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try{
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        renk = Color.FromArgb(renk.A, 255 - renk.R, 255 - renk.G, 255 - renk.B);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void mirroringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width / 2; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        Color tmp = resim.GetPixel(resim.Width - x - 1, y);
                        resim.SetPixel(resim.Width - x - 1, y, renk);
                        resim.SetPixel(x, y, tmp);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap leftRotated = new Bitmap(resim.Height, resim.Width);
                for (int y = 0; y < leftRotated.Height; ++y)
                    for (int x = 0; x < leftRotated.Width; ++x)
                    {
                        renk = resim.GetPixel(resim.Width - y - 1, x);
                        leftRotated.SetPixel(x, y, renk);
                    }
                resim = leftRotated;
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap rightRotated = new Bitmap(resim.Height, resim.Width);
                for (int y = 0; y < rightRotated.Height; ++y)
                    for (int x = 0; x < rightRotated.Width; ++x)
                    {
                        renk = resim.GetPixel(y, resim.Height - x - 1);
                        rightRotated.SetPixel(x, y, renk);
                    }
                resim = rightRotated;
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        int ortalama = (int)((renk.R + renk.G + renk.B) / 3);
                        renk = Color.FromArgb(ortalama, ortalama, ortalama);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        renk = Color.FromArgb(renk.R, 0, 0);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        renk = Color.FromArgb(0, renk.G, 0);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        renk = Color.FromArgb(0, 0, renk.B);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        int channel = renk.R;
                        renk = Color.FromArgb(channel, channel, channel);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        int channel = renk.G;
                        renk = Color.FromArgb(channel, channel, channel);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        int channel = renk.B;
                        renk = Color.FromArgb(channel, channel, channel);
                        resim.SetPixel(x, y, renk);
                    }
                pictureBox1.Image = resim;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }

        private void reopenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resim != null)
            {
                resim = new Bitmap(resimDosyaYolu);
                pictureBox1.Image = resim;
            }
            else
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                histogramForm histogram = new histogramForm();
                
                for (int i = 0; i < 256; ++i)
                {
                    histogram.chart1.Series["R"].Points.AddXY(i, 0);
                    histogram.chart1.Series["G"].Points.AddXY(i, 0);
                    histogram.chart1.Series["B"].Points.AddXY(i, 0);
                }

                for (int y = 0; y < resim.Height; ++y)
                    for (int x = 0; x < resim.Width; ++x)
                    {
                        renk = resim.GetPixel(x, y);
                        ++histogram.chart1.Series["R"].Points[renk.R].YValues[0];

                        ++histogram.chart1.Series["G"].Points[renk.G].YValues[0];
                        ++histogram.chart1.Series["B"].Points[renk.B].YValues[0];
                    }
                histogram.Show();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Öncelikle File->Open ile bir resim açınız!", "Hata");
            }
        }



        private void helpShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CTRL+S -> Save\n" +
                            "CTRL+O -> Open\n" +
                            "CTRL+Z -> Reopen\n" +
                            "CTRL+I -> Invert\n" +
                            "CTRL+M -> Mirroring\n" +
                            "CTRL+L -> Left Rotate\n" +
                            "CTRL+R -> Right Rotate\n" +
                            "CTRL+G -> Gray Scale\n" +
                            "CTRL+H -> Histogram\n", "Help");
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
