﻿using AOC23.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        var before = new DateTimeOffset();
        
        object tempSolution;
        #region Solved

        //// T1.1
        //before = DateTimeOffset.Now;
        //tempSolution = Task01.Part1("T1.1.txt");
        //Console.WriteLine($"T1.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        //// T1.2
        //before = DateTimeOffset.Now;
        //tempSolution = Task01.Part2("T1.1.txt");
        //Console.WriteLine($"T1.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        //// T2.1
        //before = DateTimeOffset.Now;
        //tempSolution = Task02.Part1("T2.1.txt");
        //Console.WriteLine($"T2.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        //// T2.2
        //before = DateTimeOffset.Now;
        //tempSolution = Task02.Part2("T2.1.txt");
        //Console.WriteLine($"T2.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");


        //// T3.1
        //before = DateTimeOffset.Now;
        //tempSolution = Task03.Part1("T3.1.txt");
        //Console.WriteLine($"T3.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");


        //// T3.2
        //before = DateTimeOffset.Now;
        //tempSolution = Task03.Part2("T3.1.txt");
        //Console.WriteLine($"T3.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        // T4.1
        //before = DateTimeOffset.Now;
        //tempSolution = Task04.Part1("T4.1.txt");
        //Console.WriteLine($"T4.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");


        // T4.2
        //before = DateTimeOffset.Now;
        //tempSolution = Task04.Part2("T4.1.txt");
        //Console.WriteLine($"T4.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");
        #endregion

        // T5.1
        before = DateTimeOffset.Now;
        tempSolution = Task05.Part1("T5.1.txt");
        Console.WriteLine($"T5.1 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

        // T5.2
        before = DateTimeOffset.Now;
        tempSolution = Task05.Part2("T5.1.txt");
        Console.WriteLine($"T5.2 Solution: {tempSolution.ToString()}, Duration: {DateTimeOffset.Now.ToUnixTimeMilliseconds() - before.ToUnixTimeMilliseconds()} ms.");

    }
}



