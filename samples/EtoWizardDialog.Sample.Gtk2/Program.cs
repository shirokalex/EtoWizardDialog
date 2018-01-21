using System;
using Eto;

namespace EtoWizardDialog.Sample.Gtk2
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new SampleApplication(Platforms.Gtk2).Run();
        }
    }
}