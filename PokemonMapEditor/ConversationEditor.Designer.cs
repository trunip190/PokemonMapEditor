namespace PokemonMapEditor
{
    partial class ConversationEditor
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
            this.listViewConvos = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewReqs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxReqName = new System.Windows.Forms.TextBox();
            this.numReqVal = new System.Windows.Forms.NumericUpDown();
            this.panelReq = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonReqUpd = new System.Windows.Forms.Button();
            this.buttonReqAdd = new System.Windows.Forms.Button();
            this.panelCons = new System.Windows.Forms.Panel();
            this.listViewCons = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxConsName = new System.Windows.Forms.TextBox();
            this.buttonConUpd = new System.Windows.Forms.Button();
            this.numConsVal = new System.Windows.Forms.NumericUpDown();
            this.buttonConAdd = new System.Windows.Forms.Button();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBoxChoice = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewChoices = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.radioGreeting = new System.Windows.Forms.RadioButton();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.radioFarewell = new System.Windows.Forms.RadioButton();
            this.numItemCount = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numReqVal)).BeginInit();
            this.panelReq.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelCons.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConsVal)).BeginInit();
            this.panelDisplay.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemCount)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewConvos
            // 
            this.listViewConvos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewConvos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewConvos.Location = new System.Drawing.Point(0, 0);
            this.listViewConvos.Margin = new System.Windows.Forms.Padding(0);
            this.listViewConvos.Name = "listViewConvos";
            this.listViewConvos.Size = new System.Drawing.Size(504, 122);
            this.listViewConvos.TabIndex = 0;
            this.listViewConvos.UseCompatibleStateImageBehavior = false;
            this.listViewConvos.View = System.Windows.Forms.View.Details;
            this.listViewConvos.SelectedIndexChanged += new System.EventHandler(this.listViewConvos_SelectedIndexChanged);
            this.listViewConvos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewConvos_KeyUp);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Text";
            this.columnHeader5.Width = 186;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 57;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Requirement";
            this.columnHeader7.Width = 68;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Value";
            this.columnHeader8.Width = 41;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Consequence";
            this.columnHeader9.Width = 71;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Value";
            this.columnHeader10.Width = 41;
            // 
            // listViewReqs
            // 
            this.listViewReqs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewReqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReqs.Location = new System.Drawing.Point(0, 22);
            this.listViewReqs.Margin = new System.Windows.Forms.Padding(0);
            this.listViewReqs.Name = "listViewReqs";
            this.listViewReqs.Size = new System.Drawing.Size(252, 81);
            this.listViewReqs.TabIndex = 1;
            this.listViewReqs.UseCompatibleStateImageBehavior = false;
            this.listViewReqs.View = System.Windows.Forms.View.Details;
            this.listViewReqs.SelectedIndexChanged += new System.EventHandler(this.listViewReqs_SelectedIndexChanged);
            this.listViewReqs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewReqs_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // textBoxText
            // 
            this.textBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxText.Location = new System.Drawing.Point(0, 0);
            this.textBoxText.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(252, 100);
            this.textBoxText.TabIndex = 3;
            // 
            // textBoxReqName
            // 
            this.textBoxReqName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxReqName.Location = new System.Drawing.Point(0, 0);
            this.textBoxReqName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxReqName.Name = "textBoxReqName";
            this.textBoxReqName.Size = new System.Drawing.Size(97, 20);
            this.textBoxReqName.TabIndex = 4;
            // 
            // numReqVal
            // 
            this.numReqVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numReqVal.Location = new System.Drawing.Point(97, 0);
            this.numReqVal.Margin = new System.Windows.Forms.Padding(0);
            this.numReqVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numReqVal.Name = "numReqVal";
            this.numReqVal.Size = new System.Drawing.Size(42, 20);
            this.numReqVal.TabIndex = 5;
            // 
            // panelReq
            // 
            this.panelReq.Controls.Add(this.listViewReqs);
            this.panelReq.Controls.Add(this.panel6);
            this.panelReq.Controls.Add(this.panel4);
            this.panelReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReq.Location = new System.Drawing.Point(0, 0);
            this.panelReq.Margin = new System.Windows.Forms.Padding(0);
            this.panelReq.Name = "panelReq";
            this.panelReq.Size = new System.Drawing.Size(252, 124);
            this.panelReq.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(252, 22);
            this.panel6.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Requirements";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxReqName);
            this.panel4.Controls.Add(this.buttonReqUpd);
            this.panel4.Controls.Add(this.numReqVal);
            this.panel4.Controls.Add(this.buttonReqAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 103);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 21);
            this.panel4.TabIndex = 9;
            // 
            // buttonReqUpd
            // 
            this.buttonReqUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReqUpd.FlatAppearance.BorderSize = 0;
            this.buttonReqUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReqUpd.Location = new System.Drawing.Point(173, 0);
            this.buttonReqUpd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReqUpd.Name = "buttonReqUpd";
            this.buttonReqUpd.Size = new System.Drawing.Size(61, 20);
            this.buttonReqUpd.TabIndex = 8;
            this.buttonReqUpd.Text = "Update";
            this.buttonReqUpd.UseVisualStyleBackColor = true;
            this.buttonReqUpd.Click += new System.EventHandler(this.buttonReqUpd_Click);
            // 
            // buttonReqAdd
            // 
            this.buttonReqAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReqAdd.FlatAppearance.BorderSize = 0;
            this.buttonReqAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReqAdd.Location = new System.Drawing.Point(139, 0);
            this.buttonReqAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReqAdd.Name = "buttonReqAdd";
            this.buttonReqAdd.Size = new System.Drawing.Size(34, 20);
            this.buttonReqAdd.TabIndex = 7;
            this.buttonReqAdd.Text = "Add";
            this.buttonReqAdd.UseVisualStyleBackColor = true;
            this.buttonReqAdd.Click += new System.EventHandler(this.buttonReqAdd_Click);
            // 
            // panelCons
            // 
            this.panelCons.Controls.Add(this.listViewCons);
            this.panelCons.Controls.Add(this.panel7);
            this.panelCons.Controls.Add(this.panel3);
            this.panelCons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCons.Location = new System.Drawing.Point(252, 0);
            this.panelCons.Margin = new System.Windows.Forms.Padding(0);
            this.panelCons.Name = "panelCons";
            this.panelCons.Size = new System.Drawing.Size(252, 124);
            this.panelCons.TabIndex = 10;
            // 
            // listViewCons
            // 
            this.listViewCons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewCons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCons.Location = new System.Drawing.Point(0, 22);
            this.listViewCons.Margin = new System.Windows.Forms.Padding(0);
            this.listViewCons.Name = "listViewCons";
            this.listViewCons.Size = new System.Drawing.Size(252, 81);
            this.listViewCons.TabIndex = 1;
            this.listViewCons.UseCompatibleStateImageBehavior = false;
            this.listViewCons.View = System.Windows.Forms.View.Details;
            this.listViewCons.SelectedIndexChanged += new System.EventHandler(this.listViewCons_SelectedIndexChanged);
            this.listViewCons.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewCons_KeyUp);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(252, 22);
            this.panel7.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Consequences";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxConsName);
            this.panel3.Controls.Add(this.buttonConUpd);
            this.panel3.Controls.Add(this.numConsVal);
            this.panel3.Controls.Add(this.buttonConAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 21);
            this.panel3.TabIndex = 10;
            // 
            // textBoxConsName
            // 
            this.textBoxConsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxConsName.Location = new System.Drawing.Point(0, 1);
            this.textBoxConsName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxConsName.Name = "textBoxConsName";
            this.textBoxConsName.Size = new System.Drawing.Size(97, 20);
            this.textBoxConsName.TabIndex = 4;
            // 
            // buttonConUpd
            // 
            this.buttonConUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConUpd.FlatAppearance.BorderSize = 0;
            this.buttonConUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConUpd.Location = new System.Drawing.Point(173, 1);
            this.buttonConUpd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConUpd.Name = "buttonConUpd";
            this.buttonConUpd.Size = new System.Drawing.Size(61, 20);
            this.buttonConUpd.TabIndex = 9;
            this.buttonConUpd.Text = "Update";
            this.buttonConUpd.UseVisualStyleBackColor = true;
            this.buttonConUpd.Click += new System.EventHandler(this.buttonConUpd_Click);
            // 
            // numConsVal
            // 
            this.numConsVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numConsVal.Location = new System.Drawing.Point(97, 1);
            this.numConsVal.Margin = new System.Windows.Forms.Padding(0);
            this.numConsVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numConsVal.Name = "numConsVal";
            this.numConsVal.Size = new System.Drawing.Size(42, 20);
            this.numConsVal.TabIndex = 5;
            // 
            // buttonConAdd
            // 
            this.buttonConAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConAdd.FlatAppearance.BorderSize = 0;
            this.buttonConAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConAdd.Location = new System.Drawing.Point(139, 1);
            this.buttonConAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConAdd.Name = "buttonConAdd";
            this.buttonConAdd.Size = new System.Drawing.Size(34, 20);
            this.buttonConAdd.TabIndex = 6;
            this.buttonConAdd.Text = "Add";
            this.buttonConAdd.UseVisualStyleBackColor = true;
            this.buttonConAdd.Click += new System.EventHandler(this.buttonConAdd_Click);
            // 
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.panel1);
            this.panelDisplay.Controls.Add(this.panel11);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(5, 5);
            this.panelDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(504, 346);
            this.panelDisplay.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewConvos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 122);
            this.panel1.TabIndex = 14;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tableLayoutPanel1);
            this.panel11.Controls.Add(this.tableLayoutPanel2);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 122);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(504, 224);
            this.panel11.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelCons, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelReq, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 124);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 100);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.textBoxChoice);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.listViewChoices);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(255, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(246, 94);
            this.panel8.TabIndex = 18;
            // 
            // textBoxChoice
            // 
            this.textBoxChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChoice.Location = new System.Drawing.Point(0, 0);
            this.textBoxChoice.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxChoice.Multiline = true;
            this.textBoxChoice.Name = "textBoxChoice";
            this.textBoxChoice.Size = new System.Drawing.Size(120, 70);
            this.textBoxChoice.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button2);
            this.panel9.Controls.Add(this.button1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 70);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(120, 24);
            this.panel9.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(60, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewChoices
            // 
            this.listViewChoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11});
            this.listViewChoices.Dock = System.Windows.Forms.DockStyle.Right;
            this.listViewChoices.Location = new System.Drawing.Point(120, 0);
            this.listViewChoices.Margin = new System.Windows.Forms.Padding(0);
            this.listViewChoices.Name = "listViewChoices";
            this.listViewChoices.Size = new System.Drawing.Size(126, 94);
            this.listViewChoices.TabIndex = 0;
            this.listViewChoices.UseCompatibleStateImageBehavior = false;
            this.listViewChoices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Choice";
            this.columnHeader11.Width = 155;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.textBoxText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 100);
            this.panel2.TabIndex = 15;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.radioGreeting);
            this.panel10.Controls.Add(this.comboItem);
            this.panel10.Controls.Add(this.radioFarewell);
            this.panel10.Controls.Add(this.numItemCount);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(123, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(129, 100);
            this.panel10.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "<- Text | Choices ->";
            // 
            // radioGreeting
            // 
            this.radioGreeting.AutoSize = true;
            this.radioGreeting.Checked = true;
            this.radioGreeting.Location = new System.Drawing.Point(3, 52);
            this.radioGreeting.Name = "radioGreeting";
            this.radioGreeting.Size = new System.Drawing.Size(65, 17);
            this.radioGreeting.TabIndex = 11;
            this.radioGreeting.TabStop = true;
            this.radioGreeting.Text = "Greeting";
            this.radioGreeting.UseVisualStyleBackColor = true;
            // 
            // comboItem
            // 
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(3, 75);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(110, 21);
            this.comboItem.TabIndex = 13;
            // 
            // radioFarewell
            // 
            this.radioFarewell.AutoSize = true;
            this.radioFarewell.Location = new System.Drawing.Point(4, 29);
            this.radioFarewell.Name = "radioFarewell";
            this.radioFarewell.Size = new System.Drawing.Size(64, 17);
            this.radioFarewell.TabIndex = 12;
            this.radioFarewell.TabStop = true;
            this.radioFarewell.Text = "Farewell";
            this.radioFarewell.UseVisualStyleBackColor = true;
            // 
            // numItemCount
            // 
            this.numItemCount.Location = new System.Drawing.Point(71, 49);
            this.numItemCount.Margin = new System.Windows.Forms.Padding(0);
            this.numItemCount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numItemCount.Name = "numItemCount";
            this.numItemCount.Size = new System.Drawing.Size(42, 20);
            this.numItemCount.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonUpdate);
            this.panel5.Controls.Add(this.buttonAdd);
            this.panel5.Controls.Add(this.buttonCancel);
            this.panel5.Controls.Add(this.buttonSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(5, 351);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(504, 34);
            this.panel5.TabIndex = 11;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(89, 6);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(8, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(385, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(304, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ConversationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.panel5);
            this.MinimumSize = new System.Drawing.Size(478, 332);
            this.Name = "ConversationEditor";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(514, 390);
            ((System.ComponentModel.ISupportInitialize)(this.numReqVal)).EndInit();
            this.panelReq.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelCons.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConsVal)).EndInit();
            this.panelDisplay.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemCount)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewConvos;
        private System.Windows.Forms.ListView listViewReqs;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxReqName;
        private System.Windows.Forms.NumericUpDown numReqVal;
        private System.Windows.Forms.Panel panelReq;
        private System.Windows.Forms.Panel panelCons;
        private System.Windows.Forms.TextBox textBoxConsName;
        private System.Windows.Forms.NumericUpDown numConsVal;
        private System.Windows.Forms.ListView listViewCons;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReqAdd;
        private System.Windows.Forms.Button buttonConAdd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RadioButton radioFarewell;
        private System.Windows.Forms.RadioButton radioGreeting;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonReqUpd;
        private System.Windows.Forms.Button buttonConUpd;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.NumericUpDown numItemCount;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBoxChoice;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewChoices;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
