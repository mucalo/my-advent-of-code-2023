using AOC23.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task04
    {
        public static object Part1(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            int sum = 0;

            foreach (var line in lines)
            {
                var cardValue = 0;

                var relevantLine = line.Substring(line.IndexOf(": ") + 2);
                var mainParts = relevantLine.Split(" | ");

                var winningNumbers = ConvertStringToList(mainParts[0]);
                var myNumbers = ConvertStringToList(mainParts[1]);

                foreach (var myNumber  in myNumbers)
                {
                    if (winningNumbers.Contains(myNumber))
                    {
                        if (cardValue == 0) cardValue = 1; else cardValue *= 2;
                    }
                }

                sum += cardValue;
            }

            return sum;
        }

        public static object Part2(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            int sum = 0;
            Dictionary<int, int> Instances = new Dictionary<int, int>();
            for (int i = 1; i <= lines.Length; i++)
            {
                Instances.Add(i, 1);
            }

            int index = 1;
            foreach (var line in lines)
            {
                var cardValue = 0;

                var relevantLine = line.Substring(line.IndexOf(": ") + 2);
                var mainParts = relevantLine.Split(" | ");

                var winningNumbers = ConvertStringToList(mainParts[0]);
                var myNumbers = ConvertStringToList(mainParts[1]);

                foreach (var myNumber in myNumbers)
                {
                    if (winningNumbers.Contains(myNumber))
                    {
                        cardValue++;
                    }
                }

                // I need to copy the next cardValue cards
                // by as many times as I've been copied so far
                for (int i = 1; i <= cardValue; i++)
                {
                    Instances[i + index] = Instances[i + index] + Instances[index];
                }


                index++;
            }

            return Instances.Values.Sum(v => v);
        }




        private static List<int> ConvertStringToList(string inputString)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < inputString.Length; i += 3)
            {
                if (i + 1 < inputString.Length)
                {
                    // Take two characters and convert to an integer
                    string numberString = inputString.Substring(i, 2).Trim();
                    if (int.TryParse(numberString, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }

            return numbers;
        }
    }
}
