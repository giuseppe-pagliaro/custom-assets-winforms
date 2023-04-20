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
            clickProtector = new Panel();
            controlPanel = new Panel();
            noFocusObj = new Label();
            panelButtons = new Panel();
            txtBoxCurrentPage = new TextBox();
            buttonEnd = new Button();
            buttonNext = new Button();
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
            txtPlaceHolder.Click += CustomList_Click;
            // 
            // itemsPanel
            // 
            itemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemsPanel.BackColor = SystemColors.ControlDark;
            itemsPanel.Controls.Add(clickProtector);
            itemsPanel.Controls.Add(txtPlaceHolder);
            itemsPanel.Location = new Point(0, 0);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(550, 434);
            itemsPanel.TabIndex = 1;
            itemsPanel.SizeChanged += itemsPanel_SizeChanged;
            itemsPanel.Click += CustomList_Click;
            // 
            // clickProtector
            // 
            clickProtector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clickProtector.BackColor = Color.Transparent;
            clickProtector.Location = new Point(0, 0);
            clickProtector.Name = "clickProtector";
            clickProtector.Size = new Size(550, 0);
            clickProtector.TabIndex = 1;
            clickProtector.Click += CustomList_Click;
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
            controlPanel.Click += CustomList_Click;
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
            panelButtons.Controls.Add(buttonEnd);
            panelButtons.Controls.Add(buttonNext);
            panelButtons.Controls.Add(buttonBack);
            panelButtons.Controls.Add(buttonStart);
            panelButtons.Dock = DockStyle.Right;
            panelButtons.Location = new Point(248, 0);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(302, 50);
            panelButtons.TabIndex = 1;
            panelButtons.Click += CustomList_Click;
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
            txtBoxCurrentPage.Enter += txtBoxCurrentPage_Enter;
            txtBoxCurrentPage.KeyPress += txtBoxCurrentPage_KeyPress;
            txtBoxCurrentPage.Leave += txtBoxCurrentPage_Leave;
            // 
            // buttonEnd
            // 
            buttonEnd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonEnd.BackColor = SystemColors.ControlDark;
            buttonEnd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEnd.Location = new Point(251, 11);
            buttonEnd.Name = "buttonEnd";
            buttonEnd.Size = new Size(48, 29);
            buttonEnd.TabIndex = 3;
            buttonEnd.Text = ">>";
            buttonEnd.UseVisualStyleBackColor = false;
            buttonEnd.Click += buttonEnd_Click;
            // 
            // buttonNext
            // 
            buttonNext.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonNext.BackColor = SystemColors.ControlDark;
            buttonNext.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNext.Location = new Point(197, 11);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(48, 29);
            buttonNext.TabIndex = 2;
            buttonNext.Text = ">";
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
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
            txtPageCount.Click += CustomList_Click;
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
            Click += CustomList_Click;
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
        private Button buttonEnd;
        private Button buttonNext;
        private TextBox txtBoxCurrentPage;
        private Label noFocusObj;
        private Panel clickProtector;
    }
}
