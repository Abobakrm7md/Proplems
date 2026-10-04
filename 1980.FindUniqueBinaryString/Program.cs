// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

//Console.WriteLine(FindDifferentBinaryString(["111", "011", "001"]));
Console.WriteLine(NumSpecial([[1, 0, 0], [0, 0, 1], [1, 0, 0]]));



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

static int NumSpecial(int[][] mat)
{
    int rows = mat.Length;
    int cols = mat[0].Length;

    // مصفوفات لتخزين عدد الآحاد في كل صف وكل عمود
    int[] rowCount = new int[rows];
    int[] colCount = new int[cols];

    // الخطوة الأولى: حساب عدد الآحاد في كل صف وعمود
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (mat[r][c] == 1)
            {
                rowCount[r]++;
                colCount[c]++;
            }
        }
    }

    int specialPositions = 0;

    // الخطوة الثانية: التحقق من المواقع التي تحتوي على 1 وتطبق الشرط
    for (int r = 0; r < rows; r++)
    {
        // تحسين بسيط: إذا كان الصف لا يحتوي إلا على واحد، نبحث في أعمدته
        if (rowCount[r] == 1)
        {
            for (int c = 0; c < cols; c++)
            {
                if (mat[r][c] == 1 && colCount[c] == 1)
                {
                    specialPositions++;
                }
            }
        }
    }

    return specialPositions;
}
