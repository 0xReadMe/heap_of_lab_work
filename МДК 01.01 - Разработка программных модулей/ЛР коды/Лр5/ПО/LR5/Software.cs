using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    abstract class Software
    {
        public string name;
        public string code;
        public bool openSource;
        public string developer;
        public DateTime date;

        public Software(string name, string code, bool openSource, string developer)
        {
            this.name = name;
            this.code = code;
            this.openSource = openSource;
            this.developer = developer;
        }

        public abstract void InfoSoftware();

        public static Software[] CompareTo(Software[] n)
        {
            var soft = new List<Software>();
            for (int i = 0; i < n.Length; i++) 
            {
                soft.Add(n[i]);
            }
            soft.Sort((sft1, sft2) =>
            {
                var res = sft1.name.CompareTo(sft2.name);
                return res;
            });
            n = soft.ToArray();
            return n;
        }
    }
}
