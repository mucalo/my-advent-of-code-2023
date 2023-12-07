using AOC23.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        var before = new DateTimeOffset();
        
        object tempSolution;

        // T1.1
        before = DateTimeOffset.Now;
        tempSolution = Task01.Part1("T1.1.txt");
        Console.WriteLine($"T1.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        // T1.2
        before = DateTimeOffset.Now;
        tempSolution = Task01.Part2("T1.1.txt");
        Console.WriteLine($"T1.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

    }
}



