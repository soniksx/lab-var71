using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Commands
{
    internal abstract class Command
    {
        public class CommandException : Exception { public CommandException(string msg) : base(msg) { } }
       
        private string info;
        private string name;
        public Command(string name, string info)
        {
            this.Name = name;
            this.Info = info;
        }
  
        public string Info { get => info; set => info = value; }
        public string Name { get => name; set => name = value; }

        public virtual async Task<bool> Run()
        {
            if (ConsoleIo.Instance == null)
                return false;

            return true;
        }
    }
}
