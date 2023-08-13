using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;
using HermoRestClient;
using System.Reflection;

namespace HermoItemManagers.FieldsFormBuilders
{
    public class ItemEditorBuilder : FieldsFormBuilder<ItemEditorBuilder>
    {
        private ItemEditorBuilder()
        {
            ActionBtnText = "Edit";
            editWarningTitleTxt = "Editing Item";
            editingMsg = editWarningTitleTxt;
            editWarningMsgTxt = "Are you sure you want to edit this element? The process is irreversible.";
        }

        private string editWarningTitleTxt;
        private string editingMsg;
        private string editWarningMsgTxt;
        private Func<ItemDatas, ItemDatas, ItemDatas>? editMethod;

        #region Properties

        public string EditWarningTitleTxt
        {
            get { return editWarningTitleTxt; }
            set { editWarningTitleTxt = value; }
        }

        public string EditingMsg
        {
            get { return editingMsg; }
            set { editingMsg = value; }
        }

        public string EditWarningMsgTxt
        {
            get { return editWarningMsgTxt; }
            set { editWarningMsgTxt = value; }
        }

        public Func<ItemDatas, ItemDatas, ItemDatas>? EditMethod
        {
            get { return editMethod; }
            set { editMethod = value; }
        }

        #endregion

        public override void Populate(FieldsForm fieldsForm)
        {
            ItemDatas item = fieldsForm.Item;

            fieldsForm.Text = $"{item.ClassNameToString()} #{item.Id}";

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                if (property.PropertyType.Equals(typeof(HermoPhoneNumber)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(HermoDate)))
                {
                    fieldsForm.AddField(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg, fieldsForm.Style)
                    { Togglable = true, FilterType = FilterType.Date, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(int)))
                {
                    fieldsForm.AddField(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg, fieldsForm.Style)
                    { Togglable = true, FilterType = FilterType.NumbersOnly, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(float)) || property.PropertyType.Equals(typeof(double)))
                {
                    fieldsForm.AddField(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg, fieldsForm.Style)
                    { Togglable = true, FilterType = FilterType.DecimalNumbersOnly, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(string)))
                {
                    fieldsForm.AddField(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? PropIsNullMsg, fieldsForm.Style)
                    { Togglable = true, FilterType = FilterType.None, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else
                {
                    // TODO generate selector.
                }

                fieldsForm.Fields[fieldsForm.Fields.Count - 1].Width = fieldsForm.ActionBtnWidth;
                fieldsForm.Height += fieldsForm.ActionBtnLocation.Y * (fieldsForm.Fields.Count) + fieldsForm.Fields[fieldsForm.Fields.Count - 1].Height * (fieldsForm.Fields.Count);
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
            if (MessageBox.Show(editWarningMsgTxt, editWarningTitleTxt, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            using (WaitForm waitForm = new(() => ExecItemEdit(fieldsForm), fieldsForm.Style, editingMsg))
            {
                waitForm.ShowDialog();
            }

            fieldsForm.Close();
        }

        private void ExecItemEdit(FieldsForm fieldsForm)
        {
            if (editMethod is null) return;

            ItemDatas newInstance = fieldsForm.Item;
            int i = 0;
            foreach (PropertyInfo property in fieldsForm.Item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                switch (fieldsForm.Fields[i].GetType())
                {
                    // TODO other cases

                    default:
                        TextFieldEditor txtFieldEditor = (TextFieldEditor)fieldsForm.Fields[i];
                        if (!txtFieldEditor.Active || txtFieldEditor.Value != "")
                        {
                            property.SetValue(newInstance, txtFieldEditor.Value);
                        }
                        break;
                }
                if (property.PropertyType.Equals(typeof(HermoPhoneNumber)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(HermoDate)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(int)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(float)) || property.PropertyType.Equals(typeof(double)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(string)))
                {
                    TextFieldEditor txtFieldEditor = (TextFieldEditor)fieldsForm.Fields[i];

                    if (!txtFieldEditor.Active || txtFieldEditor.Value != "")
                    {
                        property.SetValue(newInstance, txtFieldEditor.Value);
                    }
                }
                else
                {
                    // TODO get value from selector.
                }

                i++;
            }

            ItemsManager.Instance.Edit(editMethod(fieldsForm.Item, newInstance));
        }
    }
}