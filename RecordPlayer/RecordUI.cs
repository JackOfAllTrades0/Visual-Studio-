using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecordPlayer
{
    class RecordUI
    {
        static void Main(string[] args)
        {
            StudentRecords RecordIt = new StudentRecords();
            RecordIt.CreateRecord();

            Console.ReadKey();
        }

    }
}
