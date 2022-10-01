namespace ConsoleShowSearchApp.Output;

internal class ConsoleWriter : IConsoleWriter {

    public void Write(string message) => Console.Write(message);

    public void WriteLine(string message) => Console.WriteLine(message);

    public void WriteError(string message) => Console.Error.Write(message);

    public void WriteLineError(string message) => Console.Error.WriteLine(message);

}
