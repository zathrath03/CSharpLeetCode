using System.Collections.Generic;
using System.Linq;

namespace _1061.Lexicographically_Smallest_Equivalent_String
{
    public class Solution
    {
        private static Dictionary<char, HashSet<char>> _charMap;
        private static Dictionary<char, char> _memo;

        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            _charMap = new Dictionary<char, HashSet<char>>();
            _memo = new Dictionary<char, char>();

            foreach (var (c1, c2) in s1.Zip(s2, (c1, c2) => (first: c1, second: c2)))
            {
                AddToMap(c1, c2);
                AddToMap(c2, c1);
            }

            return string.Join("", baseStr.Select(Bfs));
        }

        private static void AddToMap(char key, char val)
        {
            if (_charMap.ContainsKey(key))
                _charMap[key].Add(val);
            else
                _charMap[key] = new HashSet<char> { val };
        }

        private static char Bfs(char c)
        {
            if (_memo.ContainsKey(c)) return _memo[c];
            if (!_charMap.ContainsKey(c)) return c;

            var smallestChar = FindSmallestChar(c, out var seen);

            UpdateMemo(seen, smallestChar);

            return smallestChar;
        }

        private static char FindSmallestChar(char c, out HashSet<char> seen)
        {
            var smallestChar = c;
            seen = new HashSet<char>();
            var queue = new HashSet<char> { c };

            smallestChar = SmallestCharLoop(seen, queue, smallestChar);

            return smallestChar;
        }

        private static void UpdateMemo(HashSet<char> seen, char smallestChar)
        {
            foreach (var c in seen) _memo[c] = smallestChar;
        }

        private static char SmallestCharLoop(ISet<char> seen, ISet<char> queue, char smallestChar)
        {
            while (queue.Count > 0)
            {
                var c = Pop(queue);
                if (seen.Contains(c)) continue;
                seen.Add(c);
                smallestChar = smallestChar.CompareTo(c) < 0 ? smallestChar : c;
                queue.UnionWith(_charMap[c]);
            }

            return smallestChar;
        }

        private static char Pop(ICollection<char> queue)
        {
            var c = queue.First();
            queue.Remove(c);
            return c;
        }
    }
}