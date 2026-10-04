
using System;

Console.WriteLine(BitwiseComplement(5));
Console.WriteLine("############################");
Console.WriteLine(BitwiseComplement2(5));
Console.WriteLine(BitwiseComplement1(5));



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
static int BitwiseComplement(int n)
{
    if (n == 0) return 1;

    int mask = 0;
    int temp = n;
    while (temp > 0)
    {
        mask = (mask << 1) | 1;
        temp >>= 1;
    }
    return n ^ mask;
}
static int BitwiseComplement2(int n) { if (n == 0) { return 1; } int mask = 0; for (int i = 0; i < 31; i++) { mask |= 1 << i; } return ~n; }
static int BitwiseComplement1(int n)
{
	if (n == 0) { return 1; }
	int mask = ~0;
	// Initialize mask with all bits set
	for (int i = 0; i < 31; i++)
	{ // Assuming32-bit integer
		mask &= ~(1 << i);
	}
	return (int)(~n & mask);
} // Perform bitwise AND operation between the bitwise NOT of n and the mask}


