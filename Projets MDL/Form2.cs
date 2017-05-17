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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            FillDataGridView();
        }

        void FillDataGridView()
        {

            DataTable Table = new DataTable();
            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("NOM", typeof(string));
            Table.Columns.Add("LIENSITE", typeof(string));
            Table.Columns.Add("ADRESSE", typeof(string));
            Table.Columns.Add("VILLE", typeof(string));
            Table.Columns.Add("CODEPOSTAL", typeof(int));
            Table.Columns.Add("TELEPHONE", typeof(int));
            Table.Columns.Add("EMAIL", typeof(string));
            Table.Columns.Add("TYPE", typeof(string));

            ModeleBDD con = new ModeleBDD();

            foreach (Clubs Club in con.getClubs())
            {
                Table.Rows.Add( Club.getId(), Club.getNom(),Club.getLienSite(), Club.getAdresse(), Club.getVille(), Club.getCPT(), Club.getTel(), Club.getEMail(), Club.getType().getLibelle());

            }

            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow Ranger = this.dataGridView1.Rows[e.RowIndex];
                textNom.Text = Ranger.Cells["Nom"].Value.ToString();
                textLienSite.Text = Ranger.Cells["LIENSITE"].Value.ToString();
                textAdresse.Text = Ranger.Cells["ADRESSE"].Value.ToString();
                textCPT.Text = Ranger.Cells["CODEPOSTAL"].Value.ToString();
                textVille.Text = Ranger.Cells["VILLE"].Value.ToString();
                textEmail.Text = Ranger.Cells["EMAIL"].Value.ToString();
                textTel.Text = Ranger.Cells["TELEPHONE"].Value.ToString();
                comboBox1.Text = Ranger.Cells["TYPE"].Value.ToString();
                textID.Text = Ranger.Cells["ID"].Value.ToString();

            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                TypeClub letype = new TypeClub();
                letype.setLibelle(comboBox1.Text);

                Clubs club = new Clubs();
                club.setLienSite(textLienSite.Text);
                club.setNom(textNom.Text);
                club.setMail(textEmail.Text);
                club.setType(letype);
                club.setAdresse(textAdresse.Text);
                club.setCPT(Int32.Parse(textCPT.Text));
                club.setVille(textVille.Text);
                club.setTel(Int32.Parse(textTel.Text));

                ModeleBDD bd = new ModeleBDD();

                bd.setClub(club);


                textNom.Text = "";
                textLienSite.Text = "";
                comboBox1.Text = "";
                textEmail.Text = "";
                textAdresse.Text = "";
                textCPT.Text = "";
                textVille.Text = "";
                textTel.Text = "";
                labelInfo.Text = club.getNom() + " a été ajouter avec succès ";
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
                TypeClub letype = new TypeClub();
                letype.setLibelle(comboBox1.Text);

                Clubs club = new Clubs();

                club.setId(Int32.Parse(textID.Text));
                club.setLienSite(textLienSite.Text);
                club.setNom(textNom.Text);
                club.setMail(textEmail.Text);
                club.setType(letype);
                club.setAdresse(textAdresse.Text);
                club.setCPT(Int32.Parse(textCPT.Text));
                club.setVille(textVille.Text);
                club.setTel(Int32.Parse(textTel.Text));

                ModeleBDD bd = new ModeleBDD();

                bd.UPDATEClub(club);

                labelInfo.Text = club.getNom() + " a été modifié ";
                dataGridView1.ClearSelection();
                FillDataGridView();
            } else
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
                con.subClub(id);
                labelInfo.Text = textNom + " a été supprimé";
                
                textID.Text = "";
                textNom.Text = "";
                textLienSite.Text = "";
                comboBox1.Text = "";
                textEmail.Text = "";
                textAdresse.Text = "";
                textCPT.Text = "";
                textVille.Text = "";
                textTel.Text = "";
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
            List<TypeClub> ListeType = con.getTypeClub();
            foreach (TypeClub liste in ListeType)
            {
                comboBox1.Items.Add(liste.getLibelle().ToString());
            }
        }

        private void buttonType_Click(object sender, EventArgs e)
        {
            Form5Type F5 = new Form5Type();
            F5.Show();
        }

        private bool condition()
        {
            bool resultat;
            if (textID.Text == "" || textNom.Text == "" || textLienSite.Text == "" || comboBox1.Text == "" || textEmail.Text == "" || textAdresse.Text == "" || textCPT.Text == "" || textVille.Text == "" || textTel.Text == "")
            {
                resultat = false;
            } else {
                resultat = true; 
            }
            return resultat;

        }

        private void textCPT_KeyPress(object sender, KeyPressEventArgs e)
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

        void chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textTel_KeyPress(object sender, KeyPressEventArgs e)
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
