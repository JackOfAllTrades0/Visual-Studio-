using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Time
{
    public class TimeFilingSystem
    {
        public DateTime TimeSaved; // Time at which the data was saved
        public string namedata;
        private StreamReader sr;
        private StreamWriter sw;

        public TimeFilingSystem(DateTime Atimesaved, string anamedata)
        {
            TimeSaved = Atimesaved;
            namedata = anamedata;
            Console.WriteLine("Initialising Filing System");
        }

        public void WriteTimeFile()
        {
            using (sw = new StreamWriter("LoggedTime.txt", append: true))
            {
                sw.WriteLine($"Name: {namedata}  ,  Saved On: {TimeSaved.ToString()}");
            }
        }

        public void ReadTimeFile()
        {
            int count = 0;
            using (sr = new StreamReader("LoggedTime.txt"))
            {
                while (sr.ReadLine() != null)
                {
                    if (count == 0)
                    {
                        sr.DiscardBufferedData();
                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    }
                    count = 1;
                    sr.ReadLine();
                }

            }

        }

    }

 
}
