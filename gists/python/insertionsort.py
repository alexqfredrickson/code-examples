"""
complexity: О(n^2) -> O(n^2) -> O(n)
"""


def insertionsort(arr):
    """
    Returns a sorted array.
    """

    if len(arr) <= 1:
        return arr  # because it's already sorted

    for i in range(0, len(arr)):

        # compare arr[i] with previous elements
        for j in range(0, i):
            if arr[i] > arr[j]:
                continue
            else:
                # arr[i] must be inserted at index j
                # all elements between j to i must be right-shifted
                temp = arr[i]

                for k in range(i, j, -1):
                    arr[k] = arr[k-1]

                arr[j] = temp

    return arr
