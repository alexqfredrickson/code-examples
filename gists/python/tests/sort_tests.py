import random
import unittest
from .. import quicksort, mergesort


class SortTests(unittest.TestCase):

    def setUp(self):
        self.sorted_list = list(range(0, 10000))
        self.shuffled_list = self.sorted_list.copy()
        random.shuffle(self.shuffled_list)

    def tearDown(self):
        print("{} {}.".format(
            self.sort_algorithm_name,
            "failed" if self.sorted_list != self.shuffled_list else "succeeded")
        )

        print("Here's the resulting array:")

        if len(self.shuffled_list) < 50:
            print(", ".join([str(s) for s in self.shuffled_list]))
        else:
            print(
                ", ".join([str(s) for s in self.shuffled_list[0:20]]) + " ... " +
                ", ".join(
                    [str(s) for s in self.shuffled_list[len(self.shuffled_list) - 20:len(self.shuffled_list) - 1]]
                )
            )

    def test_quicksort(self):
        self.sort_algorithm_name = "Quicksort"
        quicksort.quicksort(self.shuffled_list)

    def test_mergesort(self):
        self.sort_algorithm_name = "Mergesort"
        self.shuffled_list = mergesort.mergesort(self.shuffled_list)
