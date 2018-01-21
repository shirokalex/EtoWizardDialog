using Eto.Drawing;
using Eto.Forms;

namespace EtoWizardDialog.Sample
{
    public class SampleApplication : Application
    {
        public SampleApplication(string platform) 
            : base(platform)
        {
        }

        public override void Run()
        {
            var pages = new WizardPage[] {new PageOne(), new PageTwo()};

            var wizard = new WizardDialog(pages)
            {
                Title = "Sample wizard dialog",
                ClientSize = new Size(400, 400)
            };

            wizard.ShowModal();
        }
    }
}