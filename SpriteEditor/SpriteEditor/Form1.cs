using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;



namespace SpriteEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            pictureBox2.AllowDrop = true;
        }

        public void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var filesNames = data as string[];
                if (filesNames.Length > 0)
                {
                    pictureBox1.Image = Image.FromFile(filesNames[0]);
                    textBox1.Text = Path.GetFileName(filesNames[0].ToString());
                    textBox2.Text = fileList[0].ToString();
                }
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList2 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var filesNames = data as string[];
                if (filesNames.Length > 0)
                {
                    pictureBox2.Image = Image.FromFile(filesNames[0]);
                    //File.Copy()
                    File.Copy(filesNames[0].ToString(), $@"Temp\{textBox1.Text}", true);
                }
            }
        }

        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
    
}
