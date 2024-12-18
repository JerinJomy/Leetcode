using System.Xml;

namespace leetcode;

public static class BinarySearch
{
    public static int Lowerbound(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, ans = -1;
        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (arr[mid] >= target)
            {
                high = mid - 1;
                ans = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans == -1 ? arr.Length : ans;
    }

    public static int Upperbound(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, ans = -1;
        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (arr[mid] > target)
            {
                high = mid - 1;
                ans = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans == -1 ? arr.Length : ans;
    }

    public static int FirstOccurance(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, ans = -1;
        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (arr[mid] >= target)
            {
                high = mid - 1;
                if (arr[mid] == target)
                {
                    ans = mid;
                }
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;
    }
     public static int LastOccurance(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, ans = -1;
        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (arr[mid] <= target)
            {
                low = mid + 1;
                if (arr[mid] == target)
                {
                    ans = mid;
                }
            }
            else
            {
                high = mid - 1;
            }
        }

        return ans;
    }
    
}