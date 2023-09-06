using System.Globalization;

public class Solution
{
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

    public void PrintArray(int[] digits)
    {
        foreach (var digit in digits)
            System.Console.Write(digit);
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
