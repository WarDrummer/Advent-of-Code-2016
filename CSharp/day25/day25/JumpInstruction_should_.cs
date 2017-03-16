using NUnit.Framework;

namespace day25
{
    // ReSharper disable once InconsistentNaming
    public class JumpInstruction_should_
    {
        [TestCase(3)]
        [TestCase(-1)]
        public void update_instruction_pointer_when_x_value_not_0(int value)
        {
            var computer = new Computer(new [] { Instruction.Create($"jnz 1 {value}") });

            computer.Run();

            Assert.AreEqual(value, computer.InstructionPointer);
        }

        [Test]
        public void increment_instruction_pointer_normally_when_x_value_0()
        {
            var computer = new Computer(new[] { Instruction.Create("jnz 0 3") });

            computer.Run();

            Assert.AreEqual(1, computer.InstructionPointer);
        }

        [Test]
        public void update_instruction_pointer_when_x_register_value_not_0()
        {
            var computer = new Computer(new[] {Instruction.Create("jnz a 3")}) {Registers = {[0] = 1}};
            computer.Run();

            Assert.AreEqual(3, computer.InstructionPointer);
        }

        [Test]
        public void increment_instruction_pointer_normally_when_x_register_value_0()
        {
            var computer = new Computer(new[] { Instruction.Create("jnz a 3") });

            computer.Run();

            Assert.AreEqual(1, computer.InstructionPointer);
        }
    }
}
