"""
complexity: О(n^2)
"""


def selectionsort(arr):
    """
    Returns a sorted array.
    """

    if len(arr) <= 1:
        return arr  # because it's already sorted

    for i in range(0, len(arr)):

        # grab the pointer's current value; assume the smallest value is located at this index
        current_value_index = i
        minimum_value_index = i

        # look the minimum/smallest value after index i
        for j in range(i, len(arr)):
            if arr[j] < arr[minimum_value_index]:
                minimum_value_index = j

        # if a smaller value was found, swap them
        if minimum_value_index and minimum_value_index != current_value_index:
            temp_value = arr[i]
            arr[current_value_index] = arr[minimum_value_index]
            arr[minimum_value_index] = temp_value

    return arr
