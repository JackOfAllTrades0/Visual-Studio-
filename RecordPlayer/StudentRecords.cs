using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesTable;

namespace RecordPlayer
{
    class StudentRecords
    {
        public static string ClassName;
        public StreamWriter sw = new StreamWriter("Class_Records.txt", append: true);
        public StreamReader sr = new StreamReader("Class_Records.txt");
        public static List<int> Order_Length = new List<int>();     
        public static IDictionary<string, List<int>> OrdinalFiles = new Dictionary<string, List<int>>(); // contains a dictionary of all record names and the order they were
        public record Person(string ID, string FirstName, string Surname, string TutorGroup, string Score); // 'Blue prints' for a record containing fields relative to a student
        public static Person[] StuData = new Person[]
        {

        };

        public StudentRecords(string nameOfClass ) 
        {
            ClassName = nameOfClass;
        }

        public void CreateRecord()
        {
            string[] fields = UsefulMethods.InputInLogs("ID~FirstName~Surname~TutorGroup~Score", 5);
            StuData = StuData.Append(new Person(fields[0], fields[1], fields[2], fields[3], fields[4])).ToArray();
        }

        public void LogRecords()
        {
            Console.WriteLine($"{ClassName}:");
            foreach (var student in StuData)
            {
                Console.WriteLine(student);
            }
        }

        public void SaveCurrentRecord()
        {
            int numlines = 0;
            using (sw)
            {
                sw.WriteLine(" - \n" + ClassName + ":");
                foreach (var student in StuData)
                {
                    sw.WriteLine("-" + student);
                    numlines++;
                }
                sw.WriteLine("End of Class Record");
                Order_Length.Add(OrdinalFiles.Count + 1);
                Order_Length.Add(numlines + 3);
                OrdinalFiles.Add(ClassName, Order_Length);
            }
        }

        public void LoadRecord()
        {
            List<string> FileContents = new List<string> { };
            try
            { 
                using (sr)
                {
                    while (sr.Peek() > -1)
                    {
                        FileContents.Append(sr.ReadLine());
                    }
                }
            }
            catch(Exception e)
            {
                
            }
        }

       
    }

}

namespace System.Runtime.CompilerServices
{
   /// using System.ComponentModel;
    /// <summary>
    /// Reserved to be used by the compiler for tracking metadata.
    /// Tis class should not be used by developers in scource code.
    /// </summary>  
    ///[EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit
    { 
    }
}
