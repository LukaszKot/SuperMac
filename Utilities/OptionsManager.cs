using System;
using System.Collections.Generic;

namespace SuperMac.Utilities
{
    public class OptionsManager
    {
        public string Description { get; private set; }
        private readonly List<Option> _list = new();
        public string Incentive { get; private set; }

        private OptionsManager(string description, string incentive = "Wybierz opcje: ")
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Incentive = incentive;
        }

        public static OptionsManager Question(string description, string incentive = "Wybierz opcje: ")
        {
            return new OptionsManager(description, incentive);
        }

        public OptionsManager AddOption(string text, Action action)
        {
            _list.Add(new Option(text, action));
            return this;
        }

        public void Ask()
        {
            Console.WriteLine(Description);
            for(int i=0; i<_list.Count; i++)
            {
                Console.WriteLine($"{ i + 1 }. { _list[i].Description }");
            }
            Console.WriteLine(Incentive);

            try 
            {
                var option = int.Parse(Console.ReadLine());
                _list[option - 1].Execute();
            }
            catch(FormatException)
            {
                Console.WriteLine("Podana opcja nie jest prawidłowa. Spróbuj jeszcze raz!");
                Ask();
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Podana opcja nie istnieje. Spróbuj jeszcze raz.");
                Ask();
            }

            
        }

    }
}