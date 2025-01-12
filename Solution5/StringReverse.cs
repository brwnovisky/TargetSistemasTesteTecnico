namespace Solution5;

public static class StringReverse
{
    public static string Reverse(string input)
    {
        var charArray = input.ToCharArray();
        var index = 0;
        var reverseIndex = charArray.Length - 1;

        while (index < reverseIndex)
        {
            (charArray[index], charArray[reverseIndex]) = (charArray[reverseIndex--], charArray[index++]);
        }
        
        return new string(charArray);
    }
}
