using Domain.Model;
using System;
using System.Linq;

namespace AdminConsole.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var armory = GetTheArmory("scifi");
                armory
                    .GetWeapons()
                    .ToList()
                    .ForEach(w => { Console.WriteLine(w.ToString()); });

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} - {1}", ex.GetType(), ex.Message);
                Console.WriteLine(ex.StackTrace ?? String.Empty);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("...");
                Console.ReadKey();
            }
        }

        private static IArmory GetTheArmory(string name)
        {
            if ("fantasy".Equals(name)) { return new FantasyArmory(); }
            else { return new SciFiArmory(); }
        }
    }
}
