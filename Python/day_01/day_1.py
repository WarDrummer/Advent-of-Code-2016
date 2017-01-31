from sets import Set


class Orientation:
    def __init__(self):
        pass

    NORTH = 0
    EAST = 1
    SOUTH = 2
    WEST = 3


class ShortestDistanceCalculator:
    def __init__(self):
        pass

    _orientation = Orientation.NORTH
    _xDistance = 0
    _yDistance = 0

    def get_orientation(self):
        return self._orientation

    def get_instructions(self, input_string):
        return input_string.split(', ')

    def execute_instructions(self, instructions):
        for instruction in instructions:
            self.move(instruction)

    def execute_instructions_until_same_location_visited(self, instructions):
        for instruction in instructions:
            self.move(instruction)

    def get_shortest_distance(self):
        return abs(self._xDistance) + abs(self._yDistance)

    def move(self, instruction):
        direction, number_of_blocks = self.__parse_instruction(instruction)

        self.__change_orientation(direction)

        self.update_distance(number_of_blocks)

    @staticmethod
    def __parse_instruction(instruction):
        return instruction[0], int(instruction[1:])

    def __change_orientation(self, direction):
        if direction == 'R':
            self._orientation = (self._orientation + 1) % 4
        elif direction == 'L':
            self._orientation = self._orientation - 1 if self._orientation != Orientation.NORTH else Orientation.WEST

    def update_distance(self, number_of_blocks):
        if self._orientation == Orientation.WEST:
            self._xDistance -= number_of_blocks
        elif self._orientation == Orientation.EAST:
            self._xDistance += number_of_blocks
        elif self._orientation == Orientation.NORTH:
            self._yDistance += number_of_blocks
        elif self._orientation == Orientation.SOUTH:
            self._yDistance -= number_of_blocks

# This is sloppy, doesn't have tests, and needs major reworking...
class ShortestDistanceToSameLocationTwiceCalculator(ShortestDistanceCalculator):
    _previousLocations = Set([])

    def update_distance(self, number_of_blocks):
        if self._orientation == Orientation.WEST:
            for i in range(0, number_of_blocks):
                self.__update_x_distance(-1)
                if self.__was_previously_visited():
                    break
        elif self._orientation == Orientation.EAST:
            for i in range(0, number_of_blocks):
                self.__update_x_distance(1)
                if self.__was_previously_visited():
                    break
        elif self._orientation == Orientation.NORTH:
            for i in range(0, number_of_blocks):
                self.__update_y_distance(1)
                if self.__was_previously_visited():
                    break
        elif self._orientation == Orientation.SOUTH:
            for i in range(0, number_of_blocks):
                self.__update_y_distance(-1)
                if self.__was_previously_visited():
                    break

    def __update_x_distance(self, number_of_blocks):
        self._xDistance += number_of_blocks

    def __update_y_distance(self, number_of_blocks):
        self._yDistance += number_of_blocks

    def __was_previously_visited(self):
        current_location = "{0},{1}".format(str(self._xDistance), str(self._yDistance))
        if current_location in self._previousLocations:
            print "First: " + str(self.get_shortest_distance())
            return True
        else:
            self._previousLocations.add(current_location)
            return False


calculator = ShortestDistanceToSameLocationTwiceCalculator()

instructions = calculator.get_instructions("L1, L5, R1, R3, L4, L5, R5, R1, L2, L2, L3, R4, L2, R3, R1, L2, R5, R3, "
                                           "L4, R4, L3, R3, R3, L2, R1, L3, R2, L1, R4, L2, R4, L4, R5, L3, R1, R1, "
                                           "L1, L3, L2, R1, R3, R2, L1, R4, L4, R2, L189, L4, R5, R3, L1, R47, R4, "
                                           "R1, R3, L3, L3, L2, R70, L1, R4, R185, R5, L4, L5, R4, L1, L4, R5, L3, "
                                           "R2, R3, L5, L3, R5, L1, R5, L4, R1, R2, L2, L5, L2, R4, L3, R5, R1, L5, "
                                           "L4, L3, R4, L3, L4, L1, L5, L5, R5, L5, L2, L1, L2, L4, L1, L2, R3, R1, "
                                           "R1, L2, L5, R2, L3, L5, L4, L2, L1, L2, R3, L1, L4, R3, R3, L2, R5, L1, "
                                           "L3, L3, L3, L5, R5, R1, R2, L3, L2, R4, R1, R1, R3, R4, R3, L3, R3, L5, "
                                           "R2, L2, R4, R5, L4, L3, L1, L5, L1, R1, R2, L1, R3, R4, R5, R2, R3, L2, "
                                           "L1, L5")

calculator.execute_instructions(instructions)

print calculator.get_shortest_distance()