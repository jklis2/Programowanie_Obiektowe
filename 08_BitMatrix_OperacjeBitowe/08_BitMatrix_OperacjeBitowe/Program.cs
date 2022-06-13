// file: BitMatrixPartial.cs
using System;
using System.Collections.Generic;
using System.Collections;

public partial class BitMatrix
{
    public BitMatrix And(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] & other.data[i];
        }

        return this;
    }

    public BitMatrix Or(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] | other.data[i];
        }

        return this;
    }

    public BitMatrix Xor(BitMatrix other)
    {
        if (other == null) throw new ArgumentNullException();
        if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] ^ other.data[i];
        }

        return this;
    }

    public BitMatrix Not()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = !data[i];
        }
        return this;
    }

    public static BitMatrix operator &(BitMatrix b1, BitMatrix b2)
    {
        if (b1 == null || b2 == null) throw new ArgumentNullException();
        if (b1.NumberOfColumns != b2.NumberOfColumns || b1.NumberOfRows != b2.NumberOfRows) throw new ArgumentException();
        var newMatrix = (BitMatrix)b1.Clone();
        return newMatrix.And(b2);
    }
    public static BitMatrix operator |(BitMatrix b1, BitMatrix b2)
    {
        if (b1 == null || b2 == null) throw new ArgumentNullException();
        if (b1.NumberOfColumns != b2.NumberOfColumns || b1.NumberOfRows != b2.NumberOfRows) throw new ArgumentException();
        var newMatrix = (BitMatrix)b1.Clone();
        return newMatrix.Or(b2);
    }
    public static BitMatrix operator ^(BitMatrix b1, BitMatrix b2)
    {
        if (b1 == null || b2 == null) throw new ArgumentNullException();
        if (b1.NumberOfColumns != b2.NumberOfColumns || b1.NumberOfRows != b2.NumberOfRows) throw new ArgumentException();
        var newMatrix = (BitMatrix)b1.Clone();
        return newMatrix.Xor(b2);
    }
    public static BitMatrix operator !(BitMatrix b1)
    {
        if (b1 == null) throw new ArgumentNullException();
        var newMatrix = (BitMatrix)b1.Clone();
        return newMatrix.Not();
    }
}