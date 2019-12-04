using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class UserTest
    {
        private String testSTR;
        private Test test;
        public Test userTest_compl;
        private int id = -1;
        int[] userTestid;
        int[] userQuestionTypeCount;
        int[] userQuestionTypeCountSuccess = new int[4];

        public UserTest(String testPath)
        {
            TestSaver saver = new TestSaver();
            //saver.setPath(testPath);

            testSTR = saver.Load_test();
            parseSTR();
            generateUserTest();
        }

        private void parseSTR()
        {
            string[] testPRS = testSTR.Split('|');
            ArrayList questions = new ArrayList();
            for(int i = 10; i < testPRS.Length - 2; i += 3)
            {
                string[] test_11 = testPRS[i].Split('&');
                int testType = Int32.Parse(test_11[0]);
                string test_Question = test_11[1];
                ArrayList questionList = new ArrayList();
                int question_rate = 1;
                string[] questiond = testPRS[i + 1].Split('$');
                for(int j = 0; j < 4; j++)
                {
                    string[] questions_ = questiond[j].Split('-');
                    if(testType == 1 || testType == 2)
                    {
                        Answer_type_1 ans = new Answer_type_1();
                        ans.isChecked = bool.Parse(questions_[0]);
                        ans.answer_text = questions_[1];
                        questionList.Add(ans);
                    }
                    if (testType == 3)
                    {
                        Answer_type_2 ans = new Answer_type_2();
                        ans.answer_text = questions_[1];
                        ans.answer_equal_text = questions_[1];
                        questionList.Add(ans);
                    }
                }
                question_rate = Int32.Parse(testPRS[i+2]);
                questions.Add(new Question(test_Question, questionList, question_rate, testType));
            }
            int numberOfAllQuestion = Int32.Parse(testPRS[0]);
            int maxOfGraduate = Int32.Parse(testPRS[1]);
            int numberOfQuestion = Int32.Parse(testPRS[2]);
            int maxOfGraduateUser = Int32.Parse(testPRS[3]);
            int testTime = Int32.Parse(testPRS[4]);
            int questionTime = Int32.Parse(testPRS[5]);
            // Parse question of grad
            int[] gradearr = new int[4];
            for(int i = 0; i < 4; i++)
                gradearr[i] = Int32.Parse(testPRS[6+i]);
            userQuestionTypeCount = gradearr;
            test = new Test(numberOfQuestion, questions, maxOfGraduate, gradearr, testTime, questionTime, numberOfAllQuestion, maxOfGraduateUser);
            userTestid = new int[numberOfQuestion];
        }

        public int getQuestionCount()
        {
            return test.getQuestionCount();
        }

        public Question getNextQuestion()
        {
            id++;
            return (Question)test.getQuestion(userTestid[id]);
        }

        private void generateUserTest()
        {
            Random rnd = new Random();
            int i = 0;
            int l = -1;
            while (i < test.getQuestionCount())
            {
                
                bool isEq = true;
                Question q;
                int q_g;
                do
                {
                    if (l < test.getAllQuestionCount() - 1)
                        l++;
                    else
                        l = 0;
                    q = test.getQuestion(l);
                    q_g = q.getGraquate();
                    if(userQuestionTypeCount[q_g] > userQuestionTypeCountSuccess[q_g] + 1)
                    {
                        isEq = false;
                        continue;
                    }
                    for (int j = 0; j < i - 1; j++)
                    {
                        if (userTestid[i] == userTestid[j])
                        {
                            isEq = false;
                            break;
                        }
                    }
                } while (!isEq);
                if (isEq)
                {
                    userQuestionTypeCountSuccess[q_g]++;
                    userTestid[i] = l;
                    i++;
                }
            }
            System.Diagnostics.Debug.WriteLine(userTestid.ToString());
        }
    }
}
