// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

Console.WriteLine(CheckOnesSegment("1010"));

static int MinFlips(string s)
{
    int n = s.Length;
    string s2 = s + s; // مضاعفة السلسلة لمحاكاة الدوران

    // الأنماط المستهدفة (0101... و 1010...)
    StringBuilder target1 = new StringBuilder();
    StringBuilder target2 = new StringBuilder();

    for (int i = 0; i < s2.Length; i++)
    {
        target1.Append(i % 2 == 0 ? '0' : '1');
        target2.Append(i % 2 == 0 ? '1' : '0');
    }

    int diff1 = 0, diff2 = 0;
    int left = 0;
    int minFlips = int.MaxValue;

    for (int right = 0; right < s2.Length; right++)
    {
        // 1. إضافة الحرف الجديد لجهة اليمين في الحسبة
        if (s2[right] != target1[right]) diff1++;
        if (s2[right] != target2[right]) diff2++;

        // 2. إذا كبر حجم الشباك عن n، "نطرح" تأثير الحرف اللي خرج من الشمال
        if ((right - left + 1) > n)
        {
            if (s2[left] != target1[left]) diff1--;
            if (s2[left] != target2[left]) diff2--;
            left++; // تحريك بداية الشباك
        }

        // 3. لما الشباك يوصل للحجم n بالظبط، نشوف أقل عدد تغييرات
        if ((right - left + 1) == n)
        {
            minFlips = Math.Min(minFlips, Math.Min(diff1, diff2));
        }
    }

    return minFlips;
}

static bool CheckOnesSegment(string s)
{
    // إذا وجدنا "01" فهذا يعني أن هناك قطعة وحايد بدأت بعد ما قطعة انتهت
    return !s.Contains("01");
}