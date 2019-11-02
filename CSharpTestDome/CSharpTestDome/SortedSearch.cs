/*
    Implement function CountNumbers that accepts a sorted array of unique integers and, 
        efficiently with respect to time used, 
        counts the number of array elements that are less than the parameter lessThan.

    For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2 because there are two array elements less than 4. 
*/

using System;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int start = 0;
        int end = sortedArray.Length - 1;
        int mid = 0;
        while(start < end)
        {
            mid = (start + end)/2;
            if (sortedArray[mid] > lessThan)
            {
                end = mid - 1;
                if (start > end)
                    end = start;
            }
            else if (sortedArray[mid] == lessThan)
            {
                return mid;
            }
            else
            {
                start = mid + 1;
                if (start > sortedArray.Length - 1)
                    start = sortedArray.Length - 1;
            }
        };
        if(start == end)
        {
            if(sortedArray[start] < lessThan)
            {
                return start +1;
            }
            else
            {
                return start;
            }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 3, 5, 7 }, 4)); // the first two indices are less than 4, so result will be 2
    }
}
