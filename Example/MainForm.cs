using Commons;
using CustomSearchBars;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            customSearchBar.Request = Requests.SEARCH_UNIS_BY_COUNTRY;
            customSearchBar.SearchMade += customSearchBar_SearchMade;
        }

        private static List<DataExample> GenPlaceHolderList(int lenght)
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
            StyleAppliers.Button(this.buttonLightMode, style);
            StyleAppliers.Button(this.buttonDarkMode, style);
            customSearchBar.Style = style;
            StyleAppliers.TextBox(this.textBoxResult, style);
            customList.Style = style;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyStyles(Styles.LIGHT_MODE);
            this.buttonLightMode.BackColor = Styles.LIGHT_MODE.SecondaryInteractableColor;
            this.buttonLightMode.Enabled = false;
            customList.SetItems<DataExample, ExampleItem>(GenPlaceHolderList(10));
            noFocusObj.Focus();
        }

        private void buttonLightMode_Click(object sender, EventArgs e)
        {
            ApplyStyles(Styles.LIGHT_MODE);
            this.buttonLightMode.BackColor = Styles.LIGHT_MODE.SecondaryInteractableColor;
            this.buttonDarkMode.BackColor = Styles.LIGHT_MODE.PrimaryInteractableColor;
            this.buttonLightMode.Enabled = false;
            this.buttonDarkMode.Enabled = true;
            noFocusObj.Focus();
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            ApplyStyles(Styles.DARK_MODE);
            this.buttonLightMode.BackColor = Styles.DARK_MODE.PrimaryInteractableColor;
            this.buttonDarkMode.BackColor = Styles.DARK_MODE.SecondaryInteractableColor;
            this.buttonLightMode.Enabled = true;
            this.buttonDarkMode.Enabled = false;
            noFocusObj.Focus();
        }

        private void customSearchBar_SearchMade(object? sender, SearchMadeEventArgs e)
        {
            this.textBoxResult.Text = e.Result;
        }
    }
}