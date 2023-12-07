using AOC23.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task03
    {
        public static object Part1(string filePath)
        {
            var lines = FileAux.GetInputData(filePath).ToArray();
            var sum = 0;

            // Next number we're calculating and it's position
            int number = -1;
            int position = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                var tmpString = lines[i];
                var endOfLastNumber = 0;
                do
                {
                    (position, number) = GetNextNumber(lines[i].Substring(endOfLastNumber));
                    tmpString = lines[i].Substring(endOfLastNumber);

                    if (position != -1)
                    {
                        // Number found
                        bool isTouching = false;
                        bool hasInitialPadding = false;
                        bool hasPosteriorPadding = false;


                        // Check character before if exists and if isTouching
                        if (position > 0)
                        {
                            hasInitialPadding = true;
                            if (tmpString[position - 1] != '.') isTouching = true;
                        }

                        // Check character after if exists and is Touching
                        if (position + number.ToString().Length < tmpString.Length)
                        {
                            hasPosteriorPadding = true;
                            if (tmpString[position + number.ToString().Length] != '.') isTouching = true;
                        }

                        var lengthOfRectangle = number.ToString().Length
                            + (hasInitialPadding ? 1 : 0)
                            + (hasPosteriorPadding ? 1 : 0);
                        var stringOfDots = new string('.', lengthOfRectangle);
                        var initialPositionOfRectangle = endOfLastNumber + position - (hasInitialPadding ? 1 : 0);

                        // Check if above exists and is touching
                        if (i > 0)
                        {

                            var stringToCompare = lines[i - 1].Substring(initialPositionOfRectangle, lengthOfRectangle);
                            if (stringToCompare != stringOfDots) isTouching = true;
                        }

                        // Check if below exists and is touching
                        if (i < lines.Length - 1)
                        {

                            var stringToCompare = lines[i + 1].Substring(initialPositionOfRectangle, lengthOfRectangle);
                            if (stringToCompare != stringOfDots) isTouching = true;
                        }


                        // IF isTouching then sum
                        if (isTouching) sum += number;


                        // Number processed, increase counter
                        endOfLastNumber = endOfLastNumber + position + number.ToString().Length;

                    }
                } while (position != -1);

            }

            return sum;
        }

        public static object Part2(string filePath)
        {
            Dictionary<(int, int), List<int>> NumbersAroundPoints = new();

            var lines = FileAux.GetInputData(filePath).ToArray();
            var sum = 0;

            // Next number we're calculating and it's position
            int number = -1;
            int position = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                var tmpString = lines[i];
                var endOfLastNumber = 0;
                do
                {
                    (position, number) = GetNextNumber(lines[i].Substring(endOfLastNumber));
                    tmpString = lines[i].Substring(endOfLastNumber);

                    if (position != -1)
                    {
                        // Number found
                        bool isTouching = false;
                        bool hasInitialPadding = false;
                        bool hasPosteriorPadding = false;


                        // Check character before if exists and if isTouching
                        if (position > 0)
                        {
                            hasInitialPadding = true;

                            if (tmpString[position - 1] == '*')
                            {
                                NumbersAroundPoints.TryAdd((i, endOfLastNumber + position - 1), new List<int>());
                                NumbersAroundPoints[(i, endOfLastNumber + position - 1)].Add(number);
                            }
                        }

                        // Check character after if exists and is Touching
                        if (position + number.ToString().Length < tmpString.Length)
                        {
                            hasPosteriorPadding = true;
                            if (tmpString[position + number.ToString().Length] == '*')
                            {
                                NumbersAroundPoints.TryAdd((i, endOfLastNumber + position + number.ToString().Length), new List<int>());
                                NumbersAroundPoints[(i, endOfLastNumber + position + number.ToString().Length)].Add(number);
                            }
                        }

                        var lengthOfRectangle = number.ToString().Length
                            + (hasInitialPadding ? 1 : 0)
                            + (hasPosteriorPadding ? 1 : 0);
                        var initialPositionOfRectangle = endOfLastNumber + position - (hasInitialPadding ? 1 : 0);

                        // Check if above exists and is touching
                        if (i > 0)
                        {
                            var stringToCompare = lines[i - 1].Substring(initialPositionOfRectangle, lengthOfRectangle);
                            if (stringToCompare.IndexOf('*') != -1)
                            {
                                // Contains at least one star, we need to go char by char as there may be multiple
                                for (int j = initialPositionOfRectangle; j < initialPositionOfRectangle + lengthOfRectangle; j++)
                                {
                                    if (lines[i - 1][j] == '*')
                                    {
                                        NumbersAroundPoints.TryAdd((i - 1, j), new List<int>());
                                        NumbersAroundPoints[(i - 1, j)].Add(number);
                                    }
                                }
                            }
                        }

                        // Check if below exists and is touching
                        if (i < lines.Length - 1)
                        {
                            var stringToCompare = lines[i + 1].Substring(initialPositionOfRectangle, lengthOfRectangle);
                            if (stringToCompare.IndexOf('*') != -1)
                            {
                                // Contains at least one star, we need to go char by char as there may be multiple
                                for (int j = initialPositionOfRectangle; j < initialPositionOfRectangle + lengthOfRectangle; j++)
                                {
                                    if (lines[i + 1][j] == '*')
                                    {
                                        NumbersAroundPoints.TryAdd((i + 1, j), new List<int>());
                                        NumbersAroundPoints[(i + 1, j)].Add(number);
                                    }
                                }
                            }
                        }

                        // Number processed, increase counter
                        endOfLastNumber = endOfLastNumber + position + number.ToString().Length;
                    }
                } while (position != -1);

            }

            foreach (var pair in NumbersAroundPoints)
            {
                if (pair.Value.Count == 2)
                {
                    sum += (pair.Value[0] * pair.Value[1]);
                }
            }

            return sum;
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
            return (startsAt, string.Empty == number ? 0 : Convert.ToInt32(number));
        }
    }
}
