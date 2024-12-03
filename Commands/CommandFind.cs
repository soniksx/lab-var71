using lab_var7.Equations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Commands
{
    internal class CommandFind : Command
    {
        public CommandFind(string name, string info) : base(name, info) { }

        public override async Task<bool> Run()
        {
            if (!base.Run().Result) return false;

            var equationId = -1;
            Console.WriteLine("Input the index: ");
            ConsoleIo.Instance.TryGetNextInt(out equationId);
            if ((equationId <= 0) || (equationId > EquationsHolder.Instance.SavedEquations.Count))
            {
                Console.WriteLine("Invalid Equation id");
                return false;
            }

            Equation? foundEquation = null;
            foreach (var entry in EquationsHolder.Instance.SavedEquations)
            {
                if (entry.Value.Id == equationId)
                {
                    foundEquation = entry.Value;
                    break;
                }
            }
            if (foundEquation == null)
            {
                Console.WriteLine("Equation with id #" + equationId.ToString() + " not found");
                return false;
            }

            System.Console.WriteLine(foundEquation.FormatDescription() + " solution: " + foundEquation.FormatSolutions());

            return true;
        }
    }
}
