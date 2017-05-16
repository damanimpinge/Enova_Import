using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelImport
{
    class Program
    {
        static void Main(string[] args)
        {

            ImportExcel _import = new ImportExcel();

           var result= _import.ImportExceltoEnovaDb();
           if (result)
           { Console.WriteLine("Data Inserted in the database successfully"); }
           else {
               Console.WriteLine("Error while inserting the data in the database");
           }
            Console.ReadLine();

        }
    }
}
