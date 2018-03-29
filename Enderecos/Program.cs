namespace Enderecos
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleSync.Execute();
            ExampleAsync.Execute().Wait();
        }
    }
}