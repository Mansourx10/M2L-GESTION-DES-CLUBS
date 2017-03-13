using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projets_MDL
{
    class ModeleBDD
    {
        private string connectionString;

        public ModeleBDD()
        {
            Initialize();
        }

        private void Initialize()
        {
            string server = "localhost";
            string port = "3306";
            string database = "projetm2l";
            string uid = "root";
            string password = "";
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }
        /// <summary>
        /// methode setAdherents ajouter un les attribust d'un adherents dans un tableau
        /// </summary>
        /// <param name="me">est un abjet de la classe Adherents</param>
        public void setAdherent(Adherents me)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO adherents(Licence, Sexe, Nom, Prenom, Naissance, Adresse, CodePostal, Ville, Cotisation) VALUES (@Licence, @Sexe, @Nom, @Prenom, @Naissance, @Adresse, @CodePostal, @Ville, @Cotisation)";
                command.Parameters.AddWithValue("@Licence", me.getNumeroLicence());
                command.Parameters.AddWithValue("@Sexe", me.getSexe());
                command.Parameters.AddWithValue("@Nom", me.getNom());
                command.Parameters.AddWithValue("@Prenom", me.getPrenom());
                command.Parameters.AddWithValue("@Naissance", me.getNaissance());
                command.Parameters.AddWithValue("@Adresse", me.getAdresse());
                command.Parameters.AddWithValue("@CodePostal", me.getCPT());
                command.Parameters.AddWithValue("@Ville", me.getVille());
                command.Parameters.AddWithValue("@Cotisation", me.getCotisation());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }



        /// <summary>
        /// Methode qui selection tous adhernts sur la base de données
        /// </summary>
        /// <returns>Return un Listes des adherents</returns>
        public List<Adherents> getAdherents()
        {
            List<Adherents> lesAdherents = new List<Adherents>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM adherents";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajiute dans la liste les ahderents de la base de données
                    while (dataReader.Read())
                    {
                        Adherents lAdherent = new Adherents();
                        lAdherent.setNumeroLicence((string)dataReader["Licence"]);
                        lAdherent.setSexe((string)dataReader["Sexe"]);
                        lAdherent.setNom((string)dataReader["Nom"]);
                        lAdherent.setPrenom((string)dataReader["Prenom"]);
                        lAdherent.setNaissance((string)dataReader["Naissance"]);
                        lAdherent.setAdresse((string)dataReader["Adresse"]);
                        lAdherent.setCPT((int)dataReader["CodePostal"]);
                        lAdherent.setVille((string)dataReader["Ville"]);
                        lAdherent.setCotisation((int)dataReader["Cotisation"]);

                        lesAdherents.Add(lAdherent);
                    }

                }

                connection.Close();

                return lesAdherents;

                
            }

        }

        /// <summary>
        /// Methode qui permet de supprimer un adherents de la base de données
        /// </summary>
        /// <param name="nom">Le nom de l'adherent a supprimer de la table</param>
        public void subAdherents(string nom)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM adherents WHERE nom=@nom";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@nom", nom);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
