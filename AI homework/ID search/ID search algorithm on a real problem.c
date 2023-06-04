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

    List<string> path = IdSearch(graph, "Kabul", "Mazar-i-Sharif", 4);

    if (path != null) {
      Console.WriteLine(string.Join(" -> ", path));
    } else {
      Console.WriteLine("Path not found");
    }
  }

  static List<string> IdSearch(Dictionary<string, List<string>> graph, string startNode, string endNode, int depth) {
    if (startNode == endNode) {
      
      return new List<string>() {startNode};
    } else if (depth == 0) {
      return null;
    } else {

      foreach (string neighbor in graph[startNode]) {
        List<string> path = IdSearch(graph, neighbor, endNode, depth - 1);
        
        if (path != null) {
      
          path.Insert(0, startNode);
          return path;
        }
      }
      
      return null;
    }
  }
}
