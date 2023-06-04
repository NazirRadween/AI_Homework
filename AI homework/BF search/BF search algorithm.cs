using System;
using System.Collections.Generic;

class BfSearch
{
    public static List<string> BfSearchAlg(Dictionary<string, List<string>> graph, string start, string goal)
    {
        var queue = new Queue<List<string>>();
        var visited = new HashSet<string>();
        queue.Enqueue(new List<string>() {start});

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var current = path[path.Count - 1];

            if (current == goal)
            {
                return path;
            }

            if (!visited.Contains(current))
            {
                visited.Add(current);

                foreach (var neighbor in graph[current])
                {
                    var newPath = new List<string>(path);
                    newPath.Add(neighbor);
                    queue.Enqueue(newPath);
                }
            }
        }

        return null;
    }
}

