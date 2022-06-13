// file: BitMatrixPartial.cs
using System;
using System.Collections.Generic;
using System.Collections;

public partial class BitMatrix
{
    public static BitMatrix Parse(string s)
    {
        if (s == null || s.Length == 0) throw new ArgumentNullException();

        var parsedInts = new List<int>();
        int numOfRows = 0;
        int numOfCols = -1;

        foreach (string line in s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            foreach (char ch in line.Trim())
            {
                var newInt = (int)char.GetNumericValue(ch);
                if (newInt != 0 && newInt != 1) throw new FormatException();
                parsedInts.Add(newInt);
            }
            numOfRows++;

            if (numOfCols != -1 && numOfCols != line.Trim().Length) throw new FormatException();
            numOfCols = line.Trim().Length;
        }

        return new BitMatrix(numOfRows, numOfCols, parsedInts.ToArray());
    }
    public static bool TryParse(string s, out BitMatrix result)
    {
        result = null;
        if (s == null || s.Length == 0) return false;

        var parsedInts = new List<int>();
        int numOfRows = 0;
        int numOfCols = -1;

        foreach (string line in s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            foreach (char ch in line.Trim())
            {
                var newInt = (int)char.GetNumericValue(ch);
                if (newInt != 0 && newInt != 1) return false;
                parsedInts.Add(newInt);
            }
            numOfRows++;

            if (numOfCols != -1 && numOfCols != line.Trim().Length) return false;
            numOfCols = line.Trim().Length;
        }

        result = new BitMatrix(numOfRows, numOfCols, parsedInts.ToArray());
        return true;
    }


}