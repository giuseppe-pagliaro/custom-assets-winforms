using CustomItemManagers;

namespace Example
{
    public partial class ExampleEditor : FieldsForm
    {
        public ExampleEditor()
        {
            InitializeComponent();
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            fieldExample.Style = Style;
        }
    }
}