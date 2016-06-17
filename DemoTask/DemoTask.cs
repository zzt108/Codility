using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    class Solution
    {
        private bool SimpleSum(int[] A, int pos)
        {
            long left = 0;
            long right = 0;
            var index = 0;

            foreach (var i in A)
            {
                if (index < pos)
                {
                    left += i;
                }
                if (index > pos)
                {
                    right += i;
                }
                index++;
            }
            return left == right;
        }

        private decimal InitSum(int[] a)
        {
            decimal result = 0;
            for (int i = 1; i <= a.GetUpperBound(0); i++)
            {
                result += a[i];
            }
            return result;
        }

        private int FastSolution(int[] a)
        {
            decimal left = 0;
            decimal right = InitSum(a);
            var upperBound = a.GetUpperBound(0);
            for (var i = 0; i <= upperBound; i++)
            {
                if (left == right)
                {
                    return i;
                }
                else
                {
                    left += a[i];
                    if (i<upperBound)
                    {
                        right -= a[i + 1];                        
                    }
                }
            }
            return -1;

        }
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //return SimpleSolution(A);
            return FastSolution(A);
        }

        private int SimpleSolution(int[] A)
        {
            for (var i = 0; i <= A.GetUpperBound(0); i++)
            {
                if (SimpleSum(A, i))
                {
                    return i;
                }
            }
            return -1;
        }
    }

    [TestClass]
    public class DemoTask
    {
  
        [TestMethod]
        public void TestMethod1()
        {
            var a = new[]{-1, 3, -4, 5, 1, -6, 2, 1};
            Assert.AreEqual(1, new Solution().solution(a));

            a = new[] { 1, 2, 1 };
            Assert.AreEqual(1, new Solution().solution(a));

            a = new[] { -2147483648 };
            Assert.AreEqual(0, new Solution().solution(a));

            a = new[] { 0, 0 };
            Assert.AreEqual(0, new Solution().solution(a));

            a = new[] { -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648 };
            Assert.AreEqual(5, new Solution().solution(a)); 

        }
    }
}
