using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    interface ICipher
    {
        public string Encode(string text);
        public string Decode(string text);
    }
}
