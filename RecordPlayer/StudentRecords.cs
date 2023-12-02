using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesTable;

namespace RecordPlayer
{
    class StudentRecords
    {
        public record Person(string ID, string FirstName, string Surname, string TutorGroup, string Score); // 'Blue prints' for a record containing fields relative to a student
        public static Person[] StuData = new Person[]
        {

        };

        public void CreateRecord()
        {
            string[] fields = UsefulMethods.InputInLogs("ID~FirstName~Surname~TutorGroup~Score", 5);
            StuData = StuData.Append(new Person(fields[0], fields[1], fields[2], fields[3], fields[4])).ToArray();
        }

        public void LogRecords(string ClassName)
        {
            Console.WriteLine($"{ClassName}:");
            foreach (var student in StuData)
            {
                Console.WriteLine(student);
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
