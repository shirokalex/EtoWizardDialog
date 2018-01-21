using Eto.Forms;

namespace EtoWizardDialog.Sample
{
    public class PageOne : WizardPage
    {
        public PageOne()
        {
            IsCompleted = false;

            var checkBoxIsCompleted = new CheckBox {Text = "<- Check this to make page completed"};
            checkBoxIsCompleted.CheckedChanged += (sender, args) => IsCompleted = checkBoxIsCompleted.Checked ?? false;

            Content = new StackLayout
            {
                Padding = 10,
                Spacing = 10,
                Items =
                {
                    new TextBox { Text = "TetBox" },
                    new Button { Text = "Button" },
                    checkBoxIsCompleted
                }
            };
        }

        public override void InitializePage()
        {
            MessageBox.Show(this, "PageOne initialized");
        }

        public override void Commit()
        {
            MessageBox.Show(this, "PageOne commited");
        }
    }
}