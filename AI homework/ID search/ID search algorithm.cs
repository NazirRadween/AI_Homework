using System;
using System.Collections.Generic;

class IdSearch
{
    // Recursive function to perform the depth-limited search
    private static List<string> Dls(Dictionary<string, List<string>> graph, string current, string goal, int limit, HashSet<string> visited)
    {
        visited.Add(current);
        if (current == goal)
        {
            return new List<string> { current };
        }
        else if (limit == 0)
        {
            return null;
        }
        else
        {
            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    var path = Dls(graph, neighbor, goal, limit - 1, visited);
                    if (path != null)
                    {
                        path.Insert(0, current);
                        return path;
                    }
                }
            }
            return null;
        }
    }

    public static List<string> IdSearchAlg(Dictionary<string, List<string>> graph, string start, string goal, int depthLimit)
    {
        for (int limit = 0; limit <= depthLimit; limit++)
        {
            var visited = new HashSet<string>();
            var path = Dls(graph, start, goal, limit, visited);
            if (path != null)
            {
                return path;
            }
        }
        return null;
    }
}
