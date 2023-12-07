using AOC23.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task01
    {
        public static object Part1(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            int sum = 0;
            foreach (var line in lines)
            {
                var charLine = line.ToCharArray();
                bool firstDigitSet = false;
                bool lastDigitSet = false;
                char firstDigit = '0';
                char lastDigit = '0';

                for (var i = 0; i < line.Length; i++)
                {
                    if (Char.IsDigit(charLine[i]) && !firstDigitSet)
                    {
                        firstDigitSet = true;
                        firstDigit = charLine[i];
                    }

                    if (Char.IsDigit(charLine[line.Length - i - 1]) && !lastDigitSet)
                    {
                        lastDigitSet = true;
                        lastDigit = charLine[line.Length - i - 1];
                    }

                    if (firstDigitSet && lastDigitSet)
                    {
                        break;
                    }

                }

                sum += Convert.ToInt32(firstDigit.ToString() + lastDigit.ToString());

            }
            return sum;
        }

        public static object Part2(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            string[] allowedNumbers =
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };
            int sum = 0;



            foreach (var line in lines)
            {
                var charLine = line.ToCharArray();
                bool firstDigitSet = false;
                bool lastDigitSet = false;
                int firstDigit = -1;
                int lastDigit = -1;

                for (var i = 0; i < line.Length; i++)
                {
                    if (!firstDigitSet)
                    {
                        firstDigit = GetDigit(i, line, allowedNumbers);
                        if (firstDigit != -1) firstDigitSet = true;
                    }

                    if (!lastDigitSet)
                    {
                        lastDigit = GetDigit(line.Length - i - 1, line, allowedNumbers);
                        if (lastDigit != -1) lastDigitSet = true;
                    }

                    if (firstDigitSet && lastDigitSet)
                    {
                        break;
                    }

                }

                sum += Convert.ToInt32(firstDigit.ToString() + lastDigit.ToString());

            }
            return sum;
        }


        private static int GetDigit(int index, string line, string[] allowedNumbers)
        {
            if (Char.IsDigit(line.Substring(index, 1).ToCharArray()[0])) return Convert.ToInt32(line.Substring(index, 1));

            int numberIndex = 1;
            foreach (var number in allowedNumbers)
            {
                if (line.Length >= index + number.Length)
                {
                    if (line.Substring(index, number.Length) == number) return numberIndex;
                }
                numberIndex++;
            }

            return -1;
        }
    }
}
