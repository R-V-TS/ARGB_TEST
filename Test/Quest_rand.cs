using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Quest_rand
    {
        String cur_quest;
        List<int> bunch_of_ans = new List<int>();

        public static List<T> Shuffle<T> (List<T> list)
        {
            Random rnd = new Random();
            for (int i =0; i<list.Count;i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
        }
        public Quest_rand(String curr_question, List<int> bunch_of_answers)
        {
            cur_quest = curr_question;
            foreach (var item in bunch_of_answers)
            {
                bunch_of_ans.Add(item);
            }
            Console.WriteLine(bunch_of_answers);
            bunch_of_ans = Shuffle(bunch_of_ans);
            Console.WriteLine(bunch_of_ans);
            System.Diagnostics.Debug.WriteLine(bunch_of_answers);
            System.Diagnostics.Debug.WriteLine(bunch_of_ans);
        }
    }
}
