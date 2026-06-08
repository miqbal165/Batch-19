namespace ConsoleApp2
{

    internal abstract class Program
    {
        
        private static void Main()
        {
            string fullName = "Muhammad Iqbal";
            Console.WriteLine($"{fullName.GetType().Name} {nameof(fullName)} = {fullName}");
            Console.WriteLine("First Line\rSecond Line");
        }
    }
}