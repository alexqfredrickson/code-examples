"""
complexity: О(n) -> O(n log n) -> O(n log n)
author: john von neumann; 1945
"""


def mergesort(arr):
    """
    Returns a sorted array.
    """

    if len(arr) <= 1:
        return arr  # because it's already sorted

    # otherwise, sort the array.  start by splitting the array into halves
    unsorted_left_half = arr[0:(len(arr) // 2)]
    unsorted_right_half = arr[(len(arr) // 2):len(arr)]

    # recurse on each to obtain a sorted array - after all, mergesort() returns a sorted array
    sorted_left_half = mergesort(unsorted_left_half)
    sorted_right_half = mergesort(unsorted_right_half)

    # merge the smaller, sorted arrays into a bigger one
    combined_sorted_array = []

    while len(sorted_left_half) > 0 and len(sorted_right_half) > 0:
        if sorted_left_half[0] < sorted_right_half[0]:
            combined_sorted_array.append(sorted_left_half[0])
            sorted_left_half = sorted_left_half[1: len(sorted_left_half)]
        else:
            combined_sorted_array.append(sorted_right_half[0])
            sorted_right_half = sorted_right_half[1: len(sorted_right_half)]

    if len(sorted_left_half) > 0:
        combined_sorted_array += sorted_left_half

    if len(sorted_right_half) > 0:
        combined_sorted_array += sorted_right_half

    # return the combined sorted array
    return combined_sorted_array