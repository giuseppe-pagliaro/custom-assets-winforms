namespace Commons
{
    public static class StyleAppliers
    {
        public static void PrimaryBg(Form form, Style style)
        {
            form.BackColor = style.PrimaryBackColor;
        }

        public static void PrimaryBg(UserControl userControl, Style style)
        {
            userControl.BackColor = style.PrimaryBackColor;
        }

        public static void PrimaryBg(Panel panel, Style style)
        {
            panel.BackColor = style.PrimaryBackColor;
        }

        public static void PrimaryBg(GroupBox groupBox, Style style, FontStyle titleFontStyle)
        {
            groupBox.BackColor = style.PrimaryBackColor;

            groupBox.ForeColor = style.FontColor;
            groupBox.Font = new Font(style.FontType, groupBox.Font.SizeInPoints);

            if (groupBox.Font.Style != titleFontStyle)
            {
                groupBox.Font = new Font(groupBox.Font, titleFontStyle);
            }
        }

        public static void SecondaryBg(Form form, Style style)
        {
            form.BackColor = style.SecondaryBackColor;
        }

        public static void SecondaryBg(UserControl userControl, Style style)
        {
            userControl.BackColor = style.SecondaryBackColor;
        }

        public static void SecondaryBg(Panel panel, Style style)
        {
            panel.BackColor = style.SecondaryBackColor;
        }

        public static void SecondaryBg(GroupBox groupBox, Style style, FontStyle titleFontStyle)
        {
            groupBox.BackColor = style.SecondaryBackColor;

            groupBox.ForeColor = style.FontColor;
            groupBox.Font = new Font(style.FontType, groupBox.Font.SizeInPoints);

            if (groupBox.Font.Style != titleFontStyle)
            {
                groupBox.Font = new Font(groupBox.Font, titleFontStyle);
            }
        }

        public static void Label(Label label, Style style, FontStyle fontStyle)
        {
            label.ForeColor = style.FontColor;
            label.Font = new Font(style.FontType, label.Font.SizeInPoints);

            if (label.Font.Style != fontStyle)
            {
                label.Font = new Font(label.Font, fontStyle);
            }
        }

        public static void LinkLabel(LinkLabel linkLabel, Style style)
        {
            linkLabel.LinkColor = style.PrimaryInteractableColor;
            linkLabel.ActiveLinkColor = style.InteractableFontColor;
            linkLabel.VisitedLinkColor = style.PrimaryInteractableColor;
            linkLabel.Font = new Font(style.FontType, linkLabel.Font.SizeInPoints, FontStyle.Underline);
        }

        public static void LinkLabelWithVisited(LinkLabel linkLabel, Style style)
        {
            linkLabel.LinkColor = style.PrimaryInteractableColor;
            linkLabel.ActiveLinkColor = style.InteractableFontColor;
            linkLabel.VisitedLinkColor = style.SecondaryInteractableColor; ;
            linkLabel.Font = new Font(style.FontType, linkLabel.Font.SizeInPoints, FontStyle.Underline);
        }

        public static void TextBox(TextBox textBox, Style style)
        {
            textBox.ForeColor = style.FontColor;
            textBox.Font = new Font(style.FontType, textBox.Font.SizeInPoints);
            textBox.BackColor = style.SecondaryBackColor;
        }

        public static void Button(Button button, Style style)
        {
            button.ForeColor = style.InteractableFontColor;
            button.Font = new Font(style.FontType, button.Font.SizeInPoints);
            button.BackColor = style.PrimaryInteractableColor;
            button.FlatStyle = style.InteractableFlatStyle;
        }
    }
}