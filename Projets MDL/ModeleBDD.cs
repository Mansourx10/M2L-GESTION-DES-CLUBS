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
            string database = "gestion_clubs";
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

        /// <summary>
        /// La méthode Read retourne un Adherent en fonction de l'id en parametre. 
        /// </summary>
        /// <param name="id">id de l'adherent selectionnedans la dataGridView</param>
        /// <returns>un adhrent</returns>
        public Adherents Read(int id)
        {
            Adherents lAdherent = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM adherents where id=@id";

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        lAdherent = new Adherents();
                        lAdherent.setId((int)dataReader["id"]);
                        lAdherent.setNumeroLicence((string)dataReader["Licence"]);
                        lAdherent.setNom((string)dataReader["Nom"]);
                        lAdherent.setPrenom((string)dataReader["Prenom"]);
                        lAdherent.setNaissance((string)dataReader["Naissance"]);
                        lAdherent.setAdresse((string)dataReader["Adresse"]);
                        lAdherent.setCPT((int)dataReader["CodePoastal"]);
                        lAdherent.setVille((string)dataReader["Ville"]);
                        lAdherent.setCotisation(dataReader["Cotisation"] != DBNull.Value ? (int)dataReader["Cotisation"] : 0);
                    }
                }
            }

            return lAdherent;
        }


        //La methode est modifié
        /// <summary>
        /// Methode qui selection tous clubs sur la base de données
        /// </summary>
        /// <returns>Return un Listes des clubs</returns>
        public List<Clubs> getClubs()
        {
            List<Clubs> lesClubs = new List<Clubs>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT c.id AS IdClub, c.Nom, c.LienSIte, c.Adresse, c.Ville, c.CodePostal, c.Telephone, c.Email, c.id_type, t.id AS IdType, t.Libelle From clubs AS c INNER JOIN type AS t ON c.id_type = t.id";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajiute dans la liste les ahderents de la base de données
                    while (dataReader.Read())
                    {
                        TypeClub Type = new TypeClub();
                        Type.setId((int)dataReader["IdType"]);
                        Type.setLibelle((string)dataReader["Libelle"]);

                        Clubs lClub = new Clubs();
                        lClub.setId((int)dataReader["IdClub"]);
                        lClub.setLienSite((string)dataReader["LienSite"]);
                        lClub.setMail((string)dataReader["Email"]);
                        lClub.setNom((string)dataReader["Nom"]);
                        lClub.setType(Type);
                        lClub.setTel((int)dataReader["Telephone"]);
                        lClub.setAdresse((string)dataReader["Adresse"]);
                        lClub.setCPT((int)dataReader["CodePostal"]);
                        lClub.setVille((string)dataReader["Ville"]);
                        
                        lesClubs.Add(lClub);
                    }

                }

                connection.Close();

                return lesClubs;
                
            }
        }

        /// <summary>
        /// methode setClub ajouter un club dans la base dedonnées
        /// </summary>
        /// <param name="leClub">est un abjet de la classe Clubs</param>
        public void setClub(Clubs leClub)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO clubs(Nom, LienSite, Adresse, Ville, CodePostal, Telephone, Email, Type) VALUES (@Nom, @LienSite, @Adresse, @Ville, @CodePostal, @Telephone, @Email, @Type)";
                command.Parameters.AddWithValue("@Nom", leClub.getNom());
                command.Parameters.AddWithValue("@LienSite", leClub.getLienSite());
                command.Parameters.AddWithValue("@Adresse", leClub.getAdresse());
                command.Parameters.AddWithValue("@Ville", leClub.getVille());
                command.Parameters.AddWithValue("@CodePostal", leClub.getCPT());
                command.Parameters.AddWithValue("@Telephone", leClub.getTel());
                command.Parameters.AddWithValue("@Email", leClub.getEMail());
                command.Parameters.AddWithValue("@Type", leClub.getType());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer un club de la base de données
        /// </summary>
        /// <param name="club">L'ID du club a supprimer de la base de données</param>
        public void subClub(int club)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM clubs WHERE id=@id";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", club);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// La méthode modifie un club en fonction de l'objet Clubs en parametre. 
        /// </summary>
        /// <param name="Clubs">Leclub a modifié </param>
        /// <returns>un club</returns>
        public void UPDATEClub(Clubs leClub)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE clubs SET Nom=@Nom, LienSite=@LienSite, Adresse=@Adresse, Ville=@Ville, CodePostal=@CodePostal, Telephone=@Telephone, Email=@Email, Type=@Type WHERE id=@id";
                command.Parameters.AddWithValue("@Id", leClub.getId());
                command.Parameters.AddWithValue("@Nom", leClub.getNom());
                command.Parameters.AddWithValue("@LienSite", leClub.getLienSite());
                command.Parameters.AddWithValue("@Adresse", leClub.getAdresse());
                command.Parameters.AddWithValue("@Ville", leClub.getVille());
                command.Parameters.AddWithValue("@CodePostal", leClub.getCPT());
                command.Parameters.AddWithValue("@Telephone", leClub.getTel());
                command.Parameters.AddWithValue("@Email", leClub.getEMail());
                command.Parameters.AddWithValue("@Type", leClub.getType());
                command.ExecuteNonQuery();
                connection.Close();
            }

          
        }

        //La methode est modifié
        /// <summary>
        /// Methode qui selection tous Typeclub de la base de données
        /// </summary>
        /// <returns>Return une Liste de Typeclub</returns>
        public List<TypeClub> getTypeClub()
        {
            List<TypeClub> lesTypeClub = new List<TypeClub>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * From type";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajoute dans la liste les TypeClub de la base
                    while (dataReader.Read())
                    {
                        TypeClub Type = new TypeClub();
                        Type.setId((int)dataReader["IdType"]);
                        Type.setLibelle((string)dataReader["Libelle"]);

                        

                        lesTypeClub.Add(Type);
                    }

                }

                connection.Close();

                return lesTypeClub;

            }
        }

    }
}
