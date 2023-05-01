using Commons;
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

        private List<DataExample> GenPlaceHolderList(int lenght)
        {
            List<DataExample> exampleItems = new();

            for (int i = 0; i < lenght; i++)
            {
                exampleItems.Add(new DataExample());

                exampleItems[i].Id = i + 1;
                exampleItems[i].Value = "Ciao";
            }

            return exampleItems;
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
            ApplyStyles(Styles.LIGHT_MODE);
            customList.SetItems<DataExample, ExampleItem>(GenPlaceHolderList(10));
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