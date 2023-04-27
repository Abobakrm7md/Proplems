
using System;

Console.WriteLine(LengthOfLongestSubstring(" "));



static int LengthOfLongestSubstring(string s)
{
	int res = 0;
	if(string.IsNullOrEmpty(s))
		return 0;
	for (int i = 0; i < s.Length; i++)
	{
		for (int j = i; j < s.Length; j++)
		{
			if (IsDistincit(s, i, j))
				res = Math.Max(res, j - i + 1);
		}
	}
	return res;
}
static bool IsDistincit(string str , int frm , int to)
{
	bool[] visited = new bool[26];
	for (int k = frm; k <= to; k++)
	{
		if (visited[str[k] - 'a'] == true)
			return false;
		visited[str[k] - 'a'] = true;

    }
	return true;
}