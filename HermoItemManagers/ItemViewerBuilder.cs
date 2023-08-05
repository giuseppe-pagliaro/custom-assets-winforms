using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;
using HermoRestClient;
using System.Reflection;

namespace HermoItemManagers
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

        private String deleteWarningTitleTxt;
        private String deletingMsg;
        private String deleteWarningMsgTxt;
        private Action<int>? deleteMethod;

        public String DeleteWarningTitleTxt
        {
            get { return deleteWarningTitleTxt; }
            set { deleteWarningTitleTxt = value; }
        }

        public String DeletingMsg
        {
            get { return deletingMsg; }
            set { deletingMsg = value; }
        }

        public String DeleteWarningMsgTxt
        {
            get { return deleteWarningMsgTxt; }
            set { deleteWarningMsgTxt = value; }
        }

        public Action<int>? DeleteMethod
        {
            get { return deleteMethod; }
            set { deleteMethod = value; }
        }

        public override void Populate(FieldsForm fieldsForm)
        {
            ItemDatas item = fieldsForm.Item;
            List<Field> fields = new();

            fieldsForm.Text = $"{item.ClassNameToString()} #{item.Id}";

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                if (Attribute.IsDefined(property, typeof(IsCopyable)))
                {
                    fields.Add(new CopyableTextField(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg));
                }
                else
                {
                    fields.Add(new TextField(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg));
                }
                fields[fields.Count - 1].Width = fieldsForm.ActionBtnWidth;
                fieldsForm.Height += fieldsForm.ActionBtnLocation.Y * fields.Count + fields[fields.Count - 1].Height * fields.Count;
            }

            for (int i = 0; i < fields.Count; i++)
            {
                fields[i].Location = new(fieldsForm.ActionBtnLocation.X, fieldsForm.ActionBtnLocation.Y * (i + 1) + fields[i].Height * i);
                fieldsForm.Controls.Add(fields[i]);
            }
            fieldsForm.ActionBtnLocation = new(fieldsForm.ActionBtnLocation.X, fields[fields.Count - 1].Location.Y + fields[fields.Count - 1].Height + fieldsForm.ActionBtnLocation.Y);
            // Update button text?
        }

        public override void ApplyStyle(FieldsForm fieldsForm)
        {
            Style.Apply(fieldsForm, fieldsForm.Style, BgType.Primary);

            foreach (Control control in fieldsForm.Controls)
            {
                if (control.GetType().IsSubclassOf(typeof(Field)))
                {
                    ((Field)control).Style = fieldsForm.Style;
                }
            }

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