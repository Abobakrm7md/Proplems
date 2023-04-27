
using System;

string[] strs = { "dog", "dracecar", "dcar" };

Console.WriteLine(LongestCommonPrefix(strs));

static string LongestCommonPrefix(string[] strs)
{
    int arrLength = strs.Length;
    string res = strs[0];
    int firstElementCountLength = res.Length;

    //loop on arr without first element
    for (int i = 1; i < arrLength; i++)
    {
        int strsLength = strs[i].Length;
        //loop on another elements in arr
        for (int j = 0; j < firstElementCountLength; j++)
        {
            //compare current element with first element , get max match , substring all matched
            if (j == strsLength || strs[i][j] != res[j])
            {
                res = res.Substring(0, j);
                firstElementCountLength = res.Length;
                if (firstElementCountLength == 0) return "";
                break;
            }
        }
    }
    return res;
}