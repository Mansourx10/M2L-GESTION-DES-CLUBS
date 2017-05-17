using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Evenements
    {
        private int Id;
        private Clubs leClub;
        private string Titre;
        private string Type;
        private string LienSite;
        private string Adresse;
        private string Ville;
        private int CodePostal;
        private DateTime Moment;

        public Evenements(int Id, Clubs club, string leTitre, string leType, string leLien, string lAdresse, string laVille, int leCp, DateTime leMoment)
        {
            this.Id = Id;
            this.leClub = club;
            this.Titre = leTitre;
            this.Type = leType;
            this.LienSite = leLien;
            this.Adresse = lAdresse;
            this.Ville = laVille;
            this.CodePostal = leCp;
            this.Moment = leMoment;
        }

        public Evenements()
        {

        }
        public int getId()
        {
            return this.Id;
        }
        public int setId(int id)
        {
            this.Id = id;
            return Id;
        }
        public Clubs getClub()
        {
            return this.leClub;
        }
        public Clubs setClub(Clubs club)
        {
            this.leClub = club;
            return leClub;
        }
        public string getTitre()
        {
            return this.Titre;
        }
        public string setTitre(string leTitre)
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
        public string setVille(string laVille)
        {
            this.Ville = laVille;
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
