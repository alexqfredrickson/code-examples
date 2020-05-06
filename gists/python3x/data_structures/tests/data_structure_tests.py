import unittest
from .. import binary_tree


class DataStructureTests(unittest.TestCase):

    def test_create_binary_tree_from_list(self):
        bt = binary_tree.BinaryTree.from_list(list(range(0, 1000000)))
        self.assertTrue(bt and bt.right_child.right_child.value == 6)
