# https://www.hackerrank.com/challenges/can-funds-be-transferred-b
from collections import namedtuple

import math

class Helper:
    @staticmethod
    def dfs(adjacencyList):
        n = len(adjacencyList)
        logn = (int) (math.ceil(math.log(n - 1, 2))) + 1
        up = []
        probabilities = []
        for i in xrange(n):
            up.append([0]*logn)
            probabilities.append(([0]*logn))

        params = namedtuple('params', 'adjacencyList timeIn timeOut probabilities up timer logn depth')
        params.adjacencyList = adjacencyList
        params.timeIn = [0] * n
        params.timeOut = [0] * n
        params.up = up
        params.probabilities = probabilities
        params.timer = 0
        params.logn = logn
        params.depth = 0
        params = Helper.dfs2(params, 0, 0, 1)
        return params

    @staticmethod
    def dfs2(p, vertex, previous, probability):
        stack = [(vertex, previous, probability, True)]
        while len(stack) > 0:
            [vertex, previous, probability, down] = stack.pop()
            if down:
                p.depth += 1
                p.timer += 1
                p.timeIn[vertex] = p.timer
                p.up[vertex][0] = previous
                p.probabilities[vertex][0] = probability
                stack.append((vertex, previous, probability, False))

                for i in xrange(1, p.logn):
                    p.up[vertex][i] = p.up[p.up[vertex][i - 1]][i - 1]
                    p.probabilities[vertex][i] = p.probabilities[vertex][i - 1] * p.probabilities[p.up[vertex][i - 1]][i - 1]

                for i in xrange(len(p.adjacencyList[vertex])):
                    buf = p.adjacencyList[vertex][i]
                    stack.append((buf[0], vertex, buf[1], True))
            else:
                p.timer += 1
                p.timeOut[vertex] = p.timer
                p.depth -= 1
        return p

    @staticmethod
    def findLowestCommonAncestor(firstVertex, secondVertex, timeIn, timeOut, up):
        if Helper.isUpper(firstVertex, secondVertex, timeIn, timeOut):
            return firstVertex
        if Helper.isUpper(secondVertex, firstVertex, timeIn, timeOut):
            return secondVertex

        current = firstVertex
        logn = len(up[0])
        for i in xrange(logn-1, -1, -1):
            ithPrev = up[current][i]
            if not Helper.isUpper(ithPrev, secondVertex, timeIn, timeOut):
                current = ithPrev
        return up[current][0]

    @staticmethod
    def probabilityToAncestor(vertex, ancestor, params):
        probability = 1
        i = params.logn - 1
        while (vertex != ancestor):
            candidate = params.up[vertex][i]
            if candidate == ancestor or not Helper.isUpper(candidate, ancestor, params.timeIn, params.timeOut):
                probability *= params.probabilities[vertex][i]
                vertex = params.up[vertex][i]
            i -= 1

        return probability

    @staticmethod
    def isUpper(ancestorCandidate, vertex, timeIn, timeOut):
        return timeIn[ancestorCandidate] <= timeIn[vertex] and timeOut[ancestorCandidate] >= timeOut[vertex]

    @staticmethod
    def canFundsBeTransferred(v1, v2, threshold, params):
        lca = Helper.findLowestCommonAncestor(v1, v2, params.timeIn, params.timeOut, params.up)
        probabilityFromFirstToLca = Helper.probabilityToAncestor(v1, lca, params)
        probabilityFromSecondToLca = Helper.probabilityToAncestor(v2, lca, params)
        transferProbability = probabilityFromFirstToLca * probabilityFromSecondToLca
        return transferProbability > 10**threshold


with open('training.txt') as file:
    n = (int) (file.readline())
    adjacencyList = []
    for i in xrange(n):
        adjacencyList.append([])

    for i in xrange(n-1):
        line = file.readline()
        split = line.split(',', 3)
        firstVertex = (int) (split[0]) - 1
        secondVertex = (int) (split[1]) - 1
        probability = (float) (split[2])
        adjacencyList[firstVertex].append((secondVertex, probability / 100.0))

    params = Helper.dfs(adjacencyList)

    line = file.readline()
    while (line != 'END'):
        split = line.split(',', 3)
        firstVertex = (int)(split[0]) - 1
        secondVertex = (int)(split[1]) - 1
        threshold = (float)(split[2])
        canBeTransferred = Helper.canFundsBeTransferred(firstVertex, secondVertex, threshold, params)
        print 'YES' if canBeTransferred else 'NO'
        line = file.readline()


