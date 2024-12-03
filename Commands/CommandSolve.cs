using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using lab_var7.Equations;


namespace lab_var7.Commands
{
    internal class CommandSolve : Command
    {
        public CommandSolve(string name, string info) : base(name, info) { }
        public override async Task<bool> Run()
        {
            if (!base.Run().Result) return false;

            System.Console.WriteLine("Select the type of equation:");
            var equationI = 1;
            foreach (Equation equation in EquationFormatsHolder.Instance.EquationsFormats)
                System.Console.WriteLine(equationI++ + " - " + equation.Description);

            System.Console.WriteLine("Input number of equation:");
            if (!ConsoleIo.Instance.TryGetNextInt(out equationI))
                throw new CommandException("Invalid number of equation");

            if ((equationI < 1) || (equationI > EquationFormatsHolder.Instance.EquationsFormats.Count))
                throw new CommandException("Invalid number of equation");



            var solvedEquation = await EquationFormatsHolder.Instance.EquationsFormats.ElementAt(equationI - 1).Solve();
           
            if (!EquationsHolder.Instance.SaveEquationIfNotExist(solvedEquation, out solvedEquation))
                System.Console.WriteLine("Solution already exists");

              System.Console.WriteLine(solvedEquation.FormatEquation(true));

            return true;
        }
    }
}
