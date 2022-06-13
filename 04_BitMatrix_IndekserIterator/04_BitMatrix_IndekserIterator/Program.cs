// file: BitMatrixPartial.cs
using System;
using System.Collections.Generic;
using System.Collections;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>
{
    public int this[int i, int j]
    {
        get
        {
            if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0) throw new IndexOutOfRangeException();
            return BoolToBit(data[(i * NumberOfColumns) + j]);
        }
        set
        {
            if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0) throw new IndexOutOfRangeException();
            data[(i * NumberOfColumns) + j] = BitToBool(value);
        }
    }


    public IEnumerator<int> GetEnumerator()
    {
        foreach (bool bit in data)
            yield return BoolToBit(bit);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}