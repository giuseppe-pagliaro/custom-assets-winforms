namespace Commons
{
    public class StyleAppliers
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
            panel.BackColor = style.SecondaryBackColor;
        }

        public static void SecondaryBg(Form form, Style style)
        {
            form.BackColor = style.PrimaryBackColor;
        }

        public static void SecondaryBg(UserControl userControl, Style style)
        {
            userControl.BackColor = style.PrimaryBackColor;
        }

        public static void SecondaryBg(Panel panel, Style style)
        {
            panel.BackColor = style.SecondaryBackColor;
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

        public static void TextBox(TextBox textBox, Style style)
        {
            textBox.ForeColor = style.FontColor;
            textBox.Font = new Font(style.FontType, textBox.Font.SizeInPoints);
            textBox.BackColor = style.SecondaryBackColor;
        }

        public static void Button(Button button, Style style)
        {
            button.ForeColor = style.ButtonFontColor;
            button.Font = new Font(style.FontType, button.Font.SizeInPoints);
            button.BackColor = style.PrimaryButtonColor;
            button.FlatStyle = style.ButtonFlatStyle;
        }
    }
}