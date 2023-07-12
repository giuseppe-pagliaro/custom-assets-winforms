using CustomAssetsCommons;
using CustomLists;

namespace Example
{
    public partial class ExampleItem : ListItem
    {
        public ExampleItem()
        {
            InitializeComponent();

            txtValue.Click += ListItem_Click;
        }

        protected override void Populate()
        {
            base.Populate();

            if (ItemDatas is null)
            {
                txtValue.Text = "Value: (Null Object)";
                return;
            }

            if (ItemDatas is not DataExample)
            {
                txtValue.Text = "Value: (Incompatible Class)";
                return;
            }

            DataExample dataExample = (DataExample)ItemDatas;

            if (dataExample.Value is null)
            {
                txtValue.Text = "Value: (Null Field)";
            }
            else
            {
                txtValue.Text = "Value: " + dataExample.Value;
            }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtValue, Style, FontStyle.Regular);
        }
    }
}