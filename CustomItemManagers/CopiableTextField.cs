using Commons;

namespace CustomItemManagers
{
    public partial class CopiableTextField : TextField
    {
        public CopiableTextField() : base() { }
        public CopiableTextField(String name, String value) : base(name, value) { }

        protected override void ApplyStyle()
        {
            StyleAppliers.SecondaryBg(this, this.Style);
            StyleAppliers.Label(this.txtName, this.Style, FontStyle.Bold);
            StyleAppliers.Label(this.txtSeparator, this.Style, FontStyle.Regular);
            StyleAppliers.CopyableLabel(this.txtValue, this.Style);
        }

        private void txtValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtValue.Text);
            // TODO add prompt.
        }
    }
}