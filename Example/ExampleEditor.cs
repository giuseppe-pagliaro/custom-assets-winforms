using Commons;
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
            fieldExample1.Style = Style;
            fieldExample2.Style = Style;
            Style.Apply(buttonUpdate, Style);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}