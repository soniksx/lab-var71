using System.Text.Json;
using static lab_var7.Commands.Command;

namespace lab_var7.Equations
{
    internal class Equation
    {
        private Dictionary<string, Factor> factors = [];
        private List<double> solutions = [];
        private string description = "";
        private int id = -1;

        public string Description { get => description; set => description = value; }
        public Dictionary<string, Factor> Factors { get => factors; set => factors = value; }
        public List<double> Solutions { get => solutions; set => solutions = value; }
        public int Id { get => id; set => id = value; }

        public Equation() { }
        public Equation(string description)
        {
            this.Description = description;
        }
        protected void AddFactor(string key, string description, double value = 0)
        {
            Factors.Add(key, new Factor(key, description, value));
        }
        public string FormatDescription()
        {
            string output = new string(description);
            foreach (var factor in Factors)
            {
                output = output.Replace(factor.Key, factor.Value.Num.ToString());
            }
            return output;
        }
        public string FormatSolutions()
        {
            if (solutions.Count() == 0) 
                return "no solutions";

            string output = "x = ";
            foreach (double solutiuon in solutions)
            {
                output += solutiuon.ToString() + ", ";
            }
            output = output.Trim();

            int lastIndex = output.LastIndexOf(',');
            if(lastIndex != -1) output = output.Remove(lastIndex);


            return output;
        }
        public string FormatEquation(bool printId = false)
        {
            string output =
                (printId == true ? "#" + Id.ToString() + ": " : "") +
                FormatDescription() + ", " +
                FormatSolutions();

            return output;
        }

        protected void InputFactors()
        {
            System.Console.WriteLine("Input the factors:");
            foreach (var factor in Factors)
            {
                System.Console.Write(factor.Value.Description + " \'" + factor.Key + "\': ");
                if (!ConsoleIo.Instance.TryGetNextDouble(out double val))
                    throw new CommandException("Invalid factor");

                factor.Value.Num = val;
            }
        }
        
        public virtual async Task<Equation> Solve() { return this; }
    }
}
