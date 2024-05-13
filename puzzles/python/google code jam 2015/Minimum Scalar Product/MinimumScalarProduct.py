inputFilePath = "A-large-practice.in"
testCases = open(inputFilePath, "r")
outputFilePath = open("output.txt", "w")

## skip first line
case_count = int(testCases.readline().strip())
case_iterator = 0

while case_iterator < case_count:

    coords_length = int(testCases.readline().strip())
    x_coords = testCases.readline().strip().split(" ")
    y_coords = testCases.readline().strip().split(" ")

    x_coords = map(int, x_coords)
    y_coords = map(int, y_coords)

    x_coords = sorted(x_coords)
    y_coords = sorted(y_coords)
    y_coords.reverse()

    count = 0
    for i in range(0, coords_length):
        count += x_coords[i] * y_coords[i]

    output_line = "Case #%s: %d\n" % (case_iterator + 1, count)
    outputFilePath.write(output_line)

    # print(coords_length)
    # print(x_coords)
    # print(y_coords)

    case_iterator += 1

outputFilePath.close()
