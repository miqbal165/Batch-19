// Logic Exercise

for (int i = 1; i <= 150; i++)
{
    string result = "";

    if (i % 3 == 0)
    {
        result += "foo";
    } 
    
    if (i % 4 == 0)
    {
        result += "baz";
    }
    
    if (i % 5 == 0)
    {
        result += "bar";
    } 
    
    if (i % 7 == 0)
    {
        result += "jazz";  
    }

    if (string.IsNullOrWhiteSpace(result))
    {
        result += i;
    }

    Console.WriteLine(result);
}