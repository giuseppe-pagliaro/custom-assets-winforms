namespace HermoCommons
{
    public class Style
    {
        private Style()
        {
            primaryBackColor = SystemColors.Control;
            secondaryBackColor = SystemColors.ControlDark;
            fontType = "Segoe UI";
            fontColor = SystemColors.ControlText;
            primaryInteractableColor = SystemColors.Control;
            secondaryInteractableColor = Color.Black;
            interactableFontType = "Segoe UI";
            interactableFontColor = SystemColors.ControlText;
            linkColor = SystemColors.HotTrack;
            buttonFlatStyle = FlatStyle.Standard;
        }

        public Style(Color primaryBackColor, Color secondaryBackColor, string fontType, Color fontColor,
            Color primaryInteractableColor, Color secondaryInteractableColor, string interactableFontType,
            Color interactableFontColor, Color linkColor, FlatStyle buttonFlatStyle)
        {
            this.primaryBackColor = primaryBackColor;
            this.secondaryBackColor = secondaryBackColor;
            this.fontType = fontType;
            this.fontColor = fontColor;
            this.primaryInteractableColor = primaryInteractableColor;
            this.secondaryInteractableColor = secondaryInteractableColor;
            this.interactableFontType = interactableFontType;
            this.interactableFontColor = interactableFontColor;
            this.linkColor = linkColor;
            this.buttonFlatStyle = buttonFlatStyle;
        }

        private Color primaryBackColor;
        private Color secondaryBackColor;

        private string fontType;
        private Color fontColor;

        private Color primaryInteractableColor;
        private Color secondaryInteractableColor;

        private string interactableFontType;
        private Color interactableFontColor;
        private Color linkColor;
        private FlatStyle buttonFlatStyle;

        private static readonly Lazy<Style> lazyDefaultStyle = new(() => new Style());

        #region Properties

        public Color PrimaryBackColor { get { return primaryBackColor; } }
        public Color SecondaryBackColor { get { return secondaryBackColor; } }

        public string FontType { get { return fontType; } }
        public Color FontColor { get { return fontColor; } }

        public Color PrimaryInteractableColor { get { return primaryInteractableColor; } }
        public Color SecondaryInteractableColor { get { return secondaryInteractableColor; } }

        public string InteractableFontType { get { return interactableFontType; } }
        public Color InteractableFontColor { get { return interactableFontColor; } }
        public Color LinkColor { get { return linkColor; } }
        public FlatStyle ButtonFlatStyle { get { return buttonFlatStyle; } }

        public static Style DEFAULT_STYLE { get { return lazyDefaultStyle.Value; } }

        #endregion

        #region Appliers

        public static void Apply(Form form, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                form.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                form.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                form.BackColor = Color.Transparent;
            }
        }

        public static void Apply(UserControl userControl, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                userControl.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                userControl.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                userControl.BackColor = Color.Transparent;
            }
        }

        public static void Apply(Panel panel, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                panel.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                panel.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                panel.BackColor = Color.Transparent;
            }
        }

        public static void Apply(GroupBox groupBox, Style style, FontStyle titleFontStyle, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                groupBox.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                groupBox.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                groupBox.BackColor = Color.Transparent;
            }

            groupBox.ForeColor = style.FontColor;
            groupBox.Font = new Font(style.FontType, groupBox.Font.SizeInPoints);

            if (groupBox.Font.Style != titleFontStyle)
            {
                groupBox.Font = new Font(groupBox.Font, titleFontStyle);
            }
        }

        public static void Apply(TabPage tabPage, Style style, BgType bgType, FontStyle titleFontStyle)
        {
            if (bgType == BgType.Primary)
            {
                tabPage.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                tabPage.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                tabPage.BackColor = Color.Transparent;
            }

            tabPage.ForeColor = style.FontColor;
            tabPage.Font = new Font(style.FontType, tabPage.Font.SizeInPoints);

            if (tabPage.Font.Style != titleFontStyle)
            {
                tabPage.Font = new Font(tabPage.Font, titleFontStyle);
            }
        }

        public static void Apply(TabControl tabControl, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                tabControl.BackColor = style.PrimaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                tabControl.BackColor = style.SecondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                tabControl.BackColor = Color.Transparent;
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
            linkLabel.LinkColor = style.LinkColor;
            linkLabel.ActiveLinkColor = style.InteractableFontColor;

            if (linkType == LinkType.Normal)
            {
                linkLabel.VisitedLinkColor = style.LinkColor;
            }
            else
            {
                linkLabel.VisitedLinkColor = style.SecondaryInteractableColor;
            }

            linkLabel.Font = new Font(style.FontType, linkLabel.Font.SizeInPoints, FontStyle.Underline);
        }

        public static void Apply(TextBox textBox, Style style)
        {
            textBox.ForeColor = style.FontColor;
            textBox.Font = new Font(style.FontType, textBox.Font.SizeInPoints);
            textBox.BackColor = style.SecondaryBackColor;
        }

        public static void Apply(ComboBox comboBox, Style style)
        {
            comboBox.ForeColor = style.FontColor;
            comboBox.Font = new Font(style.FontType, comboBox.Font.SizeInPoints);
            comboBox.BackColor = style.SecondaryBackColor;
        }

        public static void Apply(Button button, Style style)
        {
            button.ForeColor = style.InteractableFontColor;
            button.Font = new Font(style.FontType, button.Font.SizeInPoints);
            button.BackColor = style.PrimaryInteractableColor;
            button.FlatStyle = style.ButtonFlatStyle;
        }

        public static void Apply(CheckBox checkBox, Style style, BgType bgType)
        {
            if (bgType == BgType.Primary)
            {
                checkBox.BackColor = style.primaryBackColor;
            }
            else if (bgType == BgType.Secondary)
            {
                checkBox.BackColor = style.secondaryBackColor;
            }
            else if (bgType == BgType.Transparent)
            {
                checkBox.BackColor = Color.Transparent;
            }

            checkBox.Font = new Font(style.FontType, checkBox.Font.SizeInPoints);
            checkBox.ForeColor = style.fontColor;
        }

        #endregion
    }

    public enum BgType
    {
        Primary,
        Secondary,
        Transparent,
        Inherit
    }

    public enum LinkType
    {
        Normal,
        WithVisited
    }
}