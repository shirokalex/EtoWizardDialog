using System;
using Eto.Drawing;
using Eto.Forms;

namespace EtoWizardDialog
{
    public class WizardDialog : Dialog<WizardDialogResult>
    {
        private readonly WizardPage[] pages;
        private readonly ButtonTexts buttonTexts;

        private int currentPageIndex;
        private Panel pagePlaceholder;

        private Button buttonBack;
        private Button buttonNext;
        private Button buttonCancel;

        private bool IsFirstPage => currentPageIndex == 0;
        private bool IsLastPage => currentPageIndex == pages.Length - 1;

        public WizardDialog(WizardPage[] pages)
            : this(pages, new ButtonTexts())
        {
        }

        public WizardDialog(WizardPage[] pages, ButtonTexts buttonTexts)
        {
            if (pages.Length == 0)
                throw new ArgumentException("Pages array must be not empty");

            this.pages = pages;
            foreach (var page in pages)
            {
                page.IsCompletedChanged += PageIsCompletedChanged;
            }

            this.buttonTexts = buttonTexts ?? new ButtonTexts();
            currentPageIndex = 0;
            Result = WizardDialogResult.Cancel;

            InitializeComponent();

            Shown += (sender, args) => Update();
        }

        private void InitializeComponent()
        {
            pagePlaceholder = new Panel();

            buttonBack = new Button((sender, args) => ButtonBackClicked()) { Text = buttonTexts.Back };
            buttonNext = new Button((sender, args) => ButtonNextClicked()) { Text = buttonTexts.Next };
            buttonCancel = new Button((sender, args) => Close()) { Text = buttonTexts.Cancel };

            var buttonsLayout = new StackLayout
            {
                Orientation = Orientation.Horizontal,
                Padding = 5,
                Spacing = 10,
                Items =
                {
                    null,
                    buttonBack,
                    buttonNext,
                    buttonCancel
                }
            };

            Content = new StackLayout
            {
                Padding = 10,
                Spacing = 10,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                Items =
                {
                    pagePlaceholder,
                    null,
                    CreateSeparator(),
                    buttonsLayout
                }
            };
        }

        private Control CreateSeparator()
        {
            var separator = new Drawable();
            separator.Paint += (sender, e) =>
            {
                var back = BackgroundColor;
                var dark = Color.FromArgb(back.Rb >> 1, back.Gb >> 1, back.Bb >> 1);
                using (var pen = new Pen(dark))
                {
                    e.Graphics.DrawLine(pen, 0, 0, separator.ClientSize.Width, 0);
                }
            };
            return separator;
        }

        private void ButtonBackClicked()
        {
            if (!IsFirstPage)
            {
                currentPageIndex--;
                Update();
            }
        }

        private void ButtonNextClicked()
        {
            pages[currentPageIndex].Commit();

            if (!IsLastPage)
            {
                currentPageIndex++;
                Update();
            }
            else
            {
                Close(WizardDialogResult.Ok);
            }
        }

        private void Update()
        {
            UpdateCurrentPage();
            UpdateButtons();
        }

        private void UpdateCurrentPage()
        {
            var page = pages[currentPageIndex];

            if (pagePlaceholder.Content != page)
            {
                pagePlaceholder.Content = page;
                buttonNext.Enabled = page.IsCompleted;
                page.InitializePage();
            }
        }

        private void UpdateButtons()
        {
            buttonBack.Enabled = currentPageIndex > 0;
            buttonNext.Text = IsLastPage ? buttonTexts.Finish : buttonTexts.Next;
        }

        private void PageIsCompletedChanged(bool isCompleted)
        {
            buttonNext.Enabled = isCompleted;
        }
    }
}