using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime;

namespace Test
{
    struct Answer_type_1
    {
        public String answer_text;
        public Boolean isChecked;
    }
    struct Answer_type_2
    {
        public String answer_text;
        public String answer_equal_text;
    }
    class Question
    {
        /*Переменные для сохранения*/
        String question_text;
        ArrayList answer_vector = new ArrayList();
        int grade;
        int type;

        public Question(String question_txt, ArrayList answ_vec, int grade_, int type_)
        {
            question_text = question_txt;
            foreach(object l in answ_vec)
            {
                answer_vector.Add(l);
            }
            grade = grade_;
            type = type_;
        }

        public override String ToString(){
            String ques_str = "%q%";
            ques_str += type.ToString() + " %a% " + question_text + " | ";
            foreach(object l in answer_vector){
                if(type == 1 || type == 2){
                    Answer_type_1 ans = (Answer_type_1)l;
                    ques_str += ans.isChecked + " - " + ans.answer_text + " %a% ";
                }
                else if(type == 3)
                {
                    Answer_type_2 ans = (Answer_type_2)l;
                    ques_str += ans.answer_text + " - " + ans.answer_equal_text + " %a% ";
                }
            }
            ques_str += " %a% " + grade.ToString() + " ";

            return ques_str;
        }


    }
    
}
