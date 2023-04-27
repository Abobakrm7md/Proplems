
using System;

Console.WriteLine(Reverse(-123));

static int Reverse(int x)
{
    int result = 0;
    while (x != 0)
    {
        var val = x % 10;
        var temp = result * 10 + val;
        if ((temp - val) / 10 != result) return 0;
        result = temp;
        x = x / 10;
    }
    return result;
}