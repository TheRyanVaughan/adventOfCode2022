using System;

namespace day3 {
    class Program {
        private static int sum = 0;
        static void Main(string[] args) {
            runPartTwo();
        }

        private static void runPartOne() {
            string[] lines = getLines();
            foreach (string line in lines) {
                sum += getScore(line);
            }
            Console.WriteLine(sum);
        }

        private static void runPartTwo() {
            string[] lines = getLines();
            for (int i = 0; i < lines.Length; i += 3) {
                sum += getScoreGrouped(lines[i], lines[i+1], lines[i+2]);
            }
            Console.WriteLine(sum);
        }

        private static string[] getLines() {
            return System.IO.File.ReadAllLines("./input.txt");
        }

        private static int getScoreGrouped(string a, string b, string c) {
            HashSet<char> first = new HashSet<char>();
            for (int i = 0; i < a.Length; i++) {
                first.Add(a[i]);
            }
            HashSet<char> second = new HashSet<char>();

            for (int i = 0; i < b.Length; i++) {
                second.Add(b[i]);
            }

             HashSet<char> third = new HashSet<char>();

            for (int i = 0; i < c.Length; i++) {
                third.Add(c[i]);
            }

            first.IntersectWith(b);
            first.IntersectWith(c);

            foreach (char d in first) {
                return getPriority(d);
            }
            return 0;
        }
        private static int getScore(string line) {
            return getPriority(getRepeatCharacter(line));
        }

        private static char getRepeatCharacter(string line) {
            HashSet<char> firstHalf = new HashSet<char>();
            for (int i = 0; i < line.Length / 2; i++) {
                firstHalf.Add(line[i]);
            }

            for (int i = line.Length / 2; i < line.Length; i++) {
                if (firstHalf.Contains(line[i])) {
                    Console.WriteLine($"{line[i]} {getPriority(line[i])}");
                    return line[i];
                }
            }
            return line[0];
        }

        private static int getPriority(char c) {
            if (c <= 'z' && c >= 'a') {
                return 1 + (c - 'a');
            }
            else {
                return 26 +  (1 + (c - 'A'));
            }
        }
    }
}