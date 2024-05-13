using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using practice_exercises.HackerRank.Models;

namespace practice_exercises.HackerRank.Exercises
{
    class LisasWorkbook : Exercise
    {
        public override void SolveTestCases()
        {
            int chapterCount, maxProblemsPerPage, pages = 0, specialProblemCount = 0;
            int[] problemsPerChapter;

            using (StreamReader sr = new StreamReader(InputPath))
            {
                int[] firstLine = Array.ConvertAll(sr.ReadLine().Split(' '), x => int.Parse(x));
                chapterCount = firstLine[0];
                maxProblemsPerPage = firstLine[1];
                problemsPerChapter = Array.ConvertAll(sr.ReadLine().Split(' '), x => int.Parse(x));
            }

            // determine number of pages
            for (int i = 0; i < chapterCount; i++)
            {
                int chapterProblemsCount = problemsPerChapter[i];
                int chapterPageCount = (int)Math.Ceiling((double)chapterProblemsCount / maxProblemsPerPage);
                pages += chapterPageCount;
            }

            // compile book

            int[,] book = new int[pages, maxProblemsPerPage];

            for (int i = 0; i < chapterCount; i++)
            {
                List<int> chapterProblems = Enumerable.Range(1, problemsPerChapter[i]).ToList<int>();

                while (chapterProblems.Count() % maxProblemsPerPage != 0)
                {
                    chapterProblems.Add(0);
                }

                int chapterPagesCount = chapterProblems.Count() / maxProblemsPerPage;

                for (int k = 0; k < chapterPagesCount; k++)
                {
                    List<int> page = chapterProblems.GetRange(k * maxProblemsPerPage, maxProblemsPerPage);

                    // get first index of empty page in book
                    int emptyPageIndex = 0;

                    for (int j = 0; j < book.GetLength(0); j++)
                    {
                        if (book[j, 0] != 0)
                        {
                            continue;
                        }   else
                        {
                            emptyPageIndex = j;
                            break;
                        }
                    }

                    int bookPageIndex = emptyPageIndex;

                    for (int j = 0; j < page.Count; j++)
                    {
                        int problem = page[j];
                        book[emptyPageIndex, j] = problem;
                    }
                }
            }

            // we finally have a book, good god
            for (int i = 0; i < book.GetLength(0); i++)
            {
                int pageNumber = i + 1;

                for (int j = 0; j < book.GetLength(1); j++)
                {
                    if (book[i,j] == pageNumber)
                    {
                        specialProblemCount++;
                    }
                }
            }

            Solutions.Add(specialProblemCount.ToString());
        }
    }
}