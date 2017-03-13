using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Clubs
    {
        private string Nom;
        private string LienSite;
        private string Adresse;
        private string Ville;
        private string CodePostal;
        private string Telephone;
        private string EMail;
        private string Type;

        public Clubs(string leNom, string leLien, string lAdresse, string laVille, string CPT, string Tel, string Mail, string leType)
        {
            this.Nom = leNom;
            this.LienSite = leLien;
            this.Adresse = lAdresse;
            this.Ville = laVille;
            this.CodePostal = CPT;
            this.Telephone = Tel;
            this.EMail = Mail;
            this.Type = leType;
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

        public string getCPT()
        {
            return this.CodePostal;
        }

        public string setCPT(string leCPT)
        {
            this.CodePostal = leCPT;
            return CodePostal;

        }

        public string getTel()
        {
            return this.Telephone;
        }

        public string setTel(string leTel)
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

        public string getType()
        {
            return this.Type;
        }

        public string setType(string leType)
        {
            this.Type = leType;
            return Type;

        }
    }
}
