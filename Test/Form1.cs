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
    public partial class Form1 : Form
    {
        // Config
        int all_question = 0, all_graduate = 0;
        int test_question = 0, test_graduate = 0;
        int test_time = 0, question_time = 0;
        int[] ques_graduate = { 0, 0, 0, 0 };
        int[] ques_graduate_setup = { 0, 0, 0, 0 };
        ArrayList questions2test = new ArrayList();
        ArrayList textBoxes = new ArrayList();
        ArrayList checkBoxes = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Выбор правильного(ых) ответа(ов)";
            gb_1.BackColor = Color.AliceBlue;
            gb_2.BackColor = Color.AliceBlue;
            gb_3.BackColor = Color.AliceBlue;
            groupBox2.BackColor = Color.AliceBlue;
            groupBox1.BackColor = Color.PaleTurquoise;
            button1.BackColor = Color.LightCyan;
            button2.BackColor = Color.LightCyan;
            button3.BackColor = Color.LightCyan;
            button4.BackColor = Color.LightCyan;
            button5.BackColor = Color.LightCyan;
            button6.BackColor = Color.LightCyan;

        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxes.Clear();
            checkBoxes.Clear();
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Выбор правильного(ых) ответа(ов)")
            {
                gb_2.Visible = false;
                gb_3.Visible = false;
                gb_1.Visible = true;
                textBoxes.Clear();
                textBoxes.Add(textBox3);
                textBoxes.Add(textBox4);
                textBoxes.Add(textBox5);
                textBoxes.Add(textBox6);
                checkBoxes.Clear();
                checkBoxes.Add(checkBox1);
                checkBoxes.Add(checkBox2);
                checkBoxes.Add(checkBox3);
                checkBoxes.Add(checkBox4);
            }
            else if (comboBox1.SelectedItem.ToString() == "Соответствие")
            {
                gb_1.Visible = false;
                gb_3.Visible = false;
                gb_2.Visible = true;
                textBoxes.Clear();
                textBoxes.Add(textBox7);
                textBoxes.Add(textBox11);
                textBoxes.Add(textBox8);
                textBoxes.Add(textBox12);
                textBoxes.Add(textBox9);
                textBoxes.Add(textBox13);
                textBoxes.Add(textBox10);
                textBoxes.Add(textBox14);
            }
            else if (comboBox1.SelectedItem.ToString() == "Свободный ввод ответа")
            {
                gb_1.Visible = false;
                gb_2.Visible = false;
                gb_3.Visible = true;
                textBoxes.Clear();
                textBoxes.Add(textBox7);
                textBoxes.Add(textBox11);
                textBoxes.Add(textBox8);
                textBoxes.Add(textBox12);
                textBoxes.Add(textBox9);
                textBoxes.Add(textBox13);
                textBoxes.Add(textBox10);
                textBoxes.Add(textBox14);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            query_save();
            //Функция сохранения вопроса
            comboBox1.Text = "";
            txt_1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox22.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            comboBox1.Text = "Выбор правильного(ых) ответа(ов)";
            textBoxes.Clear();
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);
            checkBoxes.Clear();
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            query_save();
            foreach (object l in questions2test)
            {
                Question q = (Question)l;
                System.Diagnostics.Debug.WriteLine(q.ToString());
            }
            comboBox1.Visible = false;
            gb_1.Visible = false;
            gb_2.Visible = false;
            gb_3.Visible = false;
            txt_1.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;

            //Result screen
            textBox1.Text = all_question.ToString();
            textBox15.Text = all_graduate.ToString();
            textBox16.Text = "0";
            textBox18.Text = "0/" + ques_graduate[0];
            textBox19.Text = "0/" + ques_graduate[1];
            textBox20.Text = "0/" + ques_graduate[2];
            textBox21.Text = "0/" + ques_graduate[3];
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Leave(object sender, EventArgs e)
        {

        }

        private void TextBox18_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TextBox18_Click(object sender, EventArgs e)
        {
            textBox18.Text = ques_graduate_setup[0].ToString();
        }

        private void TextBox18_Leave(object sender, EventArgs e)
        {
            sum_all_test_graduate();
            textBox18.Text = ques_graduate_setup[0].ToString() + "/" + ques_graduate[0].ToString();
        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            String s = textBox18.Text.ToString().Split('/')[0];
            s = s == "" ? "0" : s;
           
            if (int.Parse(s) > ques_graduate[0])
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox18.Text = ques_graduate[0].ToString();
                ques_graduate_setup[0] = ques_graduate[0];
            } else
            {
                ques_graduate_setup[0] = int.Parse(s);
            }

            if(test_question < sum_all_graduate())
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox18.Text = "0";
                ques_graduate_setup[0] = 0;
            }
        }

        private void TextBox19_Click(object sender, EventArgs e)
        {
            textBox19.Text = ques_graduate_setup[1].ToString();
        }

        private void TextBox19_Leave(object sender, EventArgs e)
        {
            sum_all_test_graduate();
            textBox19.Text = ques_graduate_setup[1].ToString() + "/" + ques_graduate[1].ToString();
        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {
            String s = textBox19.Text.ToString().Split('/')[0];
            s = s == "" ? "0" : s;

            if (int.Parse(s) > ques_graduate[1])
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox19.Text = ques_graduate[1].ToString();
                ques_graduate_setup[1] = ques_graduate[1];
            }
            else
            {
                ques_graduate_setup[1] = int.Parse(s);
            }

            if (test_question < sum_all_graduate())
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                ques_graduate_setup[1] = 0;
                textBox19.Text = "0";
            }
        }

        private void TextBox20_Click(object sender, EventArgs e)
        {
            textBox20.Text = ques_graduate_setup[2].ToString();
        }

        private void TextBox20_Leave(object sender, EventArgs e)
        {
            sum_all_test_graduate();
            textBox20.Text = ques_graduate_setup[2].ToString() + "/" + ques_graduate[2].ToString();
        }

        private void TextBox20_TextChanged(object sender, EventArgs e)
        {
            String s = textBox20.Text.ToString().Split('/')[0];
            s = s == "" ? "0" : s;

            if (int.Parse(s) > ques_graduate[2])
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox20.Text = ques_graduate[2].ToString();
                ques_graduate_setup[2] = ques_graduate[2];
            }
            else
            {
                ques_graduate_setup[2] = int.Parse(s);
            }

            if (test_question < sum_all_graduate())
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                ques_graduate_setup[2] = 0;
                textBox20.Text = "0";
            }
        }

        private void TextBox21_Click(object sender, EventArgs e)
        {
            textBox21.Text = ques_graduate_setup[2].ToString();
        }

        private void TextBox21_Leave(object sender, EventArgs e)
        {
            sum_all_test_graduate();
            textBox21.Text = ques_graduate_setup[3].ToString() + "/" + ques_graduate[3].ToString();
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            String s = textBox21.Text.ToString().Split('/')[0];
            s = s == "" ? "0" : s;

            if (int.Parse(s) > ques_graduate[3])
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox21.Text = ques_graduate[3].ToString();
                ques_graduate_setup[3] = ques_graduate[3];
            }
            else
            {
                ques_graduate_setup[3] = int.Parse(s);
            }

            if (test_question < sum_all_graduate())
            {
                MessageBox.Show("Количество вопросов не может быть больше чем общее количество вопросов!", "Ошибка");
                ques_graduate_setup[3] = 0;
                textBox21.Text = "0";
            }
        }

        private void Check_time_CheckedChanged(object sender, EventArgs e)
        {
            if (check_time.Checked == true)
            {
                txt_time.Visible = true;
            }
            else
            {
                txt_time.Visible = false;
                question_time = 0;
            }
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text.ToString() == "")
                textBox16.Text = "0";

            if(int.Parse(textBox16.Text.ToString()) > all_question)
            {
                MessageBox.Show("Количество вопросов в тесте не может быть больше чем общее количество вопросов!", "Ошибка");
                textBox16.Text = all_question.ToString();
            } else
            {
                test_question = int.Parse(textBox16.Text.ToString());
            }
        }

        private void TextBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;
            }
        }

        private void TextBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;
            }
        }


        private void TextBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;
            }
        }

        private void TextBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        
        private void TextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text.ToString() == "")
                textBox23.Text = "0";

            if (int.Parse(textBox23.Text.ToString()) > 180)
            {
                MessageBox.Show("Слишком большое время!", "Error");
                textBox23.Text = "180";
                test_time = 180;
            } else if(int.Parse(textBox23.Text.ToString()) < test_question * 0.5){
                MessageBox.Show("Слишком маленькое время время!", "Error");
                test_time = (int)(test_question * 0.5);
                textBox23.Text = test_time.ToString();
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            gb_1.Visible = true;
            gb_2.Visible = true;
            gb_3.Visible = true;
            txt_1.Visible = true;
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void GroupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void TextBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void Txt_time_TextChanged(object sender, EventArgs e)
        {
            question_time = int.Parse(txt_time.Text.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Test test = new Test(test_question, questions2test, all_graduate, ques_graduate_setup, test_time, question_time, all_question, test_graduate);
            System.Diagnostics.Debug.WriteLine(test.ToString());
        }

        private void query_save()
        {
            ArrayList ans = new ArrayList();
            String grad_txt = textBox2.Text.ToString() == "" ? "0" : textBox2.Text.ToString();
            int grad_q = int.Parse(grad_txt) > 4 ? 4 : int.Parse(grad_txt);
            grad_q = grad_q < 1 ? 1 : grad_q;

            if (comboBox1.SelectedItem.ToString() == "Выбор правильного(ых) ответа(ов)")
            {
                int checked_c = 0;
                ArrayList answers = new ArrayList();
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    Answer_type_1 ans1 = new Answer_type_1();
                    ans1.isChecked = ((CheckBox)checkBoxes[i]).Checked;
                    checked_c += ((CheckBox)checkBoxes[i]).Checked == true ? 1 : 0;
                    if (checked_c == 0 && i == checkBoxes.Count - 1)
                    {
                        ans1.isChecked = true;
                        checked_c = 1;
                    }
                    ans1.answer_text = ((TextBox)textBoxes[i]).Text.ToString();
                    answers.Add(ans1);
                }
                Question myQue = new Question(txt_1.Text.ToString(), answers, grad_q, checked_c > 1 ? 2 : 1);
                all_graduate += grad_q;
                all_question++;
                questions2test.Add(myQue);
            }
            else if (comboBox1.SelectedItem.ToString() == "Соответствие")
            {
                ArrayList answers = new ArrayList();
                for (int i = 0; i < textBoxes.Count; i += 2)
                {
                    Answer_type_2 ans1 = new Answer_type_2();
                    ans1.answer_text = ((TextBox)textBoxes[i]).Text.ToString();
                    ans1.answer_equal_text = ((TextBox)textBoxes[i + 1]).Text.ToString();
                    answers.Add(ans1);
                }
                Question myQue = new Question(txt_1.Text.ToString(), answers, grad_q, 3);
                all_graduate += grad_q;
                all_question++;
                questions2test.Add(myQue);
            }
            ques_graduate[grad_q - 1]++;
        }

        private int sum_all_graduate()
        {
            int sum = 0;
            foreach (int i in ques_graduate_setup)
                sum += i;
            return sum;
        }

        private void sum_all_test_graduate()
        {
            int sum = 0;
            for (int i = 0; i < ques_graduate_setup.Length; i++)
                sum += ((i + 1) * ques_graduate_setup[i]);
            textBox17.Text = sum.ToString();
            test_graduate = sum;
        }
    }
}
