using System;
using System.Text;

namespace CountandSay
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStaticConstractor testStatic = new TestStaticConstractor();
            //Console.WriteLine(CountandSay(10));
        }
        static string CountandSay(int n)
        {
            if (n == 1) return "1";
            if (n == 2) return "11";
            string str = "11";
            for (int i = 3; i <= n; i++)
            {
                str += '$';
                int len = str.Length;

                int cnt = 1; 
                string tmp = "";
                char[] arr = str.ToCharArray();
                for (int j = 1; j < len; j++)
                {
                    if (arr[j] != arr[j - 1])
                    {
                        tmp += cnt + 0;
                        tmp += arr[j - 1];
                        cnt = 1;
                    }
                    else cnt++;
                }
                str = tmp;
            }

            return str;
        }
    }
}
