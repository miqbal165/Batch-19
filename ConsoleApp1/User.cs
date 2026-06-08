namespace ConsoleApp1;

public class User
{
    public int Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public int Winner { get; set; } = 0;
    public int Lose { get; set; } = 0;
}