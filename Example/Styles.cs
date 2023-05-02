using Commons;

namespace Example
{
    public static class Styles
    {
        public static readonly Style LIGHT_MODE = new(
            SystemColors.Control,
            SystemColors.ControlDark,
            "Segoe UI",
            SystemColors.ControlText,
            Color.Teal,
            SystemColors.ControlDark,
            "Segoe UI",
            SystemColors.ControlText,
            FlatStyle.Standard
            );

        public static readonly Style DARK_MODE = new(
            Color.FromArgb(255, 30, 30, 30),
            Color.FromArgb(255, 51, 51, 51),
            "Segoe UI",
            SystemColors.HighlightText,
            Color.Teal,
            Color.FromArgb(255, 51, 51, 51),
            "Segoe UI",
            SystemColors.HighlightText,
            FlatStyle.Standard
            );
    }
}