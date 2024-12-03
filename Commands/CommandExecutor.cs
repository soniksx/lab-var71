using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab_var7.ConsoleIo;

namespace lab_var7.Commands
{
    internal class CommandExecutor
    {
        private static CommandExecutor instance = null;
        public static CommandExecutor Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandExecutor();
                return instance;
            }
        }

        private Dictionary<string, Command> commands = new Dictionary<string, Command>();
        internal Dictionary<string, Command> Commands { get => commands; set => commands = value; }
        public void AddCommand(Command command)
        {
            Commands.Add(command.Name, command);
        }
        public async Task<bool> TryExecuteCommandAsync(string commandName)
        {
            Command? commandToExec;
            if (!Commands.TryGetValue(commandName, out commandToExec))
            {
                System.Console.WriteLine("Invalid command. Please, retry");
                return false;
            }
            if (commandToExec == null)
                return false;

            var res = false;
            try
            {
                res = await commandToExec.Run();
            }
            catch (Command.CommandException e) { System.Console.WriteLine("Command stopped cause: " + e.Message); }
            System.Console.WriteLine("----");
            return res;

        }

        public void StartExecution()
        {
            while (true)
            {
                try
                {
                    System.Console.WriteLine("Input the command:");
                    var line = ConsoleIo.Instance.GetNextLine();
                    TryExecuteCommandAsync(line);
                }
                catch (ConsoleIoException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}

