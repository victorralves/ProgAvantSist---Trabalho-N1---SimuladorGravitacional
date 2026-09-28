namespace SimuladorGravitacional
{
    internal static class Program
    {
        [STAThread]
        static void Main()//INICIALIZA O PROGRAMA
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}