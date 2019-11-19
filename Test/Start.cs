using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
            //groupBox1.Visible = false;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.ToString() == "")
                MessageBox.Show("Выберите файл!", "Error");
            else
            {
                label1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                textBox3.Visible = false;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                button3.Visible = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //groupBox1.Visible = true;
            textBox3.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
        }
    }
}
