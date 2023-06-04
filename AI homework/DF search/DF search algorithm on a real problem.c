using System;
using System.Collections.Generic;

class MainClass {
  static void Main() {
    
    Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>() {
      {"Kabul", new List<string>() {"Ghazni", "Jalalabad"}},
      {"Ghazni", new List<string>() {"Kabul", "Kandahar", "Paktika"}},
      {"Jalalabad", new List<string>() {"Kabul", "Peshawar"}},
      {"Kandahar", new List<string>() {"Ghazni", "Spin Boldak"}},
      {"Spin Boldak", new List<string>() {"Kandahar", "Quetta"}},
      {"Quetta", new List<string>() {"Spin Boldak", "Chaman"}},
      {"Chaman", new List<string>() {"Quetta", "Spin Boldak", "Herat"}},
      {"Herat", new List<string>() {"Chaman", "Mazar-i-Sharif"}},
      {"Mazar-i-Sharif", new List<string>() {"Herat"}}
    };

  
    List<string> path = DfsSearch(graph, "Kabul", "Mazar-i-Sharif");

    if (path != null) {
      Console.WriteLine(string.Join(" -> ", path));
    } else {
      Console.WriteLine("Path not found");
    }
  }

  static List<string> DfsSearch(Dictionary<string, List<string>> graph, string startNode, string endNode) {

    Stack<string> stack = new Stack<string>();
    HashSet<string> visited = new HashSet<string>();

    stack.Push(startNode);

    while (stack.Count > 0) {
      string currentNode = stack.Pop();

      if (currentNode == endNode) {
        List<string> path = new List<string>();
        path.Insert(0, endNode);
        string parent = currentNode;
        while (graph.ContainsKey(parent)) {
          List<string> neighbors = graph[parent];
          foreach (string neighbor in neighbors) {
            if (visited.Contains(neighbor)) {
              path.Insert(0, neighbor);
              parent = neighbor;
              break;
            }
          }
        }

        path.Insert(0, startNode);
        return path;
      }
      if (!visited.Contains(currentNode)) {
        visited.Add(currentNode);
        List<string> neighbors = graph[currentNode];
        foreach (string neighbor in neighbors) {
          stack.Push(neighbor);
        }
      }
    }

    return null;
  }
}

