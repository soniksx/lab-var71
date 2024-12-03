using lab_var7.Commands;
using lab_var7.Equations;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace lab_var7
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            string fileName;
            if (args.Length == 0)
                fileName = "SavedEquations.json";
            else 
                fileName = args[0];

            if (!await EquationsHolder.Instance.LoadEquationsFromFile(fileName))
                Console.WriteLine("previous equations not loaded, new will be save in " + fileName);
            else 
                Console.WriteLine("previous equations loaded from " + fileName);

            EquationFormatsHolder.Instance.AddEquationFormat(new EquationP1());
            EquationFormatsHolder.Instance.AddEquationFormat(new EquationP2());

            var commandExecutor = CommandExecutor.Instance;
            commandExecutor.AddCommand(new CommandSolve("solve", "to select type of equation and solve it."));
            commandExecutor.AddCommand(new CommandFind("find", "to get existing solution from memory."));
            commandExecutor.AddCommand(new CommandQuit(fileName, "quit", "to exit."));
            commandExecutor.AddCommand(new CommandHelp("help", "prints info about commands."));
            commandExecutor.AddCommand(new CommandShow("show", "show saved equations."));

            await commandExecutor.TryExecuteCommandAsync("help");
            commandExecutor.StartExecution();

        }
    }
}