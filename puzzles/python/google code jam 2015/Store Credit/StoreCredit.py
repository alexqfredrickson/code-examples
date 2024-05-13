inputFilePath = "A-large-practice.in"
testCases = open(inputFilePath, "r")
outputFilePath = open("output.txt", "w")

## skip first line
case_count = int(testCases.readline().strip())
case_iterator = 0
while case_iterator < case_count:
    credit = int(testCases.readline().strip())
    num_items = int(testCases.readline().strip())
    item_prices = testCases.readline().strip().split(" ")
    for i in range(0, num_items):
        new_credit = credit - int(item_prices[i])
        item_one = int(item_prices[i])
        item_one_index = i
        item_prices.pop(i)
        if new_credit in item_prices:
            item_two_index = item_prices.index(new_credit)
            output_line = "Case #%s: " % (case_iterator + 1)
            output_line += str(min(item_one_index, item_two_index) + 1) + " "
            output_line += str(max(item_one_index, item_two_index) + 1) + "\n"

            outputFilePath.write(output_line)
            break
        else:
            item_prices.insert(i, item_one)
    case_iterator += 1

outputFilePath.close()
