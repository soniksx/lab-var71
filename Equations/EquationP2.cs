using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static lab_var7.Commands.Command;

namespace lab_var7.Equations
{
    internal class EquationP2 : Equation
    {
        public EquationP2() : base("a * x^2 + b * x + c = 0")
        {
            AddFactor("a", "Factor");
            AddFactor("b", "Factor");
            AddFactor("c", "Free member");

        }

        public override async Task<Equation> Solve()
        {
            var newEquation = new EquationP2();
            newEquation.InputFactors();

            double a = newEquation.Factors["a"].Num;
            double b = newEquation.Factors["b"].Num;
            double c = newEquation.Factors["c"].Num;

            
            double D = (b * b) - 4 * (a * c);
            if (D < 0)
            {
                //error handling
                //newEquation.Solutions.Add(double.NaN); 
                //throw new CommandException("Inputed equation has no solutions");
            }
            else
            {
                newEquation.Solutions.Add((-b + Math.Sqrt(D)) / (2 * a));
                newEquation.Solutions.Add((-b - Math.Sqrt(D)) / (2 * a));
            }
            return newEquation;
        }
    }
}
