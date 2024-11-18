using System.Runtime.InteropServices.JavaScript;

namespace leetcode
{
    public static class Sorting
    {
        public static int[] Sort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                //3,4,1
                var mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                CompareAndMerge(arr, left, mid, right);
            }
            return;
        }

        public static void QuickSort(int[] numbs, int low, int high)
        {
            if (high > low)
            {
                int pi = findPartation(numbs,low,high);

                QuickSort(numbs,low,pi-1);
                QuickSort(numbs,pi+1,high);
            }
        }

        private static int findPartation(int[] numbs, int low, int high)
        {
            var pivot = numbs[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (pivot >= numbs[j])
                {
                    i++;
                    Swap(numbs, i, j);
                }
            }
            Swap(numbs, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void CompareAndMerge(int[] arr, int left, int mid, int right)
        {
            //1,2,3
            var l1 = mid - left + 1;
            var l2 = right - mid;

            var arr1 = new int[l1];
            var arr2 = new int[l2];

            for (int i = 0; i < l1; i++)
            {
                arr1[i] = arr[left + i];
            }

            for (int i = 0; i < l2; i++)
            {
                arr2[i] = arr[mid + 1 + i];
            }

            int k = 0;
            int j = 0;

            while (k < l1 || j < l2)
            {
                var val1 = k < l1 ? arr1[k] : int.MaxValue;
                var val2 = j < l2 ? arr2[j] : int.MaxValue;
                if (val1 < val2)
                {
                    arr[left] = arr1[k];
                    k++;
                }
                else
                {
                    arr[left] = arr2[j];
                    j++;
                }
                left++;
            }


        }
    }
}