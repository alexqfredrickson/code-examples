class BinaryTree:
    def __init__(self, value, left_child, right_child):
        """

        :type left_child: BinaryTree
        :type right_child: BinaryTree
        """

        self.value = value
        self.left_child = left_child
        self.right_child = right_child

    @classmethod
    def from_list(cls, arr, index=0):
        """
        Recursively converts a list into a binary tree. Each node at index i has children at index 2i+1 and 2i+2.
        """

        return cls(
            value=arr[index],
            left_child=BinaryTree.from_list(arr, 2 * index + 1) if 2 * index + 1 < len(arr) else None,
            right_child=BinaryTree.from_list(arr, 2 * index + 2) if 2 * index + 2 < len(arr) else None
        )

    def to_list(self, arr=None):

        if not arr:
            arr = []

        arr.append(self)

        if self.left_child:
            arr + self.left_child.to_list(arr)

        if self.right_child:
            arr + self.right_child.to_list(arr)

        return arr

    @property
    def is_leaf(self):
        return not self.left_child and not self.right_child
