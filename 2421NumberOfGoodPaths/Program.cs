namespace _2421NumberOfGoodPaths;

public class Solution
{
    private static int[] _vals;
    public static int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        _vals = vals;
        var sortedEdges = edges.OrderBy(x => Math.Max(vals[x[0]], vals[x[1]]));
        var n = vals.Length;
        var goodPaths = n;
        var par = Enumerable.Range(0, n).ToArray();
        var rank = Enumerable.Repeat(1, n).ToArray();

        goodPaths += (from edge in sortedEdges
            let parentA = FindParent(edge[0], par)
            let parentB = FindParent(edge[1], par)
            select GoodPaths(parentA, parentB, rank, par)).Sum();

        return goodPaths;
    }

    private static int GoodPaths(int parentA, int parentB,  IList<int> rank, IList<int> par)
    {
        var goodPaths = 0;
        if (_vals[parentA] == _vals[parentB])
        {
            goodPaths += rank[parentA] * rank[parentB];
            par[parentA] = parentB;
            rank[parentB] += rank[parentA];
        }
        else if (_vals[parentA] > _vals[parentB])
        {
            par[parentB] = parentA;
        }
        else
        {
            par[parentA] = parentB;
        }

        return goodPaths;
    }

    private static int FindParent(int p, IList<int> par)
    {
        while (par[p] != p)
        {
            par[p] = par[par[p]];
            p = par[p];
        }

        return p;
    }
}