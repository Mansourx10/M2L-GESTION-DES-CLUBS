using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Adherents
    {
        private int id;
        private Clubs club;
        private string Licence;
        private string Sexe;
        private string Nom;
        private string Prenom;
        private DateTime DateNaissance;
        private string Adresse;
        private int CodePostal;
        private string Ville;
        private int Cotisation;

        public Adherents(int lid, Clubs leclub, string leNb, string leSexe, string lenom, string lePrenom, DateTime laNaiss, string lAdresse, int leCp, string laville, int leCotisation)
        {
            this.id = lid;
            this.club = leclub;
            this.Licence = leNb;
            this.Sexe = leSexe;
            this.Nom = lenom;
            this.Prenom = lePrenom;
            this.DateNaissance = laNaiss;
            this.Adresse = lAdresse;
            this.CodePostal = leCp;
            this.Ville = laville;
            this.Cotisation = leCotisation;
        }

        public Adherents()
        {

        }

        public int getId()
        {
            return this.id;
        }

        public int setId(int lId)
        {
            this.id = lId;
            return id;
        }

        public Clubs getClub()
        {
            return this.club;
        }

        public Clubs setClub(Clubs leclub)
        {
            this.club = leclub;
            return leclub;
        }

        public string getLicence()
        {
            return this.Licence;
        }

        public string setLicence(string laLicence)
        {
            this.Licence = laLicence;
            return Licence;
        }

        public string getSexe()
        {
            return this.Sexe;
        }

        public string setSexe(string leSexe)
        {
            this.Sexe = leSexe;
            return Sexe;
        }

        public string getNom()
        {
            return this.Nom;
        }

        public string setNom(string leNom)
        {
            this.Nom = leNom;
            return Nom;
        }

        public string getPrenom()
        {
            return this.Prenom;
        }

        public string setPrenom(string lePrenom)
        {
            this.Prenom = lePrenom;
            return Prenom;
        }

        public DateTime getNaissance()
        {
            return this.DateNaissance;
        }

        public DateTime setNaissance(DateTime laNaissance)
        {
            this.DateNaissance = laNaissance;
            return DateNaissance;
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

        public int getCotisation()
        {
            return this.Cotisation;
        }

        public int setCotisation(int laCotisation)
        {
            this.Cotisation = laCotisation;
            return Cotisation;
        }
    }
}
