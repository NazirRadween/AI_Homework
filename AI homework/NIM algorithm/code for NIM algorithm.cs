using System;

class NIM
{
    static void Main(string[] args)
    {
        int[] objects = { 3, 4, 5, 7 };
        int turn = 0;

        Console.WriteLine("Welcome to NIM game!");

        while (isGameOver(objects) == false)
        {
            Console.WriteLine("Player " + (turn + 1) + "'s turn");
            Console.Write("Objects: ");
            for (int i = 0; i < objects.Length; i++)
            {
                Console.Write(objects[i] + " ");
            }
            Console.WriteLine();

            Console.Write("Choose an object: ");
            int objectIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("Number of objects to remove: ");
            int numToRemove = Convert.ToInt32(Console.ReadLine());

            objects[objectIndex] -= numToRemove;
            turn = (turn + 1) % 2;
        }

        Console.WriteLine("Player " + (turn + 1) + " wins!");
        Console.ReadLine();
    }

    static bool isGameOver(int[] objects)
    {
        int xorSum = objects[0];

        for (int i = 1; i < objects.Length; i++)
        {
            xorSum ^= objects[i];
        }

        return xorSum == 0;
    }
}
