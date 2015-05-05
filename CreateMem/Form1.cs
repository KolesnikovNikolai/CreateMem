using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateMems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CreateMem cr;
        private void Form1_Load(object sender, EventArgs e)
        {
            cr = new CreateMem();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog(); // если файл выбран - и возвращен результат OK 
            if (res == DialogResult.OK)
            {
                string url = openFileDialog1.FileName;  // адрес изображения полученный с помощью окна выбора файла 
                cr.LoadImage(url);
                Draw(cr.getImage());
                numericUpDown1.Maximum = cr.getImage().Width;
                numericUpDown2.Maximum = cr.getImage().Height;
                numericUpDown3.Maximum = cr.getImage().Width;
                numericUpDown4.Maximum = cr.getImage().Height;
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке изображения.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog(); // если файл выбран - и возвращен результат OK 
            if (res == DialogResult.OK)
            {
                string url = saveFileDialog1.FileName;  // адрес изображения полученный с помощью окна выбора файла 
                cr.SaveImage(url+".jpg");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex){
                case 0: cr.SetUpText(textBox2.Text); cr.SetTextOnImageUp(); break;
                case 1: cr.SetDownText(textBox2.Text); cr.SetTextOnImageDown(); break;
                case 2: cr.SetTextOnImage(
                    (int)numericUpDown1.Value,
                    (int)numericUpDown2.Value,
                    (int)numericUpDown3.Value,
                    (int)numericUpDown4.Value,
                    textBox2.Text); break;
            }
            Draw(cr.getImage());
        }
        void Draw(Bitmap img){
            Graphics graphics1 = panel1.CreateGraphics();
            graphics1.DrawImage(img, new Point(0, 0));
        }
    }
}
