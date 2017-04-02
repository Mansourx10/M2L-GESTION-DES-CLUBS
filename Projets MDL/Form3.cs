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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            DataTable Table = new DataTable();
            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("CLUB", typeof(string));
            Table.Columns.Add("SEXE", typeof(string));
            Table.Columns.Add("NOM", typeof(string));
            Table.Columns.Add("PRENOM", typeof(string));
            Table.Columns.Add("ADRESSE", typeof(string));
            Table.Columns.Add("CODEPOSTAL", typeof(int));
            Table.Columns.Add("LICENCE", typeof(string));
            Table.Columns.Add("COTISATION", typeof(int));
            Table.Columns.Add("VILLE", typeof(string));
            Table.Columns.Add("NAISSANCE", typeof(string));
            
            ModeleBDD con = new ModeleBDD();

            foreach(Adherents adherent in con.getAdherents())
            {
                Table.Rows.Add(adherent.getId(), adherent.getClub().getNom(), adherent.getSexe(), adherent.getNom(), adherent.getPrenom(), adherent.getAdresse(), adherent.getCPT(), adherent.getLicence(), adherent.getCotisation(), adherent.getVille(), adherent.getNaissance());
            }

            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Ranger = this.dataGridView1.Rows[e.RowIndex];
                labelID.Text = Ranger.Cells["ID"].Value.ToString();
                comboBox2.Text = Ranger.Cells["CLUB"].Value.ToString();
                comboBox1.Text = Ranger.Cells["SEXE"].Value.ToString();
                textNom.Text = Ranger.Cells["Nom"].Value.ToString();
                textPrenom.Text = Ranger.Cells["Prenom"].Value.ToString();
                textAdresse.Text = Ranger.Cells["ADRESSE"].Value.ToString();
                textCodePostal.Text = Ranger.Cells["CODEPOSTAL"].Value.ToString();
                textLicence.Text = Ranger.Cells["LICENCE"].Value.ToString();
                textCotisation.Text = Ranger.Cells["COTISATION"].Value.ToString();
                textVille.Text = Ranger.Cells["VILLE"].Value.ToString();
                textNaissance.Text = Ranger.Cells["NAISSANCE"].Value.ToString();
                
            }
        }

        private void buttonInsertion_Click(object sender, EventArgs e)
        {
            Clubs club = new Clubs();
            club.setNom(comboBox2.Text);
            Adherents adherent = new Adherents();
            adherent.setClub(club);
            adherent.setSexe(comboBox1.Text);
            adherent.setNom(textNom.Text);
            adherent.setPrenom(textPrenom.Text);
            adherent.setLicence(textLicence.Text);
            adherent.setNaissance(textNaissance.Text);
            adherent.setAdresse(textAdresse.Text);
            adherent.setCPT(Int32.Parse(textCodePostal.Text));
            adherent.setVille(textVille.Text);
            adherent.setCotisation(Int32.Parse(textCotisation.Text));

            ModeleBDD bd = new ModeleBDD();

            bd.setAdherent(adherent);

            comboBox1.Text = "";
            comboBox2.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textLicence.Text = "";
            textNaissance.Text = "";
            textAdresse.Text = "";
            textCodePostal.Text = "";
            textVille.Text = "";
            textCotisation.Text = "";
            label10.Text = adherent.getNom() + " a été ajouter avec succès ";
            dataGridView1.ClearSelection();
            FillDataGridView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Clubs club = new Clubs();
            club.setNom(comboBox2.Text);
            Adherents adherent = new Adherents();
            adherent.setClub(club);
            adherent.setSexe(comboBox1.Text);
            adherent.setNom(textNom.Text);
            adherent.setPrenom(textPrenom.Text);
            adherent.setLicence(textLicence.Text);
            adherent.setNaissance(textNaissance.Text);
            adherent.setAdresse(textAdresse.Text);
            adherent.setCPT(Int32.Parse(textCodePostal.Text));
            adherent.setVille(textVille.Text);
            adherent.setCotisation(Int32.Parse(textCotisation.Text));

            ModeleBDD bd = new ModeleBDD();

            bd.UPDATEAdherent(adherent);

            comboBox1.Text = "";
            comboBox2.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textLicence.Text = "";
            textNaissance.Text = "";
            textAdresse.Text = "";
            textCodePostal.Text = "";
            textVille.Text = "";
            textCotisation.Text = "";
            label10.Text = adherent.getNom() + " a été modifié ";
            dataGridView1.ClearSelection();
            FillDataGridView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(labelID.Text);
            ModeleBDD con = new ModeleBDD();
            con.supAdherents(id);
            label10.Text = textNom.Text + " a été supprimé ";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textLicence.Text = "";
            textNaissance.Text = "";
            textAdresse.Text = "";
            textCodePostal.Text = "";
            textVille.Text = "";
            textCotisation.Text = "";
            
            dataGridView1.ClearSelection();
            FillDataGridView();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            ModeleBDD con = new ModeleBDD();
            List<Clubs> ListeType = con.getClubs();
            foreach (Clubs liste in ListeType)
            {
                comboBox2.Items.Add(liste.getNom().ToString());
            }
        }
    }
}
