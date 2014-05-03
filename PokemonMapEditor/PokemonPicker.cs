using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PokémonGame;

namespace PokemonMapEditor
{
    public partial class PokemonPicker : UserControl
    {
        public List<PokemonBase> pokemon = new List<PokemonBase>();
        protected int LVindex = -1;
        private List<Move> moves = new List<Move>();

        # region delegates and events
        public delegate void close();
        public event close Save;
        public event close Cancel;
        public event close Closing;

        private void onClosing()
        {
            close handler = Closing;
            if (handler != null)
            {
                handler();
            }
        }

        private void onSaving()
        {
            close handler = Save;
            if (handler != null)
            {
                handler();
            }
        }

        private void onCancel()
        {
            close handler = Cancel;
            if (handler != null)
            {
                handler();
            }
        }
        #endregion

        public PokemonPicker()
        {
            InitializeComponent();
        }

        public void LoadPokemonNames()
        {
            foreach (KeyValuePair<int, string> k in Settings.TypeLookup)
            {
                comboType.Items.Add(k.Key + " - " + k.Value);
            }

            foreach (Move m in Settings.MoveLookup.Values)
            {
                string s = m.ID + " - " + m.Name;

                comboMove1.Items.Add(s);
                comboMove2.Items.Add(s);
                comboMove3.Items.Add(s);
                comboMove4.Items.Add(s);

                moves.Add(m);
            }
        }

        # region buttons
        private void buttonSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Save Clicked.");
            onSaving();
            onClosing();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            onCancel();
            onClosing();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PokemonBase poke = new PokemonBase
            {
                Name = textName.Text,
                ID = comboType.SelectedIndex + 1,
                Level = (int)numLevel.Value,
                Gender = checkFemale.Checked,
            };

            System.Diagnostics.Debug.WriteLine(pokemon.Count);

            if (poke.ID < 1)
            {
                return;
            }

            # region moves

            # endregion

            if (LVindex > 0)
            {
                pokemon[LVindex] = poke;
            }
            else
            {
                pokemon.Add(poke);
            }

            LVindex = -1;

            updateListView();
        }
        # endregion

        # region methods
        public void LoadGroup(List<PokemonBase> pokemonList)
        {
            pokemon.Clear();
            foreach (PokemonBase p in pokemonList)
            {
                pokemon.Add(p);
            }

            updateListView();
        }

        private void LoadPokemon(int i)
        {
            PokemonBase p = pokemon[i];

            textName.Text = p.Name;
            comboType.SelectedIndex = p.ID - 1;
            numLevel.Value = p.Level;
            checkFemale.Checked = p.Gender;

            p.moves[0] = moves[comboMove1.SelectedIndex];
            p.moves[1] = moves[comboMove2.SelectedIndex];
            p.moves[2] = moves[comboMove3.SelectedIndex];
            p.moves[3] = moves[comboMove4.SelectedIndex];
        }

        private void updateListView()
        {
            listView1.Items.Clear();

            foreach (PokemonBase p in pokemon)
            {
                # region create ListViewItem
                ListViewItem lvi = new ListViewItem(p.Name);
                lvi.SubItems.Add(Settings.TypeLookup[p.ID]);
                # endregion

                listView1.Items.Add(lvi);
            }
        }
        # endregion

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
            {
                LVindex = -1;
                return;
            }

            LVindex = listView1.SelectedIndices[0];

            LoadPokemon(LVindex);
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    pokemon.RemoveAt(lvi.Index);
                    listView1.Items.RemoveAt(lvi.Index);
                }
            }
        }
    }
}
