using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task03
    {
        public static object Part1(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToArray();
            var sum = 0;

            // Next number we're calculating and it's position
            int number = -1;
            int position = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                (position, number) = GetNextNumber(lines[i]);
            }

            return sum;
        }

        public static object Part2(string filePath)
        {
            return null;
        }

        /// <summary>
        /// Method returns a tuple, first number is position and second is value.
        /// If no number in the line, return (-1, "")
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static (int, int) GetNextNumber(string line)
        {
            var startsAt = -1;
            string number = string.Empty;
            var chars = line.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Char.IsDigit(chars[i]))
                {
                    startsAt = i;
                    while (i < line.Length && Char.IsDigit(chars[i]))
                    {
                        number += chars[i].ToString();
                        i++;
                    }
                    break;
                }
            }
            return (startsAt, Convert.ToInt32(number));
        }
    }
}
