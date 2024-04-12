using System.Xml.Schema;

namespace solution
{
    public class TreeSolution
    {
        // public TreeNode PopulateDataToBSTFromSortedArray(int[] numbers)
        // {
        //     var rootNode = new TreeNode();
        //     foreach (var number in numbers)
        //     {
        //         if()
        //     }
        // }
        public List<List<int>> LevelOrderTraversal(TreeNode root)
        {
            var mainList = new List<List<int>>
            {
                new List<int>()
            };
            var queue = new Queue<KeyValuePair<int, TreeNode>>();
            queue.Enqueue(KeyValuePair.Create(0, root));
            BfsTraverseWithList(queue, mainList);
            return mainList;
        }

        public TreeNode FindInOrderPrec(TreeNode rootNode)
        {
            if (rootNode == null || rootNode.left == null)
            {
                return null;
            }
            var node = rootNode.left;
            while (true)
            {
                if (node.right == null)
                {
                    break;
                }
                node = node.right;
            }
            return node;
        }

        private void BfsTraverseWithList(Queue<KeyValuePair<int, TreeNode>> treeNodes, List<List<int>> mainList)
        {

            if (treeNodes.Count == 0)
            {
                return;
            }
            var item = treeNodes.Dequeue();
            if (mainList.Count <= item.Key)
            {
                mainList.Add(new List<int>());
            }
            mainList[item.Key].Add(item.Value.val??0);

            if (item.Value.left != null)
            {
                treeNodes.Enqueue(KeyValuePair.Create(item.Key + 1, item.Value.left));
            }
            if (item.Value.right != null)
            {
                treeNodes.Enqueue(KeyValuePair.Create(item.Key + 1, item.Value.right));
            }

            BfsTraverseWithList(treeNodes, mainList);
        }
        public void BinaryTreeBFS(TreeNode root)
        {
            var treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);
            BfsTraverse(treeNodes);
        }

        private void BfsTraverse(Queue<TreeNode> treeNodes)
        {
            if (treeNodes.Count == 0)
            {
                return;
            }
            var node = treeNodes.Dequeue();
            System.Console.WriteLine(node.val);
            if (node.left != null)
            {
                treeNodes.Enqueue(node.left);
            }
            if (node.right != null)
            {
                treeNodes.Enqueue(node.right);
            }

            BfsTraverse(treeNodes);
        }
    }
}


// for(i=0 of arr to len){
//
