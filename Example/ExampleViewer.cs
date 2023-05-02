using Commons;
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
                txtValue.Text = "Value: (Null Object)";
                return;
            }

            if (this.ItemDatas is not DataExample)
            {
                txtValue.Text = "Value: (Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)this.ItemDatas;

            if (dataExample.Value is null)
            {
                txtValue.Text = "Value: (Null Field)";
            }
            else
            {
                txtValue.Text = "Value: " + dataExample.Value;
            }
        }

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            StyleAppliers.Label(this.txtValue, this.Style, FontStyle.Regular);
        }
    }
}