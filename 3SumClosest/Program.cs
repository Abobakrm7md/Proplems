


using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

ValidatePIN("1234");


//int[] myNum = { -1, 2, 1, -4 };

//Console.WriteLine(ThreeSumClosest(myNum, 1));

static int ThreeSumClosest(int[] nums, int target)
{
    if (nums == null || nums.Count() < 3)
    {
        return int.MaxValue;
    }

   Array.Sort(nums);
    int numsCount = nums.Count();
    var diff = int.MaxValue;
    for (var i = 0; i < numsCount; i++)
    {
        var next = i + 1;
        var last = numsCount - 1;
        while (next < last)
        {
            var sum = nums[i] + nums[next] + nums[last];
            var tempdiff = Math.Abs(sum - target);
            if (tempdiff < Math.Abs(diff))
            {
                diff = sum - target;
            }
            if (sum >= target)
            {
                last--;
            }
            else if (sum < target)
            {
                next++;
            }
        }
    }

    return diff + target;
}


 static string ValidatePIN(string ATMPIN)
{
    if (ATMPIN.Length >= 4)
    {
        foreach (char value in ATMPIN)
        {
            if(!char.IsDigit(value))
                return "The ATM PIN is invalid";
        }
        //bool isDigitPresent = ATMPIN.Any(c => !char.IsDigit(c));
        //if (isDigitPresent)

        if(!CheckUniqness(ATMPIN))
            return "The ATM PIN is invalid";

        return "\"The ATM PIN is valid\"";
    }


            
    return "The ATM PIN is invalid";
    //Insert your code here 
}


static bool CheckUniqness(string text)
{
    bool[] array = new bool[256]; // or larger for Unicode

    foreach (char value in text)
        if (array[(int)value])
            return false;
        else
            array[(int)value] = true;

    return true;
}