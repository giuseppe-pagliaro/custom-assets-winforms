namespace HermoItemManagers
{
    partial class ItemViewer
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
            buttonDelete = new Button();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDelete.Location = new Point(12, 12);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(752, 65);
            buttonDelete.TabIndex = 0;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 8.142858F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(770, 50);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 28);
            noFocusObj.TabIndex = 1;
            // 
            // ItemViewer
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 89);
            Controls.Add(noFocusObj);
            Controls.Add(buttonDelete);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ItemViewer";
            Text = "ItemViewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button buttonDelete;
        protected Label noFocusObj;
    }
}