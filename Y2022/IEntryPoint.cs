namespace Y2022;

public interface IEntryPoint
{
    public static abstract void Run();
    public static abstract string Solve(string[] input);
    public static abstract string[] ReadFile();
}