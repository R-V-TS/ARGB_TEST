using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace Test
{
    class TestSaver
    {
        string filePath;
        public static TestSaver instance;
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
            FileStream fs = new FileStream(filePath, FileMode.Create);
            Save save = new Save();

            save.test_ = test_.ToString();
            
            bf.Serialize(fs, save);
            fs.Close();
        }

        public void Load_test() {
            if (!File.Exists(filePath))
            {
                return;
            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Save save = (Save)bf.Deserialize(fs);
            
            fs.Close();
        }

    }

    [System.Serializable]
    public class Save
    {
        public String test_;
    }
}
