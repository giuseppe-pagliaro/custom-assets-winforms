using CustomLists;

namespace Example
{
    public partial class ExampleItem : ListItem
    {
        public ExampleItem()
        {
            InitializeComponent();
        }

        public override void Populate()
        {
            base.Populate();

            if (ItemDatas is null)
            {
                txtValue.Text = "Value: (Null Object)";
            }
            else if (ItemDatas.GetType().IsSubclassOf(typeof(ItemDatas)))
            {
                var dataExample = (DataExample)ItemDatas;

                if (dataExample.Value is null)
                {
                    txtValue.Text = "Value: (Null Property)";
                }
                else
                {
                    txtValue.Text = "Value: " + dataExample.Value;
                }
            }
            else
            {
                txtValue.Text = "Value: (Incompatible Class)";
            }
        }

        private void ExampleItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cliccato Item " + this.ItemDatas.Id.ToString());
        }
    }
}