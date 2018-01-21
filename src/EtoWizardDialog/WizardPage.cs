using Eto.Forms;

namespace EtoWizardDialog
{
    public delegate void IsCompletedChangedEventHandler(bool isCompleted);

    public abstract class WizardPage : Panel
    {
        private bool isCompleted;

        protected WizardPage()
        {
            isCompleted = true;
        }

        public bool IsCompleted
        {
            get => isCompleted;
            protected set
            {
                isCompleted = value;
                IsCompletedChanged?.Invoke(isCompleted);
            }
        }

        public event IsCompletedChangedEventHandler IsCompletedChanged;

        public abstract void InitializePage();
        public abstract void Commit();
    }
}