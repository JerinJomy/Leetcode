// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using AutoMapper;
using linkedList;
using solution;

//test

// Operations.PopulateLinkedList();
// Operations.PopulateRandomLinkedList();
// Operations.traverseLinkedList();
// Operations.CopyTo(new Node());\
//while (true)
//{
//    System.Console.WriteLine("Enter the value: ");
//    var input = Console.ReadLine();
//    System.Console.WriteLine(Study.ContainsStr("jerinjomy", input));
//}

// while (true)
// {
//     Console.WriteLine("enter the value");
//     var input = Console.ReadLine();
//     Console.WriteLine(sol.IsValid(input));
// }
System.Console.WriteLine("start");
var sol = new Solution();
// var lst = sol.PopulateListNode(new int[] { 1,2,3,4,4,5,5,6,7 });
// sol.Traverse(lst);
var root = sol.PopulateTree(new int[] { 1, 2, 3, 4 });
System.Console.WriteLine(sol.CalculateDepth(root, 0));
// var str = Console.ReadLine();
// System.Console.WriteLine(sol.LengthOfLastWord(str));

// Console.WriteLine(sol.RemoveElements(new int[] {3,2,2,3},3));
// var list1 = sol.PopulateListNode(new int[] { 1, 2, 4 });
// var list2 = sol.PopulateListNode(new int[] { 1, 3, 4 });
// sol.Traverse(sol.MergeList(list1,list2)); 


