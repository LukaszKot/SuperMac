using System;

namespace SuperMac.Utilities
{
    public class Option
    {
        public string Description { get; private set; }
        private readonly Action _executableAction;

        public Option(string description, Action executableAction)
        {
            Description = description ?? throw new ArgumentNullException();
            _executableAction = executableAction;
        }

        public void Execute()
        {
            _executableAction();
        }
    }
}