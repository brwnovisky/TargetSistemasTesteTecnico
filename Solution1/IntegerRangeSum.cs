namespace Solution1;

public static class IntegerRangeSum
{
    public static int Sum(int index)
    {
        var k = 0;
        var sum = 0;
        
        while (k < index)
        {
            k = k + 1; 
            sum = sum + k;
        }
        
        return sum;
        
    }
}