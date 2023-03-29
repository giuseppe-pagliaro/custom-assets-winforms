namespace CustomLists
{
    partial class CustomList
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
            txtPlaceHolder = new Label();
            itemsPanel = new Panel();
            controlPanel = new Panel();
            noFocusObj = new Label();
            panelButtons = new Panel();
            txtBoxCurrentPage = new TextBox();
            buttonFine = new Button();
            buttonAvanti = new Button();
            buttonBack = new Button();
            buttonStart = new Button();
            txtPageCount = new Label();
            itemsPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // txtPlaceHolder
            // 
            txtPlaceHolder.Dock = DockStyle.Top;
            txtPlaceHolder.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPlaceHolder.Location = new Point(0, 0);
            txtPlaceHolder.Name = "txtPlaceHolder";
            txtPlaceHolder.Size = new Size(550, 125);
            txtPlaceHolder.TabIndex = 0;
            txtPlaceHolder.Text = "No Data";
            txtPlaceHolder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // itemsPanel
            // 
            itemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemsPanel.BackColor = SystemColors.ControlDark;
            itemsPanel.Controls.Add(txtPlaceHolder);
            itemsPanel.Location = new Point(0, 0);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(550, 434);
            itemsPanel.TabIndex = 1;
            itemsPanel.SizeChanged += itemsPanel_SizeChanged;
            // 
            // controlPanel
            // 
            controlPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            controlPanel.Controls.Add(noFocusObj);
            controlPanel.Controls.Add(panelButtons);
            controlPanel.Controls.Add(txtPageCount);
            controlPanel.Location = new Point(0, 440);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(550, 50);
            controlPanel.TabIndex = 2;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.Location = new Point(242, 16);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 20);
            noFocusObj.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(txtBoxCurrentPage);
            panelButtons.Controls.Add(buttonFine);
            panelButtons.Controls.Add(buttonAvanti);
            panelButtons.Controls.Add(buttonBack);
            panelButtons.Controls.Add(buttonStart);
            panelButtons.Dock = DockStyle.Right;
            panelButtons.Location = new Point(248, 0);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(302, 50);
            panelButtons.TabIndex = 1;
            // 
            // txtBoxCurrentPage
            // 
            txtBoxCurrentPage.BackColor = SystemColors.ControlDark;
            txtBoxCurrentPage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxCurrentPage.Location = new Point(111, 10);
            txtBoxCurrentPage.Name = "txtBoxCurrentPage";
            txtBoxCurrentPage.Size = new Size(80, 30);
            txtBoxCurrentPage.TabIndex = 4;
            txtBoxCurrentPage.Text = "1";
            txtBoxCurrentPage.TextAlign = HorizontalAlignment.Center;
            txtBoxCurrentPage.TextChanged += txtBoxCurrentPage_TextChanged;
            txtBoxCurrentPage.KeyPress += txtBoxCurrentPage_KeyPress;
            // 
            // buttonFine
            // 
            buttonFine.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonFine.BackColor = SystemColors.ControlDark;
            buttonFine.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFine.Location = new Point(251, 11);
            buttonFine.Name = "buttonFine";
            buttonFine.Size = new Size(48, 29);
            buttonFine.TabIndex = 3;
            buttonFine.Text = ">>";
            buttonFine.UseVisualStyleBackColor = false;
            buttonFine.Click += buttonFine_Click;
            // 
            // buttonAvanti
            // 
            buttonAvanti.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonAvanti.BackColor = SystemColors.ControlDark;
            buttonAvanti.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAvanti.Location = new Point(197, 11);
            buttonAvanti.Name = "buttonAvanti";
            buttonAvanti.Size = new Size(48, 29);
            buttonAvanti.TabIndex = 2;
            buttonAvanti.Text = ">";
            buttonAvanti.UseVisualStyleBackColor = false;
            buttonAvanti.Click += buttonAvanti_Click;
            // 
            // buttonBack
            // 
            buttonBack.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonBack.BackColor = SystemColors.ControlDark;
            buttonBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBack.Location = new Point(57, 11);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(48, 29);
            buttonBack.TabIndex = 1;
            buttonBack.Text = "<";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonStart.BackColor = SystemColors.ControlDark;
            buttonStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonStart.Location = new Point(3, 11);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(48, 29);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "<<";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // txtPageCount
            // 
            txtPageCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtPageCount.AutoSize = true;
            txtPageCount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtPageCount.Location = new Point(12, 14);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.Size = new Size(67, 23);
            txtPageCount.TabIndex = 0;
            txtPageCount.Text = "x Pages";
            // 
            // CustomList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(controlPanel);
            Controls.Add(itemsPanel);
            Name = "CustomList";
            Size = new Size(550, 490);
            Load += CustomList_Load;
            itemsPanel.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label txtPlaceHolder;
        private Panel itemsPanel;
        private Panel controlPanel;
        private Label txtPageCount;
        private Panel panelButtons;
        private Button buttonStart;
        private Button buttonBack;
        private Button buttonFine;
        private Button buttonAvanti;
        private TextBox txtBoxCurrentPage;
        private Label noFocusObj;
    }
}
