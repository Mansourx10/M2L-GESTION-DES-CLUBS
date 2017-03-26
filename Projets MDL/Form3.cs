using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projets_MDL
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void buttonInsertion_Click(object sender, EventArgs e)
        {
            Adherents adherent = new Adherents();

            adherent.setSexe(comboBox1.Text);
            adherent.setNom(textNom.Text);
            adherent.setPrenom(textPrenom.Text);
            adherent.setNumeroLicence(textLicence.Text);
            adherent.setNaissance(textNaissance.Text);
            adherent.setAdresse(textAdresse.Text);
            adherent.setCPT(Int32.Parse(textCodePostal.Text));
            adherent.setVille(textVille.Text);
            adherent.setCotisation(Int32.Parse(textCotisation.Text));

            ModeleBDD bd = new ModeleBDD();

            bd.setAdherent(adherent);

            comboBox1.Text = "";
            textNom.Text = "";
            textPrenom.Text = "";
            textLicence.Text = "";
            textNaissance.Text = "";
            textAdresse.Text = "";
            textCodePostal.Text = "";
            textVille.Text = "";
            textCotisation.Text = "";
            label10.Text = adherent.getNom() + " a été ajouter avec succès ";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Supprimer fenetreSup = new Supprimer();
            fenetreSup.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
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
                Table.Rows.Add(adherent.getSexe(), adherent.getNom(), adherent.getPrenom(), adherent.getAdresse(), adherent.getCPT(), adherent.getNumeroLicence(), adherent.getCotisation(), adherent.getVille(), adherent.getNaissance());

            }

            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();

            

        }


    }
}
