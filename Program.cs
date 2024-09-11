// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using AutoMapper;
using linkedList;
using leet;

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

var ints = new int []{1,6,1,9,3,8,4,2,7,3,5};
var sol = new Solution();

sol.QuickSort(ints,0,ints.Length-1);
sol.PrintArray(ints);

// var max=sol.SellStock(new int[] {7, 2, 5, 6, 3, 1, 4 });
// Console.WriteLine(max);



