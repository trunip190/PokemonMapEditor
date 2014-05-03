namespace PokemonMapEditor
{
    partial class PokemonPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboType = new System.Windows.Forms.ComboBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.checkCatch = new System.Windows.Forms.CheckBox();
            this.checkFemale = new System.Windows.Forms.CheckBox();
            this.comboMove1 = new System.Windows.Forms.ComboBox();
            this.comboMove2 = new System.Windows.Forms.ComboBox();
            this.comboMove3 = new System.Windows.Forms.ComboBox();
            this.comboMove4 = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 235);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Species";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(131, 30);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(116, 21);
            this.comboType.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(131, 4);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 20);
            this.textName.TabIndex = 2;
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(132, 58);
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(46, 20);
            this.numLevel.TabIndex = 3;
            // 
            // checkCatch
            // 
            this.checkCatch.AutoSize = true;
            this.checkCatch.Location = new System.Drawing.Point(249, 6);
            this.checkCatch.Name = "checkCatch";
            this.checkCatch.Size = new System.Drawing.Size(80, 17);
            this.checkCatch.TabIndex = 4;
            this.checkCatch.Text = "Catchable?";
            this.checkCatch.UseVisualStyleBackColor = true;
            // 
            // checkFemale
            // 
            this.checkFemale.AutoSize = true;
            this.checkFemale.Location = new System.Drawing.Point(184, 59);
            this.checkFemale.Name = "checkFemale";
            this.checkFemale.Size = new System.Drawing.Size(66, 17);
            this.checkFemale.TabIndex = 5;
            this.checkFemale.Text = "Female?";
            this.checkFemale.UseVisualStyleBackColor = true;
            // 
            // comboMove1
            // 
            this.comboMove1.FormattingEnabled = true;
            this.comboMove1.Location = new System.Drawing.Point(131, 85);
            this.comboMove1.Name = "comboMove1";
            this.comboMove1.Size = new System.Drawing.Size(121, 21);
            this.comboMove1.TabIndex = 6;
            // 
            // comboMove2
            // 
            this.comboMove2.FormattingEnabled = true;
            this.comboMove2.Location = new System.Drawing.Point(131, 112);
            this.comboMove2.Name = "comboMove2";
            this.comboMove2.Size = new System.Drawing.Size(121, 21);
            this.comboMove2.TabIndex = 7;
            // 
            // comboMove3
            // 
            this.comboMove3.FormattingEnabled = true;
            this.comboMove3.Location = new System.Drawing.Point(132, 139);
            this.comboMove3.Name = "comboMove3";
            this.comboMove3.Size = new System.Drawing.Size(121, 21);
            this.comboMove3.TabIndex = 8;
            // 
            // comboMove4
            // 
            this.comboMove4.FormattingEnabled = true;
            this.comboMove4.Location = new System.Drawing.Point(132, 166);
            this.comboMove4.Name = "comboMove4";
            this.comboMove4.Size = new System.Drawing.Size(121, 21);
            this.comboMove4.TabIndex = 9;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(131, 194);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(47, 23);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(229, 216);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(310, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PokemonPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboMove4);
            this.Controls.Add(this.comboMove3);
            this.Controls.Add(this.comboMove2);
            this.Controls.Add(this.comboMove1);
            this.Controls.Add(this.checkFemale);
            this.Controls.Add(this.checkCatch);
            this.Controls.Add(this.numLevel);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.listView1);
            this.Name = "PokemonPicker";
            this.Size = new System.Drawing.Size(388, 242);
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.CheckBox checkCatch;
        private System.Windows.Forms.CheckBox checkFemale;
        private System.Windows.Forms.ComboBox comboMove1;
        private System.Windows.Forms.ComboBox comboMove2;
        private System.Windows.Forms.ComboBox comboMove3;
        private System.Windows.Forms.ComboBox comboMove4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
