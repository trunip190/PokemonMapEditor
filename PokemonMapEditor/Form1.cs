using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XmlParse;
using PokémonGame;

namespace PokemonMapEditor
{
    public partial class Form1 : Form
    {
        # region Declared variables
        List<CheckBox> checkList = new List<CheckBox>();
        List<Button> ButtonList = new List<Button>();
        int level
        {
            get
            {
                int result = 0;

                if (radioButtonFloor.Checked) { result = 0; }
                if (radioButtonBase.Checked) { result = 1; }
                if (radioButtonMid.Checked) { result = 2; }
                if (radioButtonTop.Checked) { result = 3; }

                return result;
            }

            set
            {
                switch (value)
                {
                    case 0:
                        radioButtonFloor.Checked = true;
                        break;
                    case 1:
                        radioButtonBase.Checked = true;
                        break;
                    case 2:
                        radioButtonMid.Checked = true;
                        break;
                    case 3:
                        radioButtonTop.Checked = true;
                        break;
                }
            }
        }
        int tabReturn = 0;
        int[] CustPos;

        List<SpriteBase> currentLevel
        {
            get
            {
                List<SpriteBase> result;
                switch (level)
                {
                    case 0:
                        result = mapEdit.floor;
                        break;

                    case 1:
                        result = mapEdit.baseList;
                        break;

                    case 2:
                        result = mapEdit.midList;
                        break;

                    case 3:
                        result = mapEdit.topList;
                        break;

                    default:
                        result = mapEdit.midList;
                        break;
                }

                return result;
            }
        }

        //public mapArray array = new mapArray();
        public map mapEdit = new map();

        Dictionary<int, SpriteBase> listLink = new Dictionary<int, SpriteBase>();
        Dictionary<string, SpriteBase> posLink = new Dictionary<string, SpriteBase>();
        RadioButton chkLink;
        int[] savePos = new int[2];

        private string currentFile = "";

        private SpriteBase customSprite = new SpriteBase();
        private Image backGuide = new Bitmap(128, 128);
        # endregion

        public Form1()
        {
            InitializeComponent();

            Settings.appPath = GetPath();

            SpritePerson sb = new SpritePerson
            {
                Name = "Matthew",
                xPos = 2,
                yPos = 2,
                Type = 6,
                xStart = 0,
                yStart = 32,
            };
            sb.setImage(@"%PATH%\Resources\TileSets\heromfoverworld.png");

            mapEdit.midList.Add(sb);

            Settings.loadPokemon();
            Settings.loadMaps();
            Settings.loadItems();
            editor1.Initialise();

            update_all();
        }

        #region Events
        # region others
        void xmlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO work out method of updating node data.
        }
        
        private void radioButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(RadioButton))
            {
                chkLink = sender as RadioButton;
                chkLink.Select();
                Point loc = chkLink.Location;

                int[] pos = getCoords(chkLink);

                loc.X += tabPage1.Location.X + this.Location.X + chkLink.Width;
                loc.Y += tabPage1.Location.Y + this.Location.Y + chkLink.Height;

                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(loc);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            # region setup
            if (sender.GetType() != typeof(ListView))
            {
                return;
            }

            ListView tempView = sender as ListView;

            if (tempView.SelectedIndices.Count == 0)
            {
                return;
            }

            SpriteBase sB = listLink[tempView.SelectedIndices[0]];
            # endregion

            loadSpriteBase(sB);
        }

        private void checkTop_CheckedChanged(object sender, EventArgs e)
        {
            picturebox1Draw();
        }

        private void editor1_saving()
        {
            Debug.WriteLine("Saving old");
            saveSpriteBase();
        }

        private void editor1_cancelling()
        {
            tabControl1.SelectTab(tabReturn);
        }

        private void editor1_closing()
        {
            tabControl1.SelectTab(tabReturn);
        }
        # endregion

        # region buttons
        private void buttonEdit_Click(object sender, EventArgs e) //Edit
        {
            savePos = getCoords(chkLink);

            SpriteBase sb = mapEdit.getSprite(level, savePos[0], savePos[1]);

            loadSpriteBase(sb);

            tabReturn = 0;
        }

        private void buttonRefresh_Click(object sender, EventArgs e) //Refresh
        {
            Debug.WriteLine("buttonRefresh_Click");
            update_all();
        }

        private void buttonSave_Click(object sender, EventArgs e) //Save
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "eXtensible Markup Language file (*.xml)|*.xml";

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFile(SaveFileDialog.FileName);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e) //Load
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            OpenFileDialog1.Filter = "xml files| *.xml";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFile(OpenFileDialog1.FileName);
            }
        }

        private void buttonXML_Click(object sender, EventArgs e) //Show xml
        {
            tabControl1.SelectTab(3);

            tempBox.Text = generateXML().Replace("><", ">\r\n<");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();

            mapEdit.width = 10;
            mapEdit.height = 10;

            update_all();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFile))
            {
                saveFile(currentFile);
            }
            else
            {
                buttonSave_Click(sender, e);
            }
        }
        # endregion

        # region picturebox1
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point x = new Point(e.X, e.Y);

            x.X -= panel1.Width / 2;
            x.Y -= panel1.Height / 2;

            savePos = getCoords(e.X, e.Y);
            picturebox_DrawBox(savePos);
            pictureBox1.Focus();

            panel1.AutoScrollPosition = x;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            savePos = getCoords(e.X, e.Y);

            SpriteBase sb = mapEdit.getSprite(level, savePos[0], savePos[1]);

            loadSpriteBase(sb);

            tabReturn = 2;
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            # region switch key pressed
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    deleteSpriteBase();
                    break;

                # region create type
                case Keys.G:
                    updateType(1);
                    update_all();
                    break;

                case Keys.T:
                    updateType(3);
                    update_all();
                    break;

                case Keys.H:
                    updateType(5);
                    update_all();
                    break;

                case Keys.P:
                    updateType(6);
                    update_all();
                    break;

                case Keys.I:
                    updateType(0);
                    update_all();
                    break;

                case Keys.C:
                    updateType(-1);
                    update_all();
                    break;

                case Keys.M:
                    buttonStamp_Click(sender, e);
                    break;
                # endregion

                # region directional arrows
                case Keys.Up:
                    if (savePos[1] > 0)
                    {
                        savePos[1]--;
                        picturebox_DrawBox(savePos);
                    }
                    break;

                case Keys.Down:
                    savePos[1]++;
                    picturebox_DrawBox(savePos);
                    break;

                case Keys.Right:
                    savePos[0]++;
                    picturebox_DrawBox(savePos);
                    break;

                case Keys.Left:
                    if (savePos[0] > 0)
                    {
                        savePos[0]--;
                        picturebox_DrawBox(savePos);
                    }
                    break;
                # endregion

                default:
                    break;
            }
            # endregion
        }
        # endregion

        # region context menu events
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateType(1);   //grass
            update_all();
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateType(3);   //tree
            update_all();
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateType(6);
            update_all();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateType(0);
            update_all();
        }

        private void doorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateType(4);
            update_all();
        }

        private void houseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateType(5);
            update_all();
        }

        private void customToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            updateType(-1);
            update_all();
        }
        # endregion

        # region map values
        private void textMapName_TextChanged(object sender, EventArgs e)
        {
            mapEdit.name = textMapName.Text;
        }

        private void numMapWidth_ValueChanged(object sender, EventArgs e)
        {
            mapEdit.width = (int)numMapWidth.Value;
            update_mapSize();
            picturebox1Draw();
        }

        private void numMapHeight_ValueChanged(object sender, EventArgs e)
        {
            mapEdit.height = (int)numMapHeight.Value;
            update_mapSize();
            picturebox1Draw();
        }
        # endregion

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!tabPage3.ContainsFocus)
            {
                return;
            }

            switch (e.KeyCode)
            {
                # region change level
                case Keys.PageUp:
                    if (level < 3)
                    {
                        level++;
                    }
                    break;

                case Keys.PageDown:
                    if (level > 0)
                    {
                        level--;
                    }
                    break;
                # endregion

                # region change visibility
                case Keys.D1:
                    checkBase.Checked = !checkBase.Checked;
                    picturebox1Draw();
                    break;

                case Keys.D2:
                    checkMid.Checked = !checkMid.Checked;
                    picturebox1Draw();
                    break;

                case Keys.D3:
                    checkTop.Checked = !checkTop.Checked;
                    picturebox1Draw();
                    break;
                # endregion

                default:
                    //Debug.WriteLine("Pressed {0}", e.KeyCode);
                    break;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            editor1.saving -= editor1_saving;
            editor1.saving += new Editor.close(cEdit_saving);
            loadSpriteBase(customSprite);

            tabReturn = 2;
        }

        private void buttonGuide_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Settings.appPath;
            ofd.Filter = "Common Image Files|*.png;*.bmp;*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                backGuide = Image.FromFile(ofd.FileName);
                picturebox1Draw();
            }
        }

        private void buttonFillFloor_Click(object sender, EventArgs e)
        {
            int l = level;
            level = 0;

            for (int y = 0; y < mapEdit.height; y++)
            {
                for (int x = 0; x < mapEdit.width; x++)
                {
                    savePos = new int[] { x, y };

                    updateType(-1);
                }
            }

            level = l;
            update_all();
        }

        private void buttonStamp_Click(object sender, EventArgs e)
        {
            bool temp = checkBuild.Checked;
            checkBuild.Checked = true;
            int[] start = new int[] { savePos[0], savePos[1] };
            CustPos = null;

            for (int x = 0; x < numCustWidth.Value; x++)
            {
                for (int y = 0; y < numCustHeight.Value; y++)
                {
                    savePos[0] = x + start[0];
                    savePos[1] = y + start[1];

                    updateType(-1);
                }
            }

            savePos = new int[] { start[0], start[1] };
            checkBuild.Checked = temp;
            update_all();
        }
        #endregion

        #region methods
        # region loading saving getpath
        private string GetPath()
        {
            string dir = Environment.CurrentDirectory;

            foreach (string s in Directory.GetDirectories(dir, "*", SearchOption.AllDirectories))
            {
                foreach (string f in Directory.GetFiles(s))
                {
                    if (s.Contains("Resources"))
                    {
                        Settings.Resources.Add(f.Replace(dir, ""));
                    }
                }
            }

            return Environment.CurrentDirectory;
        }

        private void saveFile(string filePath)
        {
            createID();

            XmlSerializer serial = new XmlSerializer(typeof(map));

            using (Stream stream = File.Create(filePath))
            {
                serial.Serialize(stream, mapEdit);
                currentFile = filePath;
            }
        }

        private void loadFile(string filePath)
        {
            XmlSerializer serial = new XmlSerializer(typeof(map));

            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                mapEdit = serial.Deserialize(stream) as map;
            }

            currentFile = filePath;

            buttonRefresh_Click(refreshToolStripMenuItem, MouseEventArgs.Empty);
        }

        private void clearAll()
        {
            currentFile = "";

            mapEdit = new map();

            listLink.Clear();
            posLink.Clear();
            chkLink = null;
            savePos = new int[2];
        }

        private void loadSpriteBase(SpriteBase sb)
        {
            # region old method
            //editor1.sBase = sb;

            # region SpriteBase
            //editor1.textName.Text = sb.Name;
            //editor1.comboType.SelectedIndex = sb.Type;

            ////automatically overriden.
            //editor1.numxPos.Value = sb.xPos;
            //editor1.numyPos.Value = sb.yPos;

            //editor1.textSprText.Text = sb.spriteSheet;

            # region x/y start
            //try
            //{
            //    editor1.numxStart.Value = sb.xStart;
            //    editor1.numyStart.Value = sb.yStart;
            //}
            //catch (Exception exc)
            //{
            //    Debug.WriteLine(exc);
            //}
            # endregion

            //editor1.numWidth.Value = sb.width;
            //editor1.numHeight.Value = sb.height;

            //editor1.checkVis.Checked = sb.visible;
            //editor1.textBlock.Text = sb.block.ToString();
            # endregion

            # region SpriteDoor
            //if (sb.GetType() == typeof(SpriteDoor))
            //{
            //    SpriteDoor sd = sb as SpriteDoor;
            //    editor1.comboFilepath.Text = sd.file;
            //}
            # endregion

            # region SpriteItem
            //if (sb.GetType() == typeof(SpriteItem))
            //{
            //}
            # endregion

            # region SpritePerson
            //if (sb.GetType() == typeof(SpritePerson))
            //{
            //    SpritePerson sp = sb as SpritePerson;
            # region conversations
            # region Greetings
            //    foreach (convoText cT in sp.ConvoGreet)
            //    {
            //        ListViewItem lvi = new ListViewItem();

            //        lvi.Text = cT.Text;
            //        lvi.SubItems.Add("Greeting");
            //        lvi.SubItems.Add(cT.req);
            //        lvi.SubItems.Add(cT.val.ToString());
            //        lvi.SubItems.Add(cT.ConReq);
            //        lvi.SubItems.Add(cT.ConVal.ToString());

            //        editor1.listView1.Items.Add(lvi);
            //    }
            # endregion

            # region Battle Start
            //    foreach (convoText cT in sp.ConvoBattleStart)
            //    {
            //        ListViewItem lvi = new ListViewItem();

            //        lvi.Text = cT.Text;
            //        lvi.SubItems.Add("BattleStart");
            //        lvi.SubItems.Add(cT.req);
            //        lvi.SubItems.Add(cT.val.ToString());
            //        lvi.SubItems.Add(cT.ConReq);
            //        lvi.SubItems.Add(cT.ConVal.ToString());

            //        editor1.listView1.Items.Add(lvi);
            //    }
            # endregion

            # region Battle End
            //    foreach (convoText cT in sp.ConvoBattleEnd)
            //    {
            //        ListViewItem lvi = new ListViewItem();

            //        lvi.Text = cT.Text;
            //        lvi.SubItems.Add("BattleEnd");
            //        lvi.SubItems.Add(cT.req);
            //        lvi.SubItems.Add(cT.val.ToString());
            //        lvi.SubItems.Add(cT.ConReq);
            //        lvi.SubItems.Add(cT.ConVal.ToString());

            //        editor1.listView1.Items.Add(lvi);
            //    }
            # endregion

            # region Farewell
            //    foreach (convoText cT in sp.ConvoFarewell)
            //    {
            //        ListViewItem lvi = new ListViewItem();

            //        lvi.Text = cT.Text;
            //        lvi.SubItems.Add("Farewell");
            //        lvi.SubItems.Add(cT.req);
            //        lvi.SubItems.Add(cT.val.ToString());
            //        lvi.SubItems.Add(cT.ConReq);
            //        lvi.SubItems.Add(cT.ConVal.ToString());

            //        editor1.listView1.Items.Add(lvi);
            //    }
            # endregion
            # endregion

            //}
            # endregion

            # region SpritePokemon
            //if (sb.GetType() == typeof(SpritePokemon))
            //{
            //}
            # endregion

            # region SpriteTerrain
            //if (sb.GetType() == typeof(SpriteTerrain))
            //{

            //}
            # endregion

            //editor1.loaded = true;

            //if (File.Exists(editor1.textSprText.Text))
            //{
            //    editor1.button2.Image = Image.FromFile(editor1.textSprText.Text);
            //}
            # endregion

            editor1.loadSpriteBase(sb);

            tabControl1.SelectTab(1);
        }

        private void saveSpriteBase()
        {
            if (editor1.loaded)
            {
                editor1.updateSpriteBase();

                SpriteBase sb = editor1.sBase;

                # region add to list
                int[] pos = savePos;

                List<SpriteBase> tempList = getList(level);

                # region check if mapedit.list contains item at that position.
                string sPos = pos[0] + "," + pos[1];

                for (int j = 0; j < tempList.Count; j++)
                {
                    SpriteBase ts = tempList[j];

                    if (ts.xPos == sb.xPos && ts.yPos == sb.yPos)
                    {
                        tempList[j] = sb;
                    }
                }

                # endregion
                # endregion

                editor1.Clear();

                Debug.WriteLine("saveSpriteBase");
                update_all();

                savePos = new int[2];
            }
        }

        private void deleteSpriteBase()
        {
            List<SpriteBase> temp = getList(level);
            int i = mapEdit.getIndex(level, savePos[0], savePos[1]);

            if (i > -1)
            {
                temp.RemoveAt(i);
            }

            Debug.WriteLine("deleteSpriteBase");
            update_all();
        }

        private void createID()
        {
            int i = 0;
            foreach (SpriteBase sb in mapEdit.floor)
            {
                sb.ID = "fl" + i.ToString("000");
                i++;
            }

            i = 0;
            foreach (SpriteBase sb in mapEdit.baseList)
            {
                sb.ID = "ba" + i.ToString("000");
                i++;
            }

            i = 0;
            foreach (SpriteBase sb in mapEdit.midList)
            {
                sb.ID = "mi" + i.ToString("000");
                i++;
            }

            i = 0;
            foreach (SpriteBase sb in mapEdit.topList)
            {
                sb.ID = "to" + i.ToString("000");
                i++;
            }
        }
        # endregion

        # region calculations
        protected T[,] ResizeArray<T>(T[,] original, int x, int y)
        {
            //Borrowed from http://stackoverflow.com/questions/6539571/how-to-resize-multidimensional-2d-array-in-c
            //unused so far, but will be used to set the size of the map

            T[,] newArray = new T[x, y];
            int minX = Math.Min(original.GetLength(0), newArray.GetLength(0));
            int minY = Math.Min(original.GetLength(1), newArray.GetLength(1));

            for (int i = 0; i < minY; ++i)
                Array.Copy(original, i * original.GetLength(0), newArray, i * newArray.GetLength(0), minX);

            return newArray;
        }

        private int[] getCoords(Control target)
        {
            int[] pos = new int[2];

            pos[0] = int.Parse(((target.Location.X - 3) / 40).ToString());
            pos[1] = int.Parse(((target.Location.Y - 3) / 40).ToString());

            return pos;
        }

        private int[] getCoords(int x, int y)
        {
            int[] result = new int[2];

            x = (int)Math.Floor((double)(x / 32));
            y = (int)Math.Floor((double)(y / 32));

            result[0] = x;
            result[1] = y;

            return result;
        }

        private int getBox()
        {
            int i = -1;



            return i;
        }

        private string isNull(object text)
        {
            if (text == null)
            {
                return "";
            }
            else
            {
                return text.ToString();
            }
        }

        private int[] getMapSize()
        {
            int[] result = { 1, 1 };

            List<SpriteBase> temp = mapEdit.baseList;
            for (int i = 0; i < 3; i++)
            {
                if (i == 1) { temp = mapEdit.midList; }
                if (i == 2) { temp = mapEdit.topList; }

                foreach (SpriteBase sb in temp)
                {
                    if (sb != null)
                    {
                        if (sb.xPos > result[0]) result[0] = sb.xPos;
                        if (sb.yPos > result[1]) result[1] = sb.yPos;
                    }
                }
            }

            result[0] += 1;    //adjust from 0 based integer
            result[1] += 1;    //adjust from 0 based integer

            return result;
        }

        private List<SpriteBase> getList(int l)
        {
            List<SpriteBase> temp;

            # region switch (l)
            switch (l)
            {
                case 0:
                    temp = mapEdit.floor;
                    break;

                case 1:
                    temp = mapEdit.baseList;
                    break;

                case 2:
                    temp = mapEdit.midList;
                    break;

                case 3:
                    temp = mapEdit.topList;
                    break;

                default:
                    temp = mapEdit.midList;
                    break;
            }
            # endregion

            return temp;
        }
        # endregion

        # region generate SpriteBase methods
        private void updateType(int i)
        {
            int[] pos = savePos;

            List<SpriteBase> templink = getList(level);

            SpriteBase sB = new SpriteBase();

            # region set type
            switch (i)
            {
                # region 0 Item
                case 0: //item
                    sB = new SpriteItem
                    {
                        # region attributes
                        Name = "Item",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = 0,
                        block = 2,
                        xStart = 666,
                        yStart = 626,
                        width = 16,
                        height = 16
                        # endregion
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\cityspritesheet20lj.png");
                    goto case 99;
                # endregion

                # region 1 Grass
                case 1: //grass
                    sB = new SpriteTerrain
                    {
                        # region attributes
                        Name = "Grass",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = i,
                        xStart = 160,
                        yStart = 64,
                        width = 32,
                        height = 32
                        # endregion
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\trees.png");
                    goto case 99;
                # endregion

                # region 3 Tree
                case 3: //tree
                    sB = new SpriteTerrain
                    {
                        # region attributes
                        Name = "Tree",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = i,
                        xAnim = 0,
                        yAnim = 6,
                        block = 2,
                        xStart = 0,
                        yStart = 96,
                        width = 16,
                        height = 16
                        # endregion
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\trees.png");

                    if (level == 3) //set tree top
                    {
                        sB.yStart = 80;
                    }
                    goto case 99;
                # endregion

                # region 4 Door
                case 4: //door
                    sB = new SpriteDoor
                    {
                        # region attributes
                        Name = "Door",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = i,
                        xStart = 199,
                        yStart = 793,
                        width = 16,
                        height = 16,
                        file = ""
                        # endregion
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\cityspritesheet20lj.png");
                    goto case 99;
                # endregion

                # region 5 Building
                case 5: //building
                    sB = new SpriteTerrain
                    {
                        Name = "Building",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = i,
                        xStart = 423,
                        yStart = 64,
                        width = 16,
                        height = 16,
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\hgsstilesetp.png");
                    goto case 99;
                # endregion

                # region 6 NPC
                case 6: //npc
                    sB = new SpritePerson
                    {
                        # region attributes
                        Name = "npc",
                        xPos = pos[0],
                        yPos = pos[1],
                        Type = i,
                        block = 2,
                        xStart = 0,
                        yStart = 32
                        # endregion
                    };
                    sB.setImage(@"%PATH%\Resources\TileSets\heromfoverworld.png");
                    goto case 99;
                # endregion

                # region -1 Custom
                case -1: //custom sprite
                    sB = customSprite.Clone() as SpriteBase;
                    sB.xPos = pos[0];
                    sB.yPos = pos[1];

                    # region set next sprite part
                    if (checkBuild.Checked)
                    {
                        if (CustPos == null)
                        {
                            CustPos = new int[] { savePos[0], savePos[1] };
                        }
                        else
                        {
                        }

                        int x = savePos[0] - CustPos[0];
                        int y = savePos[1] - CustPos[1];

                        x *= sB.width;
                        y *= sB.height;

                        if (sB.xStart + x >= 0)
                        {
                            sB.xStart += x;
                        }
                        if (sB.yStart + y >= 0)
                        {
                            sB.yStart += y;
                        }
                    }
                    # endregion

                    goto case 99;
                # endregion

                # region cleanup
                case 99:
                    # region add to list
                    int si = mapEdit.getIndex(level, pos[0], pos[1]);
                    if (si >= 0)
                    {
                        templink[si] = sB;
                    }
                    else
                    {
                        templink.Add(sB);
                    }
                    # endregion
                    break;
                # endregion

                default:
                    break;
            }
            # endregion

        }
        # endregion

        # region picturebox
        private void picturebox1Draw()
        {
            Image tImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(tImage))
            {
                # region draw guide
                Rectangle tRect = new Rectangle(0, 0, tImage.Width, tImage.Height);
                g.DrawImage(backGuide, tRect);
                # endregion

                # region Floor
                if (checkFloor.Checked)
                {
                    g.DrawImage(SpriteLoader.LoadLayer(mapEdit.floor, tRect, 32), new Point(0, 0));
                    //foreach (SpriteBase sb in mapEdit.floor)
                    //{
                    //    Rectangle rect = new Rectangle(sb.xPos * 32, sb.yPos * 32, 32, 32);
                    //    g.DrawImage(sb.toImage(), rect);
                    //}
                }
                # endregion

                # region baseList
                if (checkBase.Checked)
                {
                    g.DrawImage(SpriteLoader.LoadLayer(mapEdit.floor, tRect, 32), new Point(0, 0));
                    //foreach (SpriteBase sB in mapEdit.baseList)
                    //{
                    //    Rectangle rect = new Rectangle(sB.xPos * 32, sB.yPos * 32, 32, 32);
                    //    g.DrawImage(sB.toImage(), rect);
                    //}
                }
                # endregion

                # region midList
                if (checkMid.Checked)
                {
                    g.DrawImage(SpriteLoader.LoadLayer(mapEdit.midList, tRect, 32), new Point(0, 0));
                    //foreach (SpriteBase sB in mapEdit.midList)
                    //{
                    //    Rectangle rect = new Rectangle(sB.xPos * 32, sB.yPos * 32, 32, 32);
                    //    g.DrawImage(sB.toImage(), rect);
                    //}
                }
                # endregion

                # region topList
                if (checkTop.Checked)
                {
                    g.DrawImage(SpriteLoader.LoadLayer(mapEdit.topList, tRect, 32), new Point(0, 0));
                    //foreach (SpriteBase sB in mapEdit.topList)
                    //{
                    //    Rectangle rect = new Rectangle(sB.xPos * 32, sB.yPos * 32, 32, 32);
                    //    g.DrawImage(sB.toImage(), rect);
                    //}
                }
                # endregion
            }

            pictureBox1.BackgroundImage = tImage;
        }

        private void picturebox_DrawBox(int[] pos)
        {
            Rectangle rect = new Rectangle(pos[0] * 32, pos[1] * 32, 32, 32);

            Image overlay = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(overlay))
            {
                g.DrawRectangle(new Pen(Color.Red), rect);
            }

            pictureBox1.Image = overlay;
        }
        # endregion

        # region updates
        private void update_all()
        {
            int count = mapEdit.midList.Count;

            # region map data
            textMapName.Text = mapEdit.name;
            numMapWidth.Value = mapEdit.width;
            numMapHeight.Value = mapEdit.height;
            # endregion

            # region update dictionaries
            posLink.Clear();
            foreach (SpriteBase sB in mapEdit.midList)
            {
                string pos = sB.xPos + "," + sB.yPos;
                posLink.Add(pos, sB);
            }
            # endregion

            # region listView1
            listView1.Items.Clear();
            listLink.Clear();

            List<SpriteBase> tempMap = getList(level);

            listView1.OwnerDraw = true;
            foreach (SpriteBase sA in tempMap)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sA.Name;
                item.SubItems.Add(sA.xPos.ToString());
                item.SubItems.Add(sA.yPos.ToString());

                listView1.Items.Add(item);
                listLink.Add(listView1.Items.Count - 1, sA);
            }
            listView1.OwnerDraw = false;
            # endregion

            # region checkboxes

            foreach (Control c in tabPage1.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton chkTemp = c as RadioButton;
                    int[] pos = getCoords(chkTemp);
                }
            }
            # endregion

            # region display 2
            picturebox1Draw();
            # endregion
            
            update_mapSize();
        }
        
        private void update_mapSize()
        {
            pictureBox1.Width = mapEdit.width * 32;
            pictureBox1.Height = mapEdit.height * 32;

            if (pictureBox1.Width < 128)
            {
                pictureBox1.Width = 128;
            }

            if (pictureBox1.Height < 128)
            {
                pictureBox1.Height = 128;
            }
        }
        # endregion

        private void trim_map()
        {
            //TODO insert trimming of map.
        }

        private string generateXML()
        {
            string result = "";

            string path = @"c:\temp\temp.txt";

            XmlSerializer serial = new XmlSerializer(typeof(map));

            # region sorting
            //for (int i = 0; i < 200; i++)
            //{
            //    for (int j = 0; j < 200; j++)
            //    {
            //        if (mapEdit.baseMap[i, j] == null)
            //        {
            //            mapEdit.baseMap[i, j] = new mapPos();
            //        }
            //    }
            //}
            # endregion

            if (!File.Exists(path))
            {
                string temp = Path.GetDirectoryName(path);
                Directory.CreateDirectory(temp);
            }

            using (Stream stream = File.Create(path))
            {
                serial.Serialize(stream, mapEdit);
            }

            using (TextReader reader = new StreamReader(path))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
        #endregion

        void cEdit_saving()
        {
            CustPos = null;

            customSprite = editor1.sBase.Clone() as SpriteBase;

            editor1.saving += editor1_saving;
            editor1.saving -= cEdit_saving;
        }

        private void editor1_Load(object sender, EventArgs e)
        {

        }

        private void MoveAll(int x, int y)
        {
            foreach (SpriteBase sb in currentLevel)
            {
                sb.xPos += x;
                sb.yPos += y;
            }

            picturebox1Draw();
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            MoveAll(1, 0);
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            MoveAll(0, -1);
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            MoveAll(0, 1);
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            MoveAll(-1, 0);
        }
    }

    public static class Settings
    {
        # region Declarations
        public static string appPath = "";
        public static string mapDir = @"C:\Documents and Settings\Chris\My Documents\Dropbox\Projects\Pokémon\Pokémon\Resources\Maps\";

        public static List<string> Resources = new List<string>();
        public static List<string> maps = new List<string>();

        public static Dictionary<int, string> TypeLookup = new Dictionary<int, string>();
        public static Dictionary<string, Move> MoveLookup = new Dictionary<string, Move>();
        public static Dictionary<string, inventoryItem> ItemLookup = new Dictionary<string, inventoryItem>();
        # endregion

        public static void loadPokemon()
        {
            # region add in pokemon
            TypeLookup.Add(1, "Bulbasaur");
            TypeLookup.Add(2, "Ivysaur");
            TypeLookup.Add(3, "Venusaur");
            TypeLookup.Add(4, "Charmander");
            TypeLookup.Add(5, "Charmeleon");
            TypeLookup.Add(6, "Charizard");
            TypeLookup.Add(7, "Squirtle");
            TypeLookup.Add(8, "Wartortle");
            TypeLookup.Add(9, "Blastoise");
            TypeLookup.Add(10, "Caterpie");
            TypeLookup.Add(11, "Metapod");
            TypeLookup.Add(12, "Butterfree");
            TypeLookup.Add(13, "Weedle");
            TypeLookup.Add(14, "Kakuna");
            TypeLookup.Add(15, "Beedrill");
            TypeLookup.Add(16, "Pidgey");
            TypeLookup.Add(17, "Pidgeotto");
            TypeLookup.Add(18, "Pidgeot");
            TypeLookup.Add(19, "Rattata");
            TypeLookup.Add(20, "Raticate");
            TypeLookup.Add(21, "Spearow");
            TypeLookup.Add(22, "Fearow");
            TypeLookup.Add(23, "Ekans");
            TypeLookup.Add(24, "Arbok");
            TypeLookup.Add(25, "Pikachu");
            TypeLookup.Add(26, "Raichu");
            TypeLookup.Add(27, "Sandshrew");
            TypeLookup.Add(28, "Sandslash");
            TypeLookup.Add(29, "Nidoran♀");
            TypeLookup.Add(30, "Nidorina");
            TypeLookup.Add(31, "Nidoqueen");
            TypeLookup.Add(32, "Nidoran♂");
            TypeLookup.Add(33, "Nidorino");
            TypeLookup.Add(34, "Nidoking");
            TypeLookup.Add(35, "Clefairy");
            TypeLookup.Add(36, "Clefable");
            TypeLookup.Add(37, "Vulpix");
            TypeLookup.Add(38, "Ninetales");
            TypeLookup.Add(39, "Jigglypuff");
            TypeLookup.Add(40, "Wigglytuff");
            TypeLookup.Add(41, "Zubat");
            TypeLookup.Add(42, "Golbat");
            TypeLookup.Add(43, "Oddish");
            TypeLookup.Add(44, "Gloom");
            TypeLookup.Add(45, "Vileplume");
            TypeLookup.Add(46, "Paras");
            TypeLookup.Add(47, "Parasect");
            TypeLookup.Add(48, "Venonat");
            TypeLookup.Add(49, "Venomoth");
            TypeLookup.Add(50, "Diglett");
            TypeLookup.Add(51, "Dugtrio");
            TypeLookup.Add(52, "Meowth");
            TypeLookup.Add(53, "Persian");
            TypeLookup.Add(54, "Psyduck");
            TypeLookup.Add(55, "Golduck");
            TypeLookup.Add(56, "Mankey");
            TypeLookup.Add(57, "Primeape");
            TypeLookup.Add(58, "Growlithe");
            TypeLookup.Add(59, "Arcanine");
            TypeLookup.Add(60, "Poliwag");
            TypeLookup.Add(61, "Poliwhirl");
            TypeLookup.Add(62, "Poliwrath");
            TypeLookup.Add(63, "Abra");
            TypeLookup.Add(64, "Kadabra");
            TypeLookup.Add(65, "Alakazam");
            TypeLookup.Add(66, "Machop");
            TypeLookup.Add(67, "Machoke");
            TypeLookup.Add(68, "Machamp");
            TypeLookup.Add(69, "Bellsprout");
            TypeLookup.Add(70, "Weepinbell");
            TypeLookup.Add(71, "Victreebel");
            TypeLookup.Add(72, "Tentacool");
            TypeLookup.Add(73, "Tentacruel");
            TypeLookup.Add(74, "Geodude");
            TypeLookup.Add(75, "Graveler");
            TypeLookup.Add(76, "Golem");
            TypeLookup.Add(77, "Ponyta");
            TypeLookup.Add(78, "Rapidash");
            TypeLookup.Add(79, "Slowpoke");
            TypeLookup.Add(80, "Slowbro");
            TypeLookup.Add(81, "Magnemite");
            TypeLookup.Add(82, "Magneton");
            TypeLookup.Add(83, "Farfetch'd");
            TypeLookup.Add(84, "Doduo");
            TypeLookup.Add(85, "Dodrio");
            TypeLookup.Add(86, "Seel");
            TypeLookup.Add(87, "Dewgong");
            TypeLookup.Add(88, "Grimer");
            TypeLookup.Add(89, "Muk");
            TypeLookup.Add(90, "Shellder");
            TypeLookup.Add(91, "Cloyster");
            TypeLookup.Add(92, "Gastly");
            TypeLookup.Add(93, "Haunter");
            TypeLookup.Add(94, "Gengar");
            TypeLookup.Add(95, "Onix");
            TypeLookup.Add(96, "Drowzee");
            TypeLookup.Add(97, "Hypno");
            TypeLookup.Add(98, "Krabby");
            TypeLookup.Add(99, "Kingler");
            TypeLookup.Add(100, "Voltorb");
            TypeLookup.Add(101, "Electrode");
            TypeLookup.Add(102, "Exeggcute");
            TypeLookup.Add(103, "Exeggutor");
            TypeLookup.Add(104, "Cubone");
            TypeLookup.Add(105, "Marowak");
            TypeLookup.Add(106, "Hitmonlee");
            TypeLookup.Add(107, "Hitmonchan");
            TypeLookup.Add(108, "Lickitung");
            TypeLookup.Add(109, "Koffing");
            TypeLookup.Add(110, "Weezing");
            TypeLookup.Add(111, "Rhyhorn");
            TypeLookup.Add(112, "Rhydon");
            TypeLookup.Add(113, "Chansey");
            TypeLookup.Add(114, "Tangela");
            TypeLookup.Add(115, "Kangaskhan");
            TypeLookup.Add(116, "Horsea");
            TypeLookup.Add(117, "Seadra");
            TypeLookup.Add(118, "Goldeen");
            TypeLookup.Add(119, "Seaking");
            TypeLookup.Add(120, "Staryu");
            TypeLookup.Add(121, "Starmie");
            TypeLookup.Add(122, "Mr. Mime");
            TypeLookup.Add(123, "Scyther");
            TypeLookup.Add(124, "Jynx");
            TypeLookup.Add(125, "Electabuzz");
            TypeLookup.Add(126, "Magmar");
            TypeLookup.Add(127, "Pinsir");
            TypeLookup.Add(128, "Tauros");
            TypeLookup.Add(129, "Magikarp");
            TypeLookup.Add(130, "Gyarados");
            TypeLookup.Add(131, "Lapras");
            TypeLookup.Add(132, "Ditto");
            TypeLookup.Add(133, "Eevee");
            TypeLookup.Add(134, "Vaporeon");
            TypeLookup.Add(135, "Jolteon");
            TypeLookup.Add(136, "Flareon");
            TypeLookup.Add(137, "Porygon");
            TypeLookup.Add(138, "Omanyte");
            TypeLookup.Add(139, "Omastar");
            TypeLookup.Add(140, "Kabuto");
            TypeLookup.Add(141, "Kabutops");
            TypeLookup.Add(142, "Aerodactyl");
            TypeLookup.Add(143, "Snorlax");
            TypeLookup.Add(144, "Articuno");
            TypeLookup.Add(145, "Zapdos");
            TypeLookup.Add(146, "Moltres");
            TypeLookup.Add(147, "Dratini");
            TypeLookup.Add(148, "Dragonair");
            TypeLookup.Add(149, "Dragonite");
            TypeLookup.Add(150, "Mewtwo");
            TypeLookup.Add(151, "Mew");
            TypeLookup.Add(152, "Chikorita");
            TypeLookup.Add(153, "Bayleef");
            TypeLookup.Add(154, "Meganium");
            TypeLookup.Add(155, "Cyndaquil");
            TypeLookup.Add(156, "Quilava");
            TypeLookup.Add(157, "Typhlosion");
            TypeLookup.Add(158, "Totodile");
            TypeLookup.Add(159, "Croconaw");
            TypeLookup.Add(160, "Feraligatr");
            TypeLookup.Add(161, "Sentret");
            TypeLookup.Add(162, "Furret");
            TypeLookup.Add(163, "Hoothoot");
            TypeLookup.Add(164, "Noctowl");
            TypeLookup.Add(165, "Ledyba");
            TypeLookup.Add(166, "Ledian");
            TypeLookup.Add(167, "Spinarak");
            TypeLookup.Add(168, "Ariados");
            TypeLookup.Add(169, "Crobat");
            TypeLookup.Add(170, "Chinchou");
            TypeLookup.Add(171, "Lanturn");
            TypeLookup.Add(172, "Pichu");
            TypeLookup.Add(173, "Cleffa");
            TypeLookup.Add(174, "Igglybuff");
            TypeLookup.Add(175, "Togepi");
            TypeLookup.Add(176, "Togetic");
            TypeLookup.Add(177, "Natu");
            TypeLookup.Add(178, "Xatu");
            TypeLookup.Add(179, "Mareep");
            TypeLookup.Add(180, "Flaaffy");
            TypeLookup.Add(181, "Ampharos");
            TypeLookup.Add(182, "Bellossom");
            TypeLookup.Add(183, "Marill");
            TypeLookup.Add(184, "Azumarill");
            TypeLookup.Add(185, "Sudowoodo");
            TypeLookup.Add(186, "Politoed");
            TypeLookup.Add(187, "Hoppip");
            TypeLookup.Add(188, "Skiploom");
            TypeLookup.Add(189, "Jumpluff");
            TypeLookup.Add(190, "Aipom");
            TypeLookup.Add(191, "Sunkern");
            TypeLookup.Add(192, "Sunflora");
            TypeLookup.Add(193, "Yanma");
            TypeLookup.Add(194, "Wooper");
            TypeLookup.Add(195, "Quagsire");
            TypeLookup.Add(196, "Espeon");
            TypeLookup.Add(197, "Umbreon");
            TypeLookup.Add(198, "Murkrow");
            TypeLookup.Add(199, "Slowking");
            TypeLookup.Add(200, "Misdreavus");
            TypeLookup.Add(201, "Unown");
            TypeLookup.Add(202, "Wobbuffet");
            TypeLookup.Add(203, "Girafarig");
            TypeLookup.Add(204, "Pineco");
            TypeLookup.Add(205, "Forretress");
            TypeLookup.Add(206, "Dunsparce");
            TypeLookup.Add(207, "Gligar");
            TypeLookup.Add(208, "Steelix");
            TypeLookup.Add(209, "Snubbull");
            TypeLookup.Add(210, "Granbull");
            TypeLookup.Add(211, "Qwilfish");
            TypeLookup.Add(212, "Scizor");
            TypeLookup.Add(213, "Shuckle");
            TypeLookup.Add(214, "Heracross");
            TypeLookup.Add(215, "Sneasel");
            TypeLookup.Add(216, "Teddiursa");
            TypeLookup.Add(217, "Ursaring");
            TypeLookup.Add(218, "Slugma");
            TypeLookup.Add(219, "Magcargo");
            TypeLookup.Add(220, "Swinub");
            TypeLookup.Add(221, "Piloswine");
            TypeLookup.Add(222, "Corsola");
            TypeLookup.Add(223, "Remoraid");
            TypeLookup.Add(224, "Octillery");
            TypeLookup.Add(225, "Delibird");
            TypeLookup.Add(226, "Mantine");
            TypeLookup.Add(227, "Skarmory");
            TypeLookup.Add(228, "Houndour");
            TypeLookup.Add(229, "Houndoom");
            TypeLookup.Add(230, "Kingdra");
            TypeLookup.Add(231, "Phanpy");
            TypeLookup.Add(232, "Donphan");
            TypeLookup.Add(233, "Porygon2");
            TypeLookup.Add(234, "Stantler");
            TypeLookup.Add(235, "Smeargle");
            TypeLookup.Add(236, "Tyrogue");
            TypeLookup.Add(237, "Hitmontop");
            TypeLookup.Add(238, "Smoochum");
            TypeLookup.Add(239, "Elekid");
            TypeLookup.Add(240, "Magby");
            TypeLookup.Add(241, "Miltank");
            TypeLookup.Add(242, "Blissey");
            TypeLookup.Add(243, "Raikou");
            TypeLookup.Add(244, "Entei");
            TypeLookup.Add(245, "Suicune");
            TypeLookup.Add(246, "Larvitar");
            TypeLookup.Add(247, "Pupitar");
            TypeLookup.Add(248, "Tyranitar");
            TypeLookup.Add(249, "Lugia");
            TypeLookup.Add(250, "Ho-Oh");
            TypeLookup.Add(251, "Celebi");
            TypeLookup.Add(252, "Treecko");
            TypeLookup.Add(253, "Grovyle");
            TypeLookup.Add(254, "Sceptile");
            TypeLookup.Add(255, "Torchic");
            TypeLookup.Add(256, "Combusken");
            TypeLookup.Add(257, "Blaziken");
            TypeLookup.Add(258, "Mudkip");
            TypeLookup.Add(259, "Marshtomp");
            TypeLookup.Add(260, "Swampert");
            TypeLookup.Add(261, "Poochyena");
            TypeLookup.Add(262, "Mightyena");
            TypeLookup.Add(263, "Zigzagoon");
            TypeLookup.Add(264, "Linoone");
            TypeLookup.Add(265, "Wurmple");
            TypeLookup.Add(266, "Silcoon");
            TypeLookup.Add(267, "Beautifly");
            TypeLookup.Add(268, "Cascoon");
            TypeLookup.Add(269, "Dustox");
            TypeLookup.Add(270, "Lotad");
            TypeLookup.Add(271, "Lombre");
            TypeLookup.Add(272, "Ludicolo");
            TypeLookup.Add(273, "Seedot");
            TypeLookup.Add(274, "Nuzleaf");
            TypeLookup.Add(275, "Shiftry");
            TypeLookup.Add(276, "Taillow");
            TypeLookup.Add(277, "Swellow");
            TypeLookup.Add(278, "Wingull");
            TypeLookup.Add(279, "Pelipper");
            TypeLookup.Add(280, "Ralts");
            TypeLookup.Add(281, "Kirlia");
            TypeLookup.Add(282, "Gardevoir");
            TypeLookup.Add(283, "Surskit");
            TypeLookup.Add(284, "Masquerain");
            TypeLookup.Add(285, "Shroomish");
            TypeLookup.Add(286, "Breloom");
            TypeLookup.Add(287, "Slakoth");
            TypeLookup.Add(288, "Vigoroth");
            TypeLookup.Add(289, "Slaking");
            TypeLookup.Add(290, "Nincada");
            TypeLookup.Add(291, "Ninjask");
            TypeLookup.Add(292, "Shedinja");
            TypeLookup.Add(293, "Whismur");
            TypeLookup.Add(294, "Loudred");
            TypeLookup.Add(295, "Exploud");
            TypeLookup.Add(296, "Makuhita");
            TypeLookup.Add(297, "Hariyama");
            TypeLookup.Add(298, "Azurill");
            TypeLookup.Add(299, "Nosepass");
            TypeLookup.Add(300, "Skitty");
            TypeLookup.Add(301, "Delcatty");
            TypeLookup.Add(302, "Sableye");
            TypeLookup.Add(303, "Mawile");
            TypeLookup.Add(304, "Aron");
            TypeLookup.Add(305, "Lairon");
            TypeLookup.Add(306, "Aggron");
            TypeLookup.Add(307, "Meditite");
            TypeLookup.Add(308, "Medicham");
            TypeLookup.Add(309, "Electrike");
            TypeLookup.Add(310, "Manectric");
            TypeLookup.Add(311, "Plusle");
            TypeLookup.Add(312, "Minun");
            TypeLookup.Add(313, "Volbeat");
            TypeLookup.Add(314, "Illumise");
            TypeLookup.Add(315, "Roselia");
            TypeLookup.Add(316, "Gulpin");
            TypeLookup.Add(317, "Swalot");
            TypeLookup.Add(318, "Carvanha");
            TypeLookup.Add(319, "Sharpedo");
            TypeLookup.Add(320, "Wailmer");
            TypeLookup.Add(321, "Wailord");
            TypeLookup.Add(322, "Numel");
            TypeLookup.Add(323, "Camerupt");
            TypeLookup.Add(324, "Torkoal");
            TypeLookup.Add(325, "Spoink");
            TypeLookup.Add(326, "Grumpig");
            TypeLookup.Add(327, "Spinda");
            TypeLookup.Add(328, "Trapinch");
            TypeLookup.Add(329, "Vibrava");
            TypeLookup.Add(330, "Flygon");
            TypeLookup.Add(331, "Cacnea");
            TypeLookup.Add(332, "Cacturne");
            TypeLookup.Add(333, "Swablu");
            TypeLookup.Add(334, "Altaria");
            TypeLookup.Add(335, "Zangoose");
            TypeLookup.Add(336, "Seviper");
            TypeLookup.Add(337, "Lunatone");
            TypeLookup.Add(338, "Solrock");
            TypeLookup.Add(339, "Barboach");
            TypeLookup.Add(340, "Whiscash");
            TypeLookup.Add(341, "Corphish");
            TypeLookup.Add(342, "Crawdaunt");
            TypeLookup.Add(343, "Baltoy");
            TypeLookup.Add(344, "Claydol");
            TypeLookup.Add(345, "Lileep");
            TypeLookup.Add(346, "Cradily");
            TypeLookup.Add(347, "Anorith");
            TypeLookup.Add(348, "Armaldo");
            TypeLookup.Add(349, "Feebas");
            TypeLookup.Add(350, "Milotic");
            TypeLookup.Add(351, "Castform");
            TypeLookup.Add(352, "Kecleon");
            TypeLookup.Add(353, "Shuppet");
            TypeLookup.Add(354, "Banette");
            TypeLookup.Add(355, "Duskull");
            TypeLookup.Add(356, "Dusclops");
            TypeLookup.Add(357, "Tropius");
            TypeLookup.Add(358, "Chimecho");
            TypeLookup.Add(359, "Absol");
            TypeLookup.Add(360, "Wynaut");
            TypeLookup.Add(361, "Snorunt");
            TypeLookup.Add(362, "Glalie");
            TypeLookup.Add(363, "Spheal");
            TypeLookup.Add(364, "Sealeo");
            TypeLookup.Add(365, "Walrein");
            TypeLookup.Add(366, "Clamperl");
            TypeLookup.Add(367, "Huntail");
            TypeLookup.Add(368, "Gorebyss");
            TypeLookup.Add(369, "Relicanth");
            TypeLookup.Add(370, "Luvdisc");
            TypeLookup.Add(371, "Bagon");
            TypeLookup.Add(372, "Shelgon");
            TypeLookup.Add(373, "Salamence");
            TypeLookup.Add(374, "Beldum");
            TypeLookup.Add(375, "Metang");
            TypeLookup.Add(376, "Metagross");
            TypeLookup.Add(377, "Regirock");
            TypeLookup.Add(378, "Regice");
            TypeLookup.Add(379, "Registeel");
            TypeLookup.Add(380, "Latias");
            TypeLookup.Add(381, "Latios");
            TypeLookup.Add(382, "Kyogre");
            TypeLookup.Add(383, "Groudon");
            TypeLookup.Add(384, "Rayquaza");
            TypeLookup.Add(385, "Jirachi");
            TypeLookup.Add(386, "Deoxys");
            TypeLookup.Add(387, "Turtwig");
            TypeLookup.Add(388, "Grotle");
            TypeLookup.Add(389, "Torterra");
            TypeLookup.Add(390, "Chimchar");
            TypeLookup.Add(391, "Monferno");
            TypeLookup.Add(392, "Infernape");
            TypeLookup.Add(393, "Piplup");
            TypeLookup.Add(394, "Prinplup");
            TypeLookup.Add(395, "Empoleon");
            TypeLookup.Add(396, "Starly");
            TypeLookup.Add(397, "Staravia");
            TypeLookup.Add(398, "Staraptor");
            TypeLookup.Add(399, "Bidoof");
            TypeLookup.Add(400, "Bibarel");
            TypeLookup.Add(401, "Kricketot");
            TypeLookup.Add(402, "Kricketune");
            TypeLookup.Add(403, "Shinx");
            TypeLookup.Add(404, "Luxio");
            TypeLookup.Add(405, "Luxray");
            TypeLookup.Add(406, "Budew");
            TypeLookup.Add(407, "Roserade");
            TypeLookup.Add(408, "Cranidos");
            TypeLookup.Add(409, "Rampardos");
            TypeLookup.Add(410, "Shieldon");
            TypeLookup.Add(411, "Bastiodon");
            TypeLookup.Add(412, "Burmy");
            TypeLookup.Add(413, "Wormadam");
            TypeLookup.Add(414, "Mothim");
            TypeLookup.Add(415, "Combee");
            TypeLookup.Add(416, "Vespiquen");
            TypeLookup.Add(417, "Pachirisu");
            TypeLookup.Add(418, "Buizel");
            TypeLookup.Add(419, "Floatzel");
            TypeLookup.Add(420, "Cherubi");
            TypeLookup.Add(421, "Cherrim");
            TypeLookup.Add(422, "Shellos");
            TypeLookup.Add(423, "Gastrodon");
            TypeLookup.Add(424, "Ambipom");
            TypeLookup.Add(425, "Drifloon");
            TypeLookup.Add(426, "Drifblim");
            TypeLookup.Add(427, "Buneary");
            TypeLookup.Add(428, "Lopunny");
            TypeLookup.Add(429, "Mismagius");
            TypeLookup.Add(430, "Honchkrow");
            TypeLookup.Add(431, "Glameow");
            TypeLookup.Add(432, "Purugly");
            TypeLookup.Add(433, "Chingling");
            TypeLookup.Add(434, "Stunky");
            TypeLookup.Add(435, "Skuntank");
            TypeLookup.Add(436, "Bronzor");
            TypeLookup.Add(437, "Bronzong");
            TypeLookup.Add(438, "Bonsly");
            TypeLookup.Add(439, "Mime Jr.");
            TypeLookup.Add(440, "Happiny");
            TypeLookup.Add(441, "Chatot");
            TypeLookup.Add(442, "Spiritomb");
            TypeLookup.Add(443, "Gible");
            TypeLookup.Add(444, "Gabite");
            TypeLookup.Add(445, "Garchomp");
            TypeLookup.Add(446, "Munchlax");
            TypeLookup.Add(447, "Riolu");
            TypeLookup.Add(448, "Lucario");
            TypeLookup.Add(449, "Hippopotas");
            TypeLookup.Add(450, "Hippowdon");
            TypeLookup.Add(451, "Skorupi");
            TypeLookup.Add(452, "Drapion");
            TypeLookup.Add(453, "Croagunk");
            TypeLookup.Add(454, "Toxicroak");
            TypeLookup.Add(455, "Carnivine");
            TypeLookup.Add(456, "Finneon");
            TypeLookup.Add(457, "Lumineon");
            TypeLookup.Add(458, "Mantyke");
            TypeLookup.Add(459, "Snover");
            TypeLookup.Add(460, "Abomasnow");
            TypeLookup.Add(461, "Weavile");
            TypeLookup.Add(462, "Magnezone");
            TypeLookup.Add(463, "Lickilicky");
            TypeLookup.Add(464, "Rhyperior");
            TypeLookup.Add(465, "Tangrowth");
            TypeLookup.Add(466, "Electivire");
            TypeLookup.Add(467, "Magmortar");
            TypeLookup.Add(468, "Togekiss");
            TypeLookup.Add(469, "Yanmega");
            TypeLookup.Add(470, "Leafeon");
            TypeLookup.Add(471, "Glaceon");
            TypeLookup.Add(472, "Gliscor");
            TypeLookup.Add(473, "Mamoswine");
            TypeLookup.Add(474, "Porygon-Z");
            TypeLookup.Add(475, "Gallade");
            TypeLookup.Add(476, "Probopass");
            TypeLookup.Add(477, "Dusknoir");
            TypeLookup.Add(478, "Froslass");
            TypeLookup.Add(479, "Rotom");
            TypeLookup.Add(480, "Uxie");
            TypeLookup.Add(481, "Mesprit");
            TypeLookup.Add(482, "Azelf");
            TypeLookup.Add(483, "Dialga");
            TypeLookup.Add(484, "Palkia");
            TypeLookup.Add(485, "Heatran");
            TypeLookup.Add(486, "Regigigas");
            TypeLookup.Add(487, "Giratina");
            TypeLookup.Add(488, "Cresselia");
            TypeLookup.Add(489, "Phione");
            TypeLookup.Add(490, "Manaphy");
            TypeLookup.Add(491, "Darkrai");
            TypeLookup.Add(492, "Shaymin");
            TypeLookup.Add(493, "Arceus");
            TypeLookup.Add(494, "Victini");
            TypeLookup.Add(495, "Snivy");
            TypeLookup.Add(496, "Servine");
            TypeLookup.Add(497, "Serperior");
            TypeLookup.Add(498, "Tepig");
            TypeLookup.Add(499, "Pignite");
            TypeLookup.Add(500, "Emboar");
            TypeLookup.Add(501, "Oshawott");
            TypeLookup.Add(502, "Dewott");
            TypeLookup.Add(503, "Samurott");
            TypeLookup.Add(504, "Patrat");
            TypeLookup.Add(505, "Watchog");
            TypeLookup.Add(506, "Lillipup");
            TypeLookup.Add(507, "Herdier");
            TypeLookup.Add(508, "Stoutland");
            TypeLookup.Add(509, "Purrloin");
            TypeLookup.Add(510, "Liepard");
            TypeLookup.Add(511, "Pansage");
            TypeLookup.Add(512, "Simisage");
            TypeLookup.Add(513, "Pansear");
            TypeLookup.Add(514, "Simisear");
            TypeLookup.Add(515, "Panpour");
            TypeLookup.Add(516, "Simipour");
            TypeLookup.Add(517, "Munna");
            TypeLookup.Add(518, "Musharna");
            TypeLookup.Add(519, "Pidove");
            TypeLookup.Add(520, "Tranquill");
            TypeLookup.Add(521, "Unfezant");
            TypeLookup.Add(522, "Blitzle");
            TypeLookup.Add(523, "Zebstrika");
            TypeLookup.Add(524, "Roggenrola");
            TypeLookup.Add(525, "Boldore");
            TypeLookup.Add(526, "Gigalith");
            TypeLookup.Add(527, "Woobat");
            TypeLookup.Add(528, "Swoobat");
            TypeLookup.Add(529, "Drilbur");
            TypeLookup.Add(530, "Excadrill");
            TypeLookup.Add(531, "Audino");
            TypeLookup.Add(532, "Timburr");
            TypeLookup.Add(533, "Gurdurr");
            TypeLookup.Add(534, "Conkeldurr");
            TypeLookup.Add(535, "Tympole");
            TypeLookup.Add(536, "Palpitoad");
            TypeLookup.Add(537, "Seismitoad");
            TypeLookup.Add(538, "Throh");
            TypeLookup.Add(539, "Sawk");
            TypeLookup.Add(540, "Sewaddle");
            TypeLookup.Add(541, "Swadloon");
            TypeLookup.Add(542, "Leavanny");
            TypeLookup.Add(543, "Venipede");
            TypeLookup.Add(544, "Whirlipede");
            TypeLookup.Add(545, "Scolipede");
            TypeLookup.Add(546, "Cottonee");
            TypeLookup.Add(547, "Whimsicott");
            TypeLookup.Add(548, "Petilil");
            TypeLookup.Add(549, "Lilligant");
            TypeLookup.Add(550, "Basculin");
            TypeLookup.Add(551, "Sandile");
            TypeLookup.Add(552, "Krokorok");
            TypeLookup.Add(553, "Krookodile");
            TypeLookup.Add(554, "Darumaka");
            TypeLookup.Add(555, "Darmanitan");
            TypeLookup.Add(556, "Maractus");
            TypeLookup.Add(557, "Dwebble");
            TypeLookup.Add(558, "Crustle");
            TypeLookup.Add(559, "Scraggy");
            TypeLookup.Add(560, "Scrafty");
            TypeLookup.Add(561, "Sigilyph");
            TypeLookup.Add(562, "Yamask");
            TypeLookup.Add(563, "Cofagrigus");
            TypeLookup.Add(564, "Tirtouga");
            TypeLookup.Add(565, "Carracosta");
            TypeLookup.Add(566, "Archen");
            TypeLookup.Add(567, "Archeops");
            TypeLookup.Add(568, "Trubbish");
            TypeLookup.Add(569, "Garbodor");
            TypeLookup.Add(570, "Zorua");
            TypeLookup.Add(571, "Zoroark");
            TypeLookup.Add(572, "Minccino");
            TypeLookup.Add(573, "Cinccino");
            TypeLookup.Add(574, "Gothita");
            TypeLookup.Add(575, "Gothorita");
            TypeLookup.Add(576, "Gothitelle");
            TypeLookup.Add(577, "Solosis");
            TypeLookup.Add(578, "Duosion");
            TypeLookup.Add(579, "Reuniclus");
            TypeLookup.Add(580, "Ducklett");
            TypeLookup.Add(581, "Swanna");
            TypeLookup.Add(582, "Vanillite");
            TypeLookup.Add(583, "Vanillish");
            TypeLookup.Add(584, "Vanilluxe");
            TypeLookup.Add(585, "Deerling");
            TypeLookup.Add(586, "Sawsbuck");
            TypeLookup.Add(587, "Emolga");
            TypeLookup.Add(588, "Karrablast");
            TypeLookup.Add(589, "Escavalier");
            TypeLookup.Add(590, "Foongus");
            TypeLookup.Add(591, "Amoonguss");
            TypeLookup.Add(592, "Frillish");
            TypeLookup.Add(593, "Jellicent");
            TypeLookup.Add(594, "Alomomola");
            TypeLookup.Add(595, "Joltik");
            TypeLookup.Add(596, "Galvantula");
            TypeLookup.Add(597, "Ferroseed");
            TypeLookup.Add(598, "Ferrothorn");
            TypeLookup.Add(599, "Klink");
            TypeLookup.Add(600, "Klang");
            TypeLookup.Add(601, "Klinklang");
            TypeLookup.Add(602, "Tynamo");
            TypeLookup.Add(603, "Eelektrik");
            TypeLookup.Add(604, "Eelektross");
            TypeLookup.Add(605, "Elgyem");
            TypeLookup.Add(606, "Beheeyem");
            TypeLookup.Add(607, "Litwick");
            TypeLookup.Add(608, "Lampent");
            TypeLookup.Add(609, "Chandelure");
            TypeLookup.Add(610, "Axew");
            TypeLookup.Add(611, "Fraxure");
            TypeLookup.Add(612, "Haxorus");
            TypeLookup.Add(613, "Cubchoo");
            TypeLookup.Add(614, "Beartic");
            TypeLookup.Add(615, "Cryogonal");
            TypeLookup.Add(616, "Shelmet");
            TypeLookup.Add(617, "Accelgor");
            TypeLookup.Add(618, "Stunfisk");
            TypeLookup.Add(619, "Mienfoo");
            TypeLookup.Add(620, "Mienshao");
            TypeLookup.Add(621, "Druddigon");
            TypeLookup.Add(622, "Golett");
            TypeLookup.Add(623, "Golurk");
            TypeLookup.Add(624, "Pawniard");
            TypeLookup.Add(625, "Bisharp");
            TypeLookup.Add(626, "Bouffalant");
            TypeLookup.Add(627, "Rufflet");
            TypeLookup.Add(628, "Braviary");
            TypeLookup.Add(629, "Vullaby");
            TypeLookup.Add(630, "Mandibuzz");
            TypeLookup.Add(631, "Heatmor");
            TypeLookup.Add(632, "Durant");
            TypeLookup.Add(633, "Deino");
            TypeLookup.Add(634, "Zweilous");
            TypeLookup.Add(635, "Hydreigon");
            TypeLookup.Add(636, "Larvesta");
            TypeLookup.Add(637, "Volcarona");
            TypeLookup.Add(638, "Cobalion");
            TypeLookup.Add(639, "Terrakion");
            TypeLookup.Add(640, "Virizion");
            TypeLookup.Add(641, "Tornadus");
            TypeLookup.Add(642, "Thundurus");
            TypeLookup.Add(643, "Reshiram");
            TypeLookup.Add(644, "Zekrom");
            TypeLookup.Add(645, "Landorus");
            TypeLookup.Add(646, "Kyurem");
            TypeLookup.Add(647, "Keldeo");
            TypeLookup.Add(648, "Meloetta");
            TypeLookup.Add(649, "Genesect");

            # endregion

            loadMoves();
        }

        public static void loadMoves()
        {
            string path = appPath + @"\Resources\movelist.xml";

            using (Stream stream = File.Open(path, FileMode.Open))
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<Move>));

                List<Move> moves = serial.Deserialize(stream) as List<Move>;

                foreach (Move m in moves)
                {
                    MoveLookup.Add(m.ID, m);
                }
            }
        }

        public static void loadMaps()
        {
            mapDir = appPath + @"\..\..\..\..\Pokémon\Pokémon\Resources\Maps\";

            if (!Directory.Exists(mapDir))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    mapDir = fbd.SelectedPath;
                }
            }

            Debug.WriteLine(mapDir);

            maps = Directory.GetFiles(mapDir).ToList();
        }

        public static void loadItems()
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<inventoryItem>));
            List<inventoryItem> itemList = new List<inventoryItem>();

            string file = appPath + @"\Resources\ItemList.xml";

            using (Stream stream = File.Open(file, FileMode.Open))
            {
                itemList = serial.Deserialize(stream) as List<inventoryItem>;
            }

            foreach (inventoryItem i in itemList)
            {
                ItemLookup.Add(i.ID, i);
            }

            Debug.WriteLine("{0} items in ItemLookup.", ItemLookup.Count);
        }
    }

}