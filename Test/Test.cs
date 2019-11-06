using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Test
    {
        int number_of_quest;
        ArrayList answerarray = new ArrayList();
        int max_of_grad;
        int[] gradearray;
        int time_for_test;
        int time_for_question;
        int numb_of_all_quest;
        int count_grade;

        public Test(int numb_of_quest, ArrayList ansarray, int max_of_grade_, int[] gradearr, int time_for_test_, int time_for_quest_, int numb_of_all_quest_, int count_grade_)
        {
            number_of_quest = numb_of_quest;
            foreach(object i in ansarray)
            {
                answerarray.Add(i);
            }
            max_of_grad = max_of_grade_;
            gradearray = gradearr;
            time_for_test = time_for_test_;
            time_for_question = time_for_quest_;
            numb_of_all_quest = numb_of_all_quest_;
            count_grade = count_grade_;
        }

        public override String ToString()
        {
            String time_test_str = "";
            time_test_str += numb_of_all_quest.ToString() + " | " + max_of_grad.ToString() + " | " + " | " + number_of_quest.ToString() + " | " + count_grade.ToString() + " | " + time_for_test.ToString() + " | " + time_for_question.ToString() +  " | ";
            foreach(int l in gradearray)
            {
                time_test_str += l.ToString() + " | ";
            }
            time_test_str += "\n";
            foreach(object k in answerarray)
            {
                time_test_str += ((Question)k).ToString() + " | \n";
            }
            return time_test_str;
        }
    }
}
