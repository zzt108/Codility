using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrefixMaxProd;
namespace PerfTest
{
  class Program
  {

    private static string Concat(string s, int count)
    {
      var result = new StringBuilder(s.Length * count);

      for (int i = 0; i < count; i++)
      {
        result.Append(s);
      }
      return result.ToString();
    }

    static void Main(string[] args)
    {
      new Solution().solution(Concat("aaaaa", 200));
    }
  }
}
