namespace solution
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {

            var smallestStringlength = strs.Min(str => str.Length);
            var length = strs.Length;
            var windowSize = 1;
            var prefix = "";
            string word = "";
            string word1 = strs[0];
            while (smallestStringlength >= windowSize)
            {
                word = word1.Substring(0, windowSize);
                if (ContainsAll(strs, word))
                {
                    prefix = word.Length > prefix.Length ? word : prefix;
                }

                windowSize++;

            }

            return prefix;

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
                prev =numb;
            }

            return totalCount -dupCount;
        }
        private bool ContainsAll(string[] strs, string word)
        {
            foreach (string str in strs)
            {
                if (!str.StartsWith(word))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
