import unittest

from Python.day_02.day_2 import KeyPad


class StandardKeyPadTests(unittest.TestCase):
    def test_should_default_to_5_for_last_pressed_button(self):
        key_pad = KeyPad.create_standard_keypad()
        self.assertEqual(key_pad.get_last_pressed_button(), "5")

    def test_should_move_up_when_U_in_command(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("U")
        self.assertEqual(key_pad.get_last_pressed_button(), "2")

    def test_should_not_move_up_when_U_in_command_and_no_keys_above(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("U")
        key_pad.run_command("U")
        self.assertEqual(key_pad.get_last_pressed_button(), "2")

    def test_should_move_down_when_D_in_command(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("D")
        self.assertEqual(key_pad.get_last_pressed_button(), "8")

    def test_should_not_move_down_when_D_in_command_and_no_keys_below(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("D")
        key_pad.run_command("D")
        self.assertEqual(key_pad.get_last_pressed_button(), "8")

    def test_should_move_left_when_L_in_command(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("L")
        self.assertEqual(key_pad.get_last_pressed_button(), "4")

    def test_should_not_move_left_when_L_in_command_and_no_keys_to_left(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("L")
        key_pad.run_command("L")
        self.assertEqual(key_pad.get_last_pressed_button(), "4")

    def test_should_move_right_when_R_in_command(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("R")
        self.assertEqual(key_pad.get_last_pressed_button(), "6")

    def test_should_not_move_right_when_R_in_command_and_no_keys_to_right(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("R")
        key_pad.run_command("R")
        self.assertEqual(key_pad.get_last_pressed_button(), "6")

    def test_should_execute_multiple_moves_in_command(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("UR")
        self.assertEqual(key_pad.get_last_pressed_button(), "3")

    def test_should_track_key_presses(self):
        key_pad = KeyPad.create_standard_keypad()
        key_pad.run_command("U")
        key_pad.run_command("R")
        self.assertEqual(key_pad.get_key_presses(), "23")


class ExtendedKeyPadTests(unittest.TestCase):

    def test_should_pass_example(self):
        key_pad = KeyPad.create_extended_keypad()
        key_pad.run_command("ULL")
        key_pad.run_command("RRDDD")
        key_pad.run_command("LURDL")
        key_pad.run_command("UUUUD")
        self.assertEqual(key_pad.get_key_presses(), "5DB3")

if __name__ == '__main__':
    unittest.main()
