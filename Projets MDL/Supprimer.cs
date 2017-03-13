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
    public partial class Supprimer : Form
    {
        public Supprimer()
        {
            InitializeComponent();
        }

        private void Supprimer_Load(object sender, EventArgs e)
        {
            ModeleBDD con = new ModeleBDD();

            foreach(Adherents adherent in con.getAdherents())
            {
                listBox1.Items.Add(adherent.getNom());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            ModeleBDD con = new ModeleBDD();

            con.subAdherents(listBox1.SelectedItem.ToString());
            labelInfo.Text = listBox1.SelectedItem.ToString() + " à étè supprimer avec succès !";
        }
    }
}
