using System;
using System.IO;

namespace BinaryFileApplication
{
    class Program
    {
      
        public void WriteToFile(int numItems)
        {
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Append));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot Access file.");
                return;
            }

            for (int i = 0; i < numItems; i++)
            {
                try
                {
                    Console.Write("What would you like to write to the file?: ");

                    bw.Write();

                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message + "\n Cannot write to file.");
                    return;
                }
                bw.Close();

            }
          

        }

        public void ReadFile()
        {
            BinaryWriter bw;
            BinaryReader br;
        }
        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;

            int i = 25;
            double d = 3.14157;
            bool b = true;
            string s = "I am happy";

            //create the file
        

            //writing into the file
            

            //reading from the file
            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                i = br.ReadInt32();
                Console.WriteLine("Integer data: {0}", i);
                d = br.ReadDouble();
                Console.WriteLine("Double data: {0}", d);
                b = br.ReadBoolean();
                Console.WriteLine("Boolean data: {0}", b);
                s = br.ReadString();
                Console.WriteLine("String data: {0}", s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
            Console.ReadKey();
        }
    }
}