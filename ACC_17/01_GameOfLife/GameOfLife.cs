using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACC17._01_GameOfLife {
    /// <summary>
    ///     Implementation for the TGM HIT Advent Coding Contest 2017 in C#
    /// </summary>
    /// <author>
    ///     Marc Rousavy (marcrousavy@hotmail.com)
    /// </author>
    public class GameOfLife {
        /// <summary>
        ///     A basic Game Of Life Cell
        /// </summary>
        private struct Cell {
            /// <summary>
            ///     A Value indicating whether this Cell is alive or not
            /// </summary>
            public bool Alive { get; set; }

            public override string ToString() => ToChar().ToString();
            public char ToChar() => Alive ? '1' : '0';
        }


        /// <summary>
        ///     The constructor of GameOfLife initializes the pattern and all the private attributes
        /// </summary>
        /// <param name="initPattern">
        ///     should obey this definition for a pattern <code>"3;3;0;110001110$"</code>, where the information is
        ///     defined as <code>"width;height;generation;[row][row][row]$"</code> and the dollar($) at the end marks
        ///     the End-Of-Line.
        /// </param>
        public GameOfLife(string initPattern) {
            string[] info = initPattern.Split(";");
            Width = int.Parse(info[0]);
            Height = int.Parse(info[1]);
            Generation = int.Parse(info[2]);
            Pattern = info[3].Substring(0, info[3].Length - 1);
            RuleSet = new HashSet<string>();
        }

        private int Width { get; }

        private int Height { get; }

        private int Generation { get; set; }

        private HashSet<string> RuleSet { get; }

        private Cell[,] Matrix { get; set; }

        private string Pattern {
            get => ToPattern();
            set => Matrix = ToMatrix(value);
        }

        /// <summary>
        ///     Returns a pattern as a String for the given generation number.
        /// </summary>
        /// <param name="generation">
        ///     The generation for which the pattern should be returned.
        /// </param>
        /// <returns>
        ///     should obey this definition for a pattern "3;3;0;110001110$", where the information is defined as
        ///     <code>"width;height;generation;[row][row][row]$"</code> and the dollar ($) at the end marks the End-Of-Line.
        /// </returns>
        public string GetPattern(int generation) {
            for(int g = Generation; g < generation; g++) {
                for(int w = 0; w < Width; w++) {
                    for(int h = 0; h < Height; h++) {
                        int count = SurroundedBy(Matrix, w, h);
                        if(count < 3)
                            Matrix[w, h].Alive = false; // Starvation
                        else if(count == 3)
                            Matrix[w, h].Alive = true;  // Kept alive
                        else if(count > 3)
                            Matrix[w, h].Alive = false; // Overpopulation
                    }
                }
            }

            var ret = new StringBuilder();
            ret.Append(Width + ";");
            ret.Append(Height + ";");
            ret.Append(Generation + ";");
            ret.Append(Pattern + "$\n");
            return ret.ToString();
        }


        private static int SurroundedBy(Cell[,] array, int x, int y) {
            int count = 0;

            for(int xs = x - 1; xs < x + 1; xs++) {
                for(int ys = y - 1; ys < y + 1; ys++) {
                    if(xs <= 0 || xs >= array.Length || ys <= 0 || ys >= array.Length)
                        continue;
                    if(array[xs, ys].Alive)
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        ///     Returns the pattern of the next generation.
        /// </summary>
        /// <returns>
        ///     should obey this definition for a pattern "3;3;0;110001110$", where
        ///     the information is defined as <code>"width;height;generation;[row][row][row]$"</code>
        ///     and the dollar ($) at the end marks the End-Of-Line.
        /// </returns>
        public string GetNextPattern() {
            return GetPattern(++Generation);
        }

        /// <summary>
        ///     Returns the pattern of the previous generation.
        /// </summary>
        /// <returns>
        ///     should obey this definition for a pattern "3;3;0;110001110$", where
        ///     the information is defined as <code>"width;height;generation;[row][row][row]$"</code>
        ///     and the dollar ($) at the end marks the End-Of-Line.
        /// </returns>
        public string GetPreviousPattern() {
            return GetPattern(--Generation);
        }

        /// <summary>
        ///     Adding one rule to the Game-Of-Life Engine rule-set.
        /// </summary>
        /// <param name="descriptionId">
        ///     A String which defines a Game-Of-Life rule.
        /// </param>
        public void AddRule(string descriptionId) {
            RuleSet.Add(descriptionId);
        }

        /// <summary>
        ///     Adding rules to the Game-Of-Life Engine rule-set.
        /// </summary>
        /// <param name="descriptionIdList">
        ///     A List of Strings with Game-Of-Life rules.
        /// </param>
        public void AddRules(List<string> descriptionIdList) {
            descriptionIdList.ForEach(AddRule);
        }

        /// <summary>
        ///     Removing one rule from the Game-Of-Life Engine rule-set.
        /// </summary>
        /// <param name="descriptionId">
        ///     A String which defines a Game-Of-Life rule.
        /// </param>
        public void RemoveRule(string descriptionId) {
            RuleSet.Remove(descriptionId);
        }

        /// <summary>
        ///     Removing rules from the Game-Of-Life Engine rule-set.
        /// </summary>
        /// <param name="descriptionIdList">
        ///     A List of Strings with Game-Of-Life rules.
        /// </param>
        public void RemoveRules(List<string> descriptionIdList) {
            descriptionIdList.ForEach(RemoveRule);
        }

        /// <summary>
        ///     Exporting the patterns to a file. Example:
        ///     * <code>2;2;0;1011$ 2;2;1;0000$</code>
        ///     * <code>2;2;2;0000$ 2;2;3;0000$ 2;2;4;0000$</code>
        /// </summary>
        /// <param name="start">
        ///     First generation number.
        /// </param>
        /// <param name="end">
        ///     Last generation number.
        /// </param>
        /// <param name="filename">
        ///     Name of File.
        /// </param>
        public void ExportGenerations(int start, int end, string filename) {
            var output = new StringBuilder();

            if (start <= end)
                for (int i = start; i <= end; i++)
                    output.Append(GetPattern(i));
            else
                for (int i = end; i >= start; i--)
                    output.Append(GetPattern(i));

            try {
                File.WriteAllText(filename, output.ToString());
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        ///     Check your functionality with this main method.
        /// </summary>
        /// <param name="args">
        ///     Define as first parameter the pattern (e.g. "4;4;0;1011101010101001$"),
        ///     second the filename, third the start generation and as last parameter
        ///     the end generation. E.g. dotnet run 01_GameOfLife 4;4;0;1011101010101001$ out.csv 0 100
        /// </param>
        public static void Main(string[] args) {
            GameOfLife gol;

            if (args.Length != 4) {
                gol = new GameOfLife("4;4;0;1011101010101001$");
                gol.ExportGenerations(0, 5, "output.csv");
            } else if (args.Length == 4) {
                try {
                    gol = new GameOfLife(args[0]);
                    gol.ExportGenerations(int.Parse(args[2]), int.Parse(args[3]), args[1]);
                } catch (FormatException e) {
                    Console.WriteLine(e);
                }
            }
        }
    }
}