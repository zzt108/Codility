using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoviStar
{
    class Solution
    {
        private static int MonthNumber(string monthName)
        {
            switch (monthName.ToLower())
            {
                case "january":
                    {
                        return 1;
                    }
                case "february":
                    {
                        return 2;
                    }
                case "march":
                    {
                        return 3;
                    }
                case "april":
                    {
                        return 4;
                    }
                case "may":
                    {
                        return 5;
                    }
                case "june":
                    {
                        return 6;
                    }
                case "july":
                    {
                        return 7;
                    }
                case "august":
                    {
                        return 8;
                    }
                case "september":
                    {
                        return 9;
                    }
                case "october":
                    {
                        return 10;
                    }
                case "november":
                    {
                        return 11;
                    }

                case "december":
                    {
                        return 12;
                    }

                default:
                    return 0;
            }
        }
        public int answer(int year, string monthA, string monthB, string newYearW)
        {
            var day1 = new DateTime(year, MonthNumber(monthA), 1);
            var monthNum2 = MonthNumber(monthB);
            var year2 = year;
            //let DateTime find the last day of the second month
            var nextMonth = monthNum2+1;
            if (nextMonth == 13)
            {
                year2 = year + 1;
                nextMonth = 1;
            }
           
            var day2 = new DateTime(year2, nextMonth, 1);
            var lastSunday = day2.AddDays(-1*(int) day2.DayOfWeek);
            var dayCount = (lastSunday - day1).Days + 1;
            var weeks = dayCount/7;
 
            return weeks;
        }

        public int solution(int Y, string A, string B, string W)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return answer(Y, A, B, W);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert.AreEqual(7, new Solution().solution(2014, "April", "May", "Wednesday"));
            Assert.AreEqual(4, new Solution().solution(2016, "May", "May", "Wednesday"));
            Assert.AreEqual(4, new Solution().solution(2016, "July", "July", "Wednesday"));
            Assert.AreEqual(52, new Solution().solution(2007, "January", "December", "Wednesday"));
            Assert.AreEqual(4, new Solution().solution(2016, "February", "February", "Wednesday"));
            //Assert.AreEqual(3, new Solution().solution(2014, "December", "December", "Wednesday"));
        }
    }
}
