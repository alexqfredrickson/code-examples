inputFilePath = "B-large-practice.in"
testCases = open(inputFilePath, "r")
outputFilePath = open("output.txt", "w")

## skip first line
testCases.readline()

caseNum = 1

for line in testCases:
    ## remove new line characters
    line = line.strip()

    ## convert line (as string) to list and reverse the order of the list
    wordList = line.split(" ")
    wordList.reverse()

    newLine = "Case #%s: " % caseNum

    for word in wordList:
        newLine += word + " "
    
    newLine = newLine[:-1] + "\n"
    outputFilePath.write(newLine)
    caseNum += 1
    
outputFilePath.close()
