using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace leet
{
    public static class ArrayProblem
    {
        // prefix sum problem
        public static int LongestConsecutiveSubArray(int[] arr)
        {
            var numberSet = new HashSet<int>();
            int? start = -199, count, maxcount = 0;
            foreach (var numb in arr)
            {
                numberSet.Add(numb);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var numb = arr[i];
                if (!numberSet.Contains(numb - 1))
                {
                    count = 1;
                    while (numberSet.Contains(numb + 1))
                    {
                        count++;
                        numb = numb + 1;
                    }

                    if (count > maxcount)
                    {
                        maxcount = count;
                        start = arr[i];
                    }
                }
            }

            count = 0;
            while (count < maxcount)
            {
                Console.WriteLine(start + count);
                count++;
            }

            return maxcount.Value;
        }

        public static int SellStock(int[] stockPrices)
        {
            int maxProfit = 0;
            int lowest = stockPrices[0];
            int buyingDay = 0, sellingDay = 0;
            int lowestindex = 0;

            for (int i = 1; i < stockPrices.Length; i++)
            {
                var price = stockPrices[i];
                if (price < lowest)
                {
                    lowestindex = i;
                    lowest = price;
                    continue;
                }

                var currntProfit = price - lowest;
                if (currntProfit > maxProfit)
                {
                    maxProfit = currntProfit;
                    buyingDay = lowestindex;
                    sellingDay = i;
                }
            }

            System.Console.WriteLine($"buyon {buyingDay} sellon {sellingDay}");
            return maxProfit;
        }

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
                ReverseSubarray(nums, 0, nums.Length - 1);
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

// prefix sum problem
        public static int CountSubarrayWithGivenSum(int[] nums, int k)
        {
            int sum = 0, count = 0;
            var prefixSum = new Dictionary<int, int>();
            prefixSum.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (prefixSum.ContainsKey(sum - k))
                {
                    count += prefixSum[sum - k];
                }

                prefixSum[sum] = prefixSum.ContainsKey(sum) ? prefixSum[sum] + 1 : 1;
            }

            return count;
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

        public static void TransposeMatrix(int[,] matrix)
        {
            PrintMatrix(matrix);
            Console.WriteLine();
            int cols = matrix.GetLength(0), rows = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = row; col < cols; col++)
                {
                    (matrix[row, col], matrix[col, row]) = (matrix[col, row], matrix[row, col]);
                }
            }
            
            PrintMatrix(matrix);
        }

        public static void ReverseMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            PrintMatrix(matrix);
            Console.WriteLine();
            for (int row = 0; row < rows; row++)
            {
                int start = 0, end = cols - 1;
                while (start < end)
                {
                    (matrix[row, start],matrix[row, end]) = (matrix[row, end], matrix[row, start]);
                    start++;    
                }
            }
            
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(int[,] matrix)
        {
             int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
             for (int row = 0; row < rows; row++)
             {
                 for (int col = 0; col < cols ; col++)
                 {
                     Console.Write(matrix[row, col] + " ");
                 }
                 Console.WriteLine();
             }
        }
        
        private static void Swap(int[] arr, int i, int j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}