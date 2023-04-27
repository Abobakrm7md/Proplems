using System;
using System.Text;


Console.WriteLine(ReverseWords("Let's take LeetCode contest"));





static string ReverseWords(string s)
{
	if (string.IsNullOrEmpty(s))
		return string.Empty;
	s = s.TrimStart().TrimEnd();
    string[] splitedString = s.Split(' ');
    StringBuilder reversedStringBuilder = new StringBuilder();
    foreach (string item in splitedString)
	{
		StringBuilder reversedItem = new StringBuilder();
		for (int i = item.Length - 1; i >= 0 ; i--)
		{
			reversedItem.Append(item[i]);
        }
		reversedStringBuilder.Append(" " + reversedItem.ToString());
	}
    return reversedStringBuilder.ToString().TrimEnd().TrimStart();

}