using System;
using System.Collections;
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
    public partial class TestForm : Form
    {
        string test = " ";
        UserTest ur;
        int count_quet;
        int q_id = 0;
        public TestForm()
        {
            InitializeComponent();
            ur = new UserTest(test);
            count_quet = ur.getQuestionCount();
            Print_quest(q_id);
            q_id++;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void Print_quest(int quid)
        {
            if(q_id < count_quet) {
                Question q_1 = ur.getNextQuestion();
                if (q_1.getType() == 1 || q_1.getType() == 2)
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    textBox1.Text = q_1.getQuestionTxt();
                    ArrayList al = q_1.getAnswers();
                    Answer_type_1 at1 = (Answer_type_1)al[0];
                    Ans1.Text = at1.answer_text;
                    at1 = (Answer_type_1)al[1];
                    Ans2.Text = at1.answer_text;
                    at1 = (Answer_type_1)al[2];
                    Ans3.Text = at1.answer_text;
                    at1 = (Answer_type_1)al[3];
                    Ans4.Text = at1.answer_text;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Print_quest(q_id);
            q_id++;
        }
    }
}
