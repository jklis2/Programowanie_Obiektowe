using System;
using System.Collections.Generic;
using System.Collections;

public partial class BitMatrix
{
    public static explicit operator BitMatrix(int[,] arr)
    {
        if (arr == null) throw new NullReferenceException();
        if (arr.Length == 0) throw new ArgumentOutOfRangeException();
        return new BitMatrix(arr);
    }
    public static explicit operator BitMatrix(bool[,] arr)
    {
        if (arr == null) throw new NullReferenceException();
        if (arr.Length == 0) throw new ArgumentOutOfRangeException();
        return new BitMatrix(arr);
    }
    public static implicit operator int[,](BitMatrix matrix)
    {
        var arr = new int[matrix.NumberOfRows, matrix.NumberOfColumns];
        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                arr[i, j] = matrix[i, j];
            }
        }
        return arr;
    }
    public static implicit operator bool[,](BitMatrix matrix)
    {
        var arr = new bool[matrix.NumberOfRows, matrix.NumberOfColumns];
        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                arr[i, j] = BitToBool(matrix[i, j]);
            }
        }
        return arr;
    }
    public static explicit operator BitArray(BitMatrix matrix) => new BitArray(matrix.data);
}