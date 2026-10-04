// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(CountBinarySubstrings("00110011"));

static int NumberOfStableArrays(int zero, int one, int limit)
{
    long MOD = 1_000_000_007;

    // dp[i][j][k] حيث:
    // i: عدد الأصفار المستخدمة
    // j: عدد الآحاد المستخدمة
    // k: الرقم الأخير المضاف (0 أو 1)
    long[,,] dp = new long[zero + 1, one + 1, 2];

    // الحالات الأساسية (Base Cases)
    // بناء مصفوفات تحتوي على أصفار فقط (بشرط عدم تجاوز الـ limit)
    for (int i = 0; i <= Math.Min(zero, limit); i++)
    {
        dp[i, 0, 0] = 1;
    }
    // بناء مصفوفات تحتوي على آحاد فقط (بشرط عدم تجاوز الـ limit)
    for (int j = 0; j <= Math.Min(one, limit); j++)
    {
        dp[0, j, 1] = 1;
    }

    for (int i = 1; i <= zero; i++)
    {
        for (int j = 1; j <= one; j++)
        {

            // 1. حساب احتمالات إنهاء المصفوفة بصفر (dp[i, j, 0])
            // هي مجموع الطرق لإنهاء مصفوفة بـ (i-1) صفر و (j) واحد سواء انتهت بـ 0 أو 1
            dp[i, j, 0] = (dp[i - 1, j, 0] + dp[i - 1, j, 1]) % MOD;

            // إذا زاد عدد الأصفار عن الـ limit، يجب طرح الحالات غير المستقرة
            if (i > limit)
            {
                // الحالات غير القانونية هي التي كانت تنتهي بـ 1 ثم أضفنا بعدها (limit + 1) من الأصفار
                dp[i, j, 0] = (dp[i, j, 0] - dp[i - limit - 1, j, 1] + MOD) % MOD;
            }

            // 2. حساب احتمالات إنهاء المصفوفة بواحد (dp[i, j, 1])
            dp[i, j, 1] = (dp[i, j - 1, 0] + dp[i, j - 1, 1]) % MOD;

            // إذا زاد عدد الآحاد عن الـ limit، نطرح الحالات غير المستقرة
            if (j > limit)
            {
                // الحالات غير القانونية هي التي كانت تنتهي بـ 0 ثم أضفنا بعدها (limit + 1) من الآحاد
                dp[i, j, 1] = (dp[i, j, 1] - dp[i, j - limit - 1, 0] + MOD) % MOD;
            }
        }
    }

    // النتيجة النهائية هي مجموع الحالات التي تنتهي بصفر أو واحد عند استهلاك كل الأعداد
    return (int)((dp[zero, one, 0] + dp[zero, one, 1]) % MOD);
}


static int CountBinarySubstrings(string s)
{
    int currentGroupLength = 1;
    int previousGroupLength = 0;
    int totalCount = 0;

    for (int i = 1; i < s.Length; i++)
    {
        if (s[i] == s[i - 1])
        {
            // إذا كان الرقم مثل السابق، نزيد طول المجموعة الحالية
            currentGroupLength++;
        }
        else
        {
            // إذا اختلف الرقم، نجمع الحد الأدنى بين المجموعة السابقة والحالية
            totalCount += Math.Min(previousGroupLength, currentGroupLength);
            // تصبح المجموعة الحالية هي السابقة، ونبدأ عدّ مجموعة جديدة
            previousGroupLength = currentGroupLength;
            currentGroupLength = 1;
        }
    }

    // لا ننسى آخر مجموعتين بعد نهاية الحلقة
    totalCount += Math.Min(previousGroupLength, currentGroupLength);

    return totalCount;
}