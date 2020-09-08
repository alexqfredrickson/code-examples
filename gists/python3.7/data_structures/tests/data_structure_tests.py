import unittest
from .. import binary_tree


class DataStructureTests(unittest.TestCase):

    def test_create_binary_tree_from_list(self):
        bt = binary_tree.BinaryTree.from_list(list(range(0, 10000)))
        self.assertTrue(bt and bt.right_child.right_child.value == 6)

    def test_convert_binary_tree_to_list(self):
        bt = binary_tree.BinaryTree.from_list(list(range(0, 10000)))
        l = bt.to_list()
        self.assertTrue(len(set(l)) == 10000)
