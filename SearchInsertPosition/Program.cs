

using System;
using System.Security.Cryptography;

int[] myNum = { 1, 3, 5, 6 };

//Console.WriteLine(SearchInsert(myNum , 0));
Console.WriteLine(Search(myNum , 7));



static int SearchInsert(int[] nums, int target)
{
    int res = SearchByRecursion(nums, target, 0, nums.Length);
    return res;
}

static int SearchByRecursion(int[] nums , int target , int bottom , int top)
{
    if (bottom <= top)
    {
        int middle = (bottom + top) / 2;
        if(middle == top)
            return middle;
        if (nums[middle] == target)
            return middle;
        if ((middle + 1) < nums.Length && nums[middle] < target && nums[middle +1] > target)
            return middle + 1;
        if (nums[middle] >= target)
            return SearchByRecursion(nums, target, bottom, middle - 1);
        else
            return SearchByRecursion(nums, target, middle + 1, top);
    }
    return -1;
}

static int Search(int[] nums , int target)
{
    var low = 0;var high = nums.Length - 1;
    int middle;
    while(low <= high)
    {
        middle = (low + high) / 2;

        if (target < nums[middle])
            high = middle - 1;
        else if (target > nums[middle])
            low = middle + 1;
        else
            return middle;
    }
    return low;
}