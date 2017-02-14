
class Node:
    def __init__(self, elf_id):
        self.elf_id = elf_id
        self.next = None


def create_circle(number_of_elves):
    head = next_node = Node(1)
    for i in range(2, number_of_elves + 1):
        next_node.next = Node(i)
        next_node = next_node.next
    next_node.next = head
    return head


def create_circle_with_even_numbers_removed(number_of_elves):
    head = next_node = Node(1)
    for i in range(3, number_of_elves + 1, 2):
        next_node.next = Node(i)
        next_node = next_node.next
    next_node.next = head
    return next_node


def get_winner_win_stealing_left(circle_of_elves):
    while circle_of_elves.elf_id != circle_of_elves.next.elf_id:
        circle_of_elves.next = circle_of_elves.next.next
        circle_of_elves = circle_of_elves.next
    return circle_of_elves.elf_id


# elves = create_circle(3004953)
# print(get_winner_win_stealing_left(elves))

elves_no_even = create_circle_with_even_numbers_removed(3004953)
print(get_winner_win_stealing_left(elves_no_even))

