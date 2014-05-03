using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PokémonGame;

namespace PokemonMapEditor
{
    public partial class ConversationEditor : UserControl
    {
        # region declarations
        public List<convoText> greeting = new List<convoText>();
        public List<convoText> farewell = new List<convoText>();

        public List<convoText> choices = new List<convoText>();

        private List<convoText> conversations = new List<convoText>();
        private int lInd = -1;

        private List<variable> reqs = new List<variable>();
        private List<variable> cons = new List<variable>();

        private Dictionary<int, string> itemList = new Dictionary<int, string>();
        # endregion

        # region delegate
        public delegate void close();

        public event close Saving;
        public event close Closing;

        protected void onSaving()
        {
            close handler = Saving;
            if (handler != null)
            {
                handler();
            }
        }

        protected void onClosing()
        {
            close handler = Closing;
            if (handler != null)
            {
                handler();
            }
        }
        # endregion

        public ConversationEditor()
        {
            InitializeComponent();
        }

        # region events
        # region buttons
        private void buttonSave_Click(object sender, EventArgs e)
        {
            onSaving();
            onClosing();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            onClosing();
        }

        private void buttonReqAdd_Click(object sender, EventArgs e)
        {
            variable v = new variable
            {
                name = textBoxReqName.Text,
                val = (int)numReqVal.Value
            };
            reqs.Add(v);

            textBoxReqName.Clear();
            numReqVal.Value = 0;

            updateReqs();

            textBoxReqName.Focus();
        }

        private void buttonConAdd_Click(object sender, EventArgs e)
        {
            variable v = new variable
            {
                name = textBoxConsName.Text,
                val = (int)numConsVal.Value
            };
            cons.Add(v);

            textBoxConsName.Clear();
            numConsVal.Value = 0;

            updateCons();

            textBoxConsName.Focus();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            createConvoText(false);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            createConvoText(true);
        }
        # endregion

        # region key events
        private void listViewReqs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in listViewReqs.SelectedItems)
                {
                    int index = lvi.Index;
                    reqs.RemoveAt(index);
                    listViewReqs.Items.RemoveAt(index);
                }

                updateReqs();
            }
        }

        private void listViewCons_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in listViewCons.SelectedItems)
                {
                    int index = lvi.Index;
                    cons.RemoveAt(index);
                    listViewCons.Items.RemoveAt(index);
                }

                updateCons();
            }
        }

        private void listViewConvos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in listViewConvos.SelectedItems)
                {
                    int index = lvi.Index;

                    conversations.RemoveAt(index);
                    listViewConvos.Items.RemoveAt(index);
                }

                updateConvos();
            }
        }
        # endregion

        # region selected index changed events
        private void listViewConvos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewConvos.SelectedIndices.Count > 0)
            {
                lInd = listViewConvos.SelectedIndices[0];
                buttonUpdate.Enabled = true;

                # region enter data
                reqs = conversations[lInd].requirements;
                cons = conversations[lInd].consequences;
                textBoxText.Text = conversations[lInd].Text;
                if (conversations[lInd].item != null)
                {
                    comboItem.Text = conversations[lInd].item.ID;
                    numItemCount.Value = conversations[lInd].item.count;
                }
                choices = conversations[lInd].choices;
                # endregion

                updateCons();
                updateReqs();
                ListviewChoices_update();
            }
        }

        private void listViewReqs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewReqs.SelectedIndices.Count > 0)
            {
                int ind = listViewReqs.SelectedIndices[0];

                textBoxReqName.Text = reqs[ind].name;
                numReqVal.Value = reqs[ind].val;

                textBoxReqName.Focus();
            }
        }

        private void listViewCons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCons.SelectedIndices.Count > 0)
            {
                int ind = listViewCons.SelectedIndices[0];

                textBoxConsName.Text = cons[ind].name;
                numConsVal.Value = cons[ind].val;

                textBoxConsName.Focus();
            }
        }
        # endregion
        # endregion

        # region methods
        # region Load/Save
        public void LoadConvoList(List<convoText> greet, List<convoText> fare)
        {
            conversations = new List<convoText>();

            conversations.AddRange(greet);
            conversations.AddRange(fare);

            updateConvos();

            comboItem.Items.Clear();
            foreach (inventoryItem i in Settings.ItemLookup.Values)
            {
                comboItem.Items.Add(i.ID + " - " + i.Name);
                itemList.Add(itemList.Count, i.ID);
            }
        }

        private void SaveConvoList()
        {

        }
        # endregion

        # region Updating
        private void updateReqs()
        {
            listViewReqs.OwnerDraw = true;
            listViewReqs.Items.Clear();

            foreach (variable v in reqs)
            {
                ListViewItem lvi = new ListViewItem(v.name);
                lvi.SubItems.Add(v.val.ToString());

                listViewReqs.Items.Add(lvi);
            }

            listViewReqs.OwnerDraw = false;
        }

        private void updateCons()
        {
            listViewCons.OwnerDraw = true;
            listViewCons.Items.Clear();

            foreach (variable v in cons)
            {
                ListViewItem lvi = new ListViewItem(v.name);
                lvi.SubItems.Add(v.val.ToString());

                listViewCons.Items.Add(lvi);
            }

            listViewCons.OwnerDraw = false;
        }

        private void updateConvos()
        {
            listViewConvos.OwnerDraw = true;
            listViewConvos.Items.Clear();

            splitGroups();

            greetings_update();

            farewells_update();

            ListviewChoices_update();

            listViewConvos.OwnerDraw = false;
        }

        private void greetings_update()
        {
            foreach (convoText ct in greeting)
            {
                ListViewItem lvi = new ListViewItem(ct.Text);
                lvi.SubItems.Add("Greeting");

                listViewConvos.Items.Add(lvi);
            }
        }

        private void farewells_update()
        {
            foreach (convoText ct in farewell)
            {
                ListViewItem lvi = new ListViewItem(ct.Text);
                lvi.SubItems.Add("Farewell");

                listViewConvos.Items.Add(lvi);
            }
        }

        private void ListviewChoices_update()
        {
            listViewChoices.Items.Clear();
            foreach (convoText ct in choices)
            {
                ListViewItem lvi = new ListViewItem(ct.Text);

                listViewChoices.Items.Add(lvi);
            }
        }

        private void splitGroups()
        {
            greeting = new List<convoText>();
            farewell = new List<convoText>();

            foreach (convoText ct in conversations)
            {
                switch (ct.type)
                {
                    case "Greeting":
                        greeting.Add(ct);
                        break;

                    case "Farewell":
                        farewell.Add(ct);
                        break;

                    default:
                        Debug.WriteLine(ct.type);
                        break;
                }
            }
        }

        # endregion

        private void createConvoText(bool replace)
        {
            convoText ct = new convoText();
            ct.Text = textBoxText.Text;

            # region variables
            foreach (variable v in reqs)
            {
                variable temp = new variable();
                temp.name = v.name;
                temp.val = v.val;

                ct.requirements.Add(temp);
            }
            # endregion

            # region consequences
            foreach (variable v in cons)
            {
                variable temp = new variable();
                temp.name = v.name;
                temp.val = v.val;

                ct.consequences.Add(temp);
            }
            # endregion

            # region choices
            ct.choices = choices;
            # endregion

            # region item
            if (comboItem.SelectedIndex >= 0)
            {
                if (Settings.ItemLookup.ContainsKey(itemList[comboItem.SelectedIndex]))
                {
                    ct.item = Settings.ItemLookup[itemList[comboItem.SelectedIndex]].Clone() as inventoryItem;
                    ct.item.count = (int)numItemCount.Value;
                }
            }
            # endregion

            # region set type
            if (radioGreeting.Checked)
            {
                ct.type = "Greeting";
            }
            else
            {
                ct.type = "Farewell";
            }
            # endregion

            # region replace or add
            if (replace)
            {
                conversations[lInd] = ct;
            }
            else
            {
                conversations.Add(ct);
            }
            # endregion

            # region clear fields
            textBoxText.Clear();

            reqs = new List<variable>();
            listViewReqs.Items.Clear();
            textBoxReqName.Clear();
            numReqVal.Value = 0;

            cons = new List<variable>();
            listViewCons.Items.Clear();
            textBoxConsName.Clear();
            numConsVal.Value = 0;

            choices = new List<convoText>();
            # endregion

            updateConvos();
            textBoxText.Focus();
            buttonUpdate.Enabled = false;
        }

        public void Clear()
        {
            listViewConvos.Items.Clear();
            listViewReqs.Items.Clear();
            listViewCons.Items.Clear();
            textBoxReqName.Clear();
            numReqVal.Value = 0;
            textBoxConsName.Clear();
            numConsVal.Value = 0;
        }
        # endregion

        private void buttonReqUpd_Click(object sender, EventArgs e)
        {
            if (listViewReqs.SelectedIndices.Count > 0)
            {
                int i = listViewReqs.SelectedIndices[0];

                reqs[i].name = textBoxReqName.Text;
                reqs[i].val = (int)numReqVal.Value;

                updateReqs();
            }
        }

        private void buttonConUpd_Click(object sender, EventArgs e)
        {
            if (listViewCons.SelectedIndices.Count > 0)
            {
                int i = listViewCons.SelectedIndices[0];

                cons[i].name = textBoxConsName.Text;
                cons[i].val = (int)numConsVal.Value;

                updateCons();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            convoText ct = new convoText();
            ct.Text = textBoxChoice.Text;
            choices.Add(ct);

            textBoxChoice.Clear();
            ListviewChoices_update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listViewChoices.SelectedItems.Count > 0)
            {
                int i = listViewChoices.SelectedItems[0].Index;

                choices.RemoveAt(i);
            }

            ListviewChoices_update();
        }

    }
}
