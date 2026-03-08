// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

Console.WriteLine(FindDifferentBinaryString(["111", "011", "001"]));



static string FindDifferentBinaryString(string[] nums)
{
    StringBuilder result = new StringBuilder();


    for (int i = 0; i < nums.Length; i++)
    {
        if (nums.Length != nums[i].Length)
            return string.Empty;
        if(nums[i].Length < 1 || nums[i].Length > 16)
            return string.Empty;
        if (nums[i][i] == '0')
            result.Append('1');
        else result.Append('0');

    }
    return result.ToString();
}