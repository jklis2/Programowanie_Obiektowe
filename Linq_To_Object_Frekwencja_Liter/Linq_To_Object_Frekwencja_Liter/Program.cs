using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Linq_To_Object_Frekwencja_Liter
{
    public class Program
    {
        static void Main(string[] args)
        {
            int noOfTests = int.Parse(Console.ReadLine());
            List<string> inputStrings = new List<string>();
            List<string> inputQueries = new List<string>();
            for (int i = 0; i < noOfTests; i++)
            {
                inputStrings.Add(Console.ReadLine());
                inputQueries.Add(Console.ReadLine());
            }

            for (int i = 0; i < noOfTests; i++)
            {
                string inputStr = inputStrings[i];
                string[] query = inputQueries[i].Split(" ");

                inputStr = Regex.Replace(inputStr, "[^a-zA-Z]", String.Empty).ToLower();

                bool first = true;
                if (query[0] != "first")
                {
                    first = false;
                }
                int noOfLetters = int.Parse(query[1]);

                bool isSortedByFreq = false;
                bool byFreqAsc = true;
                foreach (var item in query)
                {
                    if (item == "byfreq")
                    {
                        isSortedByFreq = true;
                        int index = Array.IndexOf(query, item);
                        byFreqAsc = true ? query[index + 1] == "asc" : false;
                    }
                }

                bool isSortedByletter = false;
                bool byLetterAsc = true;
                foreach (var item in query)
                {
                    if (item == "byletter")
                    {
                        isSortedByletter = true;
                        int index = Array.IndexOf(query, item);
                        byLetterAsc = true ? query[index + 1] == "asc" : false;
                    }
                }

                Dictionary<char, int> myDict = new Dictionary<char, int>();
                foreach (var item in inputStr.Distinct())
                {
                    int freq = inputStr.Count(f => (f == item));
                    myDict.Add(item, freq);
                }

                if (isSortedByFreq && isSortedByletter)
                {
                    if (byFreqAsc && byLetterAsc)
                    {
                        Dictionary<char, int> myDictToBeSortedByFreqAndLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreqAndLetter.OrderBy(key => key.Value).ThenBy(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                    else if (byFreqAsc && !byLetterAsc)
                    {
                        Dictionary<char, int> myDictToBeSortedByFreqAndLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreqAndLetter.OrderBy(key => key.Value).ThenByDescending(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                    else if (!byFreqAsc && byLetterAsc)
                    {
                        Dictionary<char, int> myDictToBeSortedByFreqAndLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreqAndLetter.OrderByDescending(key => key.Value).ThenBy(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                    else
                    {
                        Dictionary<char, int> myDictToBeSortedByFreqAndLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreqAndLetter.OrderByDescending(key => key.Value).ThenByDescending(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                }

                else if (isSortedByFreq)
                {
                    if (byFreqAsc)
                    {
                        Dictionary<char, int> myDictToBeSortedByFreq = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreq.OrderBy(key => key.Value))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                    else
                    {
                        Dictionary<char, int> myDictToBeSortedByFreq = new Dictionary<char, int>(myDict);
                        myDict.Clear();
                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByFreq.OrderByDescending(key => key.Value))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                }

                else if (isSortedByletter)
                {
                    if (byLetterAsc)
                    {
                        Dictionary<char, int> myDictToBeSortedByLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();

                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByLetter.OrderBy(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                    else
                    {
                        Dictionary<char, int> myDictToBeSortedByLetter = new Dictionary<char, int>(myDict);
                        myDict.Clear();

                        foreach (KeyValuePair<char, int> dict in myDictToBeSortedByLetter.OrderByDescending(key => key.Key))
                        {
                            myDict.Add(dict.Key, dict.Value);
                        }
                    }
                }

                if (first)
                {
                    var xx = myDict.Take(noOfLetters);
                    foreach (var item in xx)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                }
                else
                {
                    var xx = myDict.TakeLast(noOfLetters);
                    foreach (var item in xx)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
