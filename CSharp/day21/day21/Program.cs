using System;
using System.Collections.Generic;
using Tools;

namespace day21
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = "abcdefgh";
            var reversalInstructions = new Stack<Instruction>();
            foreach (var instructionText in LineByLine.GetLines("input.txt"))
            {
                password = Instruction.Create(instructionText).Mutate(password);
                reversalInstructions.Push(Instruction.CreateReverse(instructionText));
            }
            Console.WriteLine("Encoded: " + password);

            var passwordToDecode = "fbgdceah";
            while (reversalInstructions.Count > 0)
            {
                var instruction = reversalInstructions.Pop();
                passwordToDecode = instruction.Mutate(passwordToDecode);
            }

            Console.WriteLine("Decoded: " + passwordToDecode);

            Console.ReadKey();
        }
    }
}
