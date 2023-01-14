using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _1061.Lexicographically_Smallest_Equivalent_String
{
    // You are given two strings of the same length s1 and s2 and a string baseStr.

    // We say s1[i] and s2[i] are equivalent characters.

    // For example, if s1 = "abc" and s2 = "cde", then we have 'a' == 'c', 'b' == 'd', and 'c' == 'e'.
    // Equivalent characters follow the usual rules of any equivalence relation:

    // Reflexivity: 'a' == 'a'.
    // Symmetry: 'a' == 'b' implies 'b' == 'a'.
    // Transitivity: 'a' == 'b' and 'b' == 'c' implies 'a' == 'c'.
    // For example, given the equivalency information from s1 = "abc" and s2 = "cde", "acd" and "aab" are equivalent strings of baseStr = "eed", and "aab" is the lexicographically smallest equivalent string of baseStr.

    // Return the lexicographically smallest equivalent string of baseStr by using the equivalency information from s1 and s2.
    internal class Program
    {
        private static void Main()
        {
            var testCases = new List<(string, string, string, string)>
            {
                ("parker", "morris", "parser", "makkek"),
                ("hello", "world", "hold", "hdld"),
                ("leetcode", "programs", "sourcecode", "aauaaaaada")
            };

            var sol = new Solution();
            foreach (var (s1, s2, baseStr, expected) in testCases)
            {
                var result = sol.SmallestEquivalentString(s1, s2, baseStr);
                Console.WriteLine(
                    $"SmallestEquivalentString({s1}, {s2}, {baseStr}) = {result} when {expected} was expected");
                Debug.Assert(result == expected);
            }
        }
    }
}