using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            const string passcode = "veumntbg";
            var q = new Queue<Room>();
            q.Enqueue(new Room(passcode, 0, 0));
            var goals = new List<int>();
            string shortestPath= string.Empty;
            while (q.Count > 0)
            {
                var currentRoom = q.Dequeue();
                if (currentRoom.IsGoal())
                {
                    var path = currentRoom.Passcode.Substring(passcode.Length);
                    if (string.IsNullOrEmpty(shortestPath))
                        shortestPath = path;
                    goals.Add(path.Length);
                    continue;
                }
                foreach (var unlockedRoom in currentRoom.GetUnlockedRooms())
                {
                    q.Enqueue(unlockedRoom);  
                }
            }

            Console.WriteLine("Shortest path: " + shortestPath);
            Console.WriteLine("Longest path: " + goals.Max());
            Console.ReadKey();
        }
    }
}