using AOC23.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC23.Tasks
{
    public static class Task05
    {
        internal class MapLine
        {
            public (long, long) SourceRange { get; set; }
            public (long, long) DestinationRange { get; set; }
            public MapLine(string line)
            {
                var parts = line.Split(' ');
                var destination = Convert.ToInt64(parts[0]);
                var source = Convert.ToInt64(parts[1]);
                var range = Convert.ToInt64(parts[2]);

                SourceRange = (source, source + range - 1);
                DestinationRange = (destination, destination + range - 1);
            }
        }

        internal class Map
        {
            public string Source { get; set; }
            public string Destination { get; set; }
            public List<MapLine> Lines { get; set; }

            public Map(int i, string[] lines)
            {
                // initial line is to define source and destination
                var mapDefinition = lines[i].Substring(0, lines[i].IndexOf(' '));
                var parts = mapDefinition.Split("-to-");
                Source = parts[0];
                Destination = parts[1];
                Lines = new List<MapLine>();

                i++;
                while (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]))
                {
                    Lines.Add(new MapLine(lines[i]));
                    i++;
                }
            }
        }


        public static object Part1(string filePath)
        {
            List<Map> maps = new List<Map>();

            long min = long.MaxValue;
            var lines = FileAux.GetInputData(filePath);

            var seeds = lines[0].Split(": ")[1].Split(" ").Select(s => Convert.ToInt64(s)).ToArray();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    maps.Add(new Map(i + 1, lines));
                }
            }

            List<string> categories = new List<string> { "seed", "soil", "fertilizer", "water", "light", "temperature", "humidity", "location" };
            for (int i = 0; i < seeds.Length; i++)
            {
                var myValue = seeds[i];
                for(int j = 0; j < categories.Count - 1; j++)
                {
                    myValue = ConvertValues(myValue, categories[j], categories[j + 1], maps);
                }

                if (myValue < min)
                {
                    min = myValue;
                }
            }


            return min;
        }

        public static object Part2(string filePath)
        {
            List<Map> maps = new List<Map>();

            long min = long.MaxValue;
            var lines = FileAux.GetInputData(filePath);

            var seeds = lines[0].Split(": ")[1].Split(" ").Select(s => Convert.ToInt64(s)).ToArray();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    maps.Add(new Map(i + 1, lines));
                }
            }

            List<string> categories = new List<string> { "seed", "soil", "fertilizer", "water", "light", "temperature", "humidity", "location" };
            
            // Loop over first range
            for (int i = 0; i < seeds[1]; i++)
            {
                var myValue = seeds[0] + i;
                for (int j = 0; j < categories.Count - 1; j++)
                {
                    myValue = ConvertValues(myValue, categories[j], categories[j + 1], maps);
                }

                if (myValue < min)
                {
                    min = myValue;
                }
            }

            // Loop over second range
            for (int i = 0; i < seeds[3]; i++)
            {
                var myValue = seeds[2] + i;
                for (int j = 0; j < categories.Count - 1; j++)
                {
                    myValue = ConvertValues(myValue, categories[j], categories[j + 1], maps);
                }

                if (myValue < min)
                {
                    min = myValue;
                }
            }


            return min;
        }



        /// <summary>
        /// Method converts Values based on input value, input value type, output value type and maps that were parsed 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="maps"></param>
        /// <returns></returns>
        private static long ConvertValues(long input, string source, string destination, List<Map> maps)
        {
            var map = maps.First(m => m.Source == source && m.Destination == destination);
            var mapLine = map.Lines.FirstOrDefault(l => l.SourceRange.Item1 <= input && l.SourceRange.Item2 >= input);

            if (mapLine == null) 
            {
                // No mapping exists, return the same number
                return input;
            }
            else
            {
                var delta = mapLine.DestinationRange.Item1 - mapLine.SourceRange.Item1;
                return input + delta;
            }
        }
    }
}
