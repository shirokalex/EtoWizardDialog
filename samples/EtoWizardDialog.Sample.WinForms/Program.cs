using System;
using Eto;

namespace EtoWizardDialog.Sample.WinForms
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new SampleApplication(Platforms.WinForms).Run();
        }
    }
}