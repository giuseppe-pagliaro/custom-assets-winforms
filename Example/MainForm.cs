using Commons;
using RestClient;
using CustomLists;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<DataExample>? exampleItems;

        private void GenPlaceHolderList(int lenght)
        {
            exampleItems = new();
            for (int i = 0; i < lenght; i++)
            {
                exampleItems.Add(new DataExample());

                exampleItems[i].Id = i + 1;
                exampleItems[i].Value = "Ciao";
            }
        }

        private void GenEmptyList()
        {
            exampleItems = new();
        }

        private void TaskSimulation()
        {
            Thread.Sleep(5000);
        }

        private void ApplyStyles(Style style)
        {
            StyleAppliers.PrimaryBg(this, style);
            customSearchBar.Style = style;
            customList.Style = style;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyStyles(Styles.DARK_MODE);

            GenPlaceHolderList(10);
            //GenEmptyList();

            if (exampleItems is null)
            {
                customList.SetItems<ItemDatas, ListItem>(new List<ItemDatas>());
            }
            else
            {
                customList.SetItems<DataExample, ExampleItem>(exampleItems);
            }

            using (WaitForm waitForm = new(TaskSimulation))
            {
                waitForm.Style = Styles.DARK_MODE;
                waitForm.ShowDialog();
            }
        }
    }
}