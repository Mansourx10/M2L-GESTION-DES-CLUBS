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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                ModeleBDD con = new ModeleBDD();
                List<Clubs> ListeType = con.getClubs();
                foreach (Clubs liste in ListeType)
                {
                    comboBox1.Items.Add(liste.getNom().ToString());
                }
            }
            catch (Exception e4)
            {
                MessageBox.Show("Message d'erreur : " + e4.Message + " \nType de l'exception " + e4.GetType() + " \nPile d'appel" + e4.StackTrace);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.ToString() != "")
                {
                    string AVG = "";
                    ModeleBDD con = new ModeleBDD();
                    Clubs leclub = new Clubs();
                    leclub.setNom(comboBox1.ToString());
                    AVG = con.AVGCotisation(leclub);
                }

            }
            catch (Exception n)
            {
                MessageBox.Show("Message d'erreur : " + n.Message + " \nType de l'exception " + n.GetType() + " \nPile d'appel" + n.StackTrace);

            }
        }
    }
}
