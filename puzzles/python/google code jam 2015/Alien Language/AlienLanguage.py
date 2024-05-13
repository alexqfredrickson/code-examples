import re

inputFilePath = "A-small-practice.in"
testCases = open(inputFilePath, "r")
outputFilePath = open("output.txt", "w")

## skip first line
metadata = testCases.readline().strip().split(" ")
current_case = 0

L = int(metadata[0])
D = int(metadata[1])
case_count = int(metadata[2])

word_dictionary = []

for i in range (0, D):
    word_dictionary.append(testCases.readline().strip())

while current_case < case_count:

    pattern = testCases.readline().strip()
    # TODO: this actually ignores all (abc) type patterns instead of including them
    pattern2 = re.split('\(.*?\)', pattern)
    count = 0

    output_line = "Case #%s: %d\n" % (current_case + 1, count)
    outputFilePath.write(output_line)
    current_case += 1

outputFilePath.close()
