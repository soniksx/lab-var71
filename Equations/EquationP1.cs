using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab_var7.Equations
{
    internal class EquationP1 : Equation
    {
        public EquationP1() : base("k * x + b = 0")
        {
            AddFactor("k", "Factor");
            AddFactor("b", "Free member");
        }

        public override async Task<Equation> Solve()
        {

            var newEquation = new EquationP1();
            newEquation.InputFactors();

            var k = newEquation.Factors["k"].Num;
            var b = newEquation.Factors["b"].Num;

            newEquation.Solutions.Add((-b) / k);
            return newEquation;
        }
    }
}
