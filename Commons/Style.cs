namespace Commons
{
    public class Style
    {
        public Style(Color primaryBackColor, Color secondaryBackColor, String fontType, Color fontColor,
            Color primaryInteractableColor, Color secondaryInteractableColor, String interactablefontType,
            Color interactablefontColor, FlatStyle interactableFlatStyle)
        {
            this.primaryBackColor = primaryBackColor;
            this.secondaryBackColor = secondaryBackColor;
            this.fontType = fontType;
            this.fontColor = fontColor;
            this.primaryInteractableColor = primaryInteractableColor;
            this.secondaryInteractableColor = secondaryInteractableColor;
            this.interactableFontType = interactablefontType;
            this.interactableFontColor = interactablefontColor;
            this.interactableFlatStyle = interactableFlatStyle;
        }

        public Style()
        {
            this.primaryBackColor = SystemColors.Control;
            this.secondaryBackColor = SystemColors.ControlDark;
            this.fontType = "Segoe UI";
            this.fontColor = SystemColors.ControlText;
            this.primaryInteractableColor = SystemColors.Control;
            this.secondaryInteractableColor = Color.Black;
            this.interactableFontType = "Segoe UI";
            this.interactableFontColor = SystemColors.ControlText;
            this.interactableFlatStyle = FlatStyle.Standard;
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