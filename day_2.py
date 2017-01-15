class KeyPadIndex:
    def __init__(self, starting_x, starting_y):
        self.X = starting_x
        self.Y = starting_y


class MoveCommandFactory:
    def __init__(self):
        pass

    @staticmethod
    def create(move_type):
        if move_type == 'U':
            return MoveUpCommand()
        elif move_type == 'D':
            return MoveDownCommand()
        elif move_type == 'L':
            return MoveLeftCommand()
        elif move_type == 'R':
            return MoveRightCommand()


class ExtendedMoveCommandFactory:
    def __init__(self):
        pass

    @staticmethod
    def create(move_type):
        if move_type == 'U':
            return ExtendedMoveUpCommand()
        elif move_type == 'D':
            return ExtendedMoveDownCommand()
        elif move_type == 'L':
            return ExtendedMoveLeftCommand()
        elif move_type == 'R':
            return ExtendedMoveRightCommand()

STANDARD_KEYPAD_NUMBERS = [[str((3 * y + x) + 1) for x in range(3)] for y in range(3)]
EXTENDED_KEYPAD_NUMBERS = [["" for x in range(5)] for y in range(5)]
EXTENDED_KEYPAD_NUMBERS[0][2] = "1"
EXTENDED_KEYPAD_NUMBERS[1][1] = "2"
EXTENDED_KEYPAD_NUMBERS[1][2] = "3"
EXTENDED_KEYPAD_NUMBERS[1][3] = "4"
EXTENDED_KEYPAD_NUMBERS[2][0] = "5"
EXTENDED_KEYPAD_NUMBERS[2][1] = "6"
EXTENDED_KEYPAD_NUMBERS[2][2] = "7"
EXTENDED_KEYPAD_NUMBERS[2][3] = "8"
EXTENDED_KEYPAD_NUMBERS[2][4] = "9"
EXTENDED_KEYPAD_NUMBERS[3][1] = "A"
EXTENDED_KEYPAD_NUMBERS[3][2] = "B"
EXTENDED_KEYPAD_NUMBERS[3][3] = "C"
EXTENDED_KEYPAD_NUMBERS[4][2] = "D"


class KeyPad:
    key_presses = ""

    def __init__(self, move_command_factory, keypad_numbers, keypad_index):
        self.move_factory = move_command_factory
        self.keypad_numbers = keypad_numbers
        self.key_pad_index = keypad_index

    @staticmethod
    def create_standard_keypad():
        return KeyPad(MoveCommandFactory(), STANDARD_KEYPAD_NUMBERS, KeyPadIndex(1,1))

    @staticmethod
    def create_extended_keypad():
        return KeyPad(ExtendedMoveCommandFactory(), EXTENDED_KEYPAD_NUMBERS, KeyPadIndex(0,2))

    def get_last_pressed_button(self):
        return self.keypad_numbers[self.key_pad_index.Y][self.key_pad_index.X]

    def run_command(self, command):
        for move in command:
            self.move_factory.create(move).update_index(self.key_pad_index)

        self.key_presses += self.get_last_pressed_button()

    def get_key_presses(self):
        return self.key_presses


class MoveCommand:
    def __init__(self):
        pass

    def can_move(self, index):
        return True

    def update_index(self, index):
        pass


class MoveUpCommand(MoveCommand):
    def can_move(self, index):
        return index.Y > 0

    def update_index(self, index):
        if self.can_move(index):
            index.Y -= 1


class MoveDownCommand(MoveCommand):
    def can_move(self, index):
        return index.Y < 2

    def update_index(self, index):
        if self.can_move(index):
            index.Y += 1


class MoveLeftCommand(MoveCommand):
    def can_move(self, index):
        return index.X > 0

    def update_index(self, index):
        if self.can_move(index):
            index.X -= 1


class MoveRightCommand(MoveCommand):
    def can_move(self, index):
        return index.X < 2

    def update_index(self, index):
        if self.can_move(index):
            index.X += 1


class ExtendedMoveUpCommand(MoveUpCommand):
    min_up_for_row = [2, 1, 0, 1, 2]

    def can_move(self, index):
        return index.Y > self.min_up_for_row[index.X]


class ExtendedMoveDownCommand(MoveDownCommand):
    max_up_for_row = [2, 3, 4, 3, 2]

    def can_move(self, index):
        return index.Y < self.max_up_for_row[index.X]


class ExtendedMoveLeftCommand(MoveLeftCommand):
    min_left_for_col = [2, 1, 0, 1, 2]

    def can_move(self, index):
        return index.X > self.min_left_for_col[index.Y]


class ExtendedMoveRightCommand(MoveRightCommand):
    max_right_for_col = [2, 3, 4, 3, 2]

    def can_move(self, index):
        return index.X < self.max_right_for_col[index.Y]


# key_pad = KeyPad.create_extended_keypad()
#
# key_pad.run_command(
#     "RDRRDLRRUDRUUUULDDRDUULLDUULDURDDUDRULDLUDDRLRDUDDURRRRURDURLLRDRUUULDLLLURDRLLULLUULULLLDLLLRRURRLRDUULRURRUDRRDRLURLRURLLULRUURRUURDDLDRDLDLLUDUULLLUUUUDULLDRRUURLDURDDDDDRLLRRURDLUDRRUUDLRRLLRDURDUDDDLRDDRDLRULLUULRULRLLULDDRURUUDLDDULDRLLURDDUDDUDRDUDLDRRRDURRLDRDRLDLLDUDDDULULRRULRLLURDRRDDUUUUUULRUDLRRDURDLRDLUDLDURUDDUUURUDLUUULDLRDURDLDUUDLDDDURUUDUUDRLRDULLDUULUDRUDRLRRRDLLDRUDULRRUDDURLDRURRLLRRRDRLLDLULULRRUURRURLLUDRRLRULURLDDDDDURUDRRRRULLUUDLDDLUUL")
# key_pad.run_command(
#     "ULURUDLULDULDLLDDLLLDRRLLUDRRDRDUDURUDLRRRRUDRDDURLRRULLDLURLDULLUDDLUDURDUURRRRLDLRLDDULLRURLULLDDRUDLRRRLDRRRDLDRLLDDRRDDLUUDRUDDLULRURLDURRLLDLRUDLLRRUULUDRLLLRLDULURRRRRDDUURDRRUUDULRUULDDULRLUDLUDDULLRLRDDLRLLURRRULDLRRRUURRLDDRDLRDLRRDRDLDRDUDRDURUUDRLRRULRDLLDLLRRRDRLDRLRLRLLLURURDULUUDDRLLDDDRURRURLRDDULLRURUDRRDRLRRRLDLRLRULDRLUURRUUULRLDLLURLLLDLLLDRRDULRURRRRLUDLLRRUDLRUDRURDRRDLUUURRDLRLRUUUDURDLUDURRUUDURLUDDDULLDRDLLDDDRLDDDRLDLDDDDUDUUDURUUDULRDDLULDRDRLURLUDRDLUULLULRLULRDDRULDUDDURUURULUDLUURLURU")
# key_pad.run_command(
#     "URLURDDRLLURRRLDLDLUDUURDRUDLLLRRDLUUULRRLURRRLUDUDLRLDDRUDLRRRULUDUDLLLULULLLRUDULDDDLLLRRRLRURDULUDDDULDLULURRRDLURDLRLLDUDRUDURDRRURULDRDUDLLRDDDUDDURLUULLULRDRRLDDLDURLRRRLDRDLDULRULRRRLRLLDULRDLURLRUUDURRUUDLLUDRUDLRLDUUDLURRRDDUUDUDRLDLDDRURDDLLDDRDLRLRDLLLUDLUUDRLRLRDDRDLRDLLUULLLLUULLDLLDLRDLRLRRLUUDLLRLRUDRURULRLRLULUDRLLUDDUDDULRLDDRUUUURULDRRULLLDUURULUDRLLURLRRLDLRRLDDRRRDUDDUDLDDLULUDDUURDLLLRLDLRDRUUUUUDDDLDRDDRRRLRURRRRDURDRURUDLURRURDRLRUUDDLDRRULLDURDRLRRDURURUULRDUDLDRDDLULULRDRRUDDRLLRLULRLLUUDRDUUDDUDLRUUDLLUULLRUULUDDLURRRLLDRLRRLLRULLDUULURLLLLUUULDR")
# key_pad.run_command(
#     "LDUURULLRLDRRUUDUUUURUUUDDDURRDDLRDLLRDDRULDDUURUDDURLLUDRDUDRDULDRRRLULUDRULLLLDRLLDRDLDLLRURULUDDDDURDDDRLLUDLDRULRDLDUDDDUUDLLRLLLDLRLRLRRUDDULDDDUDLDDLUDDULDLLLLULLLLDDURDDURRRDDRLRLLUDLLUDDDUDURUDRLRDRULULDDRULDLULULLRUULRLDULUURRDRDRRDLDDDRRLUULDLUDRDDUDLRURULLDDURLDDRULUDLDDDRDRLLRDLLUURRRURDRLRURLDDLURDRURDDURLLRLRUDUUDLDUDURRDDURDRDDUDDDUDUURURDDLLRUUDDRRDULDDLLDLRULUULRUUDLLDRLULDULDDUDLULRULDRLLDUULDDDLRLLRLULDDULDDRRRLDRRLURULRDDRDLRRDUDDRDRRRRUDUDLLRRDRRURRUURDRULDDUDURLUDDURDUDRDUULLDRURUURURDRRLDDLDLUURLULRUDURDRUUURRURRDRUDRUURDURLRULULLLULDLLDLRRLDRDLUULUDDDLRDRLRLDRUDUDRLLRL")
# key_pad.run_command(
#     "LURLUURLURDUUDRUDLDLLURRRDLDRRRULDDRRDRDUUDRUDURDDDURLUDDLULUULRRLLRULUDRDDRRRLDURDUDDURDDDLRLDDLULLDRDDLUUDUURRRLULRUURRRRLLULDUDRDUURRRURRDRDUDUDLUDULLDLDDRLUDRURDULURLURRLLURLLLRLUURLRUDLUDDRLURRUULULRLURRURUDURDLDLDDUDDRDLLRLLRRULDDRUDURUDDDUDLLRDLRUDULLLRRRUURUDUUULLRDUDRURUDULLDLLUUUDRULRLLRRDDDDUDULDRDRLLDDLLDDDURRUDURLDLRDRUURDDURLRDRURLRRLLRLULDRRLRUDURDUURRLUUULUDDDLRLULRDRLLURRRDLURDUUDRRRLUURRLLUDLUDLUULLRRDLLRDDRURRUURLDDLRLRLRUDLDLRLRDRRDLLLRDLRDUDLLDDDRD")
#
# print key_pad.get_key_presses()
