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

        /// <summary>
        /// Alimente la datagriedview avec la base de donnée
        /// </summary>
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
            Table.Columns.Add("NAISSANCE", typeof(DateTime));
            
            ModeleBDD con = new ModeleBDD();

            foreach(Adherents adherent in con.getAdherents())
            {
                Table.Rows.Add(adherent.getId(), adherent.getClub().getNom(), adherent.getSexe(), adherent.getNom(), adherent.getPrenom(), adherent.getAdresse(), adherent.getCPT(), adherent.getLicence(), adherent.getCotisation(), adherent.getVille(), adherent.getNaissance());
            }

            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }

        /// <summary>
        /// Rempli les textBox selon la selection sur la table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Ranger = this.dataGridView1.Rows[e.RowIndex];
                textID.Text = Ranger.Cells["ID"].Value.ToString();
                comboBox2.Text = Ranger.Cells["CLUB"].Value.ToString();
                comboBox1.Text = Ranger.Cells["SEXE"].Value.ToString();
                textNom.Text = Ranger.Cells["Nom"].Value.ToString();
                textPrenom.Text = Ranger.Cells["Prenom"].Value.ToString();
                textAdresse.Text = Ranger.Cells["ADRESSE"].Value.ToString();
                textCodePostal.Text = Ranger.Cells["CODEPOSTAL"].Value.ToString();
                textLicence.Text = Ranger.Cells["LICENCE"].Value.ToString();
                textCotisation.Text = Ranger.Cells["COTISATION"].Value.ToString();
                textVille.Text = Ranger.Cells["VILLE"].Value.ToString();
                dateTimePicker1.Value = (DateTime)Ranger.Cells["NAISSANCE"].Value;
                
            }
        }

        /// <summary>
        /// Ajoute un évènements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">l'évènement à ajouter</param>
        private void buttonInsertion_Click(object sender, EventArgs e)
        {
            if (condition()){
                if (verifiLicence()) {
                    Clubs club = new Clubs();
                    club.setNom(comboBox2.Text);
                    Adherents adherent = new Adherents();
                    adherent.setClub(club);
                    adherent.setSexe(comboBox1.Text);
                    adherent.setNom(textNom.Text);
                    adherent.setPrenom(textPrenom.Text);
                    adherent.setLicence(textLicence.Text);
                    adherent.setNaissance(dateTimePicker1.Value);
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
                    //dateTimePicker1.Value = DateTime.Now;
                    textAdresse.Text = "";
                    textCodePostal.Text = "";
                    textVille.Text = "";
                    textCotisation.Text = "";
                    label10.Text = adherent.getNom() + " a été ajouter avec succès ";
                    dataGridView1.ClearSelection();
                    FillDataGridView();
                } else
                    {
                        MessageBox.Show("La Licence doit être unique");
                    }
            } else
                {
                    MessageBox.Show("Veuillez rmplir tout les champs");
                }
        }

        /// <summary>
        /// Modifie l'évènement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                if (verifiLicence())
                {
                    Clubs club = new Clubs();
                    club.setNom(comboBox2.Text);
                    Adherents adherent = new Adherents();
                    adherent.setId(Int32.Parse(textID.Text));
                    adherent.setClub(club);
                    adherent.setSexe(comboBox1.Text);
                    adherent.setNom(textNom.Text);
                    adherent.setPrenom(textPrenom.Text);
                    adherent.setLicence(textLicence.Text);
                    adherent.setNaissance(dateTimePicker1.Value);
                    adherent.setAdresse(textAdresse.Text);
                    adherent.setCPT(Int32.Parse(textCodePostal.Text));
                    adherent.setVille(textVille.Text);
                    adherent.setCotisation(Int32.Parse(textCotisation.Text));

                    ModeleBDD bd = new ModeleBDD();

                    bd.UPDATEAdherent(adherent);

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textID.Text = "";
                    textNom.Text = "";
                    textPrenom.Text = "";
                    textLicence.Text = "";
                    //dateTimePicker1.Value = DateTime.Now;
                    textAdresse.Text = "";
                    textCodePostal.Text = "";
                    textVille.Text = "";
                    textCotisation.Text = "";
                    label10.Text = adherent.getNom() + " a été modifié ";
                    dataGridView1.ClearSelection();
                    FillDataGridView();
                } else
                {
                    MessageBox.Show("La licence doit être unique");
                }
            } else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }

        /// <summary>
        /// Supprime un évènement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                int id = Int32.Parse(textID.Text);
                ModeleBDD con = new ModeleBDD();
                con.supAdherents(id);
                label10.Text = textNom.Text + " a été supprimé ";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textID.Text = "";
                textNom.Text = "";
                textPrenom.Text = "";
                textLicence.Text = "";
                //dateTimePicker1.Value = DateTime.Now;
                textAdresse.Text = "";
                textCodePostal.Text = "";
                textVille.Text = "";
                textCotisation.Text = "";

                dataGridView1.ClearSelection();
                FillDataGridView();
            } else
            {
                MessageBox.Show("Veuilez remplir tout les champs");
            }
        }
        
        /// <summary>
        /// Alimente la liste avec les clubs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Vérifie si tous les champs sont remplis
        /// </summary>
        /// <returns>return vria si tous les champs sont remplis</returns>
        private bool condition()
        {
            bool resultat;
            if (comboBox1.Text == "" || textNom.Text == "" || textPrenom.Text == "" || comboBox2.Text == "" || textLicence.Text == "" || textAdresse.Text == "" || textCodePostal.Text == "" || textVille.Text == "" || textCotisation.Text == "" || dateTimePicker1.Text == "")
            {
                resultat = false;
            }
            else
            {
                resultat = true;
            }
            return resultat;

        }

        /// <summary>
        /// Vérifie que la licence est unique
        /// </summary>
        /// <returns></returns>
        private bool verifiLicence()
        {
            bool unique = false;

            ModeleBDD con = new ModeleBDD();
            foreach(var adherent in con.VerifLicence())
            {
                if(adherent.getLicence() == textLicence.Text)
                {
                    unique = false;
                } else
                {
                    unique = true;
                }
            }
            return unique;
        }

        /// <summary>
        /// Met le valeur par defaut de Sexe, la date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }


        /// <summary>
        /// Empêche l'utilisateur d'entre des caractéres.
        /// Uniquement des chifrres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCotisation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Empêche l'utilisateur d'entre des caractéres.
        /// Uniquement des chifrres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCodePostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
