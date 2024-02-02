
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solutions.Solution();

            int result = solution.FindContentChildren(new int[] { 1, 2, 3 }, new int[] { 1, 1 });
            Console.WriteLine($"Number of content children: {result}");

            int maxConsecutiveOnes = solution.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 });
            Console.WriteLine($"Maximum consecutive ones: {maxConsecutiveOnes}");
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
                if(num == 1){
                    temp++;
                }else {
                    temp = 0;
                }
                if(temp > maxNum){
                    maxNum = temp;
                }
            }
            return maxNum;
        }
    }
}

