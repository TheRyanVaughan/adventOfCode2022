// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
namespace Day5
{
    class Program 
    {
        static string[] readInput() {
            return System.IO.File.ReadAllLines("input.txt");
        }

        static string partOne(string[] input) {
            Stack<char>[] crates = populateInitialCrates(input);
            string[] commands = getCommands(input);
            foreach (var command in commands) {
                doCommand(crates, command);
            }

            string ans = "";
            foreach (var a in crates.Skip(1)) {
                ans += a.Peek();
            }
            return ans;
        }
        
        static string partTwo(string[] input) {
            Stack<char>[] crates = populateInitialCrates(input);
            string[] commands = getCommands(input);
            foreach (var command in commands) {
                doCommandPartTwo(crates, command);
            }

            string ans = "";
            foreach (var a in crates.Skip(1)) {
                ans += a.Peek();
            }
            return ans;
        }
        static void doCommand(Stack<char>[] crates, string command) {
            string[] splits = new string[] {"move", "from", "to"};
            int[] nums = command.Split(splits, StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToArray();

            for (int i = 0; i < nums[0]; i++) {
                crates[nums[2]].Push(crates[nums[1]].Pop());
            }
        }

        static void doCommandPartTwo(Stack<char>[] crates, string command) {
            string[] splits = new string[] {"move", "from", "to"};
            int[] nums = command.Split(splits, StringSplitOptions.RemoveEmptyEntries).Select(s => Int32.Parse(s)).ToArray();

            for (int i = 0; i < nums[0]; i++) {
                crates[0].Push(crates[nums[1]].Pop());
            }

            for (int i = 0; i < nums[0]; i++) {
                crates[nums[2]].Push(crates[0].Pop());
            }
        }
        static void Main(string[] args) {
            string[] input = readInput();
            Console.WriteLine(partOne(input));
            Console.WriteLine(partTwo(input));

        } 

        static Stack<char>[] populateInitialCrates(string[] input) {
            Stack<char>[] stacks = new Stack<char>[10];
            for (int i = 0; i < 10; i++) {
                stacks[i] = new Stack<char>();
            }
            input = input.Take(8).ToArray();
            for (int row = 7; row >= 0; row--) {
                for (int i = 1; i <= 9; i++) {
                    if (input[row][getCharIndex(i)] != ' ') {
                        stacks[i].Push(input[row][getCharIndex(i)]);
                    }
                }
            }
            return stacks;
        }
        static int getCharIndex(int i) {
            return ((i-1) * 4) + 1;
        }
        static string[] getCommands(string[] input) {
            return input.Skip(10).ToArray();
        }


    }
}