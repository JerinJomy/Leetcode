using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public static class Study
{
    public static bool ContainsStr(string mainStr, string subStr)
    {
        // jerinjomy
        int index = 0;
        int sslength = subStr.Length;

        while ((index + sslength) <= mainStr.Length)
        {
            var stringSlice = mainStr.Substring(index, sslength);
            if (stringSlice == subStr)
            {
                return true;
            }
            index = index + 1;
            //System.Console.WriteLine(index);
        }

        return false;
    }

    // 1,r=1,l=0

    // 2,4,6,7,9,10

    public static bool SearchBinary(int[] numbs, int val)
    {
        int left = 0, right = numbs.Length - 1;
        int mid;
        while (right >= left)
        {
            mid = left + (right - left) / 2;
            if (numbs[mid] == val)
            {
                return true;
            }

            else if (val > numbs[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }

        }

        return false;
    }

    public static void PrintPattern(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n - i - 1; k++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("");

        }
    }


    public static void Fibonoci(int n)
    {
        int i = 2;
        int val1 = 0;
        int val2 = 1;

        System.Console.Write($"{val1} ");
        System.Console.Write($"{val2} ");
        while (i < n)
        {
            var sum = val1 + val2;
            Console.Write($"{sum} ");
            val1 = val2;
            val2 = sum;
            i = i + 1;
        }
    }

    public static int FibinoRec(int n)
    {
        if (n == 1 || n == 2)
        {
            return n;
        }
        else
        {
            return FibinoRec(n-1) + FibinoRec(n - 2);
        }

    }

    public static bool Power(int test){
        bool isPower = true;
        while(test > 1){
            if(test % 2 != 0){
                return false;
            }
            test= test/2;
        }
        return isPower;
    }

}
