using System;
using System.Collections.Generic;
using System.Collections;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    public object Clone()
    {
        var clone = new BitMatrix(NumberOfRows, NumberOfColumns);

        for (int i = 0; i < data.Count; i++)
        {
            clone.data[i] = data[i];
        }

        return clone;
    }
}