using CustomAssetsCommons;
using CustomItemManagers;

namespace Example
{
    public partial class ExampleEditor : FieldsForm
    {
        public ExampleEditor()
        {
            InitializeComponent();

            noFocusObj.Focus();
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtTitle, Style, FontStyle.Bold);
            fieldPath.Style = Style;
            fieldNormal.Style = Style;
            fieldDecimalNumber.Style = Style;
            fieldNumber.Style = Style;
            fieldDate.Style = Style;
            fieldPhone.Style = Style;
            Style.Apply(buttonUpdate, Style);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}