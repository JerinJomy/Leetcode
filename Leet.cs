using System.Globalization;

namespace leet
{
    public class Solution
    {

        public void Subarray(int[] arr, int sum)
        {
            bool flag = false;
            // {1,2,4,6,2]  j = 1 , i =0
            int check = arr[0];
            int i = 0, j = 0;
            while (i < arr.Length && j < arr.Length)
            {
                if (check == sum)
                {
                    break;
                }
                else if (check > sum)
                {
                    check = check - arr[i];
                    i++;
                    if (check == sum)
                    {
                        break;
                    }
                    else if (i > j)
                    {
                        j = i;
                        check = arr[j];
                    }
                }
                else
                {
                    j++;
                    check = check + arr[j];
                }
            }

            System.Console.WriteLine($"start : {i} end: {j}");
        }

        public int LengthOfLongestSubstring(string s)
        {

            bool[] visited = new bool[256];
            int start = 0;
            int end = 0;
            int maxLen = 1;
            //jjrinjojy  i =1 j =1
            //jerin  
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length - 1 < maxLen)
                {
                    break;
                }
                for (j = j; j < s.Length; j++)
                {
                    if (visited[s[j]])
                    {
                        visited[s[i]] = false;
                        break;
                    }
                    else
                    {
                        int curLen = j - i + 1;
                        if (maxLen < curLen)
                        {
                            start = i;
                            end = j;
                            maxLen = curLen;
                        }
                        visited[s[j]] = true;
                    }
                }
            }
            return maxLen;
        }

        public void LongestSubstring(string str)
        {
            bool[] visited = new bool[256];
            int start = 0;
            int end = 0;
            int maxLen = 1;
            //jjrinjojy  i =1 j =1
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (j = j; j < str.Length; j++)
                {
                    if (visited[str[j]])
                    {
                        visited[str[i]] = false;
                        break;
                    }
                    else
                    {
                        int curLen = j - i + 1;
                        if (maxLen < curLen)
                        {
                            start = i;
                            end = j;
                            maxLen = curLen;
                        }
                        visited[str[j]] = true;
                    }
                }
            }
            System.Console.WriteLine(str.Substring(start, end - start + 1));
        }
        public string LongestCommonPrefix(string[] strs)
        {

            var length = strs.Length;
            var word1 = strs[0];
            var prefix = "";
            string word = "";
            foreach (var ch in word1)
            {
                word = word + ch;
                if (ContainsAll(strs, word))
                {
                    if (prefix.Length < word.Length)
                    {
                        prefix = word;
                    }
                }
                else
                {
                    word = "";
                }
            }

            return prefix;

        }

        public bool IsValid(string s)
        {

            var brackStack = new Stack<char>();
            foreach (char ch in s)
            {
                if (brackStack.Count == 0)
                {
                    if (IsLeftBracket(ch))
                    {
                        brackStack.Push(ch);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
                if (brackStack.Peek() == Inverse(ch))
                {
                    brackStack.Pop();
                }
                else
                {
                    if (IsLeftBracket(ch))
                    {
                        brackStack.Push(ch);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return brackStack.Count == 0;

        }

        public int RemoveDuplicates(int[] nums)
        {
            int j = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    j++;
                    nums[j] = nums[i];
                }
            }

            foreach (var num in nums)
            {
                System.Console.WriteLine(num);
            }
            return j;
        }

        public int RemoveElements(int[] nums, int val)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }


            return j;
        }

        public int RemoveDupes(int[] numbers)
        {
            // 1,1,2,3,4,5,6,6,7
            var totalCount = numbers.Length;
            int dupCount = 0;
            int prev = numbers[0];
            foreach (var numb in numbers.Skip(1))
            {
                if (prev == numb)
                {
                    dupCount++;
                }
                prev = numb;
            }

            return totalCount - dupCount;
        }

        private char Inverse(char bracket)
        {
            switch (bracket)
            {
                case '{':
                    return '}';
                case '}':
                    return '{';
                case ')':
                    return '(';
                case '(':
                    return ')';
                case '[':
                    return ']';
                case ']':
                    return '[';
                default:
                    return ' ';
            }
        }

        private bool IsLeftBracket(char bracket)
        {
            if (bracket == '{' || bracket == '(' || bracket == '[')
            {
                return true;
            }
            return false;
        }

        private bool ContainsAll(string[] strs, string word)
        {
            foreach (string str in strs)
            {
                if (str.Contains(word))
                {
                    return false;
                }
            }

            return true;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 != null || list2 != null)
            {
                var newList = new ListNode();
                CreateNewList(newList, list1, list2);
                return newList;
            }
            else
            {
                return null;
            }
        }

        private void CreateNewList(ListNode newList, ListNode list1, ListNode list2)
        {
            // list1 = [1,2,4], list2 = [1,3,4]
            if (list1 == null || list2 == null)
            {
                if (list1 != null)
                {
                    Traverse(newList, list1);
                }
                else if (list2 != null)
                {
                    Traverse(newList, list2);
                }
                else
                {
                    return;
                }

            }
            else
            {
                if (list1.val > list2.val)
                {
                    newList.val = list2.val;
                    newList.next = new ListNode();
                    CreateNewList(newList.next, list1, list2.next);
                }
                else if (list1.val < list2.val)
                {
                    newList.val = list1.val;
                    newList.next = new ListNode();
                    CreateNewList(newList.next, list1.next, list2);
                }
                else if (list1.val == list2.val)
                {
                    newList.val = list1.val;
                    newList.next = new ListNode(list2.val);
                    if (list1.next != null || list2.next != null)
                    {
                        newList.next.next = new ListNode();
                        CreateNewList(newList.next.next, list1.next, list2.next);
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        public ListNode MergeList(ListNode list1, ListNode list2)
        {
            //{1,2,4} {1,4,6}
            if (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    list1.next = MergeList(list1.next, list2);
                    return list1;
                }
                else
                {
                    list2.next = MergeList(list1, list2.next);
                    return list2;
                }
            }
            else
            {
                if (list1 == null)
                {
                    return list2;
                }
                return list1;
            }
        }

        public TreeNode PopulateTree(int[] numbers)
        {
            //0,1,2,3,4,6
            var numberQueue = new Queue<TreeNode>();
            if (!numbers.Any())
            {
                return null;
            }
            var treeNode = new TreeNode(numbers[0]);
            var parentNode = treeNode;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (parentNode.left == null)
                {
                    parentNode.left = new TreeNode(numbers[i]);
                    numberQueue.Enqueue(parentNode.left);
                }
                else if (parentNode.right == null)
                {
                    parentNode.right = new TreeNode(numbers[i]);
                    numberQueue.Enqueue(parentNode.right);
                    parentNode = numberQueue.Dequeue();
                }
            }
            return treeNode;
        }

        public void PrintInorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            PrintInorder(node.left);
            Console.WriteLine(node.val);
            PrintInorder(node.right);
        }


        public void PrintPreorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.val);
            PrintPreorder(node.left);
            PrintPreorder(node.right);
        }

        // public ListNode MergeList(ListNode l1, ListNode l2)
        // {
        //     var newList = new List<int>();
        //     while (l1 != null || l2 != null)
        //     {
        //         if (l1.val > l2.val)
        //         {
        //             newList.Add(l2.val);
        //             l2 = l2.next;
        //         }
        //         else
        //         {
        //             newList.
        //         }
        //     }




        // }

        private void Traverse(ListNode newList, ListNode list)
        {

            newList.val = list.val;
            if (list.next == null)
            {
                return;
            }
            newList.next = new ListNode();
            Traverse(newList.next, list.next);
        }

        public ListNode PopulateListNode(int[] numbs)
        {
            var list = new ListNode(numbs[0]);
            var trav = list;
            foreach (var numb in numbs.Skip(1))
            {
                trav.next = new ListNode(numb);
                trav = trav.next;
            }
            return list;
        }

        public void pythoin(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            while (i >= 0 || j >= 0)
            {
                var n1 = i >= 0 ? nums1[i] : int.MinValue;
                var n2 = j >= 0 ? nums2[j] : int.MinValue;
                if (n1 > n2)
                {
                    nums1[k] = n1;
                    i = i - 1;
                }
                else
                {
                    nums1[k] = n2;
                    j = j - 1;
                }
                k = k - 1;
            }
        }
        public int StrStr(string haystack, string needle)
        {
            var needlelength = needle.Length;
            var start = 0;
            while (start + needlelength <= haystack.Length)
            {
                string v = haystack.Substring(start, needlelength);
                System.Console.WriteLine(v);
                if (v == needle)
                {
                    return start;
                }
                start++;
            }
            return -1;
        }
        public void Traverse(ListNode list)
        {
            if (list == null)
            {
                return;
            }
            System.Console.WriteLine(list.val);
            Traverse(list.next);
        }

        public int SearchInsert(int[] nums, int target)
        {
            //1,2,3,5
            var left = 0;
            var right = nums.Length - 1;
            int mid = 0;
            while (left <= right)
            {
                // 1 2 3 
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
            }
            System.Console.WriteLine(nums[mid]);
            if (nums[mid] > target)
            {
                return mid;
            }
            else
            {
                return mid + 1;
            }
        }
        public int LengthOfLastWord(string s)
        {
            var length = s.Length;
            var startIndex = 0;
            var started = false;
            var endIndex = s.Length - 1;

            for (int i = length - 1; i >= 0; i--)
            {
                if (s[i] != ' ' & !started)
                {
                    started = true;
                    endIndex = i;
                    continue;
                }
                if (s[i] == ' ' && started)
                {
                    startIndex = i + 1;
                    break;
                }
            }
            return s.Substring(startIndex, endIndex - startIndex + 1).Length;


        }

        public int[] PlusOne(int[] digits)
        {
            var lastIndex = digits.Length - 1;
            if (digits[lastIndex] == 9)
            {
                // var newArr = new int[lastIndex + 2];
                // Array.Copy(digits, newArr, lastIndex + 1);
                for (int i = lastIndex; i >= 0; i--)
                {
                    if (digits[i] == 9)
                    {
                        digits[i] = 0;
                    }
                    else
                    {
                        digits[i] = digits[i] + 1;
                        break;
                    }
                }

                if (digits[0] == 0)
                {
                    digits[0] = 1;
                    var newArry = new int[lastIndex + 2];
                    Array.Copy(digits, newArry, lastIndex + 1);
                    return newArry;
                }
            }
            else
            {
                digits[lastIndex] = digits[lastIndex] + 1;
                return digits;
            }
            return digits;
        }

        
        public string AddBinary(string a, string b)
        {
            // 1010
            //0101
            var i = a.Length - 1;
            var j = b.Length - 1;
            var carry = '0';
            var total = "";
            while (i >= 0 || j >= 0)
            {
                //11
                //1
                var numb1 = i >= 0 ? a[i] : '0';
                var numb2 = j >= 0 ? b[j] : '0';
                //1,2,3,4,5,6,7,8
                var result = calculate(numb1, numb2);
                // carry = result.carry;
                var sum = calculate(carry, result.sum);

                carry = calculate(result.carry, sum.carry).sum;
                total = sum.sum + total;
                i--;
                j--;
            }

            if (carry == '1')
            {
                total = carry + total;
            }

            return total;
        }

        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }

            var start = 1;
            var end = x;
            int mid = 0;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if (mid == x / mid)
                {
                    return mid;
                }
                else if (mid > x / mid)
                {
                    end = mid - 1;
                }
                else if (mid < x / mid)
                {
                    start = mid + 1;
                }

            }
            return end;
        }

        public int ClimbStairs(int n)
        {
            int[] numbs = new int[45];

            numbs[1] = 1;
            numbs[2] = 2;



            return ClimbStairsRec(n, numbs);
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            Traverselst(head);
            return head;
        }

        private void Traverselst(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return;
            }
            node.next = RemoveDuplicates(node.next, node.val);
            Traverselst(node.next);
        }

        public ListNode RemoveDupesFromLst(ListNode head)
        {
            var currentNode = head;
            var checkNode = currentNode.next;
            while (currentNode != null && checkNode != null)
            {
                if (checkNode.val == currentNode.val)
                {
                    checkNode = checkNode.next;
                    continue;
                }
                else
                {
                    currentNode.next = checkNode;
                    currentNode = currentNode.next;
                    checkNode = checkNode.next;
                }
            }
            currentNode.next = null;
            return head;
        }

        public int[] MergeSortedArray(int[] arr1, int[] arr2)
        {
            // 1,2,4,6   1,3,5,5
            var l1 = arr1.Length;
            var l2 = arr2.Length;
            int mov1 = 0, mov2 = 0;

            var newArr = new int[l1 + l2];
            int i = 0;
            while (mov1 < l1 || mov2 < l2)
            {
                var val1 = mov1 < l1 ? arr1[mov1] : 0;
                var val2 = mov2 < l2 ? arr2[mov2] : 0;
                if (val1 < val2)
                {
                    newArr[i] = val1;
                    mov1 = mov1 + 1;
                }
                else
                {
                    newArr[i] = val2;
                    mov2 = mov2 + 1;
                }

                i++;
            }
            return newArr;
        }
        private ListNode RemoveDuplicates(ListNode node, int value)
        {
            var checkNode = node;
            while (checkNode.val == value)
            {
                if (checkNode.next == null)
                {
                    return null;
                }
                checkNode = checkNode.next;
            }

            return checkNode;
        }

        private int ClimbStairsRec(int n, int[] numbs)
        {
            if (n == 1)
            {
                return numbs[1];
            }
            if (n == 2)
            {
                return numbs[2];
            }
            var numb1 = numbs[n - 2] == 0 ? ClimbStairsRec(n - 2, numbs) : numbs[n - 2];
            var numb2 = numbs[n - 1] == 0 ? ClimbStairsRec(n - 1, numbs) : numbs[n - 1];
            // System.Console.WriteLine($"number1 {numb1}" +$" numb2 {numb2}" );
            var result = numb1 + numb2;
            numbs[n] = result;
            return result;
        }

        private (char carry, char sum) calculate(char numb1, char numb2)
        {
            if (numb1 == '0' && numb2 == '0')
            {
                return ('0', '0');
            }
            else if ((numb1 == '1' && numb2 == '0') || (numb1 == '0' && numb2 == '1'))
            {
                return ('0', '1');
            }
            else if ((numb1 == '1') && (numb2 == '1'))
            {
                return ('1', '0');
            }
            else
            {
                throw new Exception("nothing");
            }
        }

        public int CalculateDepth(TreeNode node, int depth)
        {
            if (node == null)
            {
                return depth;
            }
            depth = depth + 1;
            return Math.Max(CalculateDepth(node.left, depth), CalculateDepth(node.right, depth));
        }

        //[7, 1, 5, 3, 6, 4]
        public int SellStock(int[] stockPrices)
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

        public void MergeSort(int[] numbs)
        {

        }

        //[1,4,2,6,5]
        public void MergeSortedArray(int[] numbs, int l, int r)
        {
            if (l < r)
            {
                var m = l + (r - l) / 2;

                MergeSortedArray(numbs, l, m);
                MergeSortedArray(numbs, m + 1, r);


            }
        }

        // private void SortAndMerge(int[] numbs, int l, int m, int r)
        // {

        //     var arr1 = new int[m - l + 1];
        //     var arr2 = new int[r - m];

        //     for (int i = l; i <= r; i++)
        //     {
        //         arr1[]
        //     }
        //     for (int i = l; i <= m; i++)
        //     {

        //     }
        // }

        public void QuickSort(int[] numbs, int low, int high)
        {
            if (high > low)
            {
                int pi = findPartation(numbs,low,high);

                QuickSort(numbs,low,pi-1);
                QuickSort(numbs,pi+1,high);
            }
        }

        private int findPartation(int[] numbs, int low, int high)
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

        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }



}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}