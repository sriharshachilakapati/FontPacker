namespace FontPacker
{
    partial class PackerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox3D = new System.Windows.Forms.CheckBox();
            this.colorSelect2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.colorSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fontSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.previewText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.export = new System.Windows.Forms.Button();
            this.exportOthSym = new System.Windows.Forms.CheckBox();
            this.exportPunc = new System.Windows.Forms.CheckBox();
            this.exportArithOp = new System.Windows.Forms.CheckBox();
            this.exportNumbers = new System.Windows.Forms.CheckBox();
            this.exportSmallAlpha = new System.Windows.Forms.CheckBox();
            this.exportCapitalAplha = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.layerDist = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerDist)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.layerDist);
            this.groupBox1.Controls.Add(this.chkBox3D);
            this.groupBox1.Controls.Add(this.colorSelect2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.colorSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fontSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // chkBox3D
            // 
            this.chkBox3D.AutoSize = true;
            this.chkBox3D.Location = new System.Drawing.Point(16, 229);
            this.chkBox3D.Name = "chkBox3D";
            this.chkBox3D.Size = new System.Drawing.Size(76, 17);
            this.chkBox3D.TabIndex = 6;
            this.chkBox3D.Text = "Enable 3D";
            this.chkBox3D.UseVisualStyleBackColor = true;
            this.chkBox3D.CheckedChanged += new System.EventHandler(this.chkBox3D_CheckedChanged);
            // 
            // colorSelect2
            // 
            this.colorSelect2.Enabled = false;
            this.colorSelect2.Location = new System.Drawing.Point(12, 183);
            this.colorSelect2.Name = "colorSelect2";
            this.colorSelect2.Size = new System.Drawing.Size(198, 29);
            this.colorSelect2.TabIndex = 5;
            this.colorSelect2.Text = "Select Color";
            this.colorSelect2.UseVisualStyleBackColor = true;
            this.colorSelect2.Click += new System.EventHandler(this.colorSelect2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Color2";
            // 
            // colorSelect
            // 
            this.colorSelect.Location = new System.Drawing.Point(12, 111);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(198, 27);
            this.colorSelect.TabIndex = 3;
            this.colorSelect.Text = "Select Color";
            this.colorSelect.UseVisualStyleBackColor = true;
            this.colorSelect.Click += new System.EventHandler(this.colorSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font";
            // 
            // fontSelect
            // 
            this.fontSelect.Location = new System.Drawing.Point(12, 45);
            this.fontSelect.Name = "fontSelect";
            this.fontSelect.Size = new System.Drawing.Size(198, 28);
            this.fontSelect.TabIndex = 0;
            this.fontSelect.Text = "Select Font";
            this.fontSelect.UseVisualStyleBackColor = true;
            this.fontSelect.Click += new System.EventHandler(this.fontSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.previewText);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(227, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 304);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // previewText
            // 
            this.previewText.Location = new System.Drawing.Point(17, 188);
            this.previewText.Name = "previewText";
            this.previewText.Size = new System.Drawing.Size(461, 20);
            this.previewText.TabIndex = 1;
            this.previewText.Text = "Sample Text";
            this.previewText.TextChanged += new System.EventHandler(this.previewText_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.previewPanel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 157);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // previewPanel
            // 
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(3, 16);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(487, 138);
            this.previewPanel.TabIndex = 0;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.export);
            this.groupBox4.Controls.Add(this.exportOthSym);
            this.groupBox4.Controls.Add(this.exportPunc);
            this.groupBox4.Controls.Add(this.exportArithOp);
            this.groupBox4.Controls.Add(this.exportNumbers);
            this.groupBox4.Controls.Add(this.exportSmallAlpha);
            this.groupBox4.Controls.Add(this.exportCapitalAplha);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 425);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(726, 81);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Export";
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(560, 19);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(154, 48);
            this.export.TabIndex = 6;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // exportOthSym
            // 
            this.exportOthSym.AutoSize = true;
            this.exportOthSym.Location = new System.Drawing.Point(315, 50);
            this.exportOthSym.Name = "exportOthSym";
            this.exportOthSym.Size = new System.Drawing.Size(94, 17);
            this.exportOthSym.TabIndex = 5;
            this.exportOthSym.Text = "Other Symbols";
            this.exportOthSym.UseVisualStyleBackColor = true;
            // 
            // exportPunc
            // 
            this.exportPunc.AutoSize = true;
            this.exportPunc.Checked = true;
            this.exportPunc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportPunc.Location = new System.Drawing.Point(315, 27);
            this.exportPunc.Name = "exportPunc";
            this.exportPunc.Size = new System.Drawing.Size(88, 17);
            this.exportPunc.TabIndex = 4;
            this.exportPunc.Text = "Punctuations";
            this.exportPunc.UseVisualStyleBackColor = true;
            // 
            // exportArithOp
            // 
            this.exportArithOp.AutoSize = true;
            this.exportArithOp.Location = new System.Drawing.Point(166, 50);
            this.exportArithOp.Name = "exportArithOp";
            this.exportArithOp.Size = new System.Drawing.Size(121, 17);
            this.exportArithOp.TabIndex = 3;
            this.exportArithOp.Text = "Arithmetic Operators";
            this.exportArithOp.UseVisualStyleBackColor = true;
            // 
            // exportNumbers
            // 
            this.exportNumbers.AutoSize = true;
            this.exportNumbers.Checked = true;
            this.exportNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportNumbers.Location = new System.Drawing.Point(166, 27);
            this.exportNumbers.Name = "exportNumbers";
            this.exportNumbers.Size = new System.Drawing.Size(68, 17);
            this.exportNumbers.TabIndex = 2;
            this.exportNumbers.Text = "Numbers";
            this.exportNumbers.UseVisualStyleBackColor = true;
            // 
            // exportSmallAlpha
            // 
            this.exportSmallAlpha.AutoSize = true;
            this.exportSmallAlpha.Checked = true;
            this.exportSmallAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportSmallAlpha.Location = new System.Drawing.Point(19, 50);
            this.exportSmallAlpha.Name = "exportSmallAlpha";
            this.exportSmallAlpha.Size = new System.Drawing.Size(107, 17);
            this.exportSmallAlpha.TabIndex = 1;
            this.exportSmallAlpha.Text = "Alphabets (Small)";
            this.exportSmallAlpha.UseVisualStyleBackColor = true;
            // 
            // exportCapitalAplha
            // 
            this.exportCapitalAplha.AutoSize = true;
            this.exportCapitalAplha.Checked = true;
            this.exportCapitalAplha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportCapitalAplha.Location = new System.Drawing.Point(19, 27);
            this.exportCapitalAplha.Name = "exportCapitalAplha";
            this.exportCapitalAplha.Size = new System.Drawing.Size(114, 17);
            this.exportCapitalAplha.TabIndex = 0;
            this.exportCapitalAplha.Text = "Alphabets (Capital)";
            this.exportCapitalAplha.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(726, 121);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // layerDist
            // 
            this.layerDist.Enabled = false;
            this.layerDist.Location = new System.Drawing.Point(125, 256);
            this.layerDist.Name = "layerDist";
            this.layerDist.Size = new System.Drawing.Size(85, 20);
            this.layerDist.TabIndex = 7;
            this.layerDist.ValueChanged += new System.EventHandler(this.layerDist_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "3D Layer Distance";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "FontPacker fonts|*.fntpack";
            // 
            // PackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(726, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PackerForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FontPacker by Sri Harsha Chilakapati";
            this.Load += new System.EventHandler(this.PackerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerDist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fontSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TextBox previewText;
        private System.Windows.Forms.Button colorSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox chkBox3D;
        private System.Windows.Forms.Button colorSelect2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.CheckBox exportOthSym;
        private System.Windows.Forms.CheckBox exportPunc;
        private System.Windows.Forms.CheckBox exportArithOp;
        private System.Windows.Forms.CheckBox exportNumbers;
        private System.Windows.Forms.CheckBox exportSmallAlpha;
        private System.Windows.Forms.CheckBox exportCapitalAplha;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown layerDist;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}