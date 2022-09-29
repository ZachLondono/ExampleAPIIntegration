namespace TVMazeIntegration.Services;

public interface IConsoleWriter {

    public void Write(string message);

    public void WriteLine(string message);

    public void WriteError(string message);

    public void WriteLineError(string message);

}