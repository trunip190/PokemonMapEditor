namespace PokemonMapEditor
{
    partial class Editor
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
            this.comboType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkVis = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBlock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textSprText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numyStart = new System.Windows.Forms.NumericUpDown();
            this.numxStart = new System.Windows.Forms.NumericUpDown();
            this.numyPos = new System.Windows.Forms.NumericUpDown();
            this.numxPos = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textVariant = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelTerrain = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.numNewY = new System.Windows.Forms.NumericUpDown();
            this.numNewX = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.comboFilepath = new System.Windows.Forms.ComboBox();
            this.panelPerson = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.numDist = new System.Windows.Forms.NumericUpDown();
            this.textPokeCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textItems = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textDirLook = new System.Windows.Forms.TextBox();
            this.checkFight = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonPoke = new System.Windows.Forms.Button();
            this.textMoveAction = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.checkFlip = new System.Windows.Forms.CheckBox();
            this.labelFlip = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.spritePicker1 = new PokemonMapEditor.SpritePicker();
            this.pokemonPicker1 = new PokemonMapEditor.PokemonPicker();
            this.conversationEditor1 = new PokemonMapEditor.ConversationEditor();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numyStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numyPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numxPos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelTerrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewX)).BeginInit();
            this.panelPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDist)).BeginInit();
            this.panelBasic.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "0 - ",
            "1 - Grass",
            "2 - ",
            "3 - Tree",
            "4 - Door",
            "5 - House",
            "6 - Person",
            "7 - ",
            "8 - ",
            "9 - "});
            this.comboType.Location = new System.Drawing.Point(84, 36);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(100, 21);
            this.comboType.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(209, 278);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkVis
            // 
            this.checkVis.AutoSize = true;
            this.checkVis.Location = new System.Drawing.Point(301, 91);
            this.checkVis.Name = "checkVis";
            this.checkVis.Size = new System.Drawing.Size(15, 14);
            this.checkVis.TabIndex = 6;
            this.checkVis.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "block/terrain";
            // 
            // textBlock
            // 
            this.textBlock.Location = new System.Drawing.Point(84, 63);
            this.textBlock.Name = "textBlock";
            this.textBlock.Size = new System.Drawing.Size(100, 20);
            this.textBlock.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Visible?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Start pos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Name";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(84, 10);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 20);
            this.textName.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 21);
            this.button2.TabIndex = 16;
            this.button2.Text = "Pick Sprite";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textSprText
            // 
            this.textSprText.Location = new System.Drawing.Point(84, 89);
            this.textSprText.Name = "textSprText";
            this.textSprText.Size = new System.Drawing.Size(100, 20);
            this.textSprText.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Width/Height";
            // 
            // numWidth
            // 
            this.numWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numWidth.Location = new System.Drawing.Point(268, 63);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(47, 20);
            this.numWidth.TabIndex = 77;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numHeight.Location = new System.Drawing.Point(321, 63);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(47, 20);
            this.numHeight.TabIndex = 78;
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numyStart
            // 
            this.numyStart.Location = new System.Drawing.Point(321, 36);
            this.numyStart.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numyStart.Name = "numyStart";
            this.numyStart.Size = new System.Drawing.Size(47, 20);
            this.numyStart.TabIndex = 80;
            this.numyStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numxStart
            // 
            this.numxStart.Location = new System.Drawing.Point(268, 36);
            this.numxStart.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numxStart.Name = "numxStart";
            this.numxStart.Size = new System.Drawing.Size(47, 20);
            this.numxStart.TabIndex = 79;
            this.numxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numyPos
            // 
            this.numyPos.Location = new System.Drawing.Point(321, 11);
            this.numyPos.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numyPos.Name = "numyPos";
            this.numyPos.Size = new System.Drawing.Size(47, 20);
            this.numyPos.TabIndex = 82;
            this.numyPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numxPos
            // 
            this.numxPos.Location = new System.Drawing.Point(268, 11);
            this.numxPos.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numxPos.Name = "numxPos";
            this.numxPos.Size = new System.Drawing.Size(47, 20);
            this.numxPos.TabIndex = 81;
            this.numxPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(529, 367);
            this.tabControl1.TabIndex = 83;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panelTerrain);
            this.tabPage1.Controls.Add(this.panelPerson);
            this.tabPage1.Controls.Add(this.panelBasic);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.buttonSave);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(521, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textVariant);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(209, 234);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 38);
            this.panel4.TabIndex = 114;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // textVariant
            // 
            this.textVariant.Location = new System.Drawing.Point(69, 8);
            this.textVariant.Name = "textVariant";
            this.textVariant.Size = new System.Drawing.Size(71, 20);
            this.textVariant.TabIndex = 109;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 110;
            this.label15.Text = "Variant";
            // 
            // panelTerrain
            // 
            this.panelTerrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTerrain.Controls.Add(this.label6);
            this.panelTerrain.Controls.Add(this.numNewY);
            this.panelTerrain.Controls.Add(this.numNewX);
            this.panelTerrain.Controls.Add(this.label19);
            this.panelTerrain.Controls.Add(this.comboFilepath);
            this.panelTerrain.Location = new System.Drawing.Point(3, 234);
            this.panelTerrain.Name = "panelTerrain";
            this.panelTerrain.Size = new System.Drawing.Size(200, 67);
            this.panelTerrain.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 112;
            this.label6.Text = "Position";
            // 
            // numNewY
            // 
            this.numNewY.Location = new System.Drawing.Point(141, 34);
            this.numNewY.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.numNewY.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numNewY.Name = "numNewY";
            this.numNewY.Size = new System.Drawing.Size(47, 20);
            this.numNewY.TabIndex = 114;
            this.numNewY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numNewX
            // 
            this.numNewX.Location = new System.Drawing.Point(88, 34);
            this.numNewX.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numNewX.Name = "numNewX";
            this.numNewX.Size = new System.Drawing.Size(47, 20);
            this.numNewX.TabIndex = 113;
            this.numNewX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 83;
            this.label19.Text = "Map to load";
            // 
            // comboFilepath
            // 
            this.comboFilepath.FormattingEnabled = true;
            this.comboFilepath.Location = new System.Drawing.Point(88, 7);
            this.comboFilepath.Name = "comboFilepath";
            this.comboFilepath.Size = new System.Drawing.Size(100, 21);
            this.comboFilepath.TabIndex = 111;
            // 
            // panelPerson
            // 
            this.panelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPerson.Controls.Add(this.label9);
            this.panelPerson.Controls.Add(this.numDist);
            this.panelPerson.Controls.Add(this.textPokeCount);
            this.panelPerson.Controls.Add(this.label10);
            this.panelPerson.Controls.Add(this.textItems);
            this.panelPerson.Controls.Add(this.label11);
            this.panelPerson.Controls.Add(this.label12);
            this.panelPerson.Controls.Add(this.textDirLook);
            this.panelPerson.Controls.Add(this.checkFight);
            this.panelPerson.Controls.Add(this.label13);
            this.panelPerson.Controls.Add(this.buttonPoke);
            this.panelPerson.Controls.Add(this.textMoveAction);
            this.panelPerson.Controls.Add(this.label14);
            this.panelPerson.Location = new System.Drawing.Point(3, 131);
            this.panelPerson.Name = "panelPerson";
            this.panelPerson.Size = new System.Drawing.Size(515, 97);
            this.panelPerson.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "Range";
            // 
            // numDist
            // 
            this.numDist.Location = new System.Drawing.Point(147, 63);
            this.numDist.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numDist.Name = "numDist";
            this.numDist.Size = new System.Drawing.Size(41, 20);
            this.numDist.TabIndex = 110;
            // 
            // textPokeCount
            // 
            this.textPokeCount.Location = new System.Drawing.Point(78, 36);
            this.textPokeCount.Name = "textPokeCount";
            this.textPokeCount.ReadOnly = true;
            this.textPokeCount.Size = new System.Drawing.Size(32, 20);
            this.textPokeCount.TabIndex = 109;
            this.textPokeCount.Text = "0";
            this.textPokeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "Items";
            // 
            // textItems
            // 
            this.textItems.Location = new System.Drawing.Point(78, 10);
            this.textItems.Name = "textItems";
            this.textItems.Size = new System.Drawing.Size(127, 20);
            this.textItems.TabIndex = 99;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 104;
            this.label11.Text = "PokeGroup";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Fight?";
            // 
            // textDirLook
            // 
            this.textDirLook.Location = new System.Drawing.Point(292, 10);
            this.textDirLook.Name = "textDirLook";
            this.textDirLook.Size = new System.Drawing.Size(127, 20);
            this.textDirLook.TabIndex = 101;
            // 
            // checkFight
            // 
            this.checkFight.AutoSize = true;
            this.checkFight.Location = new System.Drawing.Point(78, 65);
            this.checkFight.Name = "checkFight";
            this.checkFight.Size = new System.Drawing.Size(15, 14);
            this.checkFight.TabIndex = 100;
            this.checkFight.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "dirLook";
            // 
            // buttonPoke
            // 
            this.buttonPoke.Location = new System.Drawing.Point(116, 34);
            this.buttonPoke.Name = "buttonPoke";
            this.buttonPoke.Size = new System.Drawing.Size(89, 23);
            this.buttonPoke.TabIndex = 108;
            this.buttonPoke.Text = "Pick Pokemon";
            this.buttonPoke.UseVisualStyleBackColor = true;
            this.buttonPoke.Click += new System.EventHandler(this.buttonPoke_Click);
            // 
            // textMoveAction
            // 
            this.textMoveAction.Location = new System.Drawing.Point(292, 36);
            this.textMoveAction.Name = "textMoveAction";
            this.textMoveAction.Size = new System.Drawing.Size(127, 20);
            this.textMoveAction.TabIndex = 102;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 107;
            this.label14.Text = "moveAction";
            // 
            // panelBasic
            // 
            this.panelBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBasic.Controls.Add(this.checkBoxSave);
            this.panelBasic.Controls.Add(this.label16);
            this.panelBasic.Controls.Add(this.checkFlip);
            this.panelBasic.Controls.Add(this.labelFlip);
            this.panelBasic.Controls.Add(this.label1);
            this.panelBasic.Controls.Add(this.comboType);
            this.panelBasic.Controls.Add(this.button2);
            this.panelBasic.Controls.Add(this.label8);
            this.panelBasic.Controls.Add(this.textBlock);
            this.panelBasic.Controls.Add(this.textSprText);
            this.panelBasic.Controls.Add(this.label2);
            this.panelBasic.Controls.Add(this.textName);
            this.panelBasic.Controls.Add(this.label3);
            this.panelBasic.Controls.Add(this.checkVis);
            this.panelBasic.Controls.Add(this.label4);
            this.panelBasic.Controls.Add(this.numWidth);
            this.panelBasic.Controls.Add(this.numHeight);
            this.panelBasic.Controls.Add(this.label7);
            this.panelBasic.Controls.Add(this.numyPos);
            this.panelBasic.Controls.Add(this.numxStart);
            this.panelBasic.Controls.Add(this.numxPos);
            this.panelBasic.Controls.Add(this.label5);
            this.panelBasic.Controls.Add(this.numyStart);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(3, 3);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(515, 122);
            this.panelBasic.TabIndex = 112;
            // 
            // checkFlip
            // 
            this.checkFlip.AutoSize = true;
            this.checkFlip.Location = new System.Drawing.Point(231, 91);
            this.checkFlip.Name = "checkFlip";
            this.checkFlip.Size = new System.Drawing.Size(15, 14);
            this.checkFlip.TabIndex = 83;
            this.checkFlip.UseVisualStyleBackColor = true;
            // 
            // labelFlip
            // 
            this.labelFlip.AutoSize = true;
            this.labelFlip.Location = new System.Drawing.Point(196, 92);
            this.labelFlip.Name = "labelFlip";
            this.labelFlip.Size = new System.Drawing.Size(29, 13);
            this.labelFlip.TabIndex = 84;
            this.labelFlip.Text = "Flip?";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.spritePicker1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(521, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sprites";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pokemonPicker1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(521, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pokemon";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.conversationEditor1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(521, 341);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Conversations";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(487, 341);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "Attributes";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Location = new System.Drawing.Point(371, 91);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSave.TabIndex = 85;
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(325, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 86;
            this.label16.Text = "Saves?";
            // 
            // spritePicker1
            // 
            this.spritePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritePicker1.Location = new System.Drawing.Point(3, 3);
            this.spritePicker1.MinimumSize = new System.Drawing.Size(366, 230);
            this.spritePicker1.Name = "spritePicker1";
            this.spritePicker1.Size = new System.Drawing.Size(515, 335);
            this.spritePicker1.TabIndex = 75;
            this.spritePicker1.Visible = false;
            this.spritePicker1.closing += new PokemonMapEditor.SpritePicker.close(this.spritePicker1_closing);
            this.spritePicker1.saving += new PokemonMapEditor.SpritePicker.close(this.spritePicker1_saving);
            // 
            // pokemonPicker1
            // 
            this.pokemonPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonPicker1.Location = new System.Drawing.Point(3, 3);
            this.pokemonPicker1.Name = "pokemonPicker1";
            this.pokemonPicker1.Size = new System.Drawing.Size(515, 335);
            this.pokemonPicker1.TabIndex = 0;
            this.pokemonPicker1.Visible = false;
            this.pokemonPicker1.Save += new PokemonMapEditor.PokemonPicker.close(this.pokemonPicker1_Save);
            this.pokemonPicker1.Cancel += new PokemonMapEditor.PokemonPicker.close(this.pokemonPicker1_Cancel);
            this.pokemonPicker1.Closing += new PokemonMapEditor.PokemonPicker.close(this.pokemonPicker1_Closing);
            // 
            // conversationEditor1
            // 
            this.conversationEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conversationEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversationEditor1.Location = new System.Drawing.Point(3, 3);
            this.conversationEditor1.MinimumSize = new System.Drawing.Size(478, 332);
            this.conversationEditor1.Name = "conversationEditor1";
            this.conversationEditor1.Padding = new System.Windows.Forms.Padding(5);
            this.conversationEditor1.Size = new System.Drawing.Size(515, 335);
            this.conversationEditor1.TabIndex = 1;
            this.conversationEditor1.Saving += new PokemonMapEditor.ConversationEditor.close(this.conversationEditor1_Saving);
            this.conversationEditor1.Closing += new PokemonMapEditor.ConversationEditor.close(this.conversationEditor1_Closing);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(529, 367);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(529, 367);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numyStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numyPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numxPos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelTerrain.ResumeLayout(false);
            this.panelTerrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewX)).EndInit();
            this.panelPerson.ResumeLayout(false);
            this.panelPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDist)).EndInit();
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboType;
        public System.Windows.Forms.CheckBox checkVis;
        public System.Windows.Forms.TextBox textBlock;
        public System.Windows.Forms.TextBox textName;
        private SpritePicker spritePicker1;
        public System.Windows.Forms.TextBox textSprText;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown numWidth;
        public System.Windows.Forms.NumericUpDown numHeight;
        public System.Windows.Forms.NumericUpDown numyStart;
        public System.Windows.Forms.NumericUpDown numxStart;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.NumericUpDown numyPos;
        public System.Windows.Forms.NumericUpDown numxPos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private PokemonPicker pokemonPicker1;
        private System.Windows.Forms.TabPage tabPage7;
        private ConversationEditor conversationEditor1;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox textVariant;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox checkFight;
        private System.Windows.Forms.Button buttonPoke;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textMoveAction;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox textDirLook;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox textItems;
        public System.Windows.Forms.ComboBox comboFilepath;
        private System.Windows.Forms.Panel panelTerrain;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Panel panelPerson;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown numNewY;
        public System.Windows.Forms.NumericUpDown numNewX;
        public System.Windows.Forms.TextBox textPokeCount;
        public System.Windows.Forms.CheckBox checkFlip;
        private System.Windows.Forms.Label labelFlip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numDist;
        public System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.Label label16;
    }
}
