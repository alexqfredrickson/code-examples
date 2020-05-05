"""
complexity: O(n^2) -> О(n^2) -> O(n)
"""


def bubblesort(arr):
    """
    Returns a sorted array.
    """

    if len(arr) <= 1:
        return arr  # because it's already sorted

    while True:
        some_values_were_swapped = False

        # swap all adjacent elements if they are out-of-order
        for i in range(0, len(arr) - 1):
            if arr[i+1] < arr[i]:
                temp_value = arr[i]
                arr[i] = arr[i+1]
                arr[i+1] = temp_value
                some_values_were_swapped = True

        # if no values were swapped, this is an indication that the list is completely sorted
        if not some_values_were_swapped:
            break

    return arr
