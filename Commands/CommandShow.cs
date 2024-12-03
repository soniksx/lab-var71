using lab_var7.Equations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Commands
{
    internal class CommandShow : Command
    {
        public CommandShow(string name, string info) : base(name, info) { }

        public override async Task<bool> Run()
        {
            if (!base.Run().Result) return false;


            System.Console.WriteLine("Saved equations:");
            int i = 1;
            foreach (var entry in EquationsHolder.Instance.SavedEquations)
            {
                System.Console.WriteLine("[" + i++ + "]: " + entry.Key + " | " + entry.Value.FormatSolutions());
            }
            return true;
        }
    }
}
