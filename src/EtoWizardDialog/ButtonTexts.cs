namespace EtoWizardDialog
{
    public class ButtonTexts
    {
        private const string DefaultBackText = "< Back";
        private const string DefaultNextText = "Next >";
        private const string DefaultFinishText = "Finish";
        private const string DefaultCancelText = "Cancel";

        public ButtonTexts(string back = DefaultBackText, string next = DefaultNextText, string finish = DefaultFinishText, string cancel = DefaultCancelText)
        {
            Back = back;
            Next = next;
            Finish = finish;
            Cancel = cancel;
        }

        public string Back { get; }
        public string Next { get; }
        public string Finish { get; }
        public string Cancel { get; }
    }
}