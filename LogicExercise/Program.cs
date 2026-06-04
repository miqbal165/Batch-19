for (int i = 1; i < 100; i++)
{
    if (i % 3 == 0)
    {
        Console.WriteLine("foo");
    } else if (i % 5 == 0)
    {
        Console.WriteLine("bar");
    } else if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("foobar");
        continue;
    } else
    {
        Console.WriteLine(i);
    }
}