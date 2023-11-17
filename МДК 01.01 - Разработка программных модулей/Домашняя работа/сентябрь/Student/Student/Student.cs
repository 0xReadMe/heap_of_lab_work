using System;


namespace Student
{
    class Student
    {
        public string Name;
        public int Course;
        public double Eveluations;
        public double Scholarship;
      
        public Student(string Name, int Course, double Eveluations)
        {
            this.Name = Name;
            this.Course = Course;
            this.Eveluations = Eveluations;
            if(Eveluations > 4)
                Scholarship = 1000;
            else
                Scholarship = 0;
        }
        public Student(string Name)
        {
            this.Name = Name;
            Console.WriteLine($"Мы ничего не знаем об этом студенте по имени {Name}");
        }
        public Student(string Name, double Scholarship)
        {
            this.Name = Name;
            if (Scholarship > 1000)
                Console.WriteLine($"Средний балл больше 4");
            else
                Console.WriteLine($"Средний балл меньше 4");
        }
    }
}
