namespace Commons
{
    public class StyleAppliers
    {
        public static void Panel(Panel panel, Style style)
        {
            panel.BackColor = style.PrimaryBackColor;
        }

        public static void Label(Label label, Style style)
        {
            label.ForeColor = style.FontColor;
            label.Font = new Font(style.FontType.FontFamily, label.Font.SizeInPoints);
        }

        public static void TextBox(TextBox textBox, Style style)
        {
            textBox.ForeColor = style.FontColor;
            textBox.Font = new Font(style.FontType.FontFamily, textBox.Font.SizeInPoints);
            textBox.BackColor = style.SecondaryBackColor;
        }

        public static void Button(Button button, Style style)
        {
            button.ForeColor = style.ButtonFontColor;
            button.Font = new Font(style.ButtonFontType.FontFamily, button.Font.SizeInPoints);
            button.BackColor = style.PrimaryButtonColor;
            button.FlatStyle = style.ButtonFlatStyle;
        }
    }
}