using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mystuff;

namespace RecordPlayer
{
    class StudentRecords
    {
        public static string ClassName;
        private List<string> classNames = new List<string>();
        public StreamWriter sw = new StreamWriter("Class_Records.txt",append:true);
        public StreamReader sr = new StreamReader("Class_Records.txt");
        public static Dictionary<string , int> OrdinalRecords = new Dictionary<string, int>();
        public List<string> FileContents = new List<string> { };
        public record Person(string ID, string FirstName, string Surname, string TutorGroup, string Score); // 'Blue prints' for a record containing fields relative to a student
        public static Person[] StuData = new Person[]
        {

        };

        public StudentRecords( ) 
        {
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
            catch (Exception e)
            {
                Console.WriteLine("Couldn't access file: ");
                Console.WriteLine(e.Message);
            }
        }

        public void CreateRecords()
        {
            bool ArrayFinished = false;
            const string y = "y";
            do
            {
                string[] fields = UsefulMethods.InputInLogs("ID~FirstName~Surname~TutorGroup~Score", 5);
                StuData = StuData.Append(new Person(fields[0], fields[1], fields[2], fields[3], fields[4])).ToArray();
                Console.Write("Would you like to continue? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "n")
                    ArrayFinished = true;
                else
                    ArrayFinished = false;

            } while (ArrayFinished == false);
           
        }

        public void LogRecords()
        {
            Console.WriteLine($"{ClassName}:");
            foreach (var student in StuData)
            {
                Console.WriteLine(student);
            }
        }

        public void SaveCurrentRecord(string mode)
        {
            if (mode == "save")
            {
                int numlines = 0;
                using (sw)
                {
                    sw.WriteLine(ClassName + ":");
                    foreach (var student in StuData)
                    {
                        sw.WriteLine("-" + student);
                        numlines++;
                    }
                    sw.Write("End of" + ClassName + "\n - ");
                    OrdinalRecords[ClassName] = numlines;
                }
            }
            else if (mode == "replace")
            {
                int startIndex = FileContents.IndexOf(ClassName);
                int endIndex = FileContents.IndexOf("End of" + ClassName);

                using (sw)
                {
                    
                }
            }
          
        }

        public void ClearRecords()
        {
            Array.Clear(StuData, 0, StuData.Length);
        }

        public void LoadRecord()
        {
            int StartIndex = FileContents.IndexOf(ClassName);
            int RecordDuration = OrdinalRecords[ClassName];
            string[] LoadedRecord = (string[])FileContents.Skip(StartIndex + 1).Take(RecordDuration);
            string[] FieldArray = { };
            Array.Clear(StuData, 0, StuData.Length);
            foreach (var student in LoadedRecord)
            {
                foreach (var field in student)
                {
                    FieldArray.Append(field.ToString());
                }
                StuData = StuData.Append(new Person(FieldArray[0], FieldArray[1], FieldArray[2], FieldArray[3], FieldArray[4])).ToArray();
            }

        }

        public List<string> ClassNames
        {
            get { return classNames; }
            set { classNames=value; }
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
