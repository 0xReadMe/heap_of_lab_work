using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    partial class Agent
    {
        public byte[] LogoTip
        {
            get
            {
                if (File.Exists($"{AgentLogo}"))
                { return File.ReadAllBytes($"{AgentLogo}"); }
                return null;
            }
        }
        public string CountRealization
        {
            get
            {
                int sum = RealizationProduct.Sum(s => s.ProductCount);
                return sum.ToString() + " ";
            }
        }
        public int Sale
        {
            get
            {
                decimal sum = (decimal)RealizationProduct.
                    Sum(s => s.ProductCount * s.Product.AgentMinPrice);
                if (sum < 10000) { return 0; }
                if (sum >= 10000 && sum < 50000) { return 5; }
                if (sum >= 50000 && sum < 150000) { return 10; }
                if (sum >= 150000 && sum < 500000) { return 20; }
                return 25;
            }
        }
        //public string AType
        //{
        //    get
        //    {
        //        return $"{AgentTypes.TypeName}";
        //    }
        //}
    }
}
