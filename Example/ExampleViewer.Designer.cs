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
            CustomLists.ItemDatas itemDatas1 = new CustomLists.ItemDatas();
            txtValue = new Label();
            SuspendLayout();
            // 
            // txtValue
            // 
            txtValue.AutoSize = true;
            txtValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.Location = new Point(40, 40);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(107, 28);
            txtValue.TabIndex = 1;
            txtValue.Text = "Value: Ciao";
            // 
            // ExampleViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 127);
            Controls.Add(txtValue);
            itemDatas1.Id = 0;
            ItemDatas = itemDatas1;
            Name = "ExampleViewer";
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(txtValue, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtValue;
    }
}