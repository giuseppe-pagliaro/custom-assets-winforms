namespace Commons
{
    public class Style
    {
        public Style(Color primaryBackColor, Color secondaryBackColor, Font fontType, Color fontColor,
            Color primaryButtonColor, Color secondaryButtonColor, Font buttonfontType,
            Color buttonfontColor, FlatStyle buttonFlatStyle)
        {
            this.primaryBackColor = primaryBackColor;
            this.secondaryBackColor = secondaryBackColor;
            this.fontType = fontType;
            this.fontColor = fontColor;
            this.primaryButtonColor = primaryButtonColor;
            this.secondaryButtonColor = secondaryButtonColor;
            this.buttonFontType = buttonfontType;
            this.buttonFontColor = buttonfontColor;
            this.buttonFlatStyle = buttonFlatStyle;
        }

        public Style()
        {
            this.primaryBackColor = SystemColors.Control;
            this.secondaryBackColor = SystemColors.ControlDark;
            this.fontType = new Font("Segoe UI", 9);
            this.fontColor = SystemColors.ControlText;
            this.primaryButtonColor = SystemColors.Control;
            this.secondaryButtonColor = Color.Black;
            this.buttonFontType = new Font("Segoe UI", 9);
            this.buttonFontColor = SystemColors.ControlText;
            this.buttonFlatStyle = FlatStyle.Standard;
        }

        private Color primaryBackColor;
        private Color secondaryBackColor;

        private Font fontType;
        private Color fontColor;

        private Color primaryButtonColor;
        private Color secondaryButtonColor;

        private Font buttonFontType;
        private Color buttonFontColor;
        private FlatStyle buttonFlatStyle;

        public Color PrimaryBackColor { get { return primaryBackColor; } }
        public Color SecondaryBackColor { get { return secondaryBackColor; } }

        public Font FontType { get { return fontType; } }
        public Color FontColor { get { return fontColor; } }

        public Color PrimaryButtonColor { get { return primaryButtonColor; } }
        public Color SecondaryButtonColor { get { return secondaryButtonColor; } }

        public Font ButtonFontType { get { return buttonFontType; } }
        public Color ButtonFontColor { get { return buttonFontColor; } }
        public FlatStyle ButtonFlatStyle { get { return buttonFlatStyle; } }
    }
}