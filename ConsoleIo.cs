using lab_var7.Commands;
using System;

namespace lab_var7
{
    class ConsoleIo 
    {
        private static ConsoleIo instance = null;
        public static ConsoleIo Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConsoleIo();
                return instance;
            }
        }
        public class ConsoleIoException : Exception { public ConsoleIoException(string msg) : base(msg) { } }
        public string GetNextLine(bool singleWord = false)
        {
            string? line = System.Console.ReadLine();
            if (line == null)
                throw new ConsoleIoException("Empty line.");
            line = line.Trim();

            if (singleWord)
                if (line.Split(' ').Length > 1)
                    throw new ConsoleIoException("Invalide Format.");

            return line;
        }
        public bool TryGetNextInt(out int res)
        {
            try
            {
                var line = GetNextLine(true);

                if (!Int32.TryParse(line, out res))
                    throw new ConsoleIoException("Invalide Format Expected Int.");
            }
            catch (ConsoleIoException e)
            {
                Console.WriteLine(e.Message);
                res = 0;
                return false;
            }
            return true;
        }
        public bool TryGetNextDouble(out double res)
        {
            try
            {
                var line = GetNextLine(true);

                if (!Double.TryParse(line, out res))
                    throw new ConsoleIoException("Invalide Format Expected Double.");
            }
            catch (ConsoleIoException e)
            {
                Console.WriteLine(e.Message);
                res = 0;
                return false;
            }
            return true;
        }

    }
}