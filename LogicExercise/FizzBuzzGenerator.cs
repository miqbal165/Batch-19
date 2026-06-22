namespace LogicExercise;

public class FizzBuzzGenerator
{
    private Dictionary<int, string> _rules = new Dictionary<int, string>();
    public void AddRule(int input, string output)
    {
        if (_rules.ContainsKey(input))
        {
            _rules[input] = output;
        } else
        {
            _rules.Add(input, output);
        }
    }

    public void Generate(int n)
    {

        for (int i = 1; i <= n; i++)
        {
            string currentOutput = "";

            foreach (var rule in _rules)
            {
                if (i % rule.Key == 0)
                {
                    currentOutput += rule.Value;
                }
            }

            if (string.IsNullOrWhiteSpace(currentOutput))
            {
                Console.WriteLine(i);
            } else
            {
                Console.WriteLine(currentOutput);
            }
        }
    }
}