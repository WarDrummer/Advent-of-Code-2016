import unittest

from day_18 import MapGenerator, RowGenerator, MapGeneratorRecursive


class MockRowGenerator(RowGenerator):

    def __init__(self, next_row):
        self.next_row = next_row

    def get_next_row(self, row):
        return self.next_row


class MapGeneratorTests(unittest.TestCase):
    def test_should_count_safe_tiles_in_starting_row(self):
        num_rows = 1
        starting_row = '..^^'

        self.assertEqual(MapGenerator(RowGenerator()).get_number_of_safe_tiles(starting_row, num_rows), 2)

    def test_should_aggregate_safe_tile_counts_for_all_rows(self):
        num_rows = 3
        starting_row = row_with_one_safe_tile = '^^.^^'

        row_generator = MockRowGenerator(row_with_one_safe_tile)

        self.assertEqual(MapGenerator(row_generator).get_number_of_safe_tiles(starting_row, num_rows), num_rows)

    def test_aoc_large(self):
        num_rows = 10
        starting_row = ".^^.^.^^^^"

        self.assertEqual(MapGenerator(RowGenerator()).get_number_of_safe_tiles(starting_row, num_rows), 38)


class RowGeneratorTests(unittest.TestCase):
    def test_should_generate_trap_when_previous_row_left_only_is_trap(self):
        previous_row = '.^.'

        next_row = RowGenerator().get_next_row(previous_row)

        self.assertEqual(next_row[2], '^')

    def test_should_generate_trap_when_previous_row_left_and_center_are_traps(self):
        previous_row = '.^^'

        next_row = RowGenerator().get_next_row(previous_row)

        self.assertEqual(next_row[2], '^')

    def test_should_generate_trap_when_previous_row_right_only_is_trap(self):
        previous_row = '.^.'

        next_row = RowGenerator().get_next_row(previous_row)

        self.assertEqual(next_row[0], '^')

    def test_should_generate_trap_when_previous_row_right_and_center_are_traps(self):
        previous_row = '^^.'

        next_row = RowGenerator().get_next_row(previous_row)

        self.assertEqual(next_row[0], '^')


class MapGeneratorRecursiveTests(unittest.TestCase):
    def test_should_count_safe_tiles_in_starting_row(self):
        num_rows = 1
        starting_row = '..^^'

        self.assertEqual(MapGeneratorRecursive(RowGenerator()).get_number_of_safe_tiles(starting_row, num_rows), 2)

    def test_should_aggregate_safe_tile_counts_for_all_rows(self):
        num_rows = 3
        starting_row = row_with_one_safe_tile = '^^.^^'

        row_generator = MockRowGenerator(row_with_one_safe_tile)

        self.assertEqual(MapGeneratorRecursive(row_generator).get_number_of_safe_tiles(starting_row, num_rows), num_rows)

    def test_aoc_large(self):
        num_rows = 10
        starting_row = ".^^.^.^^^^"

        self.assertEqual(MapGeneratorRecursive(RowGenerator()).get_number_of_safe_tiles(starting_row, num_rows), 38)


if __name__ == '__main__':
    unittest.main()
