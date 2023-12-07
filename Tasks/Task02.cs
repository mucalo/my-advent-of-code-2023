using AOC23.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task02
    {
        internal class GameLine
        {
            public int Red { get; set; }
            public int Green { get; set; }
            public int Blue { get; set; }

            public bool IsViolatingPartOne
            {
                get
                {
                    return Red > 12 || Green > 13 || Blue > 14;
                }
            }

            public GameLine(string gameLine)
            {
                var items = gameLine.Split(", ");
                foreach (var item in items)
                {
                    var itemParts = item.Split(" ");
                    if (itemParts[1] == "red") Red = Convert.ToInt32(itemParts[0]);
                    if (itemParts[1] == "blue") Blue = Convert.ToInt32(itemParts[0]);
                    if (itemParts[1] == "green") Green = Convert.ToInt32(itemParts[0]);

                }
            }

        }

        internal class Game
        {
            public int Index { get; set; }
            public List<GameLine> GameLines { get; set; }

            public int GetMaxRed
            {
                get
                {
                    return GameLines.Max(x => x.Red);
                }
            }
            public int GetMaxGreen
            {
                get
                {
                    return GameLines.Max(x => x.Green);
                }
            }
            public int GetMaxBlue
            {
                get
                {
                    return GameLines.Max(x => x.Blue);
                }
            }


            public bool IsViolatingPartOne { get; set; } = false;
            public Game(string inputLine, int knownIndex)
            {
                // Index = knownIndex;
                var restOfLine = inputLine.Substring(inputLine.IndexOf(": ") + 2);
                GameLines = new List<GameLine>();
                var games = restOfLine.Split("; ");
                foreach (var game in games)
                {
                    var gameLine = new GameLine(game);
                    if (gameLine.IsViolatingPartOne) IsViolatingPartOne = true;
                    GameLines.Add(gameLine);
                }
                Index = knownIndex;
            }
        }

        public static object Part1(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            int sum = 0;
            int index = 1;
            foreach (var line in lines)
            {
                var game = new Game(line, index);
                if (!game.IsViolatingPartOne) sum += index;
                index++;
            }

            return sum;
        }

        public static object Part2(string filePath)
        {
            var lines = FileAux.GetInputData(filePath);
            int sum = 0;
            int index = 1;
            foreach (var line in lines)
            {
                var game = new Game(line, index);
                sum += (game.GetMaxRed * game.GetMaxGreen * game.GetMaxBlue);
            }

            return sum;
        }
    }
}
