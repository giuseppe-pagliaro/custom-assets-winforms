namespace HermoItemManagers
{
    partial class ItemCreatorOrEditor
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
            buttonEditOrCreate = new Button();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // buttonEditOrCreate
            // 
            buttonEditOrCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEditOrCreate.Location = new Point(12, 12);
            buttonEditOrCreate.Name = "buttonEditOrCreate";
            buttonEditOrCreate.Size = new Size(752, 65);
            buttonEditOrCreate.TabIndex = 1;
            buttonEditOrCreate.Text = "Edit";
            buttonEditOrCreate.UseVisualStyleBackColor = true;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 8.142858F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(770, 47);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 28);
            noFocusObj.TabIndex = 0;
            // 
            // ItemCreatorOrEditor
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 89);
            Controls.Add(noFocusObj);
            Controls.Add(buttonEditOrCreate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ItemCreatorOrEditor";
            Text = "ItemEditor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button buttonEditOrCreate;
        private Label noFocusObj;
    }
}