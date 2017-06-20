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

        public void setId(int lId)
        {
            this.Id = lId;
            

        }

        public  string getNom()
        {
            return this.Nom;
        }

        public void setNom(string leNom)
        {
            this.Nom = leNom;
           
            
        }

        public string getLienSite()
        {
            return this.LienSite;
        }

        public void setLienSite(string leLien)
        {
            this.LienSite = leLien;
           

        }

        public string getAdresse()
        {
            return this.Adresse;
        }

        public void setAdresse(string lAdresse)
        {
            this.Adresse = lAdresse;
            

        }

        public string getVille()
        {
            return this.Ville;
        }

        public void setVille(string leVille)
        {
            this.Ville = leVille;
            

        }

        public int getCPT()
        {
            return this.CodePostal;
        }

        public void setCPT(int leCPT)
        {
            this.CodePostal = leCPT;
        }

        public int getTel()
        {
            return this.Telephone;
        }

        public void setTel(int leTel)
        {
            this.Telephone = leTel;
           

        }

        public string getEMail()
        {
            return this.EMail;
        }

        public void setMail(string leMail)
        {
            this.EMail = leMail;
            

        }

        
        public TypeClub getType()
        {
            return this.Type;
        }

        public void setType(TypeClub leType)
        {
            this.Type = leType;
           
        }
        
    }
}
