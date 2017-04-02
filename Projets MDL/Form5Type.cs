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
    public partial class Form5Type : Form
    {
        public Form5Type()
        {
            InitializeComponent();
            FillList();
        }
        
         void FillList()
        {
            
            ModeleBDD con = new ModeleBDD();
            List<TypeClub> ListType = con.getTypeClub();
            foreach(TypeClub leType in ListType)
            {
                listBox1.Items.Add(leType.getLibelle().ToString());
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ModeleBDD con = new ModeleBDD();

            TypeClub Type = new TypeClub();

            Type.setLibelle(textSport.Text);

            con.setTypeSport(Type);
            textSport.Text = "";
            listBox1.Items.Clear();
            FillList();
        }

        private void buttonSup_Click(object sender, EventArgs e)
        {
            ModeleBDD con = new ModeleBDD();

            TypeClub Type = new TypeClub();

            Type.setLibelle(textSport.Text);

            con.supTypeSport(Type);
            textSport.Text = "";
            listBox1.Items.Clear();
            FillList();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textSport.Text = listBox1.SelectedItem.ToString();
        }
    }
}
