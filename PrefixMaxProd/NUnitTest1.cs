using System;
using System.Text;
using NUnit.Framework;

namespace PrefixMaxProd
{
    // 160617 9:55 - 10:16
    //https://codility.com/demo/results/trainingSY6MXX-FBV/
    /*
     A prefix of a string S is any leading contiguous part of S. For example, "c" and "cod" are prefixes of the string "codility". For simplicity, we require prefixes to be non-empty.

The product of prefix P of string S is the number of occurrences of P multiplied by the length of P. More precisely, if prefix P consists of K characters and P occurs exactly T times in S, then the product equals K * T.

For example, S = "abababa" has the following prefixes:

"a", whose product equals 1 * 4 = 4,
"ab", whose product equals 2 * 3 = 6,
"aba", whose product equals 3 * 3 = 9,
"abab", whose product equals 4 * 2 = 8,
"ababa", whose product equals 5 * 2 = 10,
"ababab", whose product equals 6 * 1 = 6,
"abababa", whose product equals 7 * 1 = 7.
The longest prefix is identical to the original string. The goal is to choose such a prefix as maximizes the value of the product. In above example the maximal product is 10.

In this problem we consider only strings that consist of lower-case English letters (a−z).

Write a function

class Solution { public int solution(string S); }
that, given a string S consisting of N characters, returns the maximal product of any prefix of the given string. If the product is greater than 1,000,000,000 the function should return 1,000,000,000.

For example, for a string:

S = "abababa" the function should return 10, as explained above,
S = "aaa" the function should return 4, as the product of the prefix "aa" is maximal.
Assume that:

N is an integer within the range [1..300,000];
string S consists only of lower-case letters (a−z).
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N) (not counting the storage required for input arguments).*/

    class Solution {
        public int solution(string S)
        {
            const int maxResult = 1000000000;

            int result = 0;
            for (var i = 1; i <= S.Length; i++)
            {
                var prefix = GetPrefix(S, i);
                int prod = GetProd(S, prefix);
                if (prod > maxResult)
                {
                    return maxResult;
                }
                result = Math.Max(result, prod);

            }
            return result;
        }

        private int GetProd(string s, string prefix)
        {
            int occurence = 1;
            var length = prefix.Length;
            for (int i = 1; i < s.Length; i++)
            {
                if (s.Length >= i+length && s.Substring(i,length) == prefix)
                {
                    occurence++;
                }
            }
            return occurence*length;
        }

        private static string GetPrefix(string s, int i)
        {
            return s.Substring(0,i);
        }
    }



    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void TestDefault()
        {
            Assert.That(new Solution().solution("abababa"), Is.EqualTo(10));
            Assert.That(new Solution().solution("aaa"), Is.EqualTo(4));
            Assert.That(new Solution().solution(""), Is.EqualTo(0));

            Assert.That(new Solution().solution(Concat("aaaaa", 1000)), Is.EqualTo(6252500));
        }

        private static string Concat(string s, int count)
        {
            var result = new StringBuilder(s.Length*count);

            for (int i = 0; i < count; i++)
            {
                result.Append(s);
            }
            return result.ToString();
        }
    }
}