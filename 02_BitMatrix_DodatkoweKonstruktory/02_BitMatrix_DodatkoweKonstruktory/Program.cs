using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class BitMatrix
{
    public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
    {
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns, BitToBool(0));
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        if (bits != null)
        {
            for (int i = 0; i < bits.Length; i++)
            {
                if (i < data.Length)
                {
                    data[i] = Convert.ToBoolean(bits[i]);
                }

            }
        }

    }
    public BitMatrix(int[,] bits)
    {
        if (bits == null)
        {
            throw new NullReferenceException();
        }
        if (bits.Length == 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        NumberOfRows = bits.GetLength(0);
        NumberOfColumns = bits.GetLength(1);
        data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
        for (int i = 0; i < bits.GetLength(0); i++)
        {
            for (int j = 0; j < bits.GetLength(1); j++)
            {
                data[i * bits.GetLength(1) + j] = Convert.ToBoolean(bits[i, j]);
            }
        }
    }
    public BitMatrix(bool[,] bits)
    {
        if (bits == null)
        {
            throw new NullReferenceException();
        }
        if (bits.Length == 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        NumberOfRows = bits.GetLength(0);
        NumberOfColumns = bits.GetLength(1);
        data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
        for (int i = 0; i < bits.GetLength(0); i++)
        {
            for (int j = 0; j < bits.GetLength(1); j++)
            {
                data[i * bits.GetLength(1) + j] = bits[i, j];
            }
        }
    }


}