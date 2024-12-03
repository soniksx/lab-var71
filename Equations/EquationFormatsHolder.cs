using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Equations
{
    internal class EquationFormatsHolder
    {
        private static EquationFormatsHolder? instance;
        public static EquationFormatsHolder Instance
        {
            get
            {
                if (instance == null)
                    instance = new EquationFormatsHolder();
                return instance;
            }
        }
        private List<Equation> equationsFormats = [];
        public  List<Equation> EquationsFormats { get => equationsFormats; set => equationsFormats = value; }
        public void AddEquationFormat(Equation equation)
        {
            EquationsFormats.Add(equation);
        }

    }
}
