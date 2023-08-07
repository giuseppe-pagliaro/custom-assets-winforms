using HermoCommons;
using HermoItemManagers.Builders;
using HermoItemManagers.Managers;

namespace Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FieldsFormManager.Instance.RequestEntity<ItemViewerBuilder>(new DataExample() { Id = 0, Value = "Ciao" }, Style.DEFAULT_STYLE);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            FieldsFormManager.Instance.RequestEntity<ItemViewerBuilder>(new DataExample() { Id = 0, Value = "Ciao" }, Style.DEFAULT_STYLE);
        }
    }
}
