using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projets_MDL
{
    class Adherents
    {
        private string NumeroLicence;
        private string Sexe;
        private string Nom;
        private string Prenom;
        private string DateNaissance;
        private string Adresse;
        private int CodePostal;
        private string Ville;
        private int Cotisation;

        public Adherents(string leNb, string leSexe, string lenom, string lePrenom, string laNaiss, string lAdresse, int leCp, string laville, int leCotisation)
        {
            this.NumeroLicence = leNb;
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

        public string getNumeroLicence()
        {
            return this.NumeroLicence;
        }

        public string setNumeroLicence(string leNumeroLicence)
        {
            this.NumeroLicence = leNumeroLicence;
            return NumeroLicence;
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

        public string getNaissance()
        {
            return this.DateNaissance;
        }

        public string setNaissance(string laNaissance)
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
