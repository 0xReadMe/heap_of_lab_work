using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person
    {
        string fam;
        int tab;
        int salary;

        public string Fam {
            get => fam;
            set => fam = value; 
        }
        public int Tab
        {
            get => tab;
            set => tab = value;
        }
        public int Salary
        {
            get => salary;
            set 
            {
                if (value > 30000 && value < 50000)
                {
                    salary = value;
                }
                else 
                {
                    salary = 30000;
                }
            }
        }

        public Person() 
        {
        
        }

        public Person(string fam, int tab, int salary) 
        {
            Fam = fam;
            Tab = tab;
            Salary = salary;
        }
    }
}
