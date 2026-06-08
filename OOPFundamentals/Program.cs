using System.Security.Cryptography;

namespace OOPFundamentals;

internal abstract class Program
{
    public static void Main()
    {
        BorderSide b = (BorderSide) 12345;
        System.Console.WriteLine(b);
    }

    public enum BorderSide
    {
        Left,
        Right,
        Top,
        Bottom
    }
}