using HermoCommons;
using HermoItemManagers.Managers;
using System.Reflection;

namespace HermoItemManagers.ListItemBuilders
{
    public class DefaultListItemBuilder : ListItemBuilder<DefaultListItemBuilder>
    {
        private DefaultListItemBuilder()
        {
            toStringLabelFontStyle = FontStyle.Regular;
        }

        private FontStyle toStringLabelFontStyle;

        public FontStyle ToStringLabelFontStyle
        {
            get => toStringLabelFontStyle;
            set => toStringLabelFontStyle = value;
        }

        public override void Populate(ListItem listItem)
        {
            Label toStringLabel = new()
            {
                Name = "txtToString",
                AutoSize = false,
                Location = new(listItem.EditButtonLocation.Y, listItem.EditButtonLocation.Y),
                Size = new(listItem.Width - 2 * listItem.EditButtonLocation.Y - listItem.EditButtonWidth, listItem.Height - 2 * listItem.EditButtonLocation.Y),
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
                Font = new("Segoe UI", (float)13.8, toStringLabelFontStyle),
                Text = listItem.Item.ToString()
            };

            listItem.Controls.Add(toStringLabel);
        }

        public override void ApplyStyle(ListItem listItem)
        {
            Style.Apply(listItem, listItem.Style, BgType.Secondary);
            listItem.ApplyEditButtonStyle();

            foreach (Control control in listItem.Controls)
            {
                if (control.Name.Equals("txtToString"))
                {
                    Style.Apply((Label)control, listItem.Style, toStringLabelFontStyle);
                    break;
                }
            }
        }

        public override void ListItemClickedAction(ListItem listItem)
        {
            if (ViewerBuilderType is null) return;

            FieldsFormManager Instance = (FieldsFormManager)(typeof(FieldsFormManager).GetProperty("Instance")?.GetValue(null) ?? throw new InstanceNotFoundException());
            MethodInfo ReqEntityMethod = typeof(FieldsFormManager).GetMethod("RequestEntity") ?? throw new InstanceNotFoundException();

            ReqEntityMethod.MakeGenericMethod(ViewerBuilderType).Invoke(Instance, new object[] { listItem.Item, listItem.Style });
        }

        public override void ButtonEditClickedAction(ListItem listItem)
        {
            if (EditorBuilderType is null) return;

            FieldsFormManager Instance = (FieldsFormManager)(typeof(FieldsFormManager).GetProperty("Instance")?.GetValue(null) ?? throw new InstanceNotFoundException());
            MethodInfo ReqEntityMethod = typeof(FieldsFormManager).GetMethod("RequestEntity") ?? throw new InstanceNotFoundException();

            ReqEntityMethod.MakeGenericMethod(EditorBuilderType).Invoke(Instance, new object[] { listItem.Item, listItem.Style });
        }
    }
}