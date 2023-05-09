using CustomItemManagers;

namespace Example
{
    public partial class ExampleViewer : FieldsForm
    {
        public ExampleViewer()
        {
            InitializeComponent();
        }

        protected override void Populate()
        {
            base.Populate();

            if (ItemDatas is null)
            {
                fieldValue.Value = "(Null Object)";
                return;
            }

            if (ItemDatas is not DataExample)
            {
                fieldValue.Value = "(Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)ItemDatas;

            if (dataExample.Value is null)
            {
                fieldValue.Value = "(Null Field)";
            }
            else
            {
                fieldValue.Value = dataExample.Value;
            }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            fieldValue.Style = Style;
        }
    }
}