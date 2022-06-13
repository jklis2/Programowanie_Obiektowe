using System.Text;
public partial class BitMatrix
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                sb.Append(data[(i * NumberOfColumns) + j] == true ? 1 : 0);
            }
            sb.Append(System.Environment.NewLine);
        }
        return sb.ToString();
    }
}