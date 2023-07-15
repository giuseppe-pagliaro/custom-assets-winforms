namespace HermoRestClient
{
    partial class WaitForm
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
            txtLoading = new Label();
            SuspendLayout();
            // 
            // txtLoading
            // 
            txtLoading.AutoSize = true;
            txtLoading.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtLoading.Location = new Point(45, 37);
            txtLoading.Name = "txtLoading";
            txtLoading.Size = new Size(119, 31);
            txtLoading.TabIndex = 0;
            txtLoading.Text = "Loading...";
            // 
            // WaitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 105);
            Controls.Add(txtLoading);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitForm";
            Text = "WaitForm";
            FormClosing += WaitForm_FormClosing;
            Load += WaitForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtLoading;
    }
}