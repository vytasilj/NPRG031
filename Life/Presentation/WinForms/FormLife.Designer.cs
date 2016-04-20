namespace kiswa.Games.Life.WinFormsApp
{
    partial class FormLife
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLife));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbRules = new System.Windows.Forms.ComboBox();
            this.btnStep = new System.Windows.Forms.Button();
            this.pnlScroller = new System.Windows.Forms.Panel();
            this.lifeGrid = new kiswa.Games.Life.CustomControls.LifeGrid();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblZoomCount = new System.Windows.Forms.Label();
            this.lblStepNumber = new System.Windows.Forms.Label();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiFileLoadPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiFileSavePattern = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiOptionsShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiOptionsLiveCellColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiOptionsDeadCellColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiHelpAboutPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuiHelpAboutGoL = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRules = new System.Windows.Forms.Label();
            this.pnlScroller.SuspendLayout();
            this.mnuMainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(2, 530);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(83, 530);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnRandomize
            // 
            this.btnRandomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRandomize.Location = new System.Drawing.Point(164, 559);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 6;
            this.btnRandomize.Text = "R&andomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(83, 559);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(2, 559);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // cmbRules
            // 
            this.cmbRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRules.DropDownWidth = 200;
            this.cmbRules.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRules.FormattingEnabled = true;
            this.cmbRules.Location = new System.Drawing.Point(302, 2);
            this.cmbRules.MaxDropDownItems = 10;
            this.cmbRules.Name = "cmbRules";
            this.cmbRules.Size = new System.Drawing.Size(200, 21);
            this.cmbRules.TabIndex = 3;
            // 
            // btnStep
            // 
            this.btnStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStep.Location = new System.Drawing.Point(164, 530);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 23);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "Ste&p";
            this.btnStep.UseVisualStyleBackColor = true;
            // 
            // pnlScroller
            // 
            this.pnlScroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScroller.AutoScroll = true;
            this.pnlScroller.CausesValidation = false;
            this.pnlScroller.Controls.Add(this.lifeGrid);
            this.pnlScroller.Location = new System.Drawing.Point(2, 24);
            this.pnlScroller.Name = "pnlScroller";
            this.pnlScroller.Size = new System.Drawing.Size(500, 500);
            this.pnlScroller.TabIndex = 7;
            // 
            // lifeGrid
            // 
            this.lifeGrid.CellColorAlive = System.Drawing.Color.Yellow;
            this.lifeGrid.CellColorDead = System.Drawing.Color.Gray;
            this.lifeGrid.LinesSize = 1F;
            this.lifeGrid.LinesVisible = false;
            this.lifeGrid.Location = new System.Drawing.Point(0, 0);
            this.lifeGrid.Name = "lifeGrid";
            this.lifeGrid.Size = new System.Drawing.Size(500, 500);
            this.lifeGrid.TabIndex = 15;
            this.lifeGrid.TabStop = false;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZoomOut.Location = new System.Drawing.Point(455, 559);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 23);
            this.btnZoomOut.TabIndex = 8;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZoomIn.Location = new System.Drawing.Point(426, 559);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 23);
            this.btnZoomIn.TabIndex = 9;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(412, 535);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(71, 13);
            this.lblZoom.TabIndex = 10;
            this.lblZoom.Text = "Zoom In/Out:";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblZoomCount
            // 
            this.lblZoomCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZoomCount.AutoSize = true;
            this.lblZoomCount.Location = new System.Drawing.Point(484, 564);
            this.lblZoomCount.Name = "lblZoomCount";
            this.lblZoomCount.Size = new System.Drawing.Size(13, 13);
            this.lblZoomCount.TabIndex = 11;
            this.lblZoomCount.Text = "1";
            // 
            // lblStepNumber
            // 
            this.lblStepNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStepNumber.AutoSize = true;
            this.lblStepNumber.Location = new System.Drawing.Point(245, 535);
            this.lblStepNumber.Name = "lblStepNumber";
            this.lblStepNumber.Size = new System.Drawing.Size(30, 13);
            this.lblStepNumber.TabIndex = 12;
            this.lblStepNumber.Text = "Gen:";
            // 
            // lblPopulation
            // 
            this.lblPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(245, 564);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(32, 13);
            this.lblPopulation.TabIndex = 13;
            this.lblPopulation.Text = "Pop: ";
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuOptions,
            this.mnuHelp});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(504, 24);
            this.mnuMainStrip.TabIndex = 14;
            this.mnuMainStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiFileLoadPattern,
            this.mnuiFileSavePattern,
            this.toolStripSeparator1,
            this.mnuiFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuiFileLoadPattern
            // 
            this.mnuiFileLoadPattern.Image = ((System.Drawing.Image)(resources.GetObject("mnuiFileLoadPattern.Image")));
            this.mnuiFileLoadPattern.Name = "mnuiFileLoadPattern";
            this.mnuiFileLoadPattern.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuiFileLoadPattern.Size = new System.Drawing.Size(186, 22);
            this.mnuiFileLoadPattern.Text = "&Load Pattern";
            this.mnuiFileLoadPattern.Click += new System.EventHandler(this.mnuiFileLoadPattern_Click);
            // 
            // mnuiFileSavePattern
            // 
            this.mnuiFileSavePattern.Image = ((System.Drawing.Image)(resources.GetObject("mnuiFileSavePattern.Image")));
            this.mnuiFileSavePattern.Name = "mnuiFileSavePattern";
            this.mnuiFileSavePattern.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuiFileSavePattern.Size = new System.Drawing.Size(186, 22);
            this.mnuiFileSavePattern.Text = "&Save Pattern";
            this.mnuiFileSavePattern.Click += new System.EventHandler(this.mnuiFileSavePattern_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuiFileExit
            // 
            this.mnuiFileExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuiFileExit.Image")));
            this.mnuiFileExit.Name = "mnuiFileExit";
            this.mnuiFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuiFileExit.Size = new System.Drawing.Size(186, 22);
            this.mnuiFileExit.Text = "E&xit";
            this.mnuiFileExit.Click += new System.EventHandler(this.mnuiFileExit_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiOptionsShowGrid,
            this.mnuiOptionsLiveCellColor,
            this.mnuiOptionsDeadCellColor});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(56, 20);
            this.mnuOptions.Text = "&Options";
            // 
            // mnuiOptionsShowGrid
            // 
            this.mnuiOptionsShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("mnuiOptionsShowGrid.Image")));
            this.mnuiOptionsShowGrid.Name = "mnuiOptionsShowGrid";
            this.mnuiOptionsShowGrid.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuiOptionsShowGrid.Size = new System.Drawing.Size(172, 22);
            this.mnuiOptionsShowGrid.Text = "Show &Grid";
            this.mnuiOptionsShowGrid.Click += new System.EventHandler(this.mnuiOptionsShowGrid_Click);
            // 
            // mnuiOptionsLiveCellColor
            // 
            this.mnuiOptionsLiveCellColor.Image = ((System.Drawing.Image)(resources.GetObject("mnuiOptionsLiveCellColor.Image")));
            this.mnuiOptionsLiveCellColor.Name = "mnuiOptionsLiveCellColor";
            this.mnuiOptionsLiveCellColor.Size = new System.Drawing.Size(172, 22);
            this.mnuiOptionsLiveCellColor.Text = "&Live Cell Color";
            this.mnuiOptionsLiveCellColor.Click += new System.EventHandler(this.mnuiOptionsLiveCellColor_Click);
            // 
            // mnuiOptionsDeadCellColor
            // 
            this.mnuiOptionsDeadCellColor.Image = ((System.Drawing.Image)(resources.GetObject("mnuiOptionsDeadCellColor.Image")));
            this.mnuiOptionsDeadCellColor.Name = "mnuiOptionsDeadCellColor";
            this.mnuiOptionsDeadCellColor.Size = new System.Drawing.Size(172, 22);
            this.mnuiOptionsDeadCellColor.Text = "&Dead Cell Color";
            this.mnuiOptionsDeadCellColor.Click += new System.EventHandler(this.mnuiOptionsDeadCellColor_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiHelpAboutPattern,
            this.toolStripSeparator2,
            this.mnuiHelpAboutGoL});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuiHelpAboutPattern
            // 
            this.mnuiHelpAboutPattern.Enabled = false;
            this.mnuiHelpAboutPattern.Image = ((System.Drawing.Image)(resources.GetObject("mnuiHelpAboutPattern.Image")));
            this.mnuiHelpAboutPattern.Name = "mnuiHelpAboutPattern";
            this.mnuiHelpAboutPattern.Size = new System.Drawing.Size(196, 22);
            this.mnuiHelpAboutPattern.Text = "About &Latest Pattern";
            this.mnuiHelpAboutPattern.Click += new System.EventHandler(this.mnuiHelpAboutPattern_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuiHelpAboutGoL
            // 
            this.mnuiHelpAboutGoL.Image = ((System.Drawing.Image)(resources.GetObject("mnuiHelpAboutGoL.Image")));
            this.mnuiHelpAboutGoL.Name = "mnuiHelpAboutGoL";
            this.mnuiHelpAboutGoL.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuiHelpAboutGoL.Size = new System.Drawing.Size(196, 22);
            this.mnuiHelpAboutGoL.Text = "&About Game of Life";
            this.mnuiHelpAboutGoL.Click += new System.EventHandler(this.mnuiHelpAboutGoL_Click);
            // 
            // lblRules
            // 
            this.lblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRules.AutoSize = true;
            this.lblRules.Location = new System.Drawing.Point(259, 4);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(37, 13);
            this.lblRules.TabIndex = 15;
            this.lblRules.Text = "Rules:";
            this.lblRules.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FormLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 588);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.lblPopulation);
            this.Controls.Add(this.lblStepNumber);
            this.Controls.Add(this.lblZoomCount);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.cmbRules);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlScroller);
            this.Controls.Add(this.mnuMainStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainStrip;
            this.MaximizeBox = false;
            this.Name = "FormLife";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life";
            this.pnlScroller.ResumeLayout(false);
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbRules;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Panel pnlScroller;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label lblZoomCount;
        private System.Windows.Forms.Label lblStepNumber;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuiFileLoadPattern;
        private System.Windows.Forms.ToolStripMenuItem mnuiFileSavePattern;
        private System.Windows.Forms.ToolStripMenuItem mnuiFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuiOptionsShowGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuiOptionsLiveCellColor;
        private System.Windows.Forms.ToolStripMenuItem mnuiOptionsDeadCellColor;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuiHelpAboutPattern;
        private System.Windows.Forms.ToolStripMenuItem mnuiHelpAboutGoL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private kiswa.Games.Life.CustomControls.LifeGrid lifeGrid;
        private System.Windows.Forms.Label lblRules;
    }
}