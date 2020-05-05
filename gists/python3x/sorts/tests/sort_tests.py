import random
import unittest
from gists.python3x.sorts import bubblesort, quicksort, mergesort, selectionsort, insertionsort


class SortTests(unittest.TestCase):

    @staticmethod
    def set_up_unit_test():
        sorted_list = list(range(0, 1000))
        shuffled_list = sorted_list.copy()
        random.shuffle(shuffled_list)

        return sorted_list, shuffled_list

    @staticmethod
    def tear_down_unit_test(sort_algorithm_name, sorted_list, shuffled_list):
        print("{} {}.  Here's the resulting array:".format(
            sort_algorithm_name,
            "failed" if sorted_list != shuffled_list else "succeeded")
        )

        if len(shuffled_list) < 50:
            print(", ".join([str(s) for s in shuffled_list]))
        else:
            print(
                ", ".join([str(s) for s in shuffled_list[0:20]]) + " ... " +
                ", ".join(
                    [str(s) for s in shuffled_list[len(shuffled_list) - 20:len(shuffled_list) - 1]]
                )
            )

        print("")

    @staticmethod
    def test_quicksort():
        sorted_list, shuffled_list = SortTests.set_up_unit_test()
        quicksort.quicksort(shuffled_list)
        SortTests.tear_down_unit_test("Quicksort", sorted_list, shuffled_list)

    @staticmethod
    def test_mergesort():
        sorted_list, shuffled_list = SortTests.set_up_unit_test()
        shuffled_list = mergesort.mergesort(shuffled_list)
        SortTests.tear_down_unit_test("Mergesort", sorted_list, shuffled_list)

    @staticmethod
    def test_selectionsort():
        sorted_list, shuffled_list = SortTests.set_up_unit_test()
        shuffled_list = selectionsort.selectionsort(shuffled_list)
        SortTests.tear_down_unit_test("Selectionsort", sorted_list, shuffled_list)

    @staticmethod
    def test_bubblesort():
        sorted_list, shuffled_list = SortTests.set_up_unit_test()
        shuffled_list = bubblesort.bubblesort(shuffled_list)
        SortTests.tear_down_unit_test("Bubblesort", sorted_list, shuffled_list)

    @staticmethod
    def test_insertionsort():
        sorted_list, shuffled_list = SortTests.set_up_unit_test()
        shuffled_list = insertionsort.insertionsort(shuffled_list)
        SortTests.tear_down_unit_test("Insertionsort", sorted_list, shuffled_list)