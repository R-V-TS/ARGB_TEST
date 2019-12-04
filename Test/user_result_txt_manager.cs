using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    class user_result_txt_manager
    {
        string filePath;
        public void savedata(string data,string user_grade ,string user_file_path, string user_name,string user_group) {

            StreamWriter file = new StreamWriter(user_file_path+"\\data.txt");
            file.WriteLine(user_name +" "+user_group);
            file.WriteLine(data+" "+user_grade);
            file.Close();
        }
    }
}
