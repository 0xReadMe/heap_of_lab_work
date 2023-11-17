using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (sampleEntities db = new sampleEntities())
            {
                // insert
                int numberOfRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO employee values(11111,'Julia','Long',NULL);");
                Console.WriteLine($"{numberOfRowInserted} - rows affected (INSERT) | without enter param");
                // update
                int numberOfRowUpdated = db.Database.ExecuteSqlCommand("UPDATE project SET budget = budget/10+budget WHERE project_no IN(SELECT project_no FROM works_on WHERE job='Manager' AND emp_no=10102);");
                Console.WriteLine($"{numberOfRowUpdated} - rows affected (UPDATE) | without enter param");
                // delete
                try 
                {
                    int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM department WHERE location = 'Seattle'");
                    Console.WriteLine($"{numberOfRowDeleted} - rows affected (DELETE) | without enter param");
                }
                catch 
                {
                    Console.WriteLine("Не смогли выполнить удаление, возможно элемента не существует");
                    int numberOfRowDeleted = 0;
                    Console.WriteLine($"{numberOfRowDeleted} - rows affected (DELETE) | without enter param");
                }
                // Query with enter param
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%Иван%");
                int numberOfRowInserted2 = db.Database.ExecuteSqlCommand("INSERT INTO employee values(21111,'@name','Long',NULL);");
                Console.WriteLine($"{numberOfRowInserted2} - rows affected (INSERT) | with enter param");
            }
        }
    }
}

