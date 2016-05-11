namespace SimpleDraw
{
    partial class Form1
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
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.ToolboxPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ColorButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShapeComboBox = new System.Windows.Forms.ComboBox();
            this.AACheckBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ToolboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.Color.White;
            this.DrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawingPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DrawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingPanel.Location = new System.Drawing.Point(0, 48);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(682, 409);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            this.DrawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseMove);
            this.DrawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            // 
            // ToolboxPanel
            // 
            this.ToolboxPanel.Controls.Add(this.label3);
            this.ToolboxPanel.Controls.Add(this.ColorButton);
            this.ToolboxPanel.Controls.Add(this.button1);
            this.ToolboxPanel.Controls.Add(this.numericUpDown1);
            this.ToolboxPanel.Controls.Add(this.label2);
            this.ToolboxPanel.Controls.Add(this.label1);
            this.ToolboxPanel.Controls.Add(this.ShapeComboBox);
            this.ToolboxPanel.Controls.Add(this.AACheckBox);
            this.ToolboxPanel.Controls.Add(this.ClearButton);
            this.ToolboxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolboxPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolboxPanel.Name = "ToolboxPanel";
            this.ToolboxPanel.Size = new System.Drawing.Size(682, 48);
            this.ToolboxPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Color:";
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.Black;
            this.ColorButton.Location = new System.Drawing.Point(474, 11);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(47, 23);
            this.ColorButton.TabIndex = 9;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(363, 15);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shape:";
            // 
            // ShapeComboBox
            // 
            this.ShapeComboBox.FormattingEnabled = true;
            this.ShapeComboBox.Items.AddRange(new object[] {
            "Filled Circle",
            "Open Circle",
            "Filled Square",
            "Open Square"});
            this.ShapeComboBox.Location = new System.Drawing.Point(221, 14);
            this.ShapeComboBox.Name = "ShapeComboBox";
            this.ShapeComboBox.Size = new System.Drawing.Size(100, 21);
            this.ShapeComboBox.TabIndex = 3;
            this.ShapeComboBox.Text = "Filled Circle";
            // 
            // AACheckBox
            // 
            this.AACheckBox.AutoSize = true;
            this.AACheckBox.Location = new System.Drawing.Point(537, 15);
            this.AACheckBox.Name = "AACheckBox";
            this.AACheckBox.Size = new System.Drawing.Size(119, 17);
            this.AACheckBox.TabIndex = 1;
            this.AACheckBox.Text = "AntiAlias Smoothing";
            this.AACheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(12, 12);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Bitmap Image (*.bmp)|*.bmp";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 457);
            this.Controls.Add(this.DrawingPanel);
            this.Controls.Add(this.ToolboxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SimpleDraw";
            this.ToolboxPanel.ResumeLayout(false);
            this.ToolboxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.Panel ToolboxPanel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox AACheckBox;
        private System.Windows.Forms.ComboBox ShapeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

