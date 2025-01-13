using Solution2;

var number = 0;
var isParsed = false;

while (!isParsed)
{
    Console.Write("Enter a integer number: ");
    
    isParsed = int.TryParse(Console.ReadLine(), out var numberParsed);
    
    number = numberParsed;
}

if (FibonacciChecker.IsFibonacciNumber(number))
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The number {number} is a fibonacci number.");
    Console.ResetColor();
    
    return;
}

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"The number {number} is NOT a fibonacci number.");
Console.ResetColor();