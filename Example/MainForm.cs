using Commons;
using RestClient;
using CustomLists;
using CustomSearchBars;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            customSearchBar.Request = Requests.SEARCH_FIRST_RESULT;
            customSearchBar.SearchMade += customSearchBar_SearchMade;
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
            StyleAppliers.PrimaryBg(this.groupBoxStyles, style, FontStyle.Bold);
            StyleAppliers.Label(this.txtSearchInfo, style, FontStyle.Regular);
            customSearchBar.Style = style;
            StyleAppliers.TextBox(this.textBoxResult, style);
            customList.Style = style;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (WaitForm waitForm = new(TaskSimulation))
            {
                waitForm.Style = Styles.LIGHT_MODE;
                waitForm.ShowDialog();
            }

            ApplyStyles(Styles.LIGHT_MODE);

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
        }

        private void radioLightMode_CheckedChanged(object sender, EventArgs e)
        {
            ApplyStyles(Styles.LIGHT_MODE);
        }

        private void radioDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            ApplyStyles(Styles.DARK_MODE);
        }

        private void customSearchBar_SearchMade(object sender, EventArgs e)
        {
            this.textBoxResult.Text = ((SearchMadeEventArgs)e).JsonResult;
        }
    }
}