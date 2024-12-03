using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab_var7.Equations
{
    internal class EquationsHolder
    {
        private static EquationsHolder instance = null;
        public static EquationsHolder Instance
        {
            get
            {
                if (instance == null)
                    instance = new EquationsHolder();
                return instance;
            }
        }

        private  Dictionary<string, Equation> savedEquations = [];
        internal  Dictionary<string, Equation> SavedEquations { get => savedEquations; set => savedEquations = value; }

        public async Task<bool> LoadEquationsFromFile(string fileName = "SavedEquations.json")
        {
            var jsonString = "";
            if (!File.Exists(fileName))
            {
                System.Console.WriteLine("File not exists and will be created on quit");
                return false;
            }
            try
            {
                jsonString = File.ReadAllText(fileName);
                savedEquations = JsonSerializer.Deserialize<Dictionary<string, Equation>>(jsonString)!;
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("JSON error");
                return false;
            }
            return true;
        }
        public async Task SaveEquationsToFile(string fileName = "SavedEquations.json")
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(SavedEquations);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error on save: " + ex.Message);
                System.Console.ReadLine();
                return;
            }
            System.Console.WriteLine("Saved");
        }
        public bool SaveEquationIfNotExist(Equation inEquation,out Equation equation)
        {
            if (!SavedEquations.TryGetValue(inEquation.FormatDescription(), out equation))
            {
                SavedEquations.Add(inEquation.FormatDescription(), inEquation);
                equation = inEquation;
                equation.Id = SavedEquations.Count;

                return true;
            }
            return false;

        }
    }
}
