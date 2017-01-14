SAFE = '.'
TRAP = '^'


class MapGenerator:

    def __init__(self, row_generator):
        self.row_generator = row_generator

    def get_number_of_safe_tiles(self, firstRow, num_rows):
        num_of_safe_tiles = firstRow.count('.')
        prev_row = firstRow
        for i in range(0, num_rows-1):
            prev_row = self.row_generator.get_next_row(prev_row)
            num_of_safe_tiles += prev_row.count('.')
        return num_of_safe_tiles


class RowGenerator:

    def __init__(self):
        pass

    def get_next_row(self, row):
        new_cell_list = []
        num_cells = len(row)
        last_index = num_cells - 1

        for i in range(0, num_cells):
            left = row[i-1] if i > 0 else SAFE
            right = row[i+1] if i < last_index else SAFE

            if left == TRAP and right == SAFE:
                new_cell_list.append(TRAP)
            elif right == TRAP and left == SAFE:
                new_cell_list.append(TRAP)
            else:
                new_cell_list.append(SAFE)

        return ''.join(new_cell_list)