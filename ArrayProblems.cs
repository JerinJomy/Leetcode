using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace leet
{
    public static class ArrayProblem
    {
        // using hashmap
        public static void LongestSubArrayWithSumK(int[] arr, int k)
        {
            int start = -1, end = -1, maxLen = 0;
            var sumMap = new Dictionary<int, int>();
            var currentSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                currentSum = currentSum + arr[i];
                sumMap[currentSum] = i;
                if (currentSum == k)
                {
                    if (i + 1 > maxLen)
                    {
                        start = 0;
                        end = i;
                        maxLen = i + 1;
                    }
                    continue;
                }

                if (sumMap.ContainsKey(currentSum - k))
                {
                    var val = sumMap[currentSum - k];
                    if (i - val > maxLen)
                    {
                        start = sumMap[currentSum - k] + 1;
                        end = i;
                    }
                    break;
                }
            }

            Console.WriteLine($"start: {start} end {end}");
        }

        // given an array find the pair which has sum equal to k
        public static void SumPair(int[] arr, int k)
        {
            var sumMap = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (sumMap.ContainsKey(k - arr[i]))
                {
                    Console.WriteLine($"firstnumber {sumMap[k - arr[i]]} second {i} ");
                    break;
                }
                sumMap.Add(arr[i], i);
            }
        }


        public static void SumPairTwoPointer(int[] arr, int k)
        {
            var sortedArr = arr.Order();
            var j = arr.Length - 1;
            var i = 0;

            while (i < j)
            {
                if ((arr[i] + arr[j]) > k)
                {
                    j--;
                }
                else if ((arr[i] + arr[j]) < k)
                {
                    i++;
                }
                else if ((arr[i] + arr[j]) == k)
                {
                    Console.WriteLine($"first {arr[i]} second {arr[j]}");
                    return;
                }
            }

            System.Console.WriteLine("not found");

        }

        public static int[] SortOneTwoThree(int[] arr)
        {
            int zeroCount = 0, oneCount = 0, twoCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    zeroCount++;
                }
                else if (arr[i] == 1)
                {
                    oneCount++;
                }
                else if (arr[i] == 2)
                {
                    twoCount++;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (zeroCount > 0)
                {
                    arr[i] = 0;
                    zeroCount--;
                }
                else if (oneCount > 0)
                {
                    arr[i] = 1;
                    oneCount--;

                }
                else if (twoCount > 0)
                {
                    arr[i] = 2;
                    twoCount--;
                }
            }
            return arr;
        }

        // 1,1,1,6,6,6
        public static int MajroityElement(int[] nums)
        {
            int majElement = nums[0], count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    majElement = nums[i];
                    count = 1;
                }
                else if (majElement == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }

            }

            return majElement;
        }


        public static void PrintArray(this int[] digits)
        {
            foreach (var digit in digits)
                System.Console.Write(digit + " ");
        }



        //Kadane's Algorithm
        public static int MaxContinSubarray(int[] nums)
        {
            var maxTotal = nums[0];
            var currentMax = nums[0];
            int startIndex = 0, endIndex = 0, currentStartIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {

                if ((currentMax + nums[i]) > nums[i])
                {
                    currentMax = currentMax + nums[i];
                }
                else
                {
                    currentStartIndex = i;
                    currentMax = nums[i];
                }

                if (currentMax > maxTotal)
                {
                    startIndex = currentStartIndex;
                    endIndex = i;
                    maxTotal = currentMax;
                }
            }

            Console.WriteLine($"start: {startIndex} end: {endIndex}");
            return maxTotal;
        }

        //1,2,4,3,9,8,2
        public static void NextPermutation(int[] nums)
        {
            var pivot = -1;

            if (nums.Length == 1)
            {
                return;
            }

            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    pivot = i - 1;
                    break;
                }
            }

            if (pivot == -1)
            {
                ReverseSubarray(nums,0,nums.Length-1);
                return;
            }

            var swapto = pivot;
            for (int i = pivot + 1; i < nums.Length; i++)
            {
                if (nums[pivot] < nums[i])
                {
                    swapto = i;
                }
            }

            Swap(nums, pivot, swapto);
            ReverseSubarray(nums, pivot + 1, nums.Length - 1);
        }

        public static void ReverseSubarray(int[] arr, int start, int end)
        {
            while (start < end)
            {
                Swap(arr, start, end);
                start++;
                end--;
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


    }
}