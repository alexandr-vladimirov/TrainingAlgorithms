from unittest import TestCase

from main import Helper


class LcaTest(TestCase):
    def test_isAncestor(self):
        timeIn = [1, 2, 3]
        timeOut = [2, 1, 3]
        self.assertTrue(Helper.isUpper(0, 1, timeIn, timeOut))
        self.assertTrue(Helper.isUpper(0, 0, timeIn, timeOut))
        self.assertTrue(Helper.isUpper(1, 1, timeIn, timeOut))
        self.assertFalse(Helper.isUpper(1, 0, timeIn, timeOut))
        self.assertFalse(Helper.isUpper(0, 2, timeIn, timeOut))
        self.assertFalse(Helper.isUpper(2, 0, timeIn, timeOut))

    def test_findLca(self):
        timeIn = [1, 2, 3]
        timeOut = [2, 1, 3]
        up = [[0, 0], [0, 0], [0, 0]]
        self.assertEquals(0, Helper.findLowestCommonAncestor(0, 1, timeIn, timeOut, up))
        self.assertEquals(0, Helper.findLowestCommonAncestor(0, 2, timeIn, timeOut, up))
        self.assertEquals(0, Helper.findLowestCommonAncestor(1, 0, timeIn, timeOut, up))
        self.assertEquals(0, Helper.findLowestCommonAncestor(1, 2, timeIn, timeOut, up))
        self.assertEquals(0, Helper.findLowestCommonAncestor(2, 0, timeIn, timeOut, up))
        self.assertEquals(0, Helper.findLowestCommonAncestor(2, 1, timeIn, timeOut, up))

    def test_dfs(self):
        adjacencyList = [[(1, 30), (2, 40)], [], []]
        params = Helper.dfs(adjacencyList)
        self.assertItemsEqual([1, 2, 4], params.timeIn)
        self.assertItemsEqual([6, 3, 5], params.timeOut)
        self.assertItemsEqual([0, 0], params.up[1])
        self.assertItemsEqual([0, 0], params.up[2])
        self.assertItemsEqual([0, 0], params.up[0])

    def test_dfs2(self):
        adjacencyList = [[(1, 0.3)], [(2, 0.4)], []]
        params = Helper.dfs(adjacencyList)
        self.assertItemsEqual([1, 2, 3], params.timeIn)
        self.assertItemsEqual([6, 5, 4], params.timeOut)
        self.assertItemsEqual([0, 0], params.up[0])
        self.assertItemsEqual([0, 0], params.up[1])
        self.assertItemsEqual([1, 0], params.up[2])
        self.assertEquals(1, Helper.findLowestCommonAncestor(1, 2, params.timeIn, params.timeOut, params.up))

    def test_probabilityToLowestCommonAncestor(self):
        adjacencyList = [[(1, 0.3), (2, 0.4)], [(3, 0.2)], [], []]
        params = Helper.dfs(adjacencyList)
        self.assertItemsEqual([1, 1, 1], params.probabilities[0])
        self.assertItemsEqual([0.3, 0.3, 0.3], params.probabilities[1])
        self.assertItemsEqual([0.4, 0.4, 0.4], params.probabilities[2])
        self.assertItemsEqual([0.2, 0.06, 0.06], params.probabilities[3])
        self.assertEquals(1, Helper.probabilityToAncestor(0, 0, params))
        self.assertEquals(0.3, Helper.probabilityToAncestor(1, 0, params))
        self.assertEquals(0.4, Helper.probabilityToAncestor(2, 0, params))
        self.assertEquals(0.06, Helper.probabilityToAncestor(3, 0, params))
