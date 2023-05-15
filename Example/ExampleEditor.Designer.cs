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
            Commons.Style style1 = new Commons.Style();
            CustomLists.ItemDatas itemDatas1 = new CustomLists.ItemDatas();
            fieldExample = new CustomItemManagers.PathFieldEditor();
            SuspendLayout();
            // 
            // fieldExample
            // 
            fieldExample.Active = false;
            fieldExample.BackColor = SystemColors.ControlDark;
            fieldExample.BrowseButtonText = "Browse";
            fieldExample.FieldName = "Name";
            fieldExample.FileDialogMessage = "Select Folder";
            fieldExample.Location = new Point(12, 12);
            fieldExample.Mandatory = true;
            fieldExample.Name = "fieldExample";
            fieldExample.OpenDialogType = CustomItemManagers.OpenDialogType.Folder;
            fieldExample.Separator = ":";
            fieldExample.Size = new Size(628, 54);
            fieldExample.Style = style1;
            fieldExample.TabIndex = 1;
            fieldExample.Togglable = true;
            // 
            // ExampleEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 78);
            Controls.Add(fieldExample);
            itemDatas1.Id = 0;
            ItemDatas = itemDatas1;
            Name = "ExampleEditor";
            Text = "Item Datas #0";
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(fieldExample, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItemManagers.PathFieldEditor fieldExample;
    }
}
