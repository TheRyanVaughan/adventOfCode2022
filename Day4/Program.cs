// See https://aka.ms/new-console-template for more information
// num-num,num-num
using System;
using System.Linq;
namespace Day4
{
    class Program
    {
        static void Main(String[] args) {
            string[] input = System.IO.File.ReadAllLines("testOverlaps.txt");
            Console.WriteLine(partOne(input));
            Console.WriteLine(partTwo(input));
        }
        static int partOne(string[] input) {
            int overlaps = 0;
            foreach (string line in input) {
                string[] split = line.Split(',', '-');
                int[] parsed = split.Select(strNum => Int32.Parse(strNum)).ToArray();
                Interval first = new Interval(parsed[0], parsed[1]);
                Interval second = new Interval(parsed[2], parsed[3]);
                overlaps += (first.fullyOverlaps(second)) ? 1 : 0;
            }
            return overlaps;
        }

        static int partTwo(string[] input) {
            int overlaps = 0;
            foreach (string line in input) {
                string[] split = line.Split(',', '-');
                int[] parsed = split.Select(strNum => Int32.Parse(strNum)).ToArray();
                Interval first = new Interval(parsed[0], parsed[1]);
                Interval second = new Interval(parsed[2], parsed[3]);
                overlaps += (first.anyOverlap(second)) ? 1 : 0;
            }
            return overlaps;
        }
    }

    class Interval
    {
        int start;
        int end;
        public bool fullyOverlaps(Interval o) {
            return (this.start <= o.start && this.end >= o.end) || (o.start <= this.start && o.end >= this.end);
        }

        public bool anyOverlap(Interval o) {
            return (this.start <= o.start && this.end >= o.start) || (this.start >= o.start && this.start <= o.end);
        }

        public Interval(int x, int y) {
            this.start = x;
            this.end = y;
        }
    }
}