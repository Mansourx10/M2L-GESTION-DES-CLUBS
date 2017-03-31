using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class TypeClub
    {
        private int Id;
        private string Libelle;

        public TypeClub(int lId, string leLibelle)
        {
            this.Id = lId;
            this.Libelle = leLibelle;
        }

        public TypeClub()
        {

        }


        public int getId()
        {
            return this.Id;
        }

        public int setId(int lId)
        {
            this.Id = lId;
            return Id;

        }


        public string getLibelle()
        {
            return this.Libelle;
        }

        public string setLibelle(string leLibelle)
        {
            this.Libelle = leLibelle;
            return leLibelle;

        }
    }
}
