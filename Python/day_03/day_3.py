
class TriangleValidator:
    @staticmethod
    def is_valid(triangle_lengths):
        return triangle_lengths[0] + triangle_lengths[1] > triangle_lengths[2] \
               and triangle_lengths[0] + triangle_lengths[2] > triangle_lengths[1] \
               and triangle_lengths[1] + triangle_lengths[2] > triangle_lengths[0]


def convert_string_to_ints(triangle_string):
    triangle_lengths = triangle_string.split()
    return [int(triangle_lengths[0]), int(triangle_lengths[1]), int(triangle_lengths[2])]

# Part 1


def part1():
    f = open('day_3_input.txt', 'r')

    valid_triangle_count = 0
    triangle = f.readline()

    while triangle != '':
        triangle_lengths = convert_string_to_ints(triangle)
        if TriangleValidator.is_valid(triangle_lengths):
            valid_triangle_count += 1
        triangle = f.readline()

    print(valid_triangle_count)

part1()

# Part 2


def part2():
    f = open('day_3_input.txt', 'r')

    valid_triangle_count = 0
    row1_string = f.readline()

    while row1_string != '':
        row1 = convert_string_to_ints(row1_string)
        row2 = convert_string_to_ints(f.readline())
        row3 = convert_string_to_ints(f.readline())

        for x in range(0, 3):
            if TriangleValidator.is_valid([row1[x], row2[x], row3[x]]):
                valid_triangle_count += 1

        row1_string = f.readline()

    print(valid_triangle_count)

part2()
