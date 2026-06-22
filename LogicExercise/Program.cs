namespace LogicExercise;

internal abstract class Program 
{
    public static void Main()
    {
        FizzBuzzGenerator fbg = new FizzBuzzGenerator();
        fbg.AddRule(3, "foo");
        fbg.AddRule(4, "bazz");
        fbg.AddRule(5, "bar");
        fbg.AddRule(7, "jazz");
        fbg.AddRule(9, "huzz");

        fbg.Generate(115);
    }
}

