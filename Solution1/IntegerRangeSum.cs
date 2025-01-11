namespace Solution1;

public class IntegerRangeSum
{
    public void Sum(int index)
    {
        int k = 0;
        int sum = 0;
        
        while (k < index)
        {
            k = k + 1; 
            sum = sum + k;
        }
        
        Console.WriteLine(sum);
    }
}