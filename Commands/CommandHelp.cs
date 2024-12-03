using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Commands
{
    internal class CommandHelp : Command
    {
        public CommandHelp(string name, string info) : base(name, info) { }

        public override async Task<bool> Run()
        {
            if (!base.Run().Result) return false;

            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("Use one of commands:");
            foreach (var entry in CommandExecutor.Instance.Commands)
            {
                System.Console.WriteLine("\t\"" + entry.Key + "\" " + entry.Value.Info);
            }
            return true;
        }
    }
}
