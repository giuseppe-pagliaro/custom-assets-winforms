using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;
using HermoRestClient;
using System.Reflection;

namespace HermoItemManagers.Builders
{
    public class ItemViewerBuilder : FieldsFormBuilder<ItemViewerBuilder>
    {
        private ItemViewerBuilder()
        {
            ActionBtnText = "Delete";
            deleteWarningTitleTxt = "Deleting Item";
            deletingMsg = deleteWarningTitleTxt;
            deleteWarningMsgTxt = "Are you sure you want to delete this element? The process is irreversible.";
        }

        private string deleteWarningTitleTxt;
        private string deletingMsg;
        private string deleteWarningMsgTxt;
        private Action<int>? deleteMethod;

        #region Properties

        public string DeleteWarningTitleTxt
        {
            get { return deleteWarningTitleTxt; }
            set { deleteWarningTitleTxt = value; }
        }

        public string DeletingMsg
        {
            get { return deletingMsg; }
            set { deletingMsg = value; }
        }

        public string DeleteWarningMsgTxt
        {
            get { return deleteWarningMsgTxt; }
            set { deleteWarningMsgTxt = value; }
        }

        public Action<int>? DeleteMethod
        {
            get { return deleteMethod; }
            set { deleteMethod = value; }
        }

        #endregion

        public override void Populate(FieldsForm fieldsForm)
        {
            ItemDatas item = fieldsForm.Item;

            fieldsForm.Text = $"{item.ClassNameToString()} #{item.Id}";

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                if (Attribute.IsDefined(property, typeof(IsCopyable)))
                {
                    fieldsForm.AddField(new CopyableTextField(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg));
                }
                else
                {
                    fieldsForm.AddField(new TextField(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg));
                }
                fieldsForm.Fields[fieldsForm.Fields.Count - 1].Width = fieldsForm.ActionBtnWidth;
                fieldsForm.Height += fieldsForm.ActionBtnLocation.Y * fieldsForm.Fields.Count + fieldsForm.Fields[fieldsForm.Fields.Count - 1].Height * fieldsForm.Fields.Count;
            }

            for (int i = 0; i < fieldsForm.Fields.Count; i++)
            {
                fieldsForm.Fields[i].Location = new(fieldsForm.ActionBtnLocation.X, fieldsForm.ActionBtnLocation.Y * (i + 1) + fieldsForm.Fields[i].Height * i);
                fieldsForm.Controls.Add(fieldsForm.Fields[i]);
            }
            fieldsForm.ActionBtnLocation = new(fieldsForm.ActionBtnLocation.X,
                fieldsForm.Fields[fieldsForm.Fields.Count - 1].Location.Y + fieldsForm.Fields[fieldsForm.Fields.Count - 1].Height + fieldsForm.ActionBtnLocation.Y);

            fieldsForm.ActionBtnText = ActionBtnText;
        }

        public override void ApplyStyle(FieldsForm fieldsForm)
        {
            Style.Apply(fieldsForm, fieldsForm.Style, BgType.Primary);

            fieldsForm.ApplyFieldStyle();
            fieldsForm.ApplyActionBtnStyle();
        }

        public override void BtnClickedAction(FieldsForm fieldsForm)
        {
            if (deleteMethod is null) return;
            if (MessageBox.Show(deleteWarningMsgTxt, deleteWarningTitleTxt, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            ItemDatas item = fieldsForm.Item;
            using (WaitForm waitForm = new(() => { deleteMethod(item.Id); ItemsManager.Instance.Delete(item); }, fieldsForm.Style, deletingMsg))
            {
                waitForm.ShowDialog();
            }
        }
    }
}