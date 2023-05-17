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
            Commons.Style style6 = new Commons.Style();
            Commons.Style style7 = new Commons.Style();
            Commons.Style style8 = new Commons.Style();
            Commons.Style style9 = new Commons.Style();
            Commons.Style style10 = new Commons.Style();
            CustomLists.ItemDatas itemDatas2 = new CustomLists.ItemDatas();
            fieldPath = new CustomItemManagers.PathFieldEditor();
            fieldNormal = new CustomItemManagers.TextFieldEditor();
            noFocusObj = new Label();
            txtTitle = new Label();
            buttonUpdate = new Button();
            fieldDecimalNumber = new CustomItemManagers.TextFieldEditor();
            fieldNumber = new CustomItemManagers.TextFieldEditor();
            fieldDate = new CustomItemManagers.TextFieldEditor();
            SuspendLayout();
            // 
            // fieldPath
            // 
            fieldPath.Active = false;
            fieldPath.BackColor = SystemColors.ControlDark;
            fieldPath.BrowseButtonText = "Browse";
            fieldPath.FieldName = "Path";
            fieldPath.FileDialogMessage = "Select Folder";
            fieldPath.Location = new Point(12, 64);
            fieldPath.Mandatory = true;
            fieldPath.Name = "fieldPath";
            fieldPath.OpenDialogType = CustomItemManagers.OpenDialogType.Folder;
            fieldPath.Separator = ":";
            fieldPath.Size = new Size(641, 54);
            fieldPath.Style = style6;
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
            fieldNormal.Location = new Point(12, 124);
            fieldNormal.Mandatory = false;
            fieldNormal.Name = "fieldNormal";
            fieldNormal.Separator = ":";
            fieldNormal.Size = new Size(641, 54);
            fieldNormal.Style = style7;
            fieldNormal.TabIndex = 2;
            fieldNormal.Togglable = true;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(646, 54);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 17);
            noFocusObj.TabIndex = 3;
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtTitle.Location = new Point(12, 18);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(455, 31);
            txtTitle.TabIndex = 4;
            txtTitle.Text = "Just a display (does not update the item).";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUpdate.Location = new Point(12, 364);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(641, 51);
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
            fieldDecimalNumber.Location = new Point(12, 184);
            fieldDecimalNumber.Mandatory = false;
            fieldDecimalNumber.Name = "fieldDecimalNumber";
            fieldDecimalNumber.Separator = ":";
            fieldDecimalNumber.Size = new Size(641, 54);
            fieldDecimalNumber.Style = style8;
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
            fieldNumber.Location = new Point(12, 244);
            fieldNumber.Mandatory = false;
            fieldNumber.Name = "fieldNumber";
            fieldNumber.Separator = ":";
            fieldNumber.Size = new Size(641, 54);
            fieldNumber.Style = style9;
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
            fieldDate.Location = new Point(12, 304);
            fieldDate.Mandatory = false;
            fieldDate.Name = "fieldDate";
            fieldDate.Separator = ":";
            fieldDate.Size = new Size(641, 54);
            fieldDate.Style = style10;
            fieldDate.TabIndex = 8;
            fieldDate.Togglable = true;
            // 
            // ExampleEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 427);
            Controls.Add(fieldDate);
            Controls.Add(fieldNumber);
            Controls.Add(fieldDecimalNumber);
            Controls.Add(buttonUpdate);
            Controls.Add(txtTitle);
            Controls.Add(noFocusObj);
            Controls.Add(fieldNormal);
            Controls.Add(fieldPath);
            itemDatas2.Id = 0;
            ItemDatas = itemDatas2;
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
    }
}
