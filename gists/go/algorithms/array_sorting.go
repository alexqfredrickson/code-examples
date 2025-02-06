package main

import "fmt"

// avg: O(n log(n))
func quick_sort(slice []int) []int {

	if len(slice) == 0 {
		return nil
	}

	if len(slice) == 1 {
		return slice
	}

	// pick a pivot point from the middle
	pivot_index := int(float64(len(slice) / 2))
	pivot := slice[pivot_index]

	var smaller_or_equal_numbers []int
	var bigger_numbers []int

	for i := 0; i <= len(slice)-1; i++ {
		if i == pivot_index {
			continue
		}

		if slice[i] <= pivot {
			smaller_or_equal_numbers = append(smaller_or_equal_numbers, slice[i])
		} else {
			bigger_numbers = append(bigger_numbers, slice[i])
		}
	}

	// move quick-sorted smaller numbers to the left of the pivot
	new_slice := append(quick_sort(smaller_or_equal_numbers), pivot)

	// move quick-sorted bigger numbers to the right of the pivot
	return append(new_slice, quick_sort(bigger_numbers)...)
}

func merge_sort() {
	// todo
}

func heap_sort() {
	// todo
}

func counting_sort() {
	// todo
}

func radix_sort() {
	// todo
}

// avg: O(n^2)
func bubble_sort(slice []int) []int {
	for {
		is_sorted := true

		for i := 0; i < len(slice)-1; i++ {
			if slice[i] > slice[i+1] {
				temp := slice[i+1]
				slice[i+1] = slice[i]
				slice[i] = temp
				is_sorted = false
			}
		}

		if is_sorted {
			break
		}
	}

	return slice
}

func selection_sort() {
	// todo
}

func insertion_sort() {
	// todo
}

func shell_sort() {
	// todo
}

func bucket_sort() {
	// todo
}

func main() {
	a := []int{15, 12, 9, 8, 3, 1, 2, 4, 6, 5, 11, 7, 10, 13, 14}

	fmt.Println(quick_sort(a))
	// fmt.Println(merge_sort(a))
	// fmt.Println(heap_sort(a))
	// fmt.Println(counting_sort(a))
	// fmt.Println(radix_sort(a))
	fmt.Println(bubble_sort(a))
	// fmt.Println(selection_sort(a))
	// fmt.Println(insertion_sort(a))
	// fmt.Println(shell_sort(a))
	// fmt.Println(bucket_sort(a))

}
