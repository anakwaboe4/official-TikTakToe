using System.Diagnostics;

namespace TikTakToe.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello Controller!");

            ProcessStartInfo startinfo = new ProcessStartInfo("TikTakToe.WebUI.exe");
            Process p = Process.Start(startinfo);
            p.WaitForExit();
        }
    }
}
