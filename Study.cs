public static class Study
{
    public static bool ContainsStr(string mainStr, string subStr)
    {
        // jerinjomy
        int index = 0;
        int sslength = subStr.Length;

        while ((index + sslength)<= mainStr.Length)
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

}
