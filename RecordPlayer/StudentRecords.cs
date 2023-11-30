using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordPlayer
{
    class StudentRecords
    {
        public record Person(string ID, string FirstName, string Surname, string TutorGroup, int Score); // 'Blue prints' for a record containing fields relative to a student
        public static Person[] StuData;

        static void LogRecords(int numRecords)
        {
            for (int i = 0; i < numRecords; i++)
            {
                Console.Write("Enter Id: ", );
                
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
