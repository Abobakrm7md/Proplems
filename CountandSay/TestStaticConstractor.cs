using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountandSay
{
    class TestStaticConstractor
    {
        static TestStaticConstractor()
        {
            Console.WriteLine("Static intialized");
        }
        public TestStaticConstractor()
        {
            Console.WriteLine("Public intialized");
        }
    }
}
