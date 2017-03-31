using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Clubs
    {
        private int Id;
        private string Nom;
        private string LienSite;
        private string Adresse;
        private string Ville;
        private int CodePostal;
        private int Telephone;
        private string EMail;
        private TypeClub Type;

        public Clubs(int lId, string leNom, string leLien, string lAdresse, string laVille, int CPT, int Tel, string Mail, TypeClub leType)
        {
            this.Id = lId;
            this.Nom = leNom;
            this.LienSite = leLien;
            this.Adresse = lAdresse;
            this.Ville = laVille;
            this.CodePostal = CPT;
            this.Telephone = Tel;
            this.EMail = Mail;
            this.Type = leType;
        }

        public Clubs()
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

        public  string getNom()
        {
            return this.Nom;
        }

        public string setNom(string leNom)
        {
            this.Nom = leNom;
            return Nom;
            
        }

        public string getLienSite()
        {
            return this.LienSite;
        }

        public string setLienSite(string leLien)
        {
            this.LienSite = leLien;
            return LienSite;

        }

        public string getAdresse()
        {
            return this.Adresse;
        }

        public string setAdresse(string lAdresse)
        {
            this.Adresse = lAdresse;
            return Adresse;

        }

        public string getVille()
        {
            return this.Ville;
        }

        public string setVille(string leVille)
        {
            this.Ville = leVille;
            return Ville;

        }

        public int getCPT()
        {
            return this.CodePostal;
        }

        public int setCPT(int leCPT)
        {
            this.CodePostal = leCPT;
            return CodePostal;

        }

        public int getTel()
        {
            return this.Telephone;
        }

        public int setTel(int leTel)
        {
            this.Telephone = leTel;
            return Telephone;

        }

        public string getEMail()
        {
            return this.EMail;
        }

        public string setMail(string leMail)
        {
            this.EMail = leMail;
            return EMail;

        }

        
        public TypeClub getType()
        {
            return this.Type;
        }

        public TypeClub setType(TypeClub leType)
        {
            this.Type = leType;
            return Type;

        }
        
    }
}
