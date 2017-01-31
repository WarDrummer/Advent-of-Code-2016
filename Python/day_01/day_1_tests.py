import unittest

from day_1 import Orientation, ShortestDistanceCalculator


class ShortestDistanceCalculatorTests(unittest.TestCase):
    def test_should_start_facing_north(self):
        self.assertEqual(ShortestDistanceCalculator().get_orientation(), Orientation.NORTH)

    def test_should_rotate_right_when_R_command_sent(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("R1")

        self.assertEqual(calculator.get_orientation(), Orientation.EAST)

    def test_should_rotate_back_to_north_after_four_R_commands_sent(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("R1")
        calculator.move("R1")
        calculator.move("R1")
        calculator.move("R1")

        self.assertEqual(calculator.get_orientation(), Orientation.NORTH)

    def test_should_rotate_left_when_L_command_sent(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("L1")

        self.assertEqual(calculator.get_orientation(), Orientation.WEST)

    def test_should_rotate_back_to_north_after_four_L_commands_sent(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("L1")
        calculator.move("L1")
        calculator.move("L1")
        calculator.move("L1")

        self.assertEqual(calculator.get_orientation(), Orientation.NORTH)

    def test_should_move_the_number_of_blocks_given_in_command(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("L200")

        self.assertEqual(calculator.get_shortest_distance(), 200)

    def test_should_cancel_out_movement_when_going_east_and_west(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("L20") # 20 west
        calculator.move("R0") # 0 north
        calculator.move("R10") # 10 east

        self.assertEqual(calculator.get_shortest_distance(), 10)

    def test_should_cancel_out_movement_when_going_north_and_south(self):
        calculator = ShortestDistanceCalculator()

        calculator.move("L0") # 0 west
        calculator.move("R20") # 20 north
        calculator.move("R0") # 10 east
        calculator.move("R10")  # 10 south

        self.assertEqual(calculator.get_shortest_distance(), 10)

    def test_should_parse_delimited_list_of_commands(self):
        calculator = ShortestDistanceCalculator()

        instructions = calculator.get_instructions("R1, R40, L2")

        self.assertEqual(instructions[0], "R1")
        self.assertEqual(instructions[1], "R40")
        self.assertEqual(instructions[2], "L2")

    def test_should_execute_instruction_list(self):
        calculator = ShortestDistanceCalculator()

        instructions = calculator.get_instructions("L0, R20, R0, R10")

        calculator.execute_instructions(instructions)

        distance = calculator.get_shortest_distance()

        self.assertEqual(distance, 10)

if __name__ == '__main__':
    unittest.main()