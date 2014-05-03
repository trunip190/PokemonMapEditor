using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PokémonGame;

namespace PokemonMapEditor
{
    public partial class Editor : UserControl
    {
        public bool loaded = false;

        public SpriteBase sBase = new SpriteBase();
        public DialogResult result = DialogResult.Ignore;

        # region events & delegates
        public delegate void close();
        public event close closing;
        public event close saving;
        public event close cancelling;

        protected virtual void onClosing()
        {
            close handler = closing;
            if (handler != null)
            {
                handler();
            }
        }

        protected virtual void onSaving()
        {
            close handler = saving;
            if (handler != null)
            {
                handler();
                loaded = false;
            }
        }

        protected virtual void onCancelling()
        {
            close handler = cancelling;
            if (handler != null)
            {
                handler();
                loaded = false;
            }
        }
        # endregion

        public Editor()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            pokemonPicker1.LoadPokemonNames();
            loadMaps();
        }

        private void loadMaps()
        {
            foreach (string s in Settings.maps)
            {
                comboFilepath.Items.Add(Path.GetFileName(s));
            }
        }

        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        ((TextBox)c).Clear();
                        break;
                }
            }

            comboType.Text = "";

            button2.Image = null;
            conversationEditor1.Clear();
        }

        public void updateSpriteBase()
        {
            SpriteBase sb = new SpriteBase();

            # region switch (type of Sprite)
            switch (comboType.SelectedIndex)
            {
                case 0:
                    sb = new SpriteBase();
                    break;

                case 1: //grass
                    sb = new SpriteTerrain();
                    break;

                case 2:
                    sb = new SpriteBase();
                    break;

                case 3: //tree
                    sb = new SpriteTerrain();
                    break;

                case 4: //door
                    sb = new SpriteDoor();
                    break;

                case 5: //house
                    sb = new SpriteTerrain();
                    break;

                case 6: //person
                    sb = new SpritePerson();
                    break;

                case 7:
                    sb = new SpriteBase();
                    break;

                case 8:
                    sb = new SpriteBase();
                    break;

                case 9:
                    sb = new SpriteBase();
                    break;

                default:
                    sb = new SpriteBase();
                    break;
            }
            # endregion

            # region assign values
            # region SpriteBase
            sb.Name = textName.Text;                        //Name
            sb.Type = comboType.SelectedIndex;              //Type

            sb.xPos = (int)numxPos.Value;                   //xPos
            sb.yPos = (int)numyPos.Value;                   //yPos

            sb.xStart = (int)numxStart.Value;               //xStart
            sb.yStart = (int)numyStart.Value;               //yStart
            sb.setImage(textSprText.Text);                  //Sprite Sheet
            sb.visible = checkVis.Checked;                  //Visible
            int.TryParse(textBlock.Text, out sb.block);     //Block Type

            sb.width = (int)numWidth.Value;                 //Width
            sb.height = (int)numHeight.Value;               //Height
            sb.flip = checkFlip.Checked;                    //Whether image is reversed
            sb.save = checkBoxSave.Checked;                 //Save sprite when it changes?
            # endregion

            # region SpriteDoor
            if (sb.GetType() == typeof(SpriteDoor))
            {
                SpriteDoor sd = sb as SpriteDoor;

                sd.file = comboFilepath.Text;
                sd.newX = (int)numNewX.Value;
                sd.newY = (int)numNewY.Value;
            }
            # endregion

            # region SpriteItem
            if (sb.GetType() == typeof(SpriteItem))
            {
            }
            # endregion

            # region SpritePerson
            if (sb.GetType() == typeof(SpritePerson))
            {
                SpritePerson sp = sb as SpritePerson;
                # region conversations
                sp.ConvoGreet = conversationEditor1.greeting;
                sp.ConvoFarewell = conversationEditor1.farewell;
                # endregion

                sp.xOri = sp.xPos;
                sp.yOri = sp.yPos;
                sp.dist = (int)numDist.Value;
                sp.pokeGroup = (sBase as SpritePerson).pokeGroup;
            }
            # endregion

            # region SpritePokemon
            if (sb.GetType() == typeof(SpritePokemon))
            {
            }
            # endregion

            # region SpriteTerrain
            if (sb.GetType() == typeof(SpriteTerrain))
            {
                
            }
            # endregion
            # endregion

            sBase = sb;
        }

        public void loadSpriteBase(SpriteBase sb)
        {
            sBase = sb;

            # region SpriteBase
            textName.Text = sb.Name;
            comboType.SelectedIndex = sb.Type;
            comboType.Text = comboType.Items[sb.Type].ToString();

            //automatically overriden.
            numxPos.Value = sb.xPos;
            numyPos.Value = sb.yPos;

            textSprText.Text = sb.spriteSheet;

            # region x/y start
            try
            {
                numxStart.Value = sb.xStart;
                numyStart.Value = sb.yStart;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }
            # endregion

            numWidth.Value = sb.width;
            numHeight.Value = sb.height;

            checkVis.Checked = sb.visible;
            checkFlip.Checked = sb.flip;
            textBlock.Text = sb.block.ToString();
            checkBoxSave.Checked = sb.save;
            # endregion

            # region SpriteDoor
            if (sb.GetType() == typeof(SpriteDoor))
            {
                SpriteDoor sd = sb as SpriteDoor;
                comboFilepath.Text = sd.file;
                numNewX.Value = sd.newX;
                numNewY.Value = sd.newY;
            }
            # endregion

            # region SpriteItem
            if (sb.GetType() == typeof(SpriteItem))
            {
            }
            # endregion

            # region SpritePerson
            if (sb.GetType() == typeof(SpritePerson))
            {
                SpritePerson sp = sb as SpritePerson;
                # region conversations
                # region Greetings
                //foreach (convoText cT in sp.ConvoGreet)
                //{
                //    ListViewItem lvi = new ListViewItem();

                //    lvi.Text = cT.Text;
                //    lvi.SubItems.Add("Greeting");
                //    lvi.SubItems.Add(cT.req);
                //    lvi.SubItems.Add(cT.val.ToString());
                //    lvi.SubItems.Add(cT.ConReq);
                //    lvi.SubItems.Add(cT.ConVal.ToString());

                //    listView1.Items.Add(lvi);
                //}
                # endregion

                # region Battle Start
                //foreach (convoText cT in sp.ConvoBattleStart)
                //{
                //    ListViewItem lvi = new ListViewItem();

                //    lvi.Text = cT.Text;
                //    lvi.SubItems.Add("BattleStart");
                //    lvi.SubItems.Add(cT.req);
                //    lvi.SubItems.Add(cT.val.ToString());
                //    lvi.SubItems.Add(cT.ConReq);
                //    lvi.SubItems.Add(cT.ConVal.ToString());

                //    listView1.Items.Add(lvi);
                //}
                # endregion

                # region Battle End
                //foreach (convoText cT in sp.ConvoBattleEnd)
                //{
                //    ListViewItem lvi = new ListViewItem();

                //    lvi.Text = cT.Text;
                //    lvi.SubItems.Add("BattleEnd");
                //    lvi.SubItems.Add(cT.req);
                //    lvi.SubItems.Add(cT.val.ToString());
                //    lvi.SubItems.Add(cT.ConReq);
                //    lvi.SubItems.Add(cT.ConVal.ToString());

                //    listView1.Items.Add(lvi);
                //}
                # endregion

                # region Farewell
                //foreach (convoText cT in sp.ConvoFarewell)
                //{
                //    ListViewItem lvi = new ListViewItem();

                //    lvi.Text = cT.Text;
                //    lvi.SubItems.Add("Farewell");
                //    lvi.SubItems.Add(cT.req);
                //    lvi.SubItems.Add(cT.val.ToString());
                //    lvi.SubItems.Add(cT.ConReq);
                //    lvi.SubItems.Add(cT.ConVal.ToString());

                //    listView1.Items.Add(lvi);
                //}
                # endregion
                # endregion

                numDist.Value = sp.dist;
                conversationEditor1.LoadConvoList(sp.ConvoGreet, sp.ConvoFarewell);
            }
            # endregion

            # region SpritePokemon
            if (sb.GetType() == typeof(SpritePokemon))
            {
            }
            # endregion

            # region SpriteTerrain
            if (sb.GetType() == typeof(SpriteTerrain))
            {

            }
            # endregion

            loaded = true;

            if (File.Exists(textSprText.Text))
            {
                button2.Image = Image.FromFile(textSprText.Text);
            }
        }

        # region events
        # region control events
        private void buttonSave_Click(object sender, EventArgs e)
        {
            updateSpriteBase();
            result = DialogResult.OK;
            onSaving();
            onClosing();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            onCancelling();
        }

        private void textConvo_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("ERROR - called textconvo_keyup({0})", sender);
            //if (e.KeyCode == Keys.Enter)
            //{
            //    # region create ListViewitem
            //    ListViewItem lvi = new ListViewItem();
            //    lvi.Text = textConvo.Text;
            //    lvi.SubItems.Add(textConvType.Text);
            //    lvi.SubItems.Add(textConvReq.Text);
            //    lvi.SubItems.Add(textConvVal.Text);
            //    lvi.SubItems.Add(textConvConReq.Text);
            //    lvi.SubItems.Add(textConvConVal.Text);
            //    # endregion

            //    # region add to list
            //    if (listView1.SelectedItems.Count > 0)
            //    {
            //        int i = listView1.SelectedIndices[0];

            //        listView1.Items.RemoveAt(i);
            //        listView1.Items.Insert(i, lvi);
            //    }
            //    else
            //    {
            //        listView1.Items.Add(lvi);
            //    }
            //    # endregion

            //    # region clear text boxes
            //    textConvo.Clear();
            //    textConvType.Clear();
            //    textConvReq.Clear();
            //    textConvVal.Clear();
            //    textConvConReq.Clear();
            //    textConvConVal.Clear();
            //    # endregion

            //    e.Handled = true;
            //}
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("ERROR - called listView1_KeyUp({0})", sender);
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (listView1.SelectedItems.Count > 0)
            //    {
            //        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            //        textConvo.Text = "";
            //        e.Handled = true;
            //    }
            //}
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ERROR - called listView1_SelectedIndexChanged({0})", sender);
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    textConvo.Text = listView1.SelectedItems[0].SubItems[0].Text;
            //    textConvType.Text = listView1.SelectedItems[0].SubItems[1].Text;
            //    textConvReq.Text = listView1.SelectedItems[0].SubItems[2].Text;
            //    textConvVal.Text = listView1.SelectedItems[0].SubItems[3].Text;
            //    textConvConReq.Text = listView1.SelectedItems[0].SubItems[4].Text;
            //    textConvConVal.Text = listView1.SelectedItems[0].SubItems[5].Text;
            //}
        }
        # endregion

        # region spritePicker events
        private void button2_Click(object sender, EventArgs e)
        {
            spritePicker1.Show();

            Size pix = new Size((int)numWidth.Value, (int)numHeight.Value);
            spritePicker1.PixelSize = pix;

            spritePicker1.numX.Value = numxStart.Value;
            spritePicker1.numY.Value = numyStart.Value;

            spritePicker1.loadSpriteSheets();
            int ind = spritePicker1.comboBox1.Items.IndexOf(Path.GetFileName(textSprText.Text));
            spritePicker1.comboBox1.SelectedIndex = ind;

            tabControl1.SelectTab(1);
        }

        private void spritePicker1_saving()
        {
            textSprText.Text = spritePicker1.result;
            sBase.spriteSheet = spritePicker1.result;

            int x = (int)spritePicker1.numX.Value;
            int y = (int)spritePicker1.numY.Value;

            sBase.xStart = x;
            sBase.yStart = y;
            numxStart.Value = x;
            numyStart.Value = y;

            button2.Image = ImageLoad.FromSheet(spritePicker1.result, x, y, (int)numWidth.Value, (int)numHeight.Value);
            button2.Text = "";
        }

        private void spritePicker1_closing()
        {
            spritePicker1.Hide();
            tabControl1.SelectTab(0);
        }
        # endregion

        # region pokemonPicker events
        private void buttonPoke_Click(object sender, EventArgs e)
        {
            string type = sBase.GetType().ToString();

            if (type == "PokémonGame.SpritePerson")
            {
                SpritePerson pers = sBase as SpritePerson;
                
                pokemonPicker1.Show();

                pokemonPicker1.LoadGroup(pers.pokeGroup);

                tabControl1.SelectTab(2);
            }
            else
            {
                Debug.WriteLine(type);
            }

        }

        private void pokemonPicker1_Cancel()
        {
        }

        private void pokemonPicker1_Closing()
        {
            Debug.WriteLine("pokemonPicker1_Closing()");
            pokemonPicker1.Hide();
            tabControl1.SelectTab(0);
        }

        private void pokemonPicker1_Save()
        {
            SpritePerson pers = sBase as SpritePerson;

            pers.pokeGroup = pokemonPicker1.pokemon;

            textPokeCount.Text = pers.pokeGroup.Count.ToString();
        }
        # endregion

        # region conversation events
        private void conversationEditor1_Opening()
        {
            
        }

        private void conversationEditor1_Saving()
        {
            //TODO save conversations
            if (sBase.GetType() == typeof(SpritePerson))
            {
                SpritePerson sp = sBase as SpritePerson;
                sp.ConvoGreet = conversationEditor1.greeting;
                sp.ConvoFarewell = conversationEditor1.farewell;
            }
        }

        private void conversationEditor1_Closing()
        {
            tabControl1.SelectTab(0);
        }
        # endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        # endregion
    }
}
