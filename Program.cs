
using System;
using System.Collections.Generic;// this is for dictionaries
using System.Text; //for string builders


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solutions.Solution();

            // int result = solution.FindContentChildren(new int[] { 1, 2, 3 }, new int[] { 1, 1 });
            // Console.WriteLine($"Number of content children: {result}");

            // int maxConsecutiveOnes = solution.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 });
            // Console.WriteLine($"Maximum consecutive ones: {maxConsecutiveOnes}");

            // string formattedString = solution.LicenseKeyFormatting("2-5g-3-J", 2);

            // string base7 = solution.ConvertToBase7(0);
            // string rev = solution.ReverseWords("Let's take LeetCode contest");
            // int ways = solution.ClimbStairs(5);
            // bool match = solution.RotateString("abcde", "cdeab");
            int num = solution.Atoi("     +487   ");
        }
    }
}

namespace Solutions
{
    public class Solution
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int mostContent = 0;
            int j = 0;
            for (int i = 0; i < g.Length; i++)
            {
                while (j < s.Length && s[j] < g[i])
                {
                    j++;
                }
                if (j < s.Length)
                {
                    mostContent++;
                    j++;
                }
            }
            return mostContent;
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxNum = 0;
            int temp = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    temp++;
                }
                else
                {
                    temp = 0;
                }
                if (temp > maxNum)
                {
                    maxNum = temp;
                }
            }
            return maxNum;
        }

        public string LicenseKeyFormatting(string s, int k)
        {
            s = s.ToUpper().Replace("-", "");
            var res = "";
            var count = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                res = s[i] + res;
                count++;

                if ((count == k && i != 0))
                {
                    res = "-" + res;
                    count = 0;
                }

            }
            Console.WriteLine($"Res: {res}");
            return res;
        }

        public string ConvertToBase7(int num)
        {
            if (num == 0) return "0";
            bool negative = num < 0;
            string result = string.Empty;
            int baseValue = 7;
            num = Math.Abs(num);
            while (num > 0)
            {
                int remainder = num % baseValue;
                result = remainder.ToString() + result;
                num /= baseValue;
            }
            Console.WriteLine($"Res: {result}");

            return negative ? '-' + result : result;
        }

        public string ReverseWords(string s)
        {
            var arr = s.Split(" ");
            string res = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr[i].Length - 1; j >= 0; j--)
                {
                    res += arr[i][j];
                }

                if (i < arr.Length - 1)
                {
                    res += " ";
                }
            }

            Console.WriteLine($"Res: {res}");
            return res;
        }
        public int ClimbStairs(int n)
        {
            var ways = new Dictionary<int, int>()
            {
                {  0,  1 },
                {  1,  1 }
            };
            for (int i = 2; i <= n; i++)
            {
                if (ways.TryGetValue(i - 1, out int prevStepWays) && ways.TryGetValue(i - 2, out int twoStepsBackWays))
                {
                    ways[i] = prevStepWays + twoStepsBackWays;
                }
                else
                {
                    ways[i] = 1;
                }
            }
            ways.TryGetValue(n, out int result);

            return result;

        }

        public bool RotateString(string s, string goal)
        {
            int i = 0;
            while (i < goal.Length)
            {
                s = s[s.Length - 1] + s.Substring(0, s.Length - 1);
                if (s.Equals(goal))
                {
                    return true;
                }
                i++;
            }

            return false;
        }
        public int Atoi(string s)
        {
            bool negative = false;
            s = s.TrimStart();
            StringBuilder digitsBuilder = new StringBuilder();
            if (s.Length > 0)
            {
                if (s[0] == '-')
                {
                    negative = true;
                    s = s.Substring(1);
                }
                else if (s[0] == '+')
                {
                    s = s.Substring(1);
                }
            }


            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    digitsBuilder.Append(c);
                }
                else
                {
                    break;
                }
            }

            if (digitsBuilder.Length == 0)
            {
                return 0;
            }

            string digits = digitsBuilder.ToString();
            int number;
            bool success = Int32.TryParse(digits, out number);
            if (!success)
            {
                if (negative)
                {
                    return int.MinValue;
                }
                else
                {
                    return Int32.MaxValue;
                }
            }

            checked
            {
                number = negative ? -number : number;
            }

            if (number > Int32.MaxValue)
            {
                return Int32.MaxValue;
            }
            else if (number < -Int32.MaxValue)
            {
                return int.MinValue;
            }

            Console.WriteLine($"Res: {Int32.MaxValue}");
            return number;
        }
    }

}

