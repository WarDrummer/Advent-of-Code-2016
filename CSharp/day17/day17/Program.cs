using System;
using System.Collections;
using System.Collections.Generic;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            const string passcode = "veumntbg";
            var q = new Queue<Room>();
            q.Enqueue(new Room(passcode, 0, 0));
            while (q.Count > 0)
            {
                var currentRoom = q.Dequeue();
                if (currentRoom.IsGoal())
                {
                    Console.WriteLine(currentRoom.Passcode.Substring(passcode.Length));
                    break;
                }
                foreach (var unlockedRoom in currentRoom.GetUnlockedRooms())
                {
                    q.Enqueue(unlockedRoom);  
                }
            }

            Console.ReadKey();
        }
    }
}