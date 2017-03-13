using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Evenements
    {
        private string Titre;
        private string Type;
        private string LienSite;
        private string Adresse;
        private string Ville;
        private string CodePostal;
        private DateTime Moment;

        public Evenements(string leTitre, string leType, string leLien, string lAdresse, string laVille, string leCp, DateTime leMoment)
        {
            this.Titre = leTitre;
            this.Type = leType;
            this.LienSite = leLien;
            this.Adresse = lAdresse;
            this.Ville = laVille;
            this.CodePostal = leCp;
            this.Moment = leMoment;
        }

        public string getTitre()
        {
            return this.Titre;
        }

        public string setVille(string leTitre)
        {
            this.Titre = leTitre;
            return Titre;

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

        public string setville(string laVille)
        {
            this.Ville = laVille;
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

        public DateTime getMoment()
        {
            return this.Moment;
        }

        public DateTime setMoment(DateTime leMoment)
        {
            this.Moment = leMoment;
            return Moment;

        }
    }
}
