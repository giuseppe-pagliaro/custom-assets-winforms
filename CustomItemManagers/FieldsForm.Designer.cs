namespace CustomItemManagers
{
    partial class FieldsForm
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
            txtID = new Label();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.AutoSize = true;
            txtID.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtID.Location = new Point(40, 40);
            txtID.Name = "txtID";
            txtID.Size = new Size(0, 51);
            txtID.TabIndex = 0;
            // 
            // FieldsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 37);
            Controls.Add(txtID);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FieldsForm";
            Text = "Object #99999";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label txtID;
    }
}