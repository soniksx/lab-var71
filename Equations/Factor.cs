using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_var7.Equations
{
    internal class Factor
    {
        private string key;
        private string description;
        private double num;

        public Factor() { }
        public Factor(string key, string description, double value)
        {
            this.Key = key;
            this.Description = description;
            this.Num = value;
        }

        public double Num { get => num; set => this.num = value; }
        public string Description { get => description; set => description = value; }
        public string Key { get => key; set => key = value; }
    }
}
