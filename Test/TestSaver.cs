using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Test
{
    class TestSaver
    {
        string filePath;
        public static TestSaver instance;

        public void setPath(string path)
        {
            filePath = path;
        }

        public static TestSaver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestSaver();
                }
                return instance;
            }
        }

        public void Save_test(Test test_) {
            BinaryFormatter bf = new BinaryFormatter();
            filePath = Environment.CurrentDirectory + "\\test.dts";
            System.Diagnostics.Debug.WriteLine(filePath.ToString());
            FileStream fs = new FileStream(filePath, FileMode.Create);
            Save save = new Save();

            save.test_ = test_.ToString();
            
            bf.Serialize(fs, save);
            fs.Close();
        }

        public String Load_test() {
            filePath = Environment.CurrentDirectory + "\\test.dts";
            System.Diagnostics.Debug.WriteLine(filePath.ToString());
            if (!File.Exists(filePath))
            {
                return "NULL";
            }

            BinaryFormatter bf = new BinaryFormatter();
            
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Save save = (Save)bf.Deserialize(fs);

            String result = save.test_; 

            fs.Close();
            return result;
        }

    }

    [System.Serializable]
    public class Save
    {
        public String test_;
    }
}
