using CustomAssetsCommons;

namespace Example
{
    partial class ExampleEditor
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            Style style1 = new();
            Style style2 = new();
            Style style3 = new();
            Style style4 = new();
            Style style5 = new();
            Style style6 = new();
            ItemDatas itemDatas1 = new();
            fieldPath = new CustomItemManagers.PathFieldEditor();
            fieldNormal = new CustomItemManagers.TextFieldEditor();
            noFocusObj = new Label();
            txtTitle = new Label();
            buttonUpdate = new Button();
            fieldDecimalNumber = new CustomItemManagers.TextFieldEditor();
            fieldNumber = new CustomItemManagers.TextFieldEditor();
            fieldDate = new CustomItemManagers.TextFieldEditor();
            fieldPhone = new CustomItemManagers.PhoneFieldEditor();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(60, 60);
            txtID.Margin = new Padding(4, 0, 4, 0);
            // 
            // fieldPath
            // 
            fieldPath.Active = false;
            fieldPath.BackColor = SystemColors.ControlDark;
            fieldPath.BrowseButtonText = "Browse";
            fieldPath.FieldName = "Path";
            fieldPath.FileDialogMessage = "Select Folder";
            fieldPath.Location = new Point(18, 96);
            fieldPath.Mandatory = true;
            fieldPath.Margin = new Padding(9);
            fieldPath.Name = "fieldPath";
            fieldPath.OpenDialogType = CustomItemManagers.OpenDialogType.Folder;
            fieldPath.PlaceholderText = "";
            fieldPath.Separator = ":";
            fieldPath.Size = new Size(962, 81);
            fieldPath.Style = style1;
            fieldPath.TabIndex = 1;
            fieldPath.Togglable = true;
            // 
            // fieldNormal
            // 
            fieldNormal.Active = true;
            fieldNormal.BackColor = SystemColors.ControlDark;
            fieldNormal.CharLimit = 50;
            fieldNormal.FieldName = "Normal Text";
            fieldNormal.FilterType = CustomItemManagers.FilterType.None;
            fieldNormal.Location = new Point(18, 186);
            fieldNormal.Mandatory = false;
            fieldNormal.Margin = new Padding(9);
            fieldNormal.Name = "fieldNormal";
            fieldNormal.PlaceholderText = "";
            fieldNormal.Separator = ":";
            fieldNormal.Size = new Size(962, 81);
            fieldNormal.Style = style2;
            fieldNormal.TabIndex = 2;
            fieldNormal.Togglable = true;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(969, 81);
            noFocusObj.Margin = new Padding(4, 0, 4, 0);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 25);
            noFocusObj.TabIndex = 3;
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtTitle.Location = new Point(18, 27);
            txtTitle.Margin = new Padding(4, 0, 4, 0);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(662, 45);
            txtTitle.TabIndex = 4;
            txtTitle.Text = "Just a display (does not update the item).";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUpdate.Location = new Point(18, 639);
            buttonUpdate.Margin = new Padding(4);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(962, 76);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // fieldDecimalNumber
            // 
            fieldDecimalNumber.Active = true;
            fieldDecimalNumber.BackColor = SystemColors.ControlDark;
            fieldDecimalNumber.CharLimit = 50;
            fieldDecimalNumber.FieldName = "Numbers With Decimal";
            fieldDecimalNumber.FilterType = CustomItemManagers.FilterType.DecimalNumbersOnly;
            fieldDecimalNumber.Location = new Point(18, 276);
            fieldDecimalNumber.Mandatory = false;
            fieldDecimalNumber.Margin = new Padding(9);
            fieldDecimalNumber.Name = "fieldDecimalNumber";
            fieldDecimalNumber.PlaceholderText = "";
            fieldDecimalNumber.Separator = ":";
            fieldDecimalNumber.Size = new Size(962, 81);
            fieldDecimalNumber.Style = style3;
            fieldDecimalNumber.TabIndex = 6;
            fieldDecimalNumber.Togglable = true;
            // 
            // fieldNumber
            // 
            fieldNumber.Active = true;
            fieldNumber.BackColor = SystemColors.ControlDark;
            fieldNumber.CharLimit = 50;
            fieldNumber.FieldName = "Numbers";
            fieldNumber.FilterType = CustomItemManagers.FilterType.NumbersOnly;
            fieldNumber.Location = new Point(18, 366);
            fieldNumber.Mandatory = false;
            fieldNumber.Margin = new Padding(9);
            fieldNumber.Name = "fieldNumber";
            fieldNumber.PlaceholderText = "";
            fieldNumber.Separator = ":";
            fieldNumber.Size = new Size(962, 81);
            fieldNumber.Style = style4;
            fieldNumber.TabIndex = 7;
            fieldNumber.Togglable = true;
            // 
            // fieldDate
            // 
            fieldDate.Active = true;
            fieldDate.BackColor = SystemColors.ControlDark;
            fieldDate.CharLimit = 50;
            fieldDate.FieldName = "Date";
            fieldDate.FilterType = CustomItemManagers.FilterType.Date;
            fieldDate.Location = new Point(18, 456);
            fieldDate.Mandatory = false;
            fieldDate.Margin = new Padding(9);
            fieldDate.Name = "fieldDate";
            fieldDate.PlaceholderText = "";
            fieldDate.Separator = ":";
            fieldDate.Size = new Size(962, 81);
            fieldDate.Style = style5;
            fieldDate.TabIndex = 8;
            fieldDate.Togglable = true;
            // 
            // fieldPhone
            // 
            fieldPhone.Active = true;
            fieldPhone.BackColor = SystemColors.ControlDark;
            fieldPhone.DefaultIntPrefixIndex = (ushort)104;
            fieldPhone.FieldName = "Phone";
            fieldPhone.Location = new Point(18, 550);
            fieldPhone.Mandatory = false;
            fieldPhone.Margin = new Padding(4, 4, 4, 4);
            fieldPhone.Name = "fieldPhone";
            fieldPhone.PlaceholderText = "";
            fieldPhone.Separator = ":";
            fieldPhone.Size = new Size(962, 81);
            fieldPhone.Style = style6;
            fieldPhone.TabIndex = 9;
            fieldPhone.Togglable = true;
            // 
            // ExampleEditor
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 728);
            Controls.Add(fieldPhone);
            Controls.Add(fieldDate);
            Controls.Add(fieldNumber);
            Controls.Add(fieldDecimalNumber);
            Controls.Add(buttonUpdate);
            Controls.Add(txtTitle);
            Controls.Add(noFocusObj);
            Controls.Add(fieldNormal);
            Controls.Add(fieldPath);
            itemDatas1.Id = 0;
            ItemDatas = itemDatas1;
            Margin = new Padding(4);
            Name = "ExampleEditor";
            Text = "Item Datas #0";
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(fieldPath, 0);
            Controls.SetChildIndex(fieldNormal, 0);
            Controls.SetChildIndex(noFocusObj, 0);
            Controls.SetChildIndex(txtTitle, 0);
            Controls.SetChildIndex(buttonUpdate, 0);
            Controls.SetChildIndex(fieldDecimalNumber, 0);
            Controls.SetChildIndex(fieldNumber, 0);
            Controls.SetChildIndex(fieldDate, 0);
            Controls.SetChildIndex(fieldPhone, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItemManagers.PathFieldEditor fieldPath;
        private CustomItemManagers.TextFieldEditor fieldNormal;
        private Label noFocusObj;
        private Label txtTitle;
        private Button buttonUpdate;
        private CustomItemManagers.TextFieldEditor fieldDecimalNumber;
        private CustomItemManagers.TextFieldEditor fieldNumber;
        private CustomItemManagers.TextFieldEditor fieldDate;
        private CustomItemManagers.PhoneFieldEditor fieldPhone;
    }
}
