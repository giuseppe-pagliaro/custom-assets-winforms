using CustomItemManagers;

namespace Example
{
    public partial class ExampleViewer : ItemViewer
    {
        public ExampleViewer()
        {
            InitializeComponent();
        }

        public override void Populate()
        {
            base.Populate();

            if (this.ItemDatas is null)
            {
                this.fieldValue.Value = "(Null Object)";
                return;
            }

            if (this.ItemDatas is not DataExample)
            {
                this.fieldValue.Value = "(Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)this.ItemDatas;

            if (dataExample.Value is null)
            {
                this.fieldValue.Value = "(Null Field)";
            }
            else
            {
                this.fieldValue.Value = dataExample.Value;
            }
        }

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            this.fieldValue.Style = this.Style;
        }
    }
}