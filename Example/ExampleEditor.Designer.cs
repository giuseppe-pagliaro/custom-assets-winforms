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
            Commons.Style style3 = new Commons.Style();
            Commons.Style style4 = new Commons.Style();
            CustomLists.ItemDatas itemDatas2 = new CustomLists.ItemDatas();
            fieldExample1 = new CustomItemManagers.PathFieldEditor();
            fieldExample2 = new CustomItemManagers.TextFieldEditor();
            noFocusObj = new Label();
            txtTitle = new Label();
            buttonUpdate = new Button();
            SuspendLayout();
            // 
            // fieldExample1
            // 
            fieldExample1.Active = false;
            fieldExample1.BackColor = SystemColors.ControlDark;
            fieldExample1.BrowseButtonText = "Browse";
            fieldExample1.FieldName = "Example 1";
            fieldExample1.FileDialogMessage = "Select Folder";
            fieldExample1.Location = new Point(12, 64);
            fieldExample1.Mandatory = true;
            fieldExample1.Name = "fieldExample1";
            fieldExample1.OpenDialogType = CustomItemManagers.OpenDialogType.Folder;
            fieldExample1.Separator = ":";
            fieldExample1.Size = new Size(628, 54);
            fieldExample1.Style = style3;
            fieldExample1.TabIndex = 1;
            fieldExample1.Togglable = true;
            // 
            // fieldExample2
            // 
            fieldExample2.Active = true;
            fieldExample2.BackColor = SystemColors.ControlDark;
            fieldExample2.FieldName = "Example 2";
            fieldExample2.Location = new Point(12, 124);
            fieldExample2.Mandatory = false;
            fieldExample2.Name = "fieldExample2";
            fieldExample2.Separator = ":";
            fieldExample2.Size = new Size(628, 54);
            fieldExample2.Style = style4;
            fieldExample2.TabIndex = 2;
            fieldExample2.Togglable = true;
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
            buttonUpdate.Location = new Point(12, 184);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(628, 44);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // ExampleEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 240);
            Controls.Add(buttonUpdate);
            Controls.Add(txtTitle);
            Controls.Add(noFocusObj);
            Controls.Add(fieldExample2);
            Controls.Add(fieldExample1);
            itemDatas2.Id = 0;
            ItemDatas = itemDatas2;
            Name = "ExampleEditor";
            Text = "Item Datas #0";
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(fieldExample1, 0);
            Controls.SetChildIndex(fieldExample2, 0);
            Controls.SetChildIndex(noFocusObj, 0);
            Controls.SetChildIndex(txtTitle, 0);
            Controls.SetChildIndex(buttonUpdate, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItemManagers.PathFieldEditor fieldExample1;
        private CustomItemManagers.TextFieldEditor fieldExample2;
        private Label noFocusObj;
        private Label txtTitle;
        private Button buttonUpdate;
    }
}
