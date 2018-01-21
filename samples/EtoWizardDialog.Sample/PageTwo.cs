using Eto.Forms;

namespace EtoWizardDialog.Sample
{
    public class PageTwo : WizardPage
    {
        public PageTwo()
        {
            Content = new StackLayout
            {
                Padding = 10,
                Spacing = 10,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items =
                {
                    new TextArea { Height = 250 }
                }
            };
        }

        public override void InitializePage()
        {
            MessageBox.Show(this, "PageTwo initialized");
        }

        public override void Commit()
        {
            MessageBox.Show(this, "PageTwo commited");
        }
    }
}