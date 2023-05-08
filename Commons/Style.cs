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

        #region Properties

        public Color PrimaryBackColor { get { return primaryBackColor; } }
        public Color SecondaryBackColor { get { return secondaryBackColor; } }

        public String FontType { get { return fontType; } }
        public Color FontColor { get { return fontColor; } }

        public Color PrimaryInteractableColor { get { return primaryInteractableColor; } }
        public Color SecondaryInteractableColor { get { return secondaryInteractableColor; } }

        public String InteractableFontType { get { return interactableFontType; } }
        public Color InteractableFontColor { get { return interactableFontColor; } }
        public FlatStyle InteractableFlatStyle { get { return interactableFlatStyle; } }

        #endregion

        #region Appliers

        public static void Apply(Form form, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                form.BackColor = style.PrimaryBackColor;
            }
            else
            {
                form.BackColor = style.SecondaryBackColor;
            }
        }

        public static void Apply(UserControl userControl, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                userControl.BackColor = style.PrimaryBackColor;
            }
            else
            {
                userControl.BackColor = style.SecondaryBackColor;
            }
            
        }

        public static void Apply(Panel panel, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                panel.BackColor = style.PrimaryBackColor;
            }
            else
            {
                panel.BackColor = style.SecondaryBackColor;
            }
        }

        public static void Apply(GroupBox groupBox, Style style, FontStyle titleFontStyle, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                groupBox.BackColor = style.PrimaryBackColor;
            }
            else
            {
                groupBox.BackColor = style.SecondaryBackColor;
            }

            groupBox.ForeColor = style.FontColor;
            groupBox.Font = new Font(style.FontType, groupBox.Font.SizeInPoints);

            if (groupBox.Font.Style != titleFontStyle)
            {
                groupBox.Font = new Font(groupBox.Font, titleFontStyle);
            }
        }

        public static void Apply(Label label, Style style, FontStyle fontStyle)
        {
            label.ForeColor = style.FontColor;
            label.Font = new Font(style.FontType, label.Font.SizeInPoints);

            if (label.Font.Style != fontStyle)
            {
                label.Font = new Font(label.Font, fontStyle);
            }
        }

        public static void Apply(LinkLabel linkLabel, Style style, LinkType linkType)
        {
            linkLabel.LinkColor = style.PrimaryInteractableColor;
            linkLabel.ActiveLinkColor = style.InteractableFontColor;

            if (linkType == LinkType.Normal)
            {
                linkLabel.VisitedLinkColor = style.PrimaryInteractableColor;
            }
            else
            {
                linkLabel.VisitedLinkColor = style.InteractableFontColor;
            }

            linkLabel.Font = new Font(style.FontType, linkLabel.Font.SizeInPoints, FontStyle.Underline);
        }

        public static void Apply(TextBox textBox, Style style)
        {
            textBox.ForeColor = style.FontColor;
            textBox.Font = new Font(style.FontType, textBox.Font.SizeInPoints);
            textBox.BackColor = style.SecondaryBackColor;
        }

        public static void Apply(Button button, Style style)
        {
            button.ForeColor = style.InteractableFontColor;
            button.Font = new Font(style.FontType, button.Font.SizeInPoints);
            button.BackColor = style.PrimaryInteractableColor;
            button.FlatStyle = style.InteractableFlatStyle;
        }

        #endregion
    }

    public enum BgType
    {
        Primary,
        Secondary
    }

    public enum LinkType
    {
        Normal,
        WithVisited
    }
}