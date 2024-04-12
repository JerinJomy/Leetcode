namespace solution
{
    public class Solution1
    {


        private void MoveRing(int ringNumber, string startPole, string targetPole)
        {
            Console.WriteLine($"move ring {ringNumber} from {startPole} to {targetPole}");
        }

        public void TowerOfHanoi(int pileSize, string startPole, string auxPole, string targetPole)
        {
            if (pileSize == 1)
            {
                MoveRing(pileSize,startPole, targetPole);
                return;
            }
            //r3
            TowerOfHanoi(pileSize-1,startPole,targetPole,auxPole);
            MoveRing(pileSize,startPole,targetPole);
            TowerOfHanoi(pileSize-1,auxPole,startPole,targetPole);
        }
        int findheight(TreeNode node)
        {

            return Math.Max(heightRec(node.left, 0), heightRec(node.right, 0));
        }

        int heightRec(TreeNode node, int height)
        {
            if (node == null)
            {
                return height;
            }
            else
            {
                height++;
                return heightRec(node.left, height);
            }

        }

        public void StringPyramid(int height)
        {
            int sp = 4;
            int star = 1;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < sp + star; j++)
                {
                    if (j < sp)
                        Console.Write("  ");
                    else
                    {
                        Console.Write(" *");
                    }
                }
                sp = sp - 1;
                star = star + 2;
                System.Console.WriteLine();
            }
        }

        public void CharacterCount(string str)
        {
            var arr = new int[256];
            foreach (var ch in str)
            {
                arr[ch] = arr[ch] + 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {

                    System.Console.WriteLine($"{(char)i} : {arr[i]}");
                }
            }


        }
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
                prev = numb;
            }

            return totalCount - dupCount;
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
