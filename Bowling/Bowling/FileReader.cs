using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Bowling
{
    public class FileReader
    {
        private readonly string _fileName;

        public FileReader(string fileName)
        {
            _fileName = fileName;   
        }

        public char[] ReadCharFromFile()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadLine().ToCharArray();
                }
            }
        }

        public List<char[]> ReadListFromFile()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    List<char[]> scores = new List<char[]>();
                    while (!sr.EndOfStream)
                    {
                        char[] game = sr.ReadLine().ToCharArray();
                        scores.Add(game);
                    }
                    return scores;
                }
            }
        }
    }
}
