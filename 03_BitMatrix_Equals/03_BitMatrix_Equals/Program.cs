using System;

public partial class BitMatrix : IEquatable<BitMatrix>
{
    public bool Equals(BitMatrix other)
    {
        if (other == null)
        {
            return false;
        }
        for (int i = 0; i < data.Length; i++)
        {
            if (this.data[i] != other.data[i])
            {
                return false;
            }
        }

        if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
        {
            return false;
        }
        return true;
    }

    public override bool Equals(object o)
    {
        return base.Equals(o);
    }

    public override int GetHashCode()
    {
        return data.GetHashCode();
    }

    public static bool operator ==(BitMatrix p1, BitMatrix p2)
    {
        if (((object)p1) == null || ((object)p2) == null)
        {
            return Object.Equals(p1, p2);
        }

        return p1.Equals(p2);
    }

    public static bool operator !=(BitMatrix p1, BitMatrix p2)
    {

        if (((object)p1) == null || ((object)p2) == null)
        {
            return !Object.Equals(p1, p2);
        }
        return !p1.Equals(p2);
    }
}