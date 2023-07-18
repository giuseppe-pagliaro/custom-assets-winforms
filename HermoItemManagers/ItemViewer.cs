using HermoCommons;
using HermoRestClient;

namespace HermoItemManagers
{
    public partial class ItemViewer : Form
    {
        public ItemViewer()
        {
            InitializeComponent();

            Text = "No Item Provided";
            noFocusObj.Focus();
        }

        /*public ItemViewer(ItemDatas item,HermoEndpoint<> String propIsNullMsg = "(Null Value)", String deleteBtnMsg = "Delete")
        {
        }*/
    }
}