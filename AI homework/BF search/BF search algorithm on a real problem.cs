using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Define the graph connections among cities
        var graph = new Dictionary<string, List<string>>
        {
            {"Kabul", new List<string>{"Ghazni", "Jalalabad", "Kandahar"}},
            {"Ghazni", new List<string>{"Kabul"}},
            {"Jalalabad", new List<string>{"Kabul", "Kandahar"}},
            {"Kandahar", new List<string>{"Kabul", "Jalalabad"}},
        };

        // Find the shortest distance path between two cities
        var start = "Kabul";
        var goal = "Jalalabad";
        var path = BfSearch.BfSearchAlg(graph, start, goal);

        if (path != null)
        {
            Console.WriteLine($"The shortest distance path between {start} and {goal} is: {string.Join(", ", path)}");
        }
        else
        {
            Console.WriteLine("No path between the two cities was found.");
        }
    }
}

