using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVMazeIntegration.Services;

internal class ConsoleWriter : IConsoleWriter {

    public void Write(string message) => Console.Write(message);

    public void WriteLine(string message) => Console.WriteLine(message);

    public void WriteError(string message) => Console.Error.Write(message);

    public void WriteLineError(string message) => Console.Error.WriteLine(message);

}
