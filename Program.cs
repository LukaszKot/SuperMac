using System;
using SuperMac.Utilities;

Console.WriteLine("Witaj w SuperMac! Najlepszej terminalowej restauracji w .NET! U nas zawsze zjesz dobrze, smacznie i szybko!");

OptionsManager.Question("Co chcesz zrobić?")
    .AddOption("Zamówić na miejscu.", ()=> Console.WriteLine("test1"))
    .AddOption("Zamówić na wynos.", ()=> Console.WriteLine("test2"))
    .AddOption("Wyjść.", ()=> Environment.Exit(0))
    .Ask();