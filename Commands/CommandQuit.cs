using lab_var7.Equations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Commands
{
    internal class CommandQuit : Command
    {
        private string fileName = "";
        public CommandQuit(string fileName,string name, string info) : base(name, info) 
        { 
            this.fileName = fileName; 
        }
        public override async Task<bool> Run()
        {
            if (!base.Run().Result) return false;
            await EquationsHolder.Instance.SaveEquationsToFile(fileName);
            System.Environment.Exit(0);
            return true;
        }
    }
}
