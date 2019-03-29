using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Imager
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1, bitmap2;
        public Form1()
        {
            InitializeComponent();
        }
        private bool ImageCompareString(Bitmap bit1, Bitmap bit2)
        {
            MemoryStream ms = new MemoryStream();
            bit1.Save(ms, ImageFormat.Png);
            string first = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;
            bit2.Save(ms, ImageFormat.Png);
            string second = Convert.ToBase64String(ms.ToArray());
            if (first.Equals(second))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                bitmap1 = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = ofd.FileName;
                bitmap2 = new Bitmap(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool compare =  ImageCompareString(bitmap1, bitmap2);
            if (compare == true)
            {
                MessageBox.Show("A Match");
            }
            else
            {
                MessageBox.Show("Not a match");
            }
        }

    }
}
