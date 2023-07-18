using HermoItemManagers;

namespace Example
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
            ApplicationConfiguration.Initialize();
            //Application.Run(new MainForm());

            // Application.Run(ItemFormsFactory.GetFormViewer<DataExample>(new DataExample(), new NextControlLine[] { NextControlLine.NextLine }));
            Application.Run(new ItemViewer<DataExample>(new() { Id = 0, Value = "Prova"}));
        }
    }
}