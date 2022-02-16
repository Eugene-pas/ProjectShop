﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.SearchByCategoriesAndProduct
{
    public static class SearchService
    {
        

        public static string SearchWord(string word, string collection, double fuzzyness)
        {
            int LevenshteinDistance(string src, string dest)
            {
                int[,] d = new int[src.Length + 1, dest.Length + 1];
                int i, j, cost;
                char[] str1 = src.ToCharArray();
                char[] str2 = dest.ToCharArray();

                for (i = 0; i <= str1.Length; i++)
                    d[i, 0] = i;
                for (j = 0; j <= str2.Length; j++)
                    d[0, j] = j;
                for (i = 1; i <= str1.Length; i++)
                {
                    for (j = 1; j <= str2.Length; j++)
                    {

                        if (str1[i - 1] == str2[j - 1])
                            cost = 0;
                        else
                            cost = 1;

                        d[i, j] =
                            Math.Min(
                                d[i - 1, j] + 1,              // Deletion
                                Math.Min(
                                    d[i, j - 1] + 1,          // Insertion
                                    d[i - 1, j - 1] + cost)); // Substitution

                        if ((i > 1) && (j > 1) && (str1[i - 1] ==
                            str2[j - 2]) && (str1[i - 2] == str2[j - 1]))
                        {
                            d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                        }
                    }
                }

                return d[str1.Length, str2.Length];
            }
            // Calculate the Levenshtein-distance:
            int levenshteinDistance = LevenshteinDistance(word, collection);

            // Length of the longer string:
            int length = Math.Max(word.Length, collection.Length);

            // Calculate the score:
            double score = 1.0 - (double)levenshteinDistance / length;

            // Match?
            if (score > fuzzyness)
            {
                return word;
            }
            return null;
        }

    }
}

