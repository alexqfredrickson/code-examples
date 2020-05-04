"""
complexity: O(n^2) -> O(n log (n)) -> O(log(n))
author: tony hoare; 1959
alias: partition-exchange sort
"""


def quicksort(arr):

    # choose a random "pivot" (say from the middle of the partition)
    pivot_index = len(arr) // 2
    pivot_value = arr[pivot_index]

    # first, create two pointers, one at index 0 and another at index len(arr) - 1
    left_index = 0
    right_index = len(arr) - 1

    # 1. move the left pointer over to the right until a misplaced value is found
    # 2. do the same for the right pointer, in reverse
    # 3. keep swapping these values until the pointers collide
    while left_index != right_index:
        while left_index < right_index:
            if arr[left_index] < pivot_value:
                left_index += 1
            else:
                break

        while right_index > left_index:
            if arr[right_index] > pivot_value:
                right_index -= 1
            else:
                break

        if left_index != right_index:
            # if the pointers did not collide, two elements have been found which need to be swapped
            temp_value = arr[right_index]
            arr[right_index] = arr[left_index]
            arr[left_index] = temp_value
            continue

        # if the pointers collided, create two new partitions, and recurse if it makes sense to
        if len(arr[0:left_index]) > 1:
            arr[0:left_index] = quicksort(arr[0:left_index])

        if len(arr[right_index:len(arr)]) > 1:
            arr[right_index:len(arr)] = quicksort(arr[right_index:len(arr)])

        return arr
