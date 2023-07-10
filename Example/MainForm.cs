using Commons;
using CustomLists;
using CustomSearchBars;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            customSearchBar.SearchMethod = Endpoints.SearchUnis;
            customSearchBar.SearchMade += customSearchBar_SearchMade;
            customSearchBar.QueryPlaceholderText = "Type Your Country Here";
            customList.Viewer = typeof(ExampleViewer);
            customList.Editor = typeof(ExampleEditor);
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
            Style.Apply(this, style, BgType.Primary);
            Style.Apply(groupBoxStyles, style, FontStyle.Bold, BgType.Primary);
            Style.Apply(txtSearchInfo, style, FontStyle.Regular);
            Style.Apply(buttonLightMode, style);
            Style.Apply(buttonDarkMode, style);
            customSearchBar.Style = style;
            Style.Apply(textBoxResult, style);
            customList.Style = style;

            FieldsFormManager.Instance.ApplyStyle(style);
        }

        #region Event Consumers

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyStyles(Styles.LIGHT_MODE);
            buttonLightMode.BackColor = Styles.LIGHT_MODE.SecondaryInteractableColor;
            buttonLightMode.Enabled = false;
            customList.SetItems<DataExample, ExampleItem>(GenPlaceHolderList(10));
            noFocusObj.Focus();
        }

        private void buttonLightMode_Click(object sender, EventArgs e)
        {
            ApplyStyles(Styles.LIGHT_MODE);
            buttonLightMode.BackColor = Styles.LIGHT_MODE.SecondaryInteractableColor;
            buttonDarkMode.BackColor = Styles.LIGHT_MODE.PrimaryInteractableColor;
            buttonLightMode.Enabled = false;
            buttonDarkMode.Enabled = true;
            noFocusObj.Focus();
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            ApplyStyles(Styles.DARK_MODE);
            buttonLightMode.BackColor = Styles.DARK_MODE.PrimaryInteractableColor;
            buttonDarkMode.BackColor = Styles.DARK_MODE.SecondaryInteractableColor;
            buttonLightMode.Enabled = true;
            buttonDarkMode.Enabled = false;
            noFocusObj.Focus();
        }

        private void customSearchBar_SearchMade(object? sender, SearchMadeEventArgs e)
        {
            UnisSearchResult[] searchResults = (UnisSearchResult[])e.Result;

            foreach (UnisSearchResult searchResult in searchResults)
            {
                if (searchResult != null)
                {
                    textBoxResult.Text += searchResult.ToString();
                }
                else
                {
                    textBoxResult.Text += "[Null Result]";
                }

                textBoxResult.Text += "  ";
            }
        }

        #endregion
    }
}