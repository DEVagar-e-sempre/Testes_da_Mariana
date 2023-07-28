using FluentValidation;
using Serilog;
using System.Globalization;

namespace TestesDonaMaria.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

                //.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                //.CreateLogger();

            Log.Debug("Iniciando aplicação");

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipal());
        }
    }
}