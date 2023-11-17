using System;

namespace ConsoleApp1
{
    internal class Rectangle
    {
        public Line a1;
        public Line a2;
        public Line b1;
        public Line b2;
        public Rectangle(Line a1, Line a2, Line b1, Line b2)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b1 = b1;
            this.b2 = b2;
        }
    }
}
