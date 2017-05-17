using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projets_MDL
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            FillDataGridView();
            comboBox2.SelectedIndex = 0;
        }

        void FillDataGridView()
        {

            DataTable Table = new DataTable();
            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("CLUB", typeof(string));
            Table.Columns.Add("TITRE", typeof(string));
            Table.Columns.Add("TYPE", typeof(string));
            Table.Columns.Add("LIENSITE", typeof(string));
            Table.Columns.Add("ADRESSE", typeof(string));
            Table.Columns.Add("VILLE", typeof(string));
            Table.Columns.Add("CODEPOSTAL", typeof(int));
            Table.Columns.Add("DATE", typeof(DateTime));
            
            ModeleBDD con = new ModeleBDD();

            foreach(Evenements E in con.getEvent())
            {
                Table.Rows.Add(E.getId(), E.getClub().getNom(), E.getTitre(), E.getType(), E.getLienSite(), E.getAdresse(), E.getVille(), E.getCPT(), E.getMoment());

            }

            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Ranger = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = Ranger.Cells["TITRE"].Value.ToString();
                textBox2.Text = Ranger.Cells["LIENSITE"].Value.ToString();
                textBox3.Text = Ranger.Cells["ADRESSE"].Value.ToString();
                textBox4.Text = Ranger.Cells["CODEPOSTAL"].Value.ToString();
                textBox7.Text = Ranger.Cells["VILLE"].Value.ToString();
                dateTimePicker1.Value = (DateTime)Ranger.Cells["DATE"].Value;
                comboBox2.Text = Ranger.Cells["TYPE"].Value.ToString();
                comboBox1.Text = Ranger.Cells["CLUB"].Value.ToString();
                textID.Text = Ranger.Cells["ID"].Value.ToString();

            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                Clubs club = new Clubs();
                club.setNom(comboBox1.Text);

                Evenements Event = new Evenements();
                Event.setTitre(textBox1.Text);
                Event.setLienSite(textBox2.Text);
                Event.setMoment(dateTimePicker1.Value);
                Event.setClub(club);
                Event.setType(comboBox2.Text);
                Event.setVille(textBox7.Text);
                Event.setCPT(Int32.Parse(textBox4.Text));
                Event.setAdresse(textBox3.Text);
                ModeleBDD con = new ModeleBDD();
                con.setEvent(Event);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                textBox7.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";

                
                dataGridView1.ClearSelection();
                FillDataGridView();
            } else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                Clubs club = new Clubs();
                club.setNom(comboBox1.Text);

                Evenements Event = new Evenements();
                Event.setId(Int32.Parse(textID.Text));
                Event.setClub(club);
                Event.setTitre(textBox1.Text);
                Event.setMoment(dateTimePicker1.Value);
                Event.setLienSite(textBox2.Text);
                Event.setType(comboBox2.Text);
                Event.setAdresse(textBox3.Text);
                Event.setVille(textBox7.Text);
                Event.setCPT(Int32.Parse(textBox4.Text));


                ModeleBDD con = new ModeleBDD();

                con.UPDATEEvent(Event);

                //labelInfo.Text = club.getNom() + " a été modifié ";
                dataGridView1.ClearSelection();
                FillDataGridView();
            }else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                int id = Int32.Parse(textID.Text);
                ModeleBDD con = new ModeleBDD();
                con.supEvent(id);

                textID.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                textBox7.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                dataGridView1.ClearSelection();
                FillDataGridView();
            } else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            ModeleBDD con = new ModeleBDD();
            List<Clubs> ListeClubs = con.getClubs();
            foreach (Clubs liste in ListeClubs)
            {
                comboBox1.Items.Add(liste.getNom().ToString());
            }
        }

        private bool condition()
        {
            bool resultat;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                resultat = false;
            } else
            {
                resultat = true;
            }
            return resultat;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
