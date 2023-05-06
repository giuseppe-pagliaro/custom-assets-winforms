namespace Commons
{
    public class Style
    {
        public Style()
        {
            primaryBackColor = SystemColors.Control;
            secondaryBackColor = SystemColors.ControlDark;
            fontType = "Segoe UI";
            fontColor = SystemColors.ControlText;
            primaryInteractableColor = SystemColors.Control;
            secondaryInteractableColor = Color.Black;
            interactableFontType = "Segoe UI";
            interactableFontColor = SystemColors.ControlText;
            interactableFlatStyle = FlatStyle.Standard;
        }

        public Style(Color primaryBackColor, Color secondaryBackColor, String fontType, Color fontColor,
            Color primaryInteractableColor, Color secondaryInteractableColor, String interactableFontType,
            Color interactableFontColor, FlatStyle interactableFlatStyle)
        {
            this.primaryBackColor = primaryBackColor;
            this.secondaryBackColor = secondaryBackColor;
            this.fontType = fontType;
            this.fontColor = fontColor;
            this.primaryInteractableColor = primaryInteractableColor;
            this.secondaryInteractableColor = secondaryInteractableColor;
            this.interactableFontType = interactableFontType;
            this.interactableFontColor = interactableFontColor;
            this.interactableFlatStyle = interactableFlatStyle;
        }

        private Color primaryBackColor;
        private Color secondaryBackColor;

        private String fontType;
        private Color fontColor;

        private Color primaryInteractableColor;
        private Color secondaryInteractableColor;

        private String interactableFontType;
        private Color interactableFontColor;
        private FlatStyle interactableFlatStyle;

        public Color PrimaryBackColor { get { return primaryBackColor; } }
        public Color SecondaryBackColor { get { return secondaryBackColor; } }

        public String FontType { get { return fontType; } }
        public Color FontColor { get { return fontColor; } }

        public Color PrimaryInteractableColor { get { return primaryInteractableColor; } }
        public Color SecondaryInteractableColor { get { return secondaryInteractableColor; } }

        public String InteractableFontType { get { return interactableFontType; } }
        public Color InteractableFontColor { get { return interactableFontColor; } }
        public FlatStyle InteractableFlatStyle { get { return interactableFlatStyle; } }
    }
}