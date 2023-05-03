namespace Example
{
    partial class ExampleViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Commons.Style style1 = new Commons.Style();
            CustomLists.ItemDatas itemDatas1 = new CustomLists.ItemDatas();
            fieldValue = new CustomItemManagers.CopiableTextField();
            SuspendLayout();
            // 
            // fieldValue
            // 
            fieldValue.BackColor = SystemColors.ControlDark;
            fieldValue.Dock = DockStyle.Fill;
            fieldValue.FieldName = "Value";
            fieldValue.Location = new Point(0, 0);
            fieldValue.Name = "fieldValue";
            fieldValue.Separator = ":";
            fieldValue.Size = new Size(359, 52);
            fieldValue.Style = style1;
            fieldValue.TabIndex = 2;
            fieldValue.Value = "(empty)";
            // 
            // ExampleViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 52);
            Controls.Add(fieldValue);
            itemDatas1.Id = 0;
            ItemDatas = itemDatas1;
            Name = "ExampleViewer";
            Text = "Item Datas #0";
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(fieldValue, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomItemManagers.CopiableTextField fieldValue;
    }
}