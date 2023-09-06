using System.Reflection;
using System.Runtime.InteropServices;

public static class Operations
{

    public static Node list;
    public static int[] randomList = { 2, 7, 3, 1, 0, 5, 4, 6 };
    private static int count = 0;
    private static List<Node> tempNodeArray = new List<Node>();
    public static void PopulateLinkedList()
    {
        var start = true;
        var valArr = new[] { 1, 3, 4, 5, 6, 7, 55, 33 };
        list = new Node();
        var currentNode = list;
        //var tempNodeArray = new List<Node>();
        foreach (var val in valArr)
        {
            if (start)
            {
                currentNode.value = val;
                start = false;
            }
            else
            {
                currentNode.NextNode = new Node(val);
                currentNode = currentNode.NextNode;
            }
            tempNodeArray.Add(currentNode);
        }

        System.Console.WriteLine($"nodelist count: {tempNodeArray.Count}  \nnodefirst:{tempNodeArray[0].value} \nLatenode:{tempNodeArray[tempNodeArray.Count - 1].value} ");

    }

    public static void PopulateRandomLinkedList()
    {
        TraverseLinkList(list);
    }

    public static void traverseLinkedList()
    {
        if (list == null)
        {
            System.Console.WriteLine("no data");
            return;
        }

        Print(list);

    }

    private static void TraverseLinkList(Node node)
    {
        if (node == null)
        {
            count = 0;
            return;
        }
        System.Console.WriteLine(node.value);
        var index = randomList[count];
        node.RandomNode = tempNodeArray[index];
        count++;
        TraverseLinkList(node.NextNode);
    }

    private static void Print(Node node)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine($"value Node: {node.value}\n Random Node : {node.RandomNode.value}");
        Print(node.NextNode);
    }

    public static void CopyTo(Node node)
    {
        if (node == null)
        {
            return;
        }

        var nodeDictionary = new Dictionary<Node, Node>();
        var newNode = new Node();
        CopyRec(list, nodeDictionary, newNode);
        CopyRandom(list, nodeDictionary, newNode);
        Print(list);
        Console.WriteLine("new nodelist");
        Print(newNode);
    }


    //private static void CopyRec(Node node, Dictionary<Node, Node> refDic, Node newNode)
    //{
    //    if (node == null)
    //    {
    //        newNode = null;
    //        return;
    //    }

    //    newNode.value = node.value;
    //    newNode.NextNode = new Node();
    //    refDic.Add(node, newNode);
    //    CopyRec(node.NextNode, refDic, newNode.NextNode);
    //}

    private static void CopyRec(Node node, Dictionary<Node, Node> refDic, Node newNode)
    {
        if (node == null)
        {

            return;
        }

        newNode.value = node.value;
        refDic.Add(node, newNode);
        if (node.NextNode != null)
        {
            newNode.NextNode = new Node();
            CopyRec(node.NextNode, refDic, newNode.NextNode);
        }
        else
        {
            return;
        }
    }

    private static void CopyRandom(Node node, Dictionary<Node, Node> refDic, Node newNode)
    {
        if (node == null)
        {
            return;
        }
        var randomNode = refDic[node.RandomNode];
        newNode.RandomNode = randomNode;
        CopyRandom(node.NextNode, refDic, newNode.NextNode);
    }

}